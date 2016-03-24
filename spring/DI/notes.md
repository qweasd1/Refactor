DI in spring

### Auto wiring

#### concept
* export
* import 

#### how to auto-wiring
* [!TODO] when to use: 
* how to auto wiring: mark the entity to config + add @ComponentScan to the class [?] in the same package and subpackages which is a config class 



	* @Component: mark an entity to tell spring to create it as a bean
		* [?TODO] details?
			* it will have a bean id as lowercase the first letter of the class name 
				* [! but string is not safe] change the bean id, do it like @Component("bean_id")
				
	* @ComponentScan (put it on config java class): 
		* details:
			* set the base package: @ComponentScan("base.package.name")
				* you can set several packages : @ComponentScan(basePackages={"pk1","pk2"})
				* [!] you can use class in packages to get a type-safe and refactor friendly reference: @ComponentScan(basePackageClasses={cls1.class,cls2.class})
		* ref
			* seperate the config to a package standalone
	* @AutoWired
		* details:
			* autowire procedure
				* if 1 and only 1 bean satisfy, inject
				* if no match, throw exception, unless you set required = false
				* [?] if more than 1 bean satisfy, what to use?
			* required: to allow no value match
			
	* Spring annotation vs JSR-330
		* @Component = @Inject, @Named("bean_name") = @Component("bean_name")
		
#### how to use java based config
* [!] when to use when you want to import third-party library you can't touch source code
* how to use:
	* use @Configuration to mark the class used as configuration
	* create method to register as bean factory
		* set @Bean on a method
			* bean name: method name will be the id of bean by default, you can use @Bean(name="test") to specify the bean name
		* if you call a @Bean method, it will not invoke it, spring intercept it to implement the scope. this might be confusing, so do the next 
		* use @Bean method arguments to declare the dependency
	
		
#### how to use xml-base config
* [!] when to use: work with existing xml-based project


#### profile: config environment-specific bean
* @Profile("env") can be set on **config class** or **bean method**
* the @Profile bean method will only include if the profile was specified
* you can active several profiles in run time, seperate with ','
* [TODO] know each way to active profile (mainly prod and dev)
	* for dev/test, use @ActiveProfiles("dev") on the test class

#### [...TODO] @Condition: condition bean create

#### addressing wiring ambiguous
* set @Primary bean: when more beans match, choose @Primary bean
	* Primary bean not fit, with more than 1 other bean
* use @Qualifier("test"):
	* if the bean definition doens't set this, when apply @Qualifier("bean_id"") on @Autowired, it will choose the "bean_id"
	* if you set @Qualifier on @Bean, you set attr on it. You can use @Qualifier on @Autowired to filer it
	* create custom filter if you need  
	
[??] java annotation, set annotation on annotation, what's that mean ?


#### [...TODO]@Scope
	* set on export class, with @Scope annotation
	* @Scope type:
		* default : singleton
		* ConfigurableBeanFactory.SCOPE_PROTOTYPE
		* [?] session/request: @Scope(value=WebApplicationContext.SCOPE_SESSION,proxyMode=ScopedProxyMode.INTERFACES)


#### extract out some of your config props (reduce duplicate)
	* external properties file
		* how to:
			* add @PropertySource("properties_file_path...") on your config class
			* inject Environment(as env) object
				* use env.getProperty("prop.name") to get value, when not exist, return null
				* use env.getProperty("prop.name",defaultValue)
				* use env.getRequiredProperty(propname) throws IllegalStateException
				* use env.containsProperty(prop_name)
			

#### internal mechanism spring use to figure out wiring.

[important] what kind of inject can spring do for you? ###service details




### STS support 
* [?] bean definition from source code ?

	

### test
* auto-wiring : runner + config + inject 

* test system.out.log(): use @Rule StandardOutputStreamLog

* how to use dev/embedded database 
	* [sample] (http://www.mkyong.com/spring/spring-embedded-database-examples/)
	* [spring doc] (http://docs.spring.io/spring/docs/3.0.0.RC2/spring-framework-reference/html/ch12s08.html?ref=driverlayer.com/web)
* 

### check in code (dev+uat+prod)



### bean life cycle
* constructor inject 
* when a method inject invoke


### optional dependency
