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
	
	
### how to use
* aspectJ expression to express pointcuts
* advice to express the AOP logic 
	* steps:
		1. create Aspect class and mark it with @Aspect
		2. add method along with intercept annotation and pointcut expression
			* intercept annotation: @Before, @AfterReturning, @AfterThrowing,@Around {void method(ProceedingJoinPoint jp)}
			* pointcut expression: ...
			* [...TODO] you can also create pointcut and reference it using @PointCut
		3. turn on the auto-AOP proxy, add @EnableAspectJAutoProxy on the configuration class 
	* details:
		* [...TODO] intercept annotation type
		* handling parameters in advice
			* intention: extract parameters out
* [...TODO] introduction		

### [important] when to use
