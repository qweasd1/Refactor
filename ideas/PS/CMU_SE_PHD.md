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


### My understanding on language design



I thought the design of wyvern (which is professor Jonathan's project) is a great design. The most valuable thing of it, as I think , is it provide a framework to hold different language together in a structure way. This resemble the nature that in a real world, a complex system usually composite with different domain and you just can't use only one general language to decribe it efficiently. Though we can develop internal DSL for each domain but it's absolutely not enough. If you see a lot of framework with their DSL, you will find usually the DSL share very similar structure and their difference relies on the intepretor. So actually we can reuse those syntax structure along with some of their error checker and add other new need functions. We then provide quick integration tool to help integrate the new DSL into our existing wyvern system. So we can build a big repository like Maven's repository and store different language syntax and let user quickly download the build out their own DSL.

I think we always have the need to build the DSL for complex system. Usually they share the some feature, so in traditional, we always start the language from a lanuage template. This is quite like inheritance in OO programming. As we all know, OO best pratice suggest that composition is better than inheritance since it's more flexible. So I think the same thing also apply to language design.


I thought wyvern divide a whole lanugage into several small DSL segments and let small DSL segements can develop independently. It also mean that those DSL segments can be reusable. This just what we use composition in OO programming. As a result, the difficulty of develop a workable language decrease rapidly.

wyvern is also a good tool to build a framework config. Usually a framework is flexible, so we usually expose some extension points. In traditional, the extension code are usually define in xml or some language's code. It can sometimes be ackward by using this way. For example, some software requires their plugin to inheritate from specific baseclass and implment some method you have no idea. However, if you expose a more readable DSL, it might be better to understand and easy to use.

In the future maybe, we can build a maven like repository which stores many DSL segments from world around


When I design the meta data system for <Company>, I tends to use graph database as the storerage since graph database is powerful when modeling complex domain model. However, since that complexity, I think 









Since I already list 2 projects there, I hope I can express my understanding on language design in this section.

As we all know, language design has 2 core areas. The design of the underlying model and the design of syntax. The underlying model can be seen as a specific domain model, so it has no difference with a framework actually. The syntax on the other hand do nothing on domain logic. It's just like a thin layer wrapped on the domain model to make it express more easily. However to let a language used in industry, There are more things need to consider. IDE feature like code hightlight, error reporting or advanced one like quickfix and refactor are also very important. 

With the advent of tools like xtext, language development has became a product line. Xtext, build the whole life cycle including type and custom checking, scoping and reference, quick fix and refactor etc. It also provides powerful testing framework and ultitily method. It makes develope a language more easily.  So that's another thing I'm interested in: How could I implement a language efficiently by developing and using assistant tools.

Usually we don't develop a language from scratch. We usually start from a base depends on our needs and then add our new features Language on demand.



is essential for a language,

I think, at its core, language is an **efficient tool using well designed syntax to easily express its underlying domain model**. So actually we can use the  following equation to describe the same meaning:
> programming language = well designed syntax + underlying domain model 

For example, in professor Jonathan's AEminium Language, the core domain model is a scheduler which create an parallel exeution plan for a sequence of actions according to their data sharing condition. The syntax is the grammar we use to write this language. The domain model will help solve some ensential questions and an improvement on syntax can help you express your complex domain model more easily.   

When you start to develop a language, there are also some other things need to implement. 
* you need a parser to parse your source code into AST.
* you need several checkers to make sure the semantic correctness
* depends on your intention, you will need some other 

### Wher


### What's the benefit if we develop a new language.


