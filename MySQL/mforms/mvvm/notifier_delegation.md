```python
class NotifyAttrChangedDelegater():
    def __init__(self, inner):
        self.__dict__["i"] = inner
        self.__dict__["notify_config_dict"] = {}
    def register_notify_attr_change(self,name,callback):
        self.notify_config_dict[name] = callback
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
        old = getattr( self.i,name)
        if old != value:
            setattr(self.i,name,value)
            if name in self.__dict__["notify_config_dict"]:
                self.__dict__["notify_config_dict"][name](value)
```
