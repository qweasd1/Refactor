```python
# callbacks are now list
class NotifyAttrChangedDelegater():
    def __init__(self, inner):
        self.__dict__["i"] = inner
        self.__dict__["notify_config_dict"] = {}
    def register_notify_attr_change(self,name,callback):
        if name not in self.notify_config_dict:
            self.notify_config_dict[name] = []
        self.notify_config_dict[name].append(callback)
    def __getattr__(self,name):       
        if name in dir(self.i):
            a= getattr( self.i,name)
            return a
        raise AttributeError("no attribute [{0}] in both inner object and delegate object".format(name))
    def __dir__(self):
        return dir(self.i)
    def __setattr__(self,name,value):
        
            if name in dir(self.i):
                old = getattr( self.i,name)
                if old != value:
                    setattr(self.i,name,value)
                    self._notify_attr_changed(name,value)
            else:
                isNotSet = False
                try:
                    old = getattr(self,name)
                except AttributeError:
                    isNotSet = True
                if isNotSet or old != value:
                    self.__dict__[name] = value
                    self._notify_attr_changed(name,value)
```
