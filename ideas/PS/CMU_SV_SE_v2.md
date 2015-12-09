## Personal Statement

### A short Introduction of me
My name is Wang Zhendong and I'm a 24 year old Chinese boy. I got my bachelor degree from University of Science and Technology of China in 2013 and my major is statistics and finance. I didn't expect I will become a software developer until 2012 I worked as an intern in BASF logistic department. During my internship, I developed my first software which helped my department generate several complex reports automatically using Excel VBA. My interest on software development was soon inspired by this and in the last year at school I absorbed all basic knowledge of programming myself. After I graduate from school, I joined a challenge startup program holding by my friend and work on it for 1 year. After finished, I applied to Citigroup, passed their competitive interview and work as a senior developer until now. 

### About me -- a veteran in software development
Though I had only 2.5 years experience, I'm confident to say I'm already a veteran in software development.

First, I'm fluent with a wide range of language and framework. You may see a long list for them in my resume, so I won't state them again here. To show how deep I understand them. Let me talk about some topics them. For Languages, they are ensentially a facade layer above the underlying abstract model. The more advanced the language, the more efficient they can express the underlying model. In recent years, with the popularity of functional programming,  models like anonymous function, high order function, pattern match... become more and more popular and every modern language tends to include them. So, once you understand the underlying model, you should be easy to understand them in a unfamiliar language.  What I want to show here is how I learned new languages and frameworks. For language, especially the modern and general purpose language, they always share some common concept more or less . A good example for this is the concept of lambda expression and high order function. They are wide spread in nearly all modern language and the differences relies on the concrete syntax. Another example is the pattern match and usually different language has different support strength for it, some are more powerful(Scala with its case class), some are less powerful.(xtend) Once you familiar with the underlying concept, you will quickly get used to that new language. The same concept also apply to a framework. Usually a framework is aimed to solve a particular problem. So before learning a new framework, I always first make clear what kind of problem it aims to solve and what difficulty I will face if I don't use this framework. Not like language, framework usually has less static check, so when I learn a framework, I always think how I can unit test the component I wrote from the framework. Beside thinking, I will always make my hands dirty to make sure I can use them correctly in real world. 

I had a broad and comprehensive understanding on many software development related topics. I had solid understanding on OO design, design pattern and Enterprise Application Architecture. I also know domain driven development well and implement it in daily development.(One of my interest is to development assist tools to help implement DDD more easily) For programming paradigm, I'm fluent with both OO and functional flavor. For methodology, I'm a fan of Agile and TDD and used them for 1.5 years. I'm quite famliar with unit test and some mock frameworks. I'm also quite famliar with Dependency Injection along with the popular frameworks like Guice, Ninject and Spring. For CI, though I practise very little, I know the main concept for it and popular tool like Jenkins. For static analysis, I know the SonarCube. DSL, language design and complier technology is one of my big love. I'm fluent with Antlr4 and xtext and I developed several application based on them in my daily work. For instance, I implement a parser for t-sql to extract meta information by using xtext and use those information to analysis its potential performance issue. Moreover I develop a meta program to refactor the low performance sql to a high performance version automatically. I also like model driven development very much and believed it will be a big trend in the future. The Eclipse Modeling Project and its sub-projects is my best love on this area. 

### A short introduction to one of project
I'm good at designing and developing easy to use framework and logic less system which means people can use it earsily in an intuitive way and let system and framework help handle the details. 

work When I work in <Company>, One of my project is to develop a general framework to transform dirty and complex source data into a desired format. The source data could be xml, json, csv, Excel etc. The most complex source data could be xml file with several namespaces and deep hierarchey. From a user's perspective, they absolutely hope they can do the transform without in an intuitive way without touching any complex code, so decided to design my framework fullfill this need. The solution I gave is quite simple in concept but a little bit challenge. Here, let me use xml source data as an example to explain the design:
* An analysis program will read in a sample xml file, parse and collect meta information like tag name, tag relationships from it and show it to user through a GUI. 
* User then pick up the fields they want from the GUI. 
* User specify their desire format in a template
* The analysis program will generate a execution plan for the whole transform. 
* After passing the exectuion plan and source file to the transform engine, it will genrate out the file.

