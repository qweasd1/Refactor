## Composite
> a direct subclass of ```Scrollable```


### Important subclass:
* Group
// like the normal group with a text header
```java
//constructor:

new Group(parent, ${style})

//setText():
group.setText('test')
```

* [TODO] SashForms
// like a Splitor
```java

```

* TabFolder
```java
// TabFolder has no style for it
new TabFolder(parent,SWT.NONE)

// add tabItem
TabFolder folder = new TabFolder(parent,SWT.NONE);
  //add child tabItem.
  TabItem ti = new TabItem(folder,SWT.NONE);
  // set tab header
  ti.setText("tab");
  //set the content control
  ti.setControl(Control);
  
```
