#objmap - a framework to transform javascript object
## **Content**
- Trigger (Jstree)
- Prepare
- Functional Design
- Implementation Design
- Improve the Design
- Extension Tool Design

### Trigger (Jstree)
The idea of objmap came occasionally when I want to include jstree(jQuery plugin) into my angularjs app.
The obstacles I found when I use jsTree is that I need to map my domain model into a specific structure designed for jsTree.

Fort example:
my domain model is a file system:
```javascript
var my_domain_model = {
   name:'new folder1',
   isDirecotry: true,
   subFiles:[
     {
       name:'file1',
       isDirecotry: false,
     },
     {
       name:'file2',
       isDirecotry: false,
     }
   ]
}
```
and the targte model for jsTree is:
```javascript
var jstree_model ={
         'text' : 'new folder1',
         'children' : [
           { 
              text : 'file1' 
           },
           { 
              text : 'file2' 
           }
         ]
      }
```
To map my_domain_model to jstree_model, The simplest solution is to write a recursive function.

**solution 1: recursive function**
```javascript
[a recursive function]
```
Of course this is not a good solution for the following reasons:

1. recursive function can be more erroneous when it grows complex.
2. It's not general, when I change my domain model, we need to rewrite the recursive function.
3. It's imperative than declarative.


To fix the problems list above, we can use high-order function like the following

**solution 2: high-order recursive function**
```javascript
function transform(my_model, node_transformer, children_selector)
{
  var jstree_model = node_transformer(my_model)
 
  var children = children_selector(my_model)
  
  if(children !== undefined)
  {
    jstree_model.children = children.map(
      function(child_model){
         return transform(child_model, node_transformer, children_selector)
      }
    )
  }
  return jstree_model
}

var jstree_model = transform(my_model, function(x){
   return {
     test:x.name
   }
}, function(x){
   if(x.subfiles){
      return x.subfiles
   }
})
```
It solves the issue 1, 2, however, the target jstree_model can be more complex(to let you control it better)
```javascript
//one node for jstree_model
{
  id          : "string" // required
  parent      : "string" // required
  text        : "string" // node text
  icon        : "string" // string for custom
  state       : {
    opened    : boolean  // is the node open
    disabled  : boolean  // is the node disabled
    selected  : boolean  // is the node selected
  },
  li_attr     : {}  // attributes for the generated LI node
  a_attr      : {}  // attributes for the generated A node
}
```
Also, it's still imperative than declarative(what we implement in ```node_transformer``` can be complex when the transform logic become complex). Moreover, we can only use this recursive logic with jstree, but such kind of recursive logic likely to occur in many different places. 

**So, can we made it more generic? Can one javascript object transform to a new javascript object with different structure in a declarative way?**

### Prepare
##### Potential scenarios

Now we have our question, but is it a meaningful question?
The answer is **YES**!
Think about the following scenarios:
* When we build GUI in MVVM pattern, we usually need to transform our model to view model. These codes are sometimes boilerplate codes, so if we can use declarative way to do the transform, it's much easier and can save us a lot of time.
* When we use other's framework, we always need some adapting code to transform our domain model to the framework's domain model, so that we invoke the facade method of the it.(our jstree is an example for this case). Again, boilerplate code.
* when we work with AST(Abstract Syntax Tree), we actually work with an object aggregation. Then, we can use objmap to generate the structure we want instead of using visit pattern!(more declarative).

So there is no doubt that the if we can answer our question, it would be definitely useful!


##### Does there any existing framework?

Usually, before your project, look around to see if anyone has made it!
After a couple hours searching, I found a great case: **[jsonpath-object-transform](https://github.com/dvdln/jsonpath-object-transform)**

the core idea of this framework is to use a ```template``` object to specify the structure of the target object and use the ```JSONPath``` to select the fields from the origin object.
Here is a sample:
```javascript
var transform = require('jsonpath-object-transform');

var template = {
  a:{
    b:'$.x',
    c:'$.y'
  }
};

var data = {
  x:1,
  y:2
};

var result = transform(data, template);
```
Result:
```javasript
{
  a:{
      b: 1,
      c: 2
    }
  
}
```
This is really a good idea! but it still has some lack:

- It doesn't support recursive(so we can't apply it to our jsTree scenario)
- It doesn't support calculation(or expression). e.g. it can't do something like this
```javascript
var template = {
  firstName:'$.firstname',
  lastName:'$.lastname'
  name: //expected to be $.firstname + ' ' + $.lastname, but can't here
}


```

- Lacking reusable: when the transform becomes complex, we can not re-use our existing template object
-  ...(**to be continure**)

Though there still many place to improve, it's actually a good start point!


### Function Design

##### Step 1: add expression + context inference
**expression is a very useful tools to let our framework verse and flexible.**

