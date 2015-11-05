#objmap - a framework to transform javascript object
## **Content**
- Trigger (Jstree)
- Before Start
- Start Design
- More to Think

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

### Before Start
**Potential scenarios**

Now we have our question, but is it a meaningful question?
The answer is **YES**!
Think about the following scenarios:
* When we build GUI in MVVM pattern, we usually need to transform our model to view model. These codes are sometimes boilerplate codes, so if we can use declarative way to do the transform, it's much easier and can save us a lot of time.
* When we use other's framework, we always need some adapting code to transform our domain model to the framework's domain model, so that we invoke the facade method of the it.(our jstree is an example for this case). Again, boilerplate code.

So there is no doubt that the if we can answer our question, it would be definitely useful!


**Does there any existing framework?**

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

1. It doesn't support recursive(so we can't apply it to our jsTree scenario)
2. It doesn't support calculation(or expression). e.g. it can't do something like this
```javascript
var template = {
  firstName:'$.firstname',
  lastName:'$.lastname'
  name: //expected to be $.firstname + ' ' + $.lastname, but can't here
}


```


3. Lacking reusable: when the transform becomes complex, we can not re-use our existing template object
4. ...(**to be continure**)

Though there still many place to improve, it's actually a good start point!


### Start Design

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
var tansformer.register_template("file", {
  text: '$.name',
  children: ['$.subfiles', 'filter name.startWith("a")', '&file' ] // '_' represent one item from upstream of our pipeline function.
})
```

#### Part3: make it dynamic
##### add dynamic parameters to our function
```javascript
var template = {
  _f = '$.some_fields',
  _copy_: "{{_f}}"
}
```
This shall make our framework more flexible.




#### Part4: don't miss those trivial things
TODO: let user determine which one to return
