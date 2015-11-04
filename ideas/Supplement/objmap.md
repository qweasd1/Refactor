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
