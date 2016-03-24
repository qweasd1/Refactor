


# AOP

### Concept
* annotation model
* desciption model 

### overview
* logging
* security
* transaction management
* caching 



### Elements
* advice: 
	* when to invoke:
		Before
		After
		After-returning
		After-throwing
		Around 
	* what to do
* Join Point:
	* possible place advisor can be inserted 
* PointCut:
	* a filter to select part of Join Point to add Advisor
	
* INTRODUCTIONS:
	* add new field and method to existing class

* weave: merge everything together
	* compile time
	* Class load time
	* runtime
	
	
	
### when to use


## internal
* JDK dynamically proxy and CGLIB proxy, JDK dynamically proxy could be used if require an interface and CGLIB can be used if the require object is not an interface
