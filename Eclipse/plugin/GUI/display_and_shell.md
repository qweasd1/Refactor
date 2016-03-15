### blogs:
* [usage of display and shell] http://blog.csdn.net/chulaixi/article/details/3095478


### Display
* bridge between OS and SWT:
* important method:
```
Display           method Function
Display()         Allocates platform resources and creates a Display object
getCurrent()      Returns the user-interface thread
readAndDispatch() Display object interprets events and passes them to receiver
sleep()           Display object waits for events
```

### Shell
* root window




### boil code
```java
Display display = new Display();
		Shell shell = new Shell(display);
		
		////
		put your code here
		
		////
		shell.pack();
		shell.open();
		while (!shell.isDisposed()) { 
            if (!display.readAndDispatch()) {  
                display.sleep();   
            }   
        }   
		display.dispose();
```
