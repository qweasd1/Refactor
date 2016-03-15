
### Show window
```java
//block the window from exit
setBlockOnOpen(true)

//open the window
open()
```


### create UI : 
```java
...
//parent will be the embeded shell object
protected Control createContents(Composite parent)
...
```



### [?] useful method
```
ApplicationWindow method Function
addMenuBar() Configures the window with a top-level menu
addToolBar() Adds a toolbar beneath the main menu
addStatusLine() Creates a status area at the bottom of the window
setStatus(String) Displays a message in the status area
getSeparator() Returns the line separating the menu from the window
setDefaultImage(Image) Displays an image when the application has no shell
setExceptionHandler
(IExceptionHandler)
Configures the application to handle exceptions according to the
specified interface
```
