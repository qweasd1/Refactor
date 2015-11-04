##objmap - a framework to transform javascript object
#### **Content**
- Trigger (Jstree)
- Before Start
- Analysis
- Desgin of objmap

###### Trigger
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
Also, it's still imperative than declarative(what we implement in ```node_transformer``` can be complex when the transform logic become complex)
