##objmap - a framework to transform javascript object
#### **Content**
- Trigger (Jstree)
- Before Start
- Analysis
- Desgin of objmap

###### Trigger
The idea of objmap came occasionally when I want to include Jstree(jQuery plugin) into my angularjs app.
The obstacles I found when I use jsTree is that I need to map my domain model into a specific structure designed for jsTree.

Fort example, my domain model is a file system:
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
