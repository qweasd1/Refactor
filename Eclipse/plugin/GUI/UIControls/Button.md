## Button
> button with different types

### details
style:

```java
new Button(parent, ${style})
//style can be;
// * type: SWT.PUSH(default), SWT.TOGGLE, SWT.CHECK, SWT.RADIO
// * textAlignment: SWT.LEFT, SWT.CENTER, SWT.RIGHT
// * Show Arror Picture: SWT.ARROR (| SWT.LEFT, SWT.RIGHT, SWT.UP, SWT.DOWN)
// * other: SWT.SWT.FLAT
```

methods:
```java
//common
button.setText(String)
button.setImage(...)
button.setAlignment(${style})

//special: 
button.setSelection(boolean)
button.getSelection()
```

### related topics

* RadioGroupFieldEditor: used to group radio buttons
