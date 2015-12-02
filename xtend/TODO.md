### RichLiteral
- will RichLiteral have contains a new line if it used directly as the return value from a method? 
  -  seems skip the ^\s* 
- RichLiteral's indent
- ```{important}```**in unit test, RichLiteral is not equal to string since they are not the same type**

### dispatch method
- if we implement all subclasses' dispatch method, then we can use dispatch method on the base class?


### switch clause
- [see definition here](https://eclipse.org/xtend/documentation/203_xtend_expressions.html#switch-expression)
- the switch main input can be an expression. 
  - Moreover, you can give it a value and reuse in the sub case expressions(```switch <variable>: <expression> ...```)
- Type Guard: You can specify the Type you the case needs like: ```<Type> case <expression>: ...```, the main expression will cast to that type automatically
- ```{advanced}``` split out dispatch method + switch


### Classical Case
- when you need to check if an array is empty or null in an RichLiteral Template

### Extend Library

###### Collection
# Get distinct value (use ```fold``` function)
