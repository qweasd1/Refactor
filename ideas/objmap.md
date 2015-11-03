### Introduction
objmap is framework to map one json object into another structure through a schema object.
we use jsonpath to select origin fields from origin object in the schema, and the schema object itself is the template for new object. 

a quick example should let this clear
```javascript
var origin =  {
  firstName:'Tony',
  lastName:'Wang'
}
var schema = {
   person:{
      firstName:"$.firstName",
      lastName: "$.lastName"
   }
}
var new = mapper.map(origin, schema)
```
the new variable should equal

```javascript
{
   person:{
      firstName:"Tony",
      lastName: "Wang"
   }
}
```
The exmaple above is trivil, but when we introduce some feature to his, it might be powrful
##### embed exprerssion
we can embed expression so we can not only change structure but also do some calculation

```javascript
var origin =  {
  firstName:'Tony',
  lastName:'Wang'
}
var schema = {
   person:{
      name: "{{$.firstName + ' ' + $.lastName }}"
   }
}

var new = {
   name:"Tony Wang"
}
```

another example:
```javascript
var blog = {
   comments:[
      {
         time:'2015-10-12',
         content:'this is nice'
      },
      {
         time:'2015-10-12',
         content:'this is nice'
      },
      {
         time:'2015-10-12',
         content:'this is nice'
      },
      {
         time:'2015-10-12',
         content:'this is nice'
      }
   ]
}

var schema = {
   commentCount:"{{ ($.comments).count }}"
}


var new = {
   commentCount: 4
}
```


##### support private fields
sometimes we need some internal varialbes to store some value used by following expression but will not be presented to the final result. Simply add a prefix '_' before your property name

```javascript
var origin =  {
  firstName:'Tony',
  lastName:'Wang'
}
var schema = {
   _name: "{{$.firstName + ' ' + $.lastName }}",
   greeting: "Hello {{_name}}, feel happy to use objmap",
   
}

var new = {
   greeting: "Hello Tony Wang, feel happy to use objmap"
}
```
##### support transform functions
sometimes, it's convenient that we define some functions to help us transform our object
a good example maybe copy fields from origin to new object

```javascript
var origin =  {
  a1:'a1',
  a2:'a2'
}
var schema = {
   _copy_:"*"
}

var new = {
  a1:'a1',
  a2:'a2'
}
```
