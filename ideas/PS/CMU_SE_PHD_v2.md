## PS

### A short Introduction of me
I'm Wang Zhendong, a senior developer now working for <Company>.My interest in software development was inpired by an occasional internship in 2012. Since that I began to learn software development myself and soon become a creative and efficient developer. Though I perform well for my current job, my deep interest on software engineering ,especially for the following 4 areas: **language design, software architecture and model driven development and meta-programming**, finally drive me to apply for this fanstastic program! 

To be straight, my **dream mentor is Jonathan Aldrich** and **my dream projects are Plaid and Wyvern**. I will show I'm a good and potential candidates for these projects in the following sections.

### My common experience on Language design
I was interested in language design since the beginning of this year. The interest was inspired by my wish to implement some external DSLs . I used to use Regex experssion to write some simple expression DSL, but when it came into complex situation, Regex is not not enough. Then I began to study complier technology and related framework myself. While studying, I started to use complier technology in my daily development, such as extract meta data from source code and generate artifact automatically. I even implemented an Antlr like grammar mapping tool myself in javascript. Since it took much space to explain the details of these projects, I put them in my supplement materials. See them if you have the insterested. In this short essay, I will just share some of experience I gained when I study language design myself.

##### forntend design:
  The frontend of a compiler usually focus on how to parse the source code into correct AST. It's quite simple when working with simple case especially with tools like Antlr. But things soon become difficult when your language become complex or when you want to add new feature into your existing language. For instance, as I first work on complier design, I tended to write sophisticated grammar and AST rewritor to make the parser generate the AST very near to the semantic model of my language. It worked well at first but when I wanted to add some new features, I found it's awkward to modify the grammar definition. Sometimes,  there are conflicts between old feature and new feature, which can't be reconiled unless I rewrite a large portion of the grammar. With more and more trying, I realize that actually we can keep our grammar more general and simpler and introduce another transform between the AST and semantic model into the frontend of our compiler. Another trick I learned my self is make the grammar accept more widely(even illegal input), and delegate the check job to the backend components. This can reconile some of the conflict condition in practice. 
  
  For some common structure like expression, function definition, class definition, there are widely accepted grammar or pattern for them. For instance the left-refactor is the classical way to build expression grammar. So I think it's better to understand how to implement those feature efficiently which can save time when we do prototype for our own language.  

###### backend design:
  The backend of a compiler usually focus on how to transformed the AST to semantic model of your language ,depends on your need, with additonal components like semantic checker, code generator and interpreter. Since compiler exists for a long time, there are many mature patterns for these tasks. A good example is Antlr4's AST visitor and listener with which, you can calculate the expression or do type-cheking. Another example is to calculate the variable reference and scope. You can find framework level support for this feature in xtext.(one of language framework based on Eclipse Modeling Framework)
  
  From another view, once we start to work with the AST and semantic model, we are already in our familiar realm of OO programming. So, a lot of technology about OO programming can be used. Technology like AOP can make some special kind of check more easily and more reusable. Also, we can leverage the tools for M2M(model to model) transformation and M2T(model to text) transformation from some modeling driven development framework like Eclipse Modeling Framework. I also developed several tools myself. I used to develop a jquery selector like framework to work with AST. 
  
###### unit test
  Unit test is important to guarantee software quality and language development is no different. During my practice, I found unit test is ensential both in the first time I wrote the language and guarantee nothing break when I extended old feature.(for example, add a new branch for a given rule). 
  
  The most painful thing however, is that sometimes, writing test is time consuming. For instance, when implement a parser, we always need to check if we parse correctly by checking its AST structure, of course it's unwise to check the AST object directly since your test will contain too much 'assert' and be less readable. A good way to ease this issue is to change the AST into its Lisp-flavor representation.( for example AST of ```1 + 2 + 3``` has the Lisp-flavor representation: ```(+ (+ 1 2) 3)```) and then compare the string. This is more easily to write. There are more tricks on unit testing, but since we have limit space, won't speak here.
  
###### Assistant feature like: error reporting, quick fix , refactor
  Though, the topic list above not important for the creator of a language, it's important for the user since they make them work efficiently. To incorporate the features above, we need to consider more in our code. For instance, for error reporting, the simplest way is to throw an exception with error message. But usually, user need the position of error, so you also need to include the line number and column number of your exception. For another example, when you want to do quick fix, you need to provide the quick fix method the desire information parsed from source code. Both situations are not easy. 
  
  However, thanks for framework like xtext which step more than Antlr, has provide mechanism to write these functions easily! 
  
###### The strategy to develop a new language.
  Since language design in essential is a system design, so all concepts about agile development can applies to it. The following are my ideas on how to develop a language more efficiently. 
  
  **First**, I think it's important to rush out a protoype of you language while you are doing the design. With the help of framework like xtext, we can finished the prototype very quickly. Once we had the protoype, we can quickly find out the drawback in our language.
  
  **Second**, Always try your language with real world sample. Like system and framework design, we transform our fancy idea into convenient feature into our language to make specific job doing easily. But sometimes, our new feature will conflict with existing function and made some common case used to be easy but now hard to implement. I've found such kind of question in the paper of AEminium and here is a little [article](https://github.com/qweasd1/Refactor/blob/master/ideas/Supplement/plaid_thinkings.md) for it. Since I haven't read all materials about AEminium, though maybe the question I raised is solved already, the idea in the article is my current thinking.
  
  **Third**, I think it's better not to optimize your language so early. From my own veiw, the most important thing for a new language is whether its semantic model best cover the real world need. When the semantic model become stable, we then started to began the optimization since most optimization is based on semantic model. 
  
  

  
###### How to make your language popular
  To make your language popular, there are two main aspects you can improve:
* internal improvement: usually, people tends to use their familiar syntax, so it's a good idea to reuse other language's syntax for the same semantic model in your language This will ease the user's learning curve. For instance, lambda expression and pattern match are two popular feature for nearly every functional programming language, but different language give them different syntax. So don't give a new version for them yourself unless you have a solid reason for it. Also, reuse other language's mature syntax can let you reuse their implementation and you save more time when you do prototype!
* external improvement: This aspect contains many content. For intance, you need to write a good document for it. You need to setup a community for it and make sure user's question was answered in time. However, I think, always provide a good playaround environment to your user is a good idea! A good example is some [Regex Test plugin](https://regex101.com/) which give user very quick feedback when they study and use Regex.



I've list aspects I think is important for a language design here, I will list more in my supplement materials. 

### My ideas on Plaid


### My ideas on Wyvern
In enterprise software development, we tends to decompose our application into suitable sub domain. There is always an issue when 
* make every domain logic more easily. So don't embed general language
* make it more easily to describe the 

### Future plan
* advanced design pattern and parsing strategy for frontend work.
* error handling with error input. Report useful error information
