### overview
* when debug, the whole project is in debug mode not the target plug-in
* you can modify the code during debug and they will reflect in the following test



### breakpoint acc-key
* Double-Click : toggle add/remove breakpoint
* Shift-Double-Click: toggle enable/ disable breakpoint(save the config)
* Ctrl-Double-Click:  open the breakpoint configuraition pannel.
* [TODO] toggle skip all breakpoints



### [think its usage] Drop to Frame
* return to a stack frame in the thread to re-run an operation: each statement shall be bound to a specific frame, this operation will rerun the frame. However what side-effect you did before will affect the new frame running.(for e.g. a static field will be set after the first run of this frame)
* for context-free frame: 


###  update source code will automatically reflect change on test Eclipse instance if you are in a debug mode
* [pre-request]: Project | Build Automatically is enabled
* [why can we do like this] when a Java program is launched in debug mode, whenever changes to classes are made, it will update the running JVM with the new code if possible. This behavior is controled by JVM through **JVMTI** and whether, for example, the
virtual machine's canUnrestrictedlyRedefineClasses() call returns true. Generally, updating an existing method and adding a new method or field will work, but changes to interfaces and super classes may not be. 
see more on this topic : 
The ex-Sun Hotspot JVM cannot replace classes if methods are added or
interfaces are updated. Some JVMs have additional capabilities which can
substitute more code on demand. With the merging of JRockit and Hotspot
over time, more may be replaceable at runtime than before; for everything
else, there's **JRebel**.
Other JVMs, such as IBM's, can deal with a wider range of replacements
* seems eclipse will notify you that if the runtime replacement can't be integrate into the current environment.
* however, the change to **plugin.xml won't update!**

### [think of its usage] debug filter
* [page:P39] Preferences | Java | Debug | Step Filtering
* [case]
  *  add Package
  *  filter simple getters
  *  filter simple setters
  *  filter constructors
  *  ctor
  *  
  
### different breakpoint type:
* method breakpoint: 
  * Double-Click at the same line of the method signature will add this breakpoint
  * Ctrl-Double-Click at the breakpoint can let you edit whether this breakpoint stop enter/exit method
  * exit method breakpoint will stop after return expression has evaludated but a line breakpoint on a return statement will stop before the return exprssion evaluated.
* conditional breakpoints:
  * **use case**: 
    * [discuss this] when value has been incorrectly initialized. you can set the breakpoint at the constructor, and use framestack to see where it was invoked to detect where goes wrong.
  * Hit count
  * [TODO: try more on this] the conditional expression can only be expression, so if you want to have complex statement, use a static method to give the logic.
  

### debug view:
* [think the usage scenario] skip all breakpoint:
* go to file for breakpoint: select a breakpoint in Debug view and find where we set that breakpoint.
* [TODO] there are many other function in this view, see if there are other wonderful usages

