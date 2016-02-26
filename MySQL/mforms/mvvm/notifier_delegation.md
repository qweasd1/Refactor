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
## list change:
```python
class col_change_event():
    
    DELETE = 0
    INSERT = 1
    SETITEM = 2
    SORT = 3
    REVERSE = 4


class alist():
    def __init__(self,inner):
        self.i = inner
        self.general_event_register_config = []
    def register_callback(self, cb):        
        self.general_event_register_config.append(cb)
       
    
    def __getattr__(self,name):
        try:
            return getattr(self.i,name)
        except AttributeError:
            raise AttributeError("no attr {0} in Attribute".format(name))
    
    def insert(self,index,value):
        self.i.insert(index,value)
        self._notify_change(col_change_event.INSERT, (index,[value]))
    def append(self, value):
        insert_pos = len(self.i)
        self.i.append(value)
        self._notify_change(col_change_event.INSERT, (insert_pos, [value]))
    def pop(self, index = -1):
        self.i.pop(index)
        self._notify_change(col_change_event.DELETE, index)

    def extend(self,alist):
        insert_pos = len(self.i)
        self.i.extend(alist)
        self._notify_change(col_change_event.INSERT, (insert_pos,alist))
    def remove(self,obj):
        del_pos = self.i.index(obj)
        self.i.remove(obj)
        self._notify_change(col_change_event.DELETE, del_pos)
    def __setitem__(self, index, value):
        self.i.__setitem__(index,value)
        self._notify_change(col_change_event.SETITEM, (index,value))

    def __delitem__(self, index):
        self.i.__delitem__(index)
        self._notify_change(col_change_event.DELETE, index)

    def _notify_change(self, event, params):
        for cb in self.general_event_register_config:
            cb(event,params,self)
    def reverse(self):
        self.i.reverse()
        self._notify_change(col_change_event.REVERSE, self.i)
    def sort(self):
        self.i.sort()
        self._notify_change(col_change_event.SORT, self.i)
    

def test(event, col, para):
    print((event,col,para))

t = alist([-1,1,2,2])
t.register_callback(test)

t.reverse()


```
