### test your UI control in a quick way
```java
...
Display display = new Display();
Shell shell = new Shell(display);
// put your UI test code here
//new WizardDialog(shell, new NewFeedWizard()).open();
display.dispose();
...
```
