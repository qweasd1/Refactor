* http://intermediatepythonista.com/classes-and-objects-ii-descriptors
* https://docs.python.org/2.6/howto/descriptor.html


### descriptor must be new style objects or classes
```python
                #[1]: remember to add base class 'object' here
descriptor_class(object):
  #[2]: define any(__set__, __get__, __del__) method
  __get__(self, obj, obj_type)
  __set__(self,obj,value)
  __del__(self,obj)
  
  #[3]: define any properties you need in __init__ method!
```


### how to use descriptor:
```python
class test():
  #[1]: define in class level
  #[2]: bind the attr_name to descriptor behavior!
  name = some_descriptor(...)
```

### discussion
* we can dynamically **add descriptor to class object!** to change it's instance's behavior
