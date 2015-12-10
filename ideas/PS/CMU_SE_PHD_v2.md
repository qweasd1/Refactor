## PS

### A short Introduction of me
I'm Wang Zhendong, a senior developer now working for <Company>.My interest in software development was inpired by an occasional internship in 2012. Since that I began to learn software development myself and soon become a creative and efficient developer. Though I perform well for my current job, my deep interest on software engineering ,especially for the following 4 areas: **language design, software architecture and model driven development and meta-programming**, finally drive me to apply for this fanstastic program! 

To be straight, my **dream mentor is Jonathan Aldrich** and **my dream projects are Plaid and Wyvern**. I will show I'm a good and potential candidates for these projects in the following sections.

### My common experience on Language design
I was interested in language design since the beginning of this year. The interest was inspired by my wish to implement some external DSLs . I used to use Regex experssion to write some simple expression DSL, but when it came into complex situation, Regex is not not enough. Then I began to study complier technology and related framework myself. While studying, I started to use complier technology in my daily development, such as extract meta data from source code and generate artifact automatically. I even implemented an Antlr like grammar mapping tool myself in javascript. Since it took much space to explain the details of these projects, I put them in my supplement materials. See them if you have the insterested. In this short essay, I will just share some of experience I gained when I study language design myself.

* forntend design:
  The frontend of a compiler usually focus on how to parse the source code into correct AST. It's quite simple when working with simple case especially with tools like Antlr. But things soon become difficult when your language become complex or when you want to add new feature into your existing language. For instance, as I first work on complier design, I tended to write sophisticated grammar and AST rewritor to make the parser generate the AST very near to the semantic model of my language. It worked well at first but when I wanted to add some new features, I found it's awkward to modify the grammar definition. Sometimes,  there are conflicts between old feature and new feature, which can't be reconiled unless I rewrite a large portion of the grammar. With more and more trying, I realize that actually we can keep our grammar more general and simpler and introduce another transform between the AST and semantic model into the frontend of our compiler. Another trick I learned my self is make the grammar accept more options(even illegal input), and delegate the backend of  of language to 

know In this time, it's better to helpis quite simple for simple case if you use some grammar mapping tool like Antlr. usually, we can do some tradeoff between the grammar and semantic model. for complex language, we can usually used more wide-accept grammar model which can parse
* backend design
* unit test(when you try it in interation,)
* Error condition
* static check, refactor and quick fix
* when to use it in real world and when to consider performance enhancement.
* IDE support
* How to let other guys learn your language easily. Share common concept and help them understand the unique part of your language. Seasonal programmers are old foxes and they are usually familiar with feature like 

agile development


### My ideas on Plaid


### My ideas on Wyvern
In enterprise software development, we tends to decompose our application into suitable sub domain. There is always an issue when 
* make every domain logic more easily. So don't embed general language
* make it more easily to describe the 

### Future plan
* advanced design pattern and parsing strategy for frontend work.
* error handling with error input. Report useful error information
