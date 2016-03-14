### ui can only be updated from UI Thread
do something async
```java
uiControl.getDisplay().asyncExec(new Runnable(){
...
})
```
