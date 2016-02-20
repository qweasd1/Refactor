class parserBuilder:
    def __init__(self):
        pass
    def begin_class(self, name, base):
        self.methods = []
        self.clazz = ("class",name,base,self.method_cursor)
    def begin_method(self, name):  
        method_current = ("def",name,[])
        self.methods.append(method_current)
        self.current_stmt_container = method_current[2]
        
    def generate(self):
        self.buffer = []
        self.indent = 0
    def _gen(self,item):
    	item_type = item[0]
        if item_type == "class":
            self.buffer.append("class {name}({base}):\n".format(name=item[1],base=item[2]))
            self.indent_increase()
            [self._gen(m) for m in item[3]]
            self.indent_decrease()
    def indentString(self):
        return self.indent * '\t'
    def indent_increase(self):
        self.indent+=1
    def indent_decrease(self):
        self.indent-=1
    
        
        
        