A good example is Angularjs. The following code will dynamically change the button's visibility according to model's  products.count
```html
<button ng-show="products.count >= 4">Select a gift</button>
```
It's really short and convenient. In the meanwhile, angularjs also use context inference: ```product.count``` is actually on object ```$scope``` but we don't specify ```$scope``` in the expression. Angularjs knows it under such context. This is another useful tech we can use to simplify the code we need to write.

Let's turn to objmap

the best thing we expect is maybe we can use the javscript expression in our template. maybe something like this
```javascript
var template = {
  sum: '((1 + 2 + 3))'
}
```
we use '((' '))' to tell our compiler this is a expression

Also the context-inference when we want to reference other property
```javascript
var = template = {
     firstname:'$.firstname',
     lastname:'$.lastname',
     name: '((firstname + " " + lastname))' // we reference firstname and lastname here
}
```

To be more advanced, we might don't need to output firstname and lastname in our target object, so let's add a new concept: private field(or intermediate variable). Think it as a ```let``` binding in some functional programming:
```javascript
var = template {
     _fn:'$.firstname', //private
     _ln:'$.lastname',  //private
     name:'((_fn + ' ' + _ln))'
}
```

You might feel tired to see string concat like ```_fn + ' ' + _ln``` here. So let's add a string template engine here
```javascript
var = template {
     _fn:'$.firstname',
     _ln:'$.lastname',
     name:'{{_fn}} {{_ln}}' //mustache flavor string template
}
```

So far everhthing looks good! And let's turn to the second part

#### Part2: add abstraction
if expression brings flexibility, abstraction brings reusable and extensibility. The best example for abstraction is 'function' and 'object', we encapsulate reusable logic inside them.
let's see what we can do with our objmap:

###### add functions
```javascript
//copy all fields start with 'a'
var origin = {
   a_1:1,
   a_2:2,
   a_3:3,
   a_4:4,
   b_1:5,
   b_2:6
}

var target = {
   a_1:1,
   a_2:2,
   a_3:3,
   a_4:4
}

```
obviously this is not convenient to for our existing framework. So let's add some functions to it!
```javascript
//something like
var template = {
  _copy_:"a*" // _<func>_ represents a function
}
```
The template here will copy all properties which start with 'a' from orgin to target object. _<function name>_ will used to specify a function. The value of it will pass as paramenters to it.

##### add sub-template
Next, let's add sub-template.
```javascript
// recall our file system example for jstree
// we can specify our transform logic like this 
var tansformer.register_template("file", {
  text: '$.name',
  children: ['$.subfiles', '&file' ] //'&' represent invoke a sub-template
})

var target = transformer.transform(origin, 'file')

```
With sub-template, our transform logic looks extremely simple and declarative

##### add pipeline functions
When we process our domain model, it's very common to use functions like map, filter, group, reduce(in javascript). Let's include them in objmap
```javascript
  tansformer.register_template("file", {
  text: '$.name',
  children: ['$.subfiles', 'filter _.name.startWith("a")', '&file' ] // '_' represent one item from upstream of our pipeline function.
})
```

#### Part3: make it dynamic
##### add dynamic parameters to our function
```javascript
var template = {
  _f = '$.some_fields',
  _copy_: "{{_f}}" //use dynamically parameters here
}
```

##### add dynamic paramters to your jsonpath
```javascript
var tempalte = {
  the_most_popular_blog:["$.blogs","sort like 'desc'", "first"] // get the most popular blog
  author_of_the_most_popular_blog: "$.authors[?(@.name == {{the_most_popular_blog.author}})]" //use {{the_most_popular_blog.author}} to inject dynamic parameter
}
```
Here we extend the existing jsonpath expression. **As we said before embed expression in host environment can be flexible**
Now, our framework more flexible to a next level. **As a conclusion, let your framework use as much context as possible can make it dramatically flexible**




#### Part4: don't miss those things look trivial but not
There are some things look trivial but not. Missing them might cause your user use workaround for them.

###### what return: single value? array
```javascript
// which value will return for the following condition?
// when $.a has no match
// when $.a has one match
// when $.a has more than one match
var template = {
  prop: "$.a"
}
```
The desire answer may depends on your user's requirement:
```javascript
var template = {
  blogs:"$.a.b.blogs" 
}
//target.blogs will be use as a input in a array function(like map)
target.blogs.map(...)
```
In this situation, we definitely want ```blogs``` to be an array, even if it returns only 1 object.

However in such situation:
```javascript
var origin = {
   best_blog: {...}
}

var template = {
   blog: '$.best_blog'
}
```
we definitely know we only select one result, so we want to return a single value.

**So here, we need to let our users have the chance to decide which way they want, not make decisions for them! I have seen many framework set some presumed implemention and make their users use some work around to achieve their goals!** 

So let's do it like this:
```javascript
//this will always return array
var template =  {
  'blogs[]':"$.blogs"
}
//this will always return the first single result
var template = {
  'blog':"$.blog"
}

```
The example above is only one aspect. There are also other aspects like: if our jsonpath selector return nothing, shall we set the target's property as ```null``` or totally ignore it as ```undefined```? It can be meaningful for your user, since they might has checking logic like ```if(target.prop !== undefined) ``` in their code. 