As you might guess, the most complex part is how analysis program generate the execution plan. Let's see a concrete example:
Here is our source data
```xml
<!-- source data-->
<Blog>
  <Author>Tony</Author>
  <Articles>
    <Article title="1st article">
      <Comments>
        <Comment>a1_c1</Comment>
        <Comment>a1_c2</Comment>
      </Comments>
    </Article>
    <Article title="2nd article">
      <Comments>
        <Comment>a2_c1</Comment>
        <Comment>a2_c2</Comment>
      </Comments>
    </Article>
    <Article >
      <Title>3rd article<Title/>
      <Comments>
        <Comment>a3_c1</Comment>
      </Comments>
    </Article>
    <Article >
      <Title>4th article<Title/>
      <Comments error="can't read it from db">
        
      </Comments>
    </Article>
  </Articles>
</Blog>
```
Here is our desire format(a csv file): 
```
//desired data
Author|Article|Comments
Tony|1st article|a1_c1
Tony|1st article|a1_c2
Tony|2nd article|a2_c1
Tony|2nd article|a2_c2
Tony|3rd article|a3_c1

//error data flow
Author|Article|Comments
Tony|4th article|[error: can't read it from db]
```
The sample above needs to transform hierarchy data like xml into flatten data like csv.It also needs to handle heterogeneous structure(comapre the 3rd Article tag with the its previous one) and error condition(the 4th ). This is just a sample and the real world requirements can be more complex. So it's really meaningful if we can build the intelligent analysis program. Though difficult, The framework is finally finished and gained great success since it save a huge time and it won an award in <Company> 's innovation competition ranking #14 out of 110 project. (I even got the 3rd highest technology score). 



### My thought on Software Engineering
When I began to learn software development, I was attracted most by advanced language feature, framework and concepts. But after 2.5 years industry experience, I had a different view now. For software development, I think the most important thing is make clear the problem you are facing and how to decompose it into manageable part. I used to think write sophisticated to handle every situation, but now I try to decompose the issue I met to see if it actually composed of several solved small issues. From this view, I thought software development share some similar characteristics with chemistry. In chemistry there are countless compounds various in qualitiy, but there are only 100+ elements with limit rules. It's the combination of those elements and rules create the numerous compounds! Before scientist realized this, they move slowly on discovering the characteristic of different compounds but once they realized this, they move quickly and even can predicate the characteriscs of non-exist materials!  For software development, we have several common structure like tree and graph which resemble the elements in chemistry. We have patterns which is similar with rules. As developers we are actually reuse those elements and rules to construct the domain model we want, which is like compound . The aim of software enginerring is try to find out those elements and rules and how to work with them efficiently. This also build a solid foundation for future's meta programming which can made the process to combine elements with rules automatically.


#### research and working experience
* design a digit chip testing tool in my frist startup program. The software contains sophisticated and customized ploting system, complex parallel and synchronous logic and dynamically generated GUI.
* design and develop an intelligent ETL framework to transform dirty, complex and heterogeneous raw data to clean and standard format. in <Company>
* design and develop parellel optimizer for data processing. The developer only need to focus on dataflow and the optimizer will parallel the data process automatically.
* design and develop a visual data compare tool used to compare heterogeneous, large volume data from different data source. (Used in data migration project)  
* design and implement a light weight grammar mapping tool in javascript called [hanbao](https://github.com/qweasd1/hanbao) which support left recursive grammar, AST rewrite and a more powerful ASTVisitor.(It's like Antlr4 but with a totally different implementation) 
* design a flexible model to model tranformation framework in javascript called [objmap](https://github.com/qweasd1/Refactor/blob/master/ideas/Supplement/objmap.md) (haven't implement yet, but you can see the main design here)
* 


#### research interests
* Meta-programming
* Model Driven Development(especially Eclipse Modeling Project)
* PlugIn Development(especially Eclipse related)
* Enterprise Application Architecture
* Programming Language Design and Compiler Technology
* Data Warehouse Design(especially on meta-database design and automatic and adaptive ETL)
* Distributed System Design
* Parallel Programming


