* use 'true' or 'false' use  ```#include include<stdbool.h>```
* sizeof can operate on both type and object
  * sizeof(type)
  * sizeof(object)
  * sizeof expression
* [important] overflow
* cast: (newType)oldValue
* 


### string
* multi-line string: 
```c
"first line\
 another line"
```

### functional programming
* function variable
```
#include <stdio.h>
void func0() { puts("This is the function func0(). "); }
void func1() { puts("This is the function func1(). "); }
/* ... */
void (*funcTable[2])(void) = { func0, func1 }; // Array of two pointers
// to functions
// returning void.
for ( int i = 0; i < 2; ++i ) // Use the loop counter as the array
funcTable[i](); // index.
```
### pointer




### collection
* initialize expression: {a,b,c}

### memory
* malloc(size) returns pointer to the start. If return null, then no more memory
* [?]The Alignment of Objects in Memory[P68] : get align size and set align memory
* 
