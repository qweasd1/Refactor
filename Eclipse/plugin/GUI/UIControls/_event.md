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

#### all typedEvent

#### [TODO] special event on specific control

### async update UI
```java
display.asyncExec(Runnable)
```


### [INCREASE] cases
* the callback reference disposed UIControl
