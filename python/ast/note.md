* **?**parse's method signature



## basic operation

### create and show ast
```python
from ast import *

source_code = '''
t = 1
'''
#parser ast
_ast =  parse(source_code)

#print ast
dump(_ast)

```
