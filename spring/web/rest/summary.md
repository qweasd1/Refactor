benefit of rest


### rest application design:
* resource Identification
	* object
	* collections
	* ComputeResult: used to perform some logic on common resources to generate a result
* resource representation
	* id
	* attributes
* endpoint identification
	* sub domain as base URI (api.domain.com, dev.domain.com): to enforce security policies
	* use plural nouns as resource name and use id to access individual ones
		* sample: {domain}/polls/{pollId}
	* use a URI hierarchy to represent resources that are related to each other
	* for compute result, use query parameters
* verb/action identification
	* 
	
* [TODO;important] details
	* method
	* input
	* success response
		* response code
		* body
	* error response
	* description
	
	
### convention
* ResponseCode for post delete...
* Post method shall return the new create resource's uri in response's Location header



### Error handling
* [TODO:important] where will error happened?
* how to tell the error: throw custom exception annotated with @ResponseStatus(HttpStatus.NOT_FOUND)
* [TODO:important] error response format(message + error description(resource, field, code, details) )

* some convenient method
	* common check and response logic
	* [?workable] aop
	
* implementation
    * @ControllerAdvice
		* @ExceptionHandler(${Exception}.class)
		
* handling standard exception throw by Spring
	* extends ResponseEntityExceptionHandler class and override the base method
		
### Validation

* implementation
	* implementation org.spring.validation.Validator interface, inject this validator into a controller, invoke the validator's method manually to perform validation
	* JSR303 validation (Hibernate)
	  1. apply validation annotation on model
	  2. add @Valid annotation to tell spring to validate the parameters(@Valid @RequestBody Poll poll)
	* Externalizing Error Messages(put error message into properties file)
	  1. create message in format: ${Constraint_Name}.${model_name}.${field_name} in properties files
	  2. [? how to use MessageSource] @Inject MessageSource into the class
	  
	  
###  Document with Swagger framework (REST API document)
* document
	* specification: https://github.com/OAI/OpenAPI-Specification/blob/master/versions/1.2.md
