## Statement of Purpose

### About me
My name is Wang Zhendong. I'm a 24 year old Chinese boy who loves software development. I used to be a statistic student and got my bachelor degree from University of Science and Technology of China. But in 2012's summer, my interest on software development was fired when I developed my first software during my internship in BASF logistic department. Since I had very limit knowledge about software development at that time, I tried my best to absorb those knowledge during my last year at school. After I graduated in 2013, I joined a challenge startup program holded by my friend and work on it for 1 year. I learned a lot from this project and after it, I applied to Citigroup, the famous investment bank. Finally, I passed their competitive 10%-passed interview and work as a senior developer until now.



### My understanding on language Design

##### The Goals of a language
I think the goals of a language are at the core of every language's design. The goal of C is to let developer use high level model to describe the program. One of the goals of Java is to do memory management auotmatically. In AEminium, the goal is to automate the execution of program in parallel. Usually the goals of a language are conceptual not the concrete implementation.

##### Core model

The core model is the implementation model we used to realize our goals of a language. For instance, the ```GC``` class and its underlying structure is the core model to implement the automatic memory management in Java. For good language, the core model must be designed carefully to fullfill its goal. For example, In AEminium, its core model is to parallel those code with no data dependency at compile time. It looks good, but when applying in real world, there some issue. I discussed it in this [article](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/a_small_enhancement_on_AEminium.md) along with my fix method. It's always a good idea to compare our goal and our model to see if it really fits our needs.


##### syntax model
Though core model is already workable, we want to have a more easier way to express them it. As I think, Syntax model is usually more easier to design than core domain model since it's just a thin layer beyond core model For example, lambda expression is a common core model across many different language, but different language support them in different syntax degree. In Java(before Java 8), we use anonymous class to express the lambda expression which is very verbose. But in language like C# we can express them in a short-format like ```x,y=>x+y```. or in Scala  we even express it as ```_ + _```. So good syntax model design can make express the same core model more easily. Obviously, the difficulty in implementing a new syntax model relies on the parsing logic of a language. This sometimes cause bottleneck when there are conflict grammar rules. So it's sometimes tricky to use some advanced lexer or parser technology like context predicate.

    
##### additional feature for industry level language.
From a prototype view, when we finished the core model and syntax model we are already finished a language. However, for an industry level language, there are more to consider. A good example is, we need to report meaningful error message to the developer when our source code contains errors. Another example is what so called "quick fix". When you use Eclipse, you can press "ctrl+1" to invoke quick fix on error code and select an option Eclipse provides you. To implement these advanced functions we also need to embed more things in our compiler design. Since these feature shall be similar between different language, we can abstract them out and "merge" with our prototype language model when need. There are already good tool on this kind of tasks like Xtext.


The above just talk about the big picture of a language design. When implement in real world there are also some detail considerations, I list some of them in this [article](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/language_design_details.md).
 
In modern days, a language always composed with a lot of features to support more broad use cases. This kind of language is what so called general language. However, it's sometimes inconvenient to improve them since we put all things together under a big grammar. I think the advent of Wyvern changed this landscape. I will discuss this in this [article](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/wyvern_thinkings.md)

### My advantages
Though I don't have a background from CS from school and I learned all the knowledge by reading and practicing myself, I think I had deep understanding on software engineering. 

* I have 2.5 years working experience of software development, during which, most tasks I faced is quite challenge. I list some them and their challenge [here](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/working_experience.md). 
* I'm fluent with quite a lot of programming language and technology. I'm also good at solve complex real world issue(see my resume and recommendation letters)
* I'm also experience on framework and system design. [Here]() is one of my design for a model to model transform framework written in javascript
* I already had some experience on complier related work. I've written css-selector like [function](https://github.com/qweasd1/Powershell-Repo/blob/master/Language/AST/PSAst/PSAstCore.ps1) to help work with Powershell AST more easily. I used it write several [plugins](https://github.com/qweasd1/Powershell-Repo) for powershell ISE. I've written a grammar mapping tool(like Antlr4 but with different implementation) called [hanbao](https://github.com/qweasd1/hanbao) which support left recursive grammar and AST rewrite in javascript. I'm also working on a performance optimizer for complex sql query in my recent work. I already finished the parsing part of the t-sql grammar.

### Why I wish to work with Professor Jonathan
As I discuss in my understanding on language design, there are 2 main design of a language: core model design and syntax desing. For myslef, I like to invent 
