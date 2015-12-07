I'm Wang Zhendong, a chinese boy now working as a developer in Citigroup. 2.5 years working experience which was full of challenge tasks not only made me become an efficient developer but also let me familiar with most aspects of software development.  Personally, the topics of software development I like most are Enterprise Application Architecture, framework design, model driven development and language design. 

Since Jonathan Aldrich is my dream mentor. I'd like to discuss some of the language related projects I did in here. If you are interested in these projects details, see them in my supplement material.

### Hanbao, a self written grammar mapping framework which supports left recursive grammar.
At the beginning I learned Antlr4. I was curious about how it supports the left recursive grammar. Instead of reading the author's paper, I want to give a try to write a grammar mapping framework myself since sometimes I like to re-invent wheel to better understand how it was invented.

To make it not so difficult for the first the version, I first list my goals:

1. hanbao will support Left Recursive Grammar.
2. hanbao will support operator priority.
3. hanbao will support AST rewrite.

Since this is a short essay, I just pick up and show the most important aspect of hanbao, which is Left Recursive Grammar support here. I will provide more how I design the framework in supplement materials.
Let's use the classical arithmetic expression as the example.

```antlr4
// left recursive version(written in antlr4 grammar)
expr : expr '*' expr
     | expr '+' expr
     | INT 
     ;
     
INT: [0-9]+ ;
```

As we all know, in tradition, we use left-factoring to remove the left recursion like the following:
```antlr4

expr: add ;

add: multiple ('+' multiple)* ;

multiple : atomic ('*' atomic)* ;

atomic: INT
      ;
INT: [0-9]+ ;
```
Here is my solution:

1. for each left recursive alternative in a rule definition will implicitly get a priority. The topper it is, the higher the priority. In our example, ```expr '*' expr``` will have higher priority than ```expr '+' expr```.
2. we mapping from the left-recursive grammar to its left-factoring version when parsing the grammar definition:
```
// first all none left recursice alternative map to atomic. In our example, INT maps to atomic
// then according to priority, mapping the recursive alternative to its left-factoring rule. in our example, it's 
expr '*' expr will map to  multiple: atomic ('*' atomic) *
expr '+' expr will map to add:  multiple ('+' multiple)*

```

The solution is straight forward and work well when I test it. Though the algorithm looks simple here, it's not that easy to implement, especially when I need to incorporate the AST rewrite. I also experience a lot when I debug those recursive methods to see what's going wrong.

Finally after 1 week, I finished the first version and it works well! To see more details on this project, pls see the supplement material.

### SQL optimizer
When I work in <conpany>. One of my job is to generate complex report for traders using SQL. The main challenge for this job is usually we need to join more than 20 tables or table functions with complex filter condition to get the final report. The embede SQL complier just can't optimize it and usually caused long running query. To get the desired performance usually we need to spend many time manually docompose the huge sql code into small pieces to find the part that slow down the whole performance and then optimize it. It was absolutely time consuming to do this, so I think we can actually made it automatically. 

The solution I gave is not difficult in design:

1. Write a parser to parse the sql query into AST
2. Use the parsed AST and statistic information(like table size) from DB to recalculate the join relationship to generate a new sql. To be more detail, If we encounter big tables with a good filter condition which can make them smaller, we will extract them out from the origin big sql into a temp table and then let the origin big sql join the temp table. At the end of this step, we will have an in-memory model for our new SQL query.
3. Finally, we just need to regenerate the new sql query from our in-memory model.

Again it looks quite easy at first, but here is the difficulty I met:

