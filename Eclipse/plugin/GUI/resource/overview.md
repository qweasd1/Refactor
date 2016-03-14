### resource must be dispose to release
* every resource is subclass of ```Resource``` class with ```dispose``` and ```isDisposed``` method
* we can detect how many resources are allocated: ```parent.getDisplay().getDeviceData().objects```
  * ref: http://file.allitebooks.com/20150716/Eclipse%204%20Plug-in%20Development%20by%20Example%20Beginner's%20Guide.pdf P67
  * you need to Setup a debug configuration for it to finally use it.

### the dispose time:
*  http://file.allitebooks.com/20150716/Eclipse%204%20Plug-in%20Development%20by%20Example%20Beginner's%20Guide.pdf P70 bottom

### tools to detect the resource leak issue
* Sleak:  http://www.eclipse.org/swt/tools.php
