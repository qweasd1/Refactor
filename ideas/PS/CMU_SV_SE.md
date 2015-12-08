### Statement of Purpose
Hi everyone, I'm Wang zhendong, a chinese boy loves software development. Not like many students with high GPA, GRE and TOFEL scores, I actually got a low GPA at school and plain GRE and TOFEL scores. Even worse, I don't have a background from CS and know quite a few things about programming when I graduate from school. But I know I love software development, so I took the risk to join a challenge startup program after I graduated from school with nearly no salary. Then one year later, I applied to Citigroup and passed the very competive interview(usually only 10% pass) and became a senior developer. I perfrom well in my daily work and I even won an award in this year's Citi innvovation competition with my data integeration framework out of 110 projects.  



### First Internship light my path to programming
I still remember the fist time I became curious about software. It's 3.5 years ago, when I work as a summer intern in BASF's logistic department. As I worked with my colleagues, I found they needed to genreate several complex Excel reports each month. The business logic is non-trivial, so they had to manually do it and huge time was spent. Once I noticed this, an idea appeared in my mind: do we have a method to automate the generation? I felt it's an interesting question so I started to search on the Internet and finally found a programming language called VBA which can automate every jobs in Excel! Though I knew nothing about it I began to have a try and to my surprise I really made it out in 3 weeks. The time consuming report can now generate in a few seconds! It's my first time to feel that software can be such helpful to help people work better. So when I went back to school after internship, I spent nearly all my time on learning programming and soon I met my first industry level project.

