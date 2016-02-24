```python
class test():
    def __init__(self, inner, notify_configs):
        self.i = inner
        self.notify_configs = notify_config
    def __getattr__(self,name):
        try:
            a= getattr( self.i,name)
            if a != None:
                return a
        except AttributeError: 
            raise AttributeError("no attribute [{0}] in inner object".format(name))
    def __dir__(self):
        return dir(self.i)
    def __setattr__(self,name,value):
        if name != "i":
            old = getattr( self.i,name)
            if old != value:
                setattr(self.i,name,value)
                if 
        else:
            self.__dict__[name] = value
```
