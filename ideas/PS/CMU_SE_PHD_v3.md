## Statement of Purpose

### About me
My name is Wang Zhendong. I'm a 24 year old Chinese boy who loves software development. I used to be a statistic student and got my bachelor degree from University of Science and Technology of China. But in 2012's summer, my interest on software development was fired when I developed my first software during my internship in BASF logistic department. Since I had very limit knowledge about software development at that time, I tried my best to absorb those knowledge during my last year at school. After I graduated in 2013, I joined a challenge startup program holded by my friend and work on it for 1 year. I learned a lot from this project and after it, I applied to Citigroup, the famous investment bank. Finally, I passed their competitive 10%-passed interview and work as a senior developer until now.

To be straight, my dream mentor is **Jonathan Aldrich** and my dream projects are **Plaid** and **Wyvern**. Since Professor Jonathan works on language related project, I want to first show my understanding on Language Design.

### My understanding on Language Design

##### The Goals of a language
I think the goals of a language are at the core of every language's design. The goal of C is to let developer use high level model to describe the program. One of the goals of Java is to do memory management auotmatically. In AEminium, the goal is to automate the execution of program in parallel. Usually the goals of a language are conceptual not the concrete implementation.

##### Core model

The core model is the implementation model we used to realize our goals of a language. For instance, the ```GC``` class and its underlying structure is the core model to implement the automatic memory management in Java. For good language, the core model must be designed carefully to fullfill its goal. For example, In AEminium, its core model is to parallel those code with no data dependency at compile time. It looks good, but when applying in real world, there some issue. I discussed it in this [article](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/a_small_enhancement_on_AEminium.md) along with my fix method. It's always a good idea to compare our goal and our model to see if it really fits our needs.


##### syntax model
Though core model is already workable, we want to have a more easier way to express them it. As I think, Syntax model is usually more easier to design than core domain model since it's just a thin layer beyond core model For example, lambda expression is a common core model across many different language, but different language support them in different syntax degree. In Java(before Java 8), we use anonymous class to express the lambda expression which is very verbose. But in language like C# we can express them in a short-format like ```x,y=>x+y```. or in Scala  we even express it as ```_ + _```. So good syntax model design can make express the same core model more easily. Obviously, the difficulty in implementing a new syntax model relies on the parsing logic of a language. This sometimes cause bottleneck when there are conflict grammar rules. So it's sometimes tricky to use some advanced lexer or parser technology like context predicate.

    
##### additional feature for industry level language.
From a prototype view, when we finished the core model and syntax model we are already finished a language. However, for an industry level language, there are more to consider. A good example is, we need to report meaningful error message to the developer when our source code contains errors. Another example is what so called "quick fix". When you use Eclipse, you can press "ctrl+1" to invoke quick fix on error code and select an option Eclipse provides you. To implement these advanced functions we also need to embed more things in our compiler design. Since these feature shall be similar between different language, we can abstract them out and "merge" with our prototype language model when need. There are already good tool on this kind of tasks like Xtext.

##### Some Other ideas
The above just talk about the big picture of a language design. When implement a language in real world there are also some detail considerations, I list some of them here [article](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/language_design_details.md).
 
In modern days, a language is always composed with a lot of features to support more broad use cases. This kind of language is what so called general language. However, it's sometimes inconvenient to improve them since we put all things together under a big grammar. I think the advent of Wyvern changed this landscape. I will discuss this in this [article](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/wyvern_thinkings.md)

### My advantages
Though I don't have a background for CS from school, I learned all required knowledge by reading and practicing myself. Comparing with students in school, I think I had more practical expereince from industry. Here is some of my advantages: 

* I have 2.5 years working experience of software development, during which, most tasks I faced is quite challenge. I list some them and their challenge [here](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/working_experience.md). 
* I'm fluent with quite a lot of programming language and technology. I had solid understanding on software architecture. I'm also good at solve complex real world issue(see my resume and recommendation letters).
* I know what kind of language features are more useful for a developer from industry,  so I can help design more practical language. 
* I'm also experienced on framework and system design. I'm not only creative in new feature design, but also experienced on how to make the compatible with existing context. [Here](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/objmap_design.md) is one of my design for a model to model transform framework written in javascript
* I already had some experience on complier related work. I've written css-selector like [function](https://github.com/qweasd1/Powershell-Repo/blob/master/Language/AST/PSAst/PSAstCore.ps1) to help work with Powershell AST more easily. I used it write several [plugins](https://github.com/qweasd1/Powershell-Repo) for powershell ISE. I've written a grammar mapping tool(like Antlr4 but with different implementation) called [hanbao](https://github.com/qweasd1/hanbao) which support left recursive grammar and AST rewrite in javascript. I'm also working on a performance optimizer for complex t-sql query in my recent work. I already finished the parsing part of the t-sql grammar.
* I'm a quick learner and can work well on independent tasks. I learned software development all by myself including not easy ones like parallel programming and complier technology.

### Why I wish to work with Professor Jonathan
As a software developer, I always dream to improve the the quality of software and the productivity of developer by using innovation way.  [Here](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/innovation_way_to_improve_software_quality.md) is some idea I've tried before. After reading Professor Jonathan's papers, I realized how powerful the language design and type system can help realize this dream. For example, in the paper of [Tagged object](http://www.cs.cmu.edu/~aldrich/papers/ecoop15-tags.pdf), the idea to treat class as the first citizen(like function as the first citizen in functional language) can really simplify the solution of some meta-programming problems. The permission model is also a powerful concept to let parallel programming more declarative than imperative. Though it's still a long way to put them into industry, I really hope I could do my help on those projects! For myself, I always have innovation ideas on language design and software architecture, but I know still need to learn more before I can make them out perfectly.

