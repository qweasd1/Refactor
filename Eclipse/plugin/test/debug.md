### overview
* when debug, the whole project is in debug mode not the target plug-in
* you can modify the code during debug and they will reflect in the following test



### breakpoint setting



### Drop to Frame
* return to a stack frame in the thread to re-run an operation: each statement shall be bound to a specific frame, this operation will rerun the frame. However what side-effect you did before will affect the new frame running.(for e.g. a static field will be set after the first run of this frame)
