## Event

### content
* typedEvent
* 


### typedEvent
* Event subtype of TypedEvent (with special parameters)
* TypedEventListener
* use Add${EventType}Listener to add the event on specific control

typedEvent fields:
```java
TypedEvent field Function
data: Information for use in the Event handler
display: The display in which the Event fired
source: The component that triggered the Event
time: The time that the Event occurred
widget: The widget that fired the Event
// [?] what's the diff between source and widget?
```

### use **EventAdapter**(abstract class) instead of **EventListner**(interface)
EventAdapter already provide empty method for all abstract methods, just override the one you need

#### all typedEvent

### [TODO] special event on specific control
#### KeyEvent:
```
// char value of the press key
e.character

// stateMask is an integer represents the modifier keys: shift, alt, ctrl, cmd
e.stateMask

//keyCode is an integer to represent the typed key
e.keyCode
```
#### [TODO] TraverseEvent

#### [TODO] VerifyEvent


### async update UI
```java
display.asyncExec(Runnable)
```


### [INCREASE] cases
* the callback reference disposed UIControl