For step 1, the real challenge came from the parsing of the SQL. The SQL dialect we use is t-sql(for Microsoft's SQL Server) which has some of its unique feature. For example, it has many different ways to express the same syntax:  ```... from tableA as t ...```, ```... from tableA as "t"...```, ```... from tableA as [t]``` and ```... from tableA t``` has the same meaning. Another example is, t-sql has its unique feature to work with xml like ```select T.c.query('.') as result  from @dataSource.nodes('/root/info') as T(c) ``` which is highly used in our report. To compatible with all these special condition, it's quite challenge to implement the parser. But it's nice we already had some good tools on language development such as antlr and xtext. I use xtext since it also provide ultility classes for unit test though it's based on Antlr3 which doesn't support more powerful grammar mapping like Adaptive LL(*) which Antlr4 has.

For step 2, the real challenge came as some syntax different strucute share the same semantic meanning. For example: ```select * from t1 join t2 on t1.key = t2.key``` has the same meaning with ```select * from t1, t2 where t1.key = t2.key``` in tsql. So it took me some effort to transform the AST into a standard optimizer domain model. The algorithm using statistic data in DB to generate the execution plan is also non-trivial, so won't discuss it here since it took a lot of space.

From this project, I realized that some simple ideas can be difficult when we go down to details and implement them. Sometimes, unit test is quite important to make sure we did every step correct.


### My understanding on wyvern language

I thought the design of wyvern, which professor Jonathan is working on it, is a great design. As I think, the most valuable thing of it, is it provide a fine framework to hold different language together in a structure way. This is resemble to the nature that in a real world, a complex system usually composite with different domain. Obviously, we can't use only one general language to decribe complex system efficiently. To help solve this, people tend to develop some internal DSL for each domain but of course, an internal DSL is never as powerful as an external DSL since it's restricted by its host language. 

I think we always have the need to build the DSL for complex system. Usually they share the some feature, so in traditional, we always start the language from a base language template. This is quite like inheritance in OO programming. As we all know, OO best pratice suggest that composition is better than inheritance since composition is much more flexible. I think the same thing also apply to  language design. When we find a good feature in one language and want to incorperate it into a new language we need to change the grammar rule and cause compatible issue, which means we can't import a new language feature as a plug-in. For wyvern, defines


I thought wyvern divide a whole lanugage into several small DSL segments and let small DSL segements can develop independently. It also mean that those DSL segments can be reusable. This just what we use composition in OO programming. As a result, the difficulty of develop a workable language decrease rapidly.

wyvern is also a good tool to build a framework config. Usually a framework is flexible, so we usually expose some extension points. In traditional, the extension code are usually define in xml or some language's code. It can sometimes be ackward by using this way. For example, some software requires their plugin to inheritate from specific baseclass and implment some method you have no idea. However, if you expose a more readable DSL, it might be better to understand and easy to use.

In the future maybe, we can build a maven like repository which stores many DSL segments from world around and let developer pick them up and quickly integerate them into their wyvern system.

Moreover, when developers began to use this mode, we can do static analysis on their code more easily. Usually, it's hard to interpret the intension of a piece of code since general language is so much flexible. A developer can express the same idea in many different ways. When people started to use wyvern, they are more likely to give more explicit semantic information since domain specific logic are constraint inside specific DSL.

In one word I like this language and I hope I could have chance to work on it though it seems not show in this years project list.


 



### A general view on software engineering
In general, I thought software and chemistry share a lot of similar traits. In chemistry, on the one hand we have countless compounds with extremely different characteristics and on the other hand we only have only 100+ unique atoms and countable rules. Those rules and atoms combine with each other and finally generate the this diversity world. For software development, the situation is same except taht we are still on the way to figure out those basic elements and rules. So the main job for a software engineering researcher is try to find the basic elements and rule for software development and leverage them to build good software efficently.

### Areas I'm are interested in 
* Meta programming
* Model Driven Development (especially for the eclipse modeling project)
* Language Design
* Object-oriented foundations
* Design Pattern
* Plug-In development (especially for eclipse)

### Advantages of me
* I'm quite fluent with different programming language especially for functional programming.
* I'm familiar with concept about compiler and have real experience on complier techonology. I'm fluent with tool like Antlr and xtext.
* I can research and develop independently.(I've independently developed several 20000+ line of code projects which contains complex multi-thread logic, complex layout algorithm etc...) I'm also a good self learner.(Actually I learn everything about programming myself after I graduated)
* I have solid understanding and practical experience on most aspects of software development such as OO Design, Design Pattern, DSL, Enterprise Application Architecture, TDD, DDD, CI and one-click deployment. (I'm not quite famliar with security related topics)
 




### Content for supplement material
* Hanbao: a self written grammar mapping framework which supports left recursive grammar 
* objmap: the design of a JS framework to do model to model tranformation
* <Parser Framework>: a flexible parser framework
* How should a document be designed?



