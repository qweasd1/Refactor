### how to design a framework(module)
*This is a short essay about framework(module) design*

**Content**
- What's a framework(module)?
- Before everything, select a goal with your framework
- Make your framework easy to use
  - Single root
  - Similar structure(make you familiar with it)
  - has default settings, implement elegant way to override them
  - make holes(template method, template) in your framework
  - make trivil things more simple, let complex things not complex, let those hard to handle can turn back to what we can do
  - should be easy to extend
- keep those things in mind
   - don't do to much(Groovy as a sample, it can parse its code as java, but does it really necessary? It will definitely complicate the complier algorithm.)
   - error handling in your mind!(don't throw the origin exception)
- framework on demand
  - let the framework behave what you want.(give your user more option)
    - bootstrap()
    - hanbao()
  - build trivial adapter to quickly incorperate the framework in new system.

##### What is a framework?
To answer a question, to make it clear first. Before we talk anything about how to design a framework, I want pust some useful constraints on the module we are talking about: A module should have only one single root object and might has an optional config object.

here are several good examples in javascript:
