### Comments
* start with '#'

### String
* [!] ```string + int``` is not allow: use the following: ```"string" + str(1)```
* strip() == trim()


### List
* construct: list = [a,b,c,d]
* print: print(list)
* index access: list[i] i can be negative
* copy: list_new = list_old[:]
* list modification: 
  * change: list[i] = 'new value'
  * push: list.append('tail')
  * insert: list.insert(0,value)
  * remove: del list[0], list.remove('value') (it will only remove the first one)
  * pop(): pop up the tail
* sort: list.sort() (side-effect), **[? can't find]**list.sorted() (no-side-effect)
* concat
  * extend: listA.extend(listB) (side-effect: listA will be extended)
  * + : listA + listB (no-side-effct)
* reverse(side-effect): list.reverse()
* get list count: len(list)
* loop (remember the ':' after for): 
```python
for item in list:
    print(itme)
```
* range: range(start,UBound[, step])
* min, max,sum
* list Comprehensions: 
  * [raw]: http://www.secnetix.de/olli/Python/list_comprehensions.hawk
### Tuple
* initilize: (a,b,c)
* list comprehension: ```.. for (i, _) in list ..``` or ```.. for i, j in list ..```

### Bool Logic
* True/False keywords: ```True```,```False``` 
* and: use ```and```
* or : use ```or```
* in: target in list
  * not int
* False expression(will consider to be False in condition): False,(),[],{},0

### Control flow
* If/else
```python
if <test condition>:
    <then statement>
else:
    <else statement>
```
* If/elif
```python
if <test condition>:
    <then statement>
elif <elif condition>:
    <elif statement>
else:
    <else>
```
### Math
*  ```3 ** 2 => 9```: two multiplication symbols to represent exponents
*  

