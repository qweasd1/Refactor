## Widget

> the root class of all other widgets: 

### basic widget functions
```
Widget method Function
setData(String, Object) Attaches an object to the widget, accessible through String
getData() Returns the objects associated as data within the widget
getData(String) Returns the data object corresponding to the String
getStyle() Returns an int corresponding to the widget¡¯s style
getDisplay() Returns the Display object associated with the widget
toString() Returns a String representing the widget class
dispose() Deallocates the widget and its resources
isDisposed() Returns a boolean value regarding the widget¡¯s deallocation
```
 
## Control
> the subclass of Widget

### basic functions
```
Control method Function
getSize() Returns a Point object representing the widget¡¯s size
setSize(int, int) Sets the widget¡¯s size based on the given length and width
setSize(Point) Sets the widget¡¯s size according to a Point object
computeSize(int, int) Returns the dimensions needed to fully display the widget
computeSize(int, int, boolean) Returns the dimensions needed to fully display the widget,
and indicates whether its characteristics have changed
pack() Resizes the widget to its preferred size   // you should invoke pack() only after the widgets have been added to the container.
pack(boolean) Resizes the widget to its preferred size, and indicates
whether its characteristics have changed
```
