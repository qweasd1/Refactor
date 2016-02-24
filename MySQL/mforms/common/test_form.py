import mforms

class test(mforms.Form):
    def __init__(self):
        mforms.Form.__init__(self,None)
        self.set_size(800,400)
        box = mforms.newBox(False)
        
        #### put your code here
        t = mforms.newCheckBox()
        t.set_text("select me")
        t.set_active(True)
        #t.set_size(600,400)
        
        ####
        box.add(t,False,True)
        
        self.set_content(box)
        self.t = t
    def run(self):
        self.apply = mforms.newButton()
        self.cancel = mforms.newButton()
        self.center()
        self.run_modal(self.apply, self.cancel)


t = test()
t.run()
