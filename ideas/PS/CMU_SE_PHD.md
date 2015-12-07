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
Since I already list 2 projects there, I hope I can express my understanding on language design in this section.

As we all know, language design has 2 core areas. The design of the underlying model and the design of syntax. 

Let's first talk about The design of underlying model is essential for a language,

I think, at its core, language is an **efficient tool using well designed syntax to easily express its underlying domain model**. So actually we can use the  following equation to describe the same meaning:
> programming language = well designed syntax + underlying domain model 

For example, in professor Jonathan's AEminium Language, the core domain model is a scheduler which create an parallel exeution plan for a sequence of actions according to their data sharing condition. The syntax is the grammar we use to write this language. The domain model will help solve some ensential questions and an improvement on syntax can help you express your complex domain model more easily.   

When you start to develop a language, there are also some other things need to implement. 
* you need a parser to parse your source code into AST.
* you need several checkers to make sure the semantic correctness
* depends on your intention, you will need some other 

### Wher


### What's the benefit if we develop a new language.


