### PS:
- why I apply this PHD
- Who am I
  - like thinking
    - **make things simpler** 
      - sometimes, the best solution is to put some constaints on our model(WPF is such an example, AST syntax tree) and use a subset of our tool, then implment a good toolSet to help the work.
      - think broadly
      - 
    - find more easy to do way.
      - what's the weapon in our hand?(Compiler, Architecture)
    - find issues from daily development but think them in a general way
    - find 
    - rethinking those solved issue
    - rethinking the question(parser as an example). I think as a programmer, we are more easily to implement a specific function. But usually
    - think our basic things(Evaluate our current using languange)
  - like to make hands dirty
    - I like to create what I think out. I also find new issues during my development. And usually when I want to implement something complex and difficult. Start writing some code might help you re-think my question. I will explain this in one of my project
    - thinking before makes my hands dirty(centralize my question if I can)
    - got experience when facing complex questions. sometimes, we need to give some try, then we can make clear 

###Examples:
###### objmap framework
- a sample when I use jstree
- raise the questions, is there a general and convenient way to convert a one object to another structure object
  - I realize some of the potential useful case
    - select useful information from AST
    - In web development, transform the json object from AJAX's reply to view model that needs to be represent
    - use as adapter to transform  your domain model to other structure which can be consumed by another domain(our JsTree is a good example)

###### what does Software Engineering do?

###### think one question in different solution

###### two way to think: enhancement the tool for generic situation

###### pratical issue: use less to do more under the current constraint
Try to find less elements from a constraint environment and make sure they solve the issue correct and efficiently. Use constraint primary elements to build first layer abstraction. Use constraint to define the 'type'. It's more broad. Can we have some property for such structure

###### parser framework
- an assigned task
- re-thinking the question

###### object design study: Many times we are talking about the principle to design our class(model). But actually, they are not ubiquitous across all domain.(memory release). A better solution is use patterns as element upon which, we build our program. It will be both promise and quick implemntation.

###### hanbao
- why start hanbao
- Interation 1: generate the AST
- Interation 2: AST re-write
- Interation 3: add visit pattern

###### !!!!how to design a framework(module)
- What's your goal with your framework
- How we design them efficently
  - Single root
  - Similar structure(make you familiar with it)
  - has default settings, implement elegant way to override them
  - make holes(template method, template) in your framework
  - make trivil things more simple, let complex things not complex, let those hard to handle can turn back to what we can do
  - should be easy to extend
  - don't do to much(Groovy as a sample, it can parse its code as java, but does it really necessary? It will definitely complicate the complier algorithm.)
  - error handling in your mind!(don't throw the origin exception)
- framework on demand
  - let the framework behave what you want.(give your user more option)
    - bootstrap()
    - hanbao()
  - build trivial adapter to quickly incorperate the framework in new system.

###### how to design a system(stateful)
- what's the difference between a system and a framework? (stateful)
- controll the state
  - rollback

###### context-aware: make you code less(develop tool)

###### document
- raise the question: I've read many projects' documents. Some are easy to read but some are not. It's indead not easy to write a useful framework, but if your framework is not well documented, few people can start with it! So a ducument came as a must when we develop a library or framework. So we move one step further, how to efficiently write a document? 
- what's a document. from a TDD view, it the tests that shape the implemention. In the same way, we can first think how we use a document? well I think there are 2 main traditional cases: 
  - you are a new commer and want to learn the framework.
  - you already know how to use the framework but don't know the details. You might want to see what does one API exactly do
  - you have some desired functions and you don't if the framework support that. You want to find an anwser for it.

###### abstraction
a programming language is something you use to express your model.



###### logic central
we let the core logic unrevealed and don't have a core model for it


###### self design development tool(make tools easy to use!) 


###### stateful object is much harder 


###### concurrency system design(thinking how we leverage the concurrency)

###### language
language is used to describe what we want the program do.
what we can do to enhancement a language? to make it more easy to express with ideas + complier magic


###### data structure(model desgin)

###### efficient way to re-use other's code
As a community, we are in two roles: write code to facilitate others, consume other's code. So this raise 2 questions: how to make our codes easily understood and used by others. How to efficiently use other's code. (a solid a ground maybe patterns)
### Who am I

###Teachers:
- Jonathan Aldrich




--------------------------------------
- Good ideas is important and good design is also important
