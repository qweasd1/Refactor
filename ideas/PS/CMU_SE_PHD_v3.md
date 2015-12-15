## Statement of Purpose

### About me
My name is Wang Zhendong. I'm a 24 year old Chinese boy who loves software development. I used to be a statistic student and got my bachelor degree from University of Science and Technology of China. But in 2012's summer, my interest on software development was fired when I developed my first software during my internship in BASF logistic department. Since I had very limit knowledge about software development at that time, I tried my best to absorb those knowledge during my last year at school. After I graduated in 2013, I joined a challenge startup program holded by my friend and work on it for 1 year. I learned a lot from this project and after it, I applied to Citigroup, the famous investment bank. Finally, I passed their competitive 10%-passed interview and work as a senior developer until now.

To be straight, my dream mentor is **Jonathan Aldrich** and my dream projects are **Plaid** and **Wyvern**. Since Professor Jonathan works on language related project, I want to first show my understanding on Language Design.

### My understanding on Language Design

##### The Goals of a language
I think the goals of a language are the core of every language's design. They describe what problems a language want to solve. Here are several examples. For the C language , its goal is to let developer use high level model to describe program which used to be described in Assembly language. For Java, one of its goals is to free developer from memory management. For AEminium, the goal is to let developer use a more simple and declarative way to write parallel programming.

When we develop a new language in real world, our fancy ideas are usually inspired by a specific language syntax or feature. However, it's very important to consider the goals of the new language. If the goal of the language is fullfilled by other language or it has limit usage, or it's quite vague it might be less worthy for you to develop it. 

##### Core Model

The core model is the implementation model we invent to realize our goals of a language. For instance, the Garbage Collection algorithm is the core model to realize the automatic memory management in Java. The Permission system and parallel algorithm is the core model for AEminium to realize its Concurrent-by-Default Programming. 

The design of core model is quite strcit and there are some issue usually happened during this phase. One of them is when we design core model, we usually focus our attention on our interest aspect but miss some aspects which is necessary for its real world using. I found one of this case in AEnimium and I discussed it in this [article](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/a_small_enhancement_on_AEminium.md) along with my improvement. 

So, It's always a good idea to validate if a core model fits not only our goals but is also compatible with other real world need. 


##### Syntax Model
Though core model is already a workable model, we still need a easy and intuitive way to express them. That's why we need to design the syntax model. Usually a well designed syntax model can help developer write more concise and clear code. For example, lambda expression is a common core model across many different language, but different language support them in different syntax model. In Java(before Java 8), we use anonymous class to express the lambda expression which is very verbose. But in language like C# we can express them in a short-format like ```x,y=>x+y```. or in Scala  we even express the same lambda as ```_ + _```. As you see, good syntax model can make express the same core model more easily. 

When implement a concrete syntax model, the main job we do is to tuning the grammar of the language to compatible with the new syntax model. As I think, Syntax model is usually more easier to design than core domain model since the front-end technology of compiler existing for a long time. We can leverage previous experience and trick. However, the difficulty still exist when we want to improve our syntax model in an existing language. This usually caused grammar conflict and sometimes we need to rewrite large amount of grammar to fix it. The AST structure also changed which more or less affect the backend logic. I will discuss this later in Language evolution section.
    
