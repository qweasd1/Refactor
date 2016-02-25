### Intention
* delegate wrapper can replace inner object in any place(for simple case maybe it's easy for inner obj which override __getattr__ can we still do it?)
* delegate wrapper can add AOP feature

### design:
* if the attr is on inner obj, get and set their value
  * how about the special varialbe like __dict__?
* if the attr is not on inner obj, get and set it on delegation obj
* if the attr is not exist, when set set it on delegate obj, we get throw AttributeError


### Implement:
* use **dir** to search to enumerate inner property
