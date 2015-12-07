I'm Wang Zhendong, a chinese boy now working as a developer in Citigroup. 2.5 years working experience which was full of challenge tasks not only made me become an efficient developer but also let me familiar with most aspects of software development.  Personally, the topics of software development I like most are Enterprise Application Architecture, framework design, model driven development and language design. 

Since Jonathan Aldrich is my dream mentor. I'd like to discuss some of the language related projects I did in this short essay. I also prepare some essays on other areas in my supplement material.

### Hanbao, a self written grammar mapping framework which supports left recursive grammar.
At the beginning I learned Antlr4. I was curious about how it supports the left recursive grammar. Instead of reading the author's paper, I want to give a try to write a grammar mapping framework myself since sometimes I like to re-invent wheel to better understand how it was invented.

To make it not so difficult for the first the version, I first list my goals:
1. hanbao will support Left Recursive Grammar
2. hanbao will support Priority Associate
3. hanbao will support AST rewrite

Since this is a short essay, I just pick up and show one important aspect of hanbao here. I will provide more in supplement materials.
Let's use the classical arithmetic


### SQL optimizer
When I work in <conpany>. One of my job is to generate complex report for traders using data in our data warehouse. The main challenge for this job is usually we need to join more than 20 tables with complex filter condition to get the final report and the embede SQL complier just can't optimize it. To get the desired performance usually we need to spend many time manually docompose the huge sql code into small pieces to find the part that slow down the whole performance. It was absolutely time consuming to do this, so I think we can actually made it automatically. 

The solution I gave is not difficult:

1. Write a parser to parse the sql query into AST
2. Use the parsed AST and statistic information(like table size) from DB to recalculate the join relationship to generate a new sql. To be more detail, If we encounter big tables with a good filter condition which can make them smaller, we will extract them out from the origin big sql into a temp table and then let the origin big sql reference the temp table. As the end of this step, we will have an in-memory model for our new SQL query.
3. Finally, we just need to regenerate the new sql query from our in-memory model.

For step 1, the real challenge relies on the SQL dialect we use is t-sql(for Microsoft's SQL Server) which has some of its unique feature. For example, it has many different ways to express the same syntax:  ```... from tableA as t ...```, ```... from tableA as "t"...```, ```... from tableA as [t]``` and ```... from tableA t``` has the same semantic. For another example, t-sql has its unique syntax to work with xml like ```select T.c.query('.') as result  from @dataSource.nodes('/root/info') as T(c) ``` To compatible with all these special condition, it's quite challenge to implement the parser. But it's nice we already had some good tools on language development such as xtext and antlr. I use xtext since it also provide ultility classes for unit test though it doesn't support  more powerful grammar mapping like Adaptive LL(*) which Antlr4 has.

For step 2, the real challenge came as some syntax different strucute share the same semantic meanning. For example: ```select * from t1 join t2 on t1.key = t2.key``` has the same meaning with ```select * from t1, t2 where t1.key = t2.key```. So it took me some effort to transform the AST into the optimizer domain model. The algorithm using statistic data in DB to generate the execution plan is also non-trivial, so won't discuss it here since it took a lot of space.

For step 3, it's quite easy.

##### Summary: 




### What is a language?
I think, at its core, language is an **efficient tool using well designed syntax to easily express its underlying domain model**. So actually we can use the  following equation to describe the same meaning:
> programming language = well designed syntax + underlying domain model 

For example, in professor Jonathan's AEminium Language, the core domain model is a scheduler which create an parallel exeution plan for a sequence of actions according to their data sharing condition. The syntax is the grammar we use to write this language. The domain model will help solve some ensential questions and an improvement on syntax can help you express your complex domain model more easily.   

When you start to develop a language, there are also some other things need to implement. 
* you need a parser to parse your source code into AST.
* you need several checkers to make sure the semantic correctness
* depends on your intention, you will need some other 

### Wher


### What's the benefit if we develop a new language.