##### Additional features for industry level language.
From a prototype view, when we finished the core model and syntax model we are already finished a language. However, for an industry level language, there are more to consider. A good example is, we need to report meaningful error message to the developers when their source code contains errors. Another example is what so called "quick fix". When you use Eclipse, you can press "ctrl+1" to invoke quick fix on error code and select an option Eclipse provides you to fix it. To implement these advanced functions we also need to embed more things in our compiler design. Since these feature shall be similar between different language, we can abstract them out and "merge" with our prototype language model when need. There are already good tool on these tasks and [Xtext](https://eclipse.org/Xtext/) is just one of them. 

Though these features are not necessary for the design of a language, if we provide them, our language can be more easily to pick by industry developer. So it's deserved to investigate on this topic. Actually, the underlying model is quite complex.   

##### Language evolution 
We have discussed the necessary features of a language on above. In this section, I want to talk about the evolution of a general language. 

As we all know, language evolved to provide new feature to benefit developer. However, as we mentioned in Syntax Model, this sometimes caused grammar conflict with existing language grammar if we try to add new syntax model. To avoid this, a cheap and convenient way  is to reuse the existing syntax model and add new logic in compiler. The annotation in Java is such a good example. By putting them on class or method, they provide more information for complier to implement additional operation. It's a powerful pattern, but sometimes, we need more flexible syntax and the fianl result is we need to change our complex grammar! 

As I think, the resaon for such brttlte phenomenone, is we put all things in one grammar and they are coupled with each other tightly. We can't make sure when we change part it other parts won't be affected. I guess, this might be a common issue among all general language. It will definitely slow down the development speed of a language and it also increase the burden of test. But I think with the advent of Wyvern, this issue can be easy to solve! see this [article](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/wyvern_thinkings.md) about my ideas on wyvern. It also contains other opinions I had on Wyvern.


##### Language design in real world
The above just talk about the big picture of a language design. When implement a language in real world there are also some detail considerations, I list some of them in this [article](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/language_design_details.md).
 
##### Other topics 
There are still many topics about language design I'm interested in. But I don't have enough time to write them all here before deadline. I will update them [here](https://github.com/qweasd1/CMU_SE_PHD/tree/master/supplement).


### My advantages
Though I don't have a background for CS from school, I learned all required knowledge by reading and practicing myself. Comparing with students in school, I think I had more practical expereince from industry. Here is some of my advantages: 

* I have 2.5 years working experience of software development. I've worked on many different types of projects like GUI, Web Sercive, ETL, Datawahouse etc. most tasks I faced is quite challenge. I list the details for them [here](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/working_experience.md). 
* I'm fluent with quite a lot of programming language and technology. I had solid understanding on software architecture. I'm also good at solve complex real world issue(you can see them in my resume and recommendation letters).
* I'm also experienced on framework and system design. I'm not only creative in new feature design, but also experienced on how to make them compatible with existing system. [Here](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/objmap_design.md) is one of my design for a model to model transform framework written in javascript
* I'm familiar with concept from academy. I feel comfortable when I read Professor Jonathan's paper. 
* I already had some experience on complier related work. I've written css-selector like [ultility function](https://github.com/qweasd1/Powershell-Repo/blob/master/Language/AST/PSAst/PSAstCore.ps1) to help grap Powershell AST more easily. I used it to write several [plugins](https://github.com/qweasd1/Powershell-Repo) for powershell ISE. I've written a grammar mapping tool(like Antlr4 but with different implementation) called [hanbao](https://github.com/qweasd1/hanbao) which support left recursive grammar and AST rewrite in javascript. I'm also working on a performance optimizer for complex t-sql query in my recent work. I already finished the parsing part of the t-sql grammar. See my design [here](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/sql_optimizer.md)
* I'm a quick learner and can work well on independent tasks. I learned software development all by myself including not easy ones like parallel programming and complier technology. I'm also quite creative on writing assitant tool to help me do my research more easily. 

### Why I wish to work with Professor Jonathan
As a software developer, I always dream to improve the the quality of software and the productivity of developer by using innovation ways. I hope I could write intelligent framework to let developer express only the necessary information and let the framework do the rest. I used to use Meta Programming, Code Generation and Model Driven Development to design framework for this purpose.  [Here](https://github.com/qweasd1/CMU_SE_PHD/blob/master/supplement/innovation_way_to_improve_software_quality.md) is some idea I've tried before. However, after reading Professor Jonathan's papers, I realized how powerful the language design and type system can help design the framework I want. For example, in the paper of [Tagged object](http://www.cs.cmu.edu/~aldrich/papers/ecoop15-tags.pdf), the idea to treat class as the first citizen(like function as the first citizen in functional language) can really simplify the solution of some meta-programming problems. The permission model is also a powerful concept to let parallel programming more declarative than imperative. Professor Jonathan's novel ways to enhance software design on source code level provides me a new view of software development.

Another reason is I really like Wyvern Language. See this [article](https://github.com/qweasd1/CMU_SE_PHD/edit/master/supplement/wyvern_thinkings.md) about my ideas on Wyvern.

### Future Plan
##### A short one(next year)
* I hope I could consolidate my understanding on compiler technology especially for its practical use in real world.  
* I hope I could work on Plaid project and Wyvern project as soon as possible. I will prepare well my development environment, make sure I understood the detail design of the language and what my colleagues are doing quickly. I hope I could touch and understand every aspects of them after 1 year.
* I hope I could learn more on Eclipse Plugin Development. By learning it, I can write language plugin and other assisstant tool in the future.

##### A long one
* I hope I could develop framework to help language development and prototype more easily and quickly in the future. 
* I hope I could work on projects from more different background. Pratical issue in complex projects are always the best stimulus for new design and model.
* I hope I could learn more on Meta Programming and Model Driven Development. I hope I could work on related projects to enhance my understanding on these 2 areas.


Finally, I really hope I could success in this application. Thanks for reading this essay!
