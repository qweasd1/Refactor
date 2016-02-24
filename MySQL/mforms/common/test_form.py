import mforms
tab = mforms.newTabView(mforms.TabViewTabless)

#use t to reference the control you create
#use tm to reference the form you create
#use tm.run() to show the form 

class test(mforms.Form):
    def __init__(self):
        global t
        mforms.Form.__init__(self,None)
        self.set_size(800,400)
        box = mforms.newBox(False)
        
        #### put your code here
        t = mforms.new<newControl>()
        
       
        ####
        box.add(t,False,True)
        
        self.set_content(box)
        self.t = t

    def cb(self,x):
        print(x)
    def run(self):
        self.apply = mforms.newButton()
        self.cancel = mforms.newButton()
        self.center()
        self.run_modal(self.apply, self.cancel)


tm = test()
tm.run()
