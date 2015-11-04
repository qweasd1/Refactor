##objmap - a framework to transform javascript object
#### **Content**
- Trigger (Jstree)
- Before Start
- Analysis
- Desgin of objmap

###### Trigger (Jstree)
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

##### Before Start
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
