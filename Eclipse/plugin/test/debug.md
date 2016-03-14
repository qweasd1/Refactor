### overview
* when debug, the whole project is in debug mode not the target plug-in
* you can modify the code during debug and they will reflect in the following test



### breakpoint setting



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
else, there's JRebel.
Other JVMs, such as IBM's, can deal with a wider range of replacements