### First industry level project brought me to the world of software engineering
After I graduate from university, I joined a small startup program where I developed my first industry level project. It was a 100 man-months project but my boss asked me and my 2 mates to finished it in 3 months.(Of course no one told us it's a 100 man-months project until I finished it!). The whole project is very complex, which is full of multi-thread logic and dynamically generated GUI. Since client required configurable real time dashboard and interactive plot, we also had to write complex layout algorithm. My 2 mates soon quit this task and I was left to face it myself. Ladies and Gentle, a super full stack developer just borned: I had to design the architecture, wrote the code, did the test and even communicated with our client. Though it's really challenge, I thought I was lucky to touch the whole life cycle of software development. To work out program in this challenge project, I began to read a lot of books. I learned the concepts like refactor from Martin Flower's book, learned TDD from Kent's book, learn agile programming and clean code from Uncle Bob, learn the art of unit test from RoyOsherove. To improve my design, I began to learn design patterns, Enterprise Application Architecture and Domain Driven Development. To be funny, I thought I experienced all the woyrst case those authors mentioned in their books! For instance there is one time, I had to refactor 1000+ multi-thread code without any unit test in 3 days. It's at that time, I knew that unit test is really really important. Beside those mentioned above, I also read books about Aspect Oriented Programming, Functional Programming and Meta-programming.

Finally I finished the project after 9 month's hard work. The whole process let me realize that writing software is really complex but the books I read also brought me to the world of software enginerring and show me that there are some good techonology and methodology there to help us solve that kind of complexity. To learn those techonology and methodolgy better, I decided to go to an advanced company Citigroup.



____________________________

My first project is quite challenge. 
I think I was lucky with a non-CS background when I worked on my first project since I never knew how difficult the things I faced, which also means I had no fear on them. The whole project is full of complex business logic, sophiscated algorithm and high performance demand. For instances, we need to develop configurable GUI(which means it was generated dynamically according to user's configuration), We need to use complex parallel logic to ganruantee the performance and We also need to develop some plot system with unique interactive logic. I knew nothing about those areas(even don't hear term like 'parallel programming' at that time) but I'm not overwhelmed. After sevral searching and comparing I choose to use WPF for the challenge GUI. WPF is a fairly new GUI framework on .Net platform, which promising extremely flexible but has a steep learning curve. I still remember I read that 1000+ page book -- [Pro WPF](http://www.amazon.com/Pro-WPF-2010-Presentation-Foundation/dp/1430272058/ref=sr_1_3?ie=UTF8&qid=1449541096&sr=8-3&keywords=pro+WPF) time and time again and finally conquered it. I also learn some knowledge on functional programming since it can help me write better and short code.(to be more concrete, I mean Linq, an functional programming feature embedded in C# here). Every thing went quite well until I faced the multi-thread logic. I have to recognize, it's quite tricky, complex and might be the most challenge part  for me in the whole project. I spent about half a month to got its concept and tried a lof samples myself. But After I applied them into my code, I felt I still got something wrong. The code was full of lock and I need to be very careful when I change them. I guessed there must be better way to improve the code . After searching and reading, I realized that I should try to encapsulate the multi-thread logic inside thread-safe class. But soon another issue raised out that the lock I used actually hinder our performance seriously. Again, I searched and found there are lower level API exposed by .Net to let us do Kernel mode instructions and gain better performance. Finally I faced the most horrible situation, testing my application. I was shocked by the complexity when testing  a complex multi-thread programming. Sometimes I need to walk a long way and use tricks on breakpoint to get to the error-like code. I had to say I can't come up with some immediate solution to improve my design. It's my first time I realized software can be such complex and I started to think if we have method to controller such complex. 

To find the answer, I began to read any books I could find about software development. I learned the OO design from Grady Booch's [Object-Oriented Analysis and Design with Applications](http://www.amazon.com/Object-Oriented-Analysis-Design-Applications-3rd/dp/020189551X/ref=sr_1_3?ie=UTF8&qid=1449544953&sr=8-3&keywords=object+oriented+design). I learned Design Pattern from Gang of Four, learned Agile programming and clean code from Uncle Bob's book. I also read books about TDD, DDD, CI, Enterprise Application Architecture, Dependecy Inject, AOP and wide range of popular framework. For many books I read many times, but still not understand clearly. I deadly felt I need a **environment** to  apply and validate what  I've read and thought.  




* Learn Linq functional programming
* Learn to use 3rd-part control
* Learn multi-thread
* Learn the various concepts for software engineering
* Work independently



### 
* Pass the interview
* Used to think use advanced techonology is more important. Begin to think how to control the complexity of software. 
* Unit test
* How to handle the practical issue we met.
* How to design complex but maintainable system.
* Meta programming
* I still need to study
___________

I still remember my first software I wrote when I work as an intern in BASF 3.5 yeears ago. It's 2 VBA program which grab information from several Excel reports and then generate a summary report  automatically. The whole process is just like an infant began to learn how to walk since at that time, I had poor knowledege and expererience on programming. Even worse, no body in my department knew how to use VBA and I had to finish it myself. Just like baby learning walking, I tripped and fell again and again, but the desire to see a workable program help me stand up again and agian. Finally, after 3 weeks, I finished the program. I still remember my colleague was so happy when I show them the final program since in the past, it took them a whole day to manually finished the summary report. The internship just ended when I finished the program but my long journey of software development just started.

After the internship, I spent my last year in university learning the basic knowledge about programming myself. After graduation, I joined a small startup company and finished a unforgotten program. The software we need to develop is an assistant tool for chip testing which needs to have dynamically GUI, good performance  and advanced chart. The program is full of complex multi-thread logic and we were given 3 months to finished it. I was assigned to finish part of independently. To overcome it I know I need more knowledge and that's the first time, I start to learn OO design, design pattern and Enterprise Application Architecture, Unit test. I also start to learn multi-thread programming and try to design lock-free algorithm and thread-safe class. Though the project postpone for a long time, I finally finished. My first industry level project finally help me realized that to develop a complex software, I still need a long way to go. So I planned to go to a big company and Citi is my choice! 

I only did one project there, but it's really a non-trivial project. In this project, we need to develop a software which collect and analysis raw data from chips. The user requires high performance, configurable GUI and advanced dashboard and chart. Even worse, the user hope we can finished it in 3 months. My product manager estimate actually we need 100 man-months but we only had 3 developer at that time.  

The days in Citi starts with challenge. Just after the tough interview I was assigned to a brand new area I had never touch: data warehouse design. So things happened again, I began learning my  


### Why I choose CMU SV SE program.


As I wrote this letter, I had 2.5 years software development experience. Though it looks not so long, I had already became the core developer in several critical program in Citi.  In this year, I became one of the main designer and developer for Citi Credit's new data warehouse, during which I developed several high performance and easy to use ETL framework. I also won an award in CSCT Innovation competetion this year for my data integration framework. (my total score rank #14 of 110 projects and I got the 3rd highest technology score of the 110 projects). Though I got a little success now, I still remember the dream I had since I began programming: I want to make the software development easier. It's for this dream that I finally decided to quit my good career in Citi and apply for CMU SV SE program. CMU is famous for its CS and SV is famous for its practical spirit. This might be the best place to continue my study on software engineering. I hope I can learn more here and I can realize my dream one day.



### Materials
Though by now I already won a little fame in my department for my techonical skills, I never forget my dream: I hope one day, I can make software development much easier than what we do today by developing advanced tools and methodology so even non-tech people can build the software they need and fullfill their good willings. 




