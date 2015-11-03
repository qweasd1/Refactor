objmap is framework to map one json object into another structure through a schema object.
we use jsonpath to select origin fields from origin object in the schema, and the schema object itself is the template of the 

a quick example is as following
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
