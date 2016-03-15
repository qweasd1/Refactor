## Label
> a text description or sometimes a seperator

### important methods
constructor:
```java
Label lb = new Label(shell, ${style});
//use None to default

//use SWT.SEPARATOR to make it a separator
```

style:
```java
//text alignment:  SWT.CENTER | SWT.LEFT |SWT.RIGHT
setAlignment(int)
getAlignment()

//seperator: SWT.SEPARATOR ( combine with SWT.HORIZONTAL to control the orient, combine with SWT.SHADOW_XXX to control appearance )

```