###### a real world sample
```javascript
TODO: select blog
```

### Implementation Design
It looks great for the function by now, so let's consider how to implement it!

##### rethink before you start (use abstraction)
From the section **Function Design** we can see that we have many things need to develop: expression, object-template, text-template, dynamical-parameters, functions and pipe-functions. **But wait! Let's see what's in common of them:**

<table>
  <thead>
    <tr>
      <td>Component</td>
      <td>Input</td>
      <td>Output</td>
      <td>Is Pure Function?</td>
    </tr>
  </thead>
  <tbody>
   <tr>
      <td>expression</td>
      <td>context(can access both public and private fields)</td>
      <td>value</td>
      <td>true</td>
    </tr>
    <tr>
      <td>object-template</td>
      <td>context, target(the target that will return, only contains public fields)</td>
      <td>target</td>
      <td>Not Sure</td>
    </tr>
    <tr>
      <td>text-template</td>
      <td>context</td>
      <td>string</td>
      <td>true</td>
    </tr>
     <tr>
      <td>dynamical-parameters</td>
      <td>context</td>
      <td>value</td>
      <td>true</td>
    </tr>
     <tr>
      <td>functions</td>
      <td>context, target</td>
      <td>target</td>
      <td>Not Sure</td>
    </tr>
    <tr>
      <td>pipe-functions</td>
      <td>context, target</td>
      <td>value</td>
      <td>Not Sure</td>
    </tr>
  </tbody>
</table>

See it, they are actually has the same structure, what we need to do is parse them into the following formats:
```javascript
function(context) : return_value
function(context, target) : return_value //target object is need, since we might change the state of target. _copy_ function is such a example
```
Let's give a name for these 2 function: ```calculation function```
**Make things homogeneous than heterogeneous can simplify your inner implementation**

##### list the structure of your module
- a functionRepo to save/fetch all the parsed ```calculation function```
- several parsers to parse several components. They need to use:
  - a text-template engine
  - a language transformer for expression
  - a parser for pipeline functions(it's more like coffeescript not javascript so a parser is needed)
- a root facade object has methods : ```register_template```, ```register_function```, ```transform```
- register some embedded functions : e.g. ```_copy_```

After Implementation, we now have a workable solution! Let's move on to the next section to see how to improve our design.

### Improve the Design

##### Extensibility
Why extensibility important? It's because user always need some specific functions. If your module can't be extended easily, it will definitely frustrate your user. [Mustache](https://github.com/janl/mustache.js/) is such a example: Mustache is a string template engine, but you can't add a function to join string in it. Mustache's successor [handlerbar](https://github.com/wycats/handlebars.js) not only overcome this but also also support much more better extension point.

in our objmap, the extension is really easy!(use register_function to register the function then use them in your template).


##### Don't Block Your User
Sometimes user has some **non-trivial logic** that can't be expressed easily in the way your framework provided, we should give a way to let them **has the opportunity to fullfill their logic**. Since your framework is always built upon a more powerful but quite low level platform(like jquery to javascript), a usually handy solution is to let your user can go back to write code in that low level platform if necessary. So in the objmap, le's add a new feature like:
```javascript
var template = {
  prop:function(context, origin) {
     
  }
}
```
See it? the function(...) we add do the same thing as our expression do, but you can turn back to your familiar javascript when you feel it's hard to express your logic in expression.

##### Let your User leverage the same power as you
Well, the previous feature doesn't come to an end. In obj model, we can leverage **jsonpath** like ``` prop: '$.origin_prop'```. But when it turns to use ```funtion```, we can't use the jsonpath unless we include the reference to it.(We don't expose it from our framework). It's usually inconvenient, so let's change our function signature to ```function(context, origin, utility)``` then we can use jsonpath utility like ```utility.jsonpath(some_obj, '$.prop')```.
BTW, you can also register other utility if you want like following:
```javascript
tansformer.register_ultility("your utility name", your_utility) 
```
Now, objmap becomes more extensible! And it's time to move to the next topic!

### Extension Tool Design
What does **Extension Tool** mean here? Actually, what I mean is **a tool to help people use your framework better**. This is just like an IDE to a languange, with the syntax highlight, auto-completion,..., you work not only more efficiently but have less chance to make errors.

The most simple form of extension tool might be the a REPL console: You directly see what does your code do. Some other examples maybe like **Regex Testor** which highlight the match item when you develop complex regex expression. This sort of tool has the same feature: **let you see the result immediately**. This feature is very useful for the following reasons:
- it can help new user quickly play with your framework and get familiar.
- it can be handy for test the integrity when user using your framework to develop.

So, for our objmap, we need at least **an input area** to get our ```origin``` object, **an input area** to edit our ```template``` and **an output area** to display our ```target```

There are absolutely more entension function we can discuss here, but since it's already not a short essay, let's omit them this time.

