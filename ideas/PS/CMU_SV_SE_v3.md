## Statement of Purpose

### About Me
  My name is Wang Zhendong. I'm a 24 year old Chinese boy who loves software development. I used to be a statistic student and got my bachelor degree from University of Science and Technology of China. But in 2012's summer, my interest on software development was fired when I developed my first software during my internship in BASF logistic department. Since I had very limit knowledge about software development at that time, I tried my best to absorb those knowledge during my last year at school. After I graduated in 2013, I joined a challenge startup program holded by my friend and work on it for 1 year. I learned a lot from this project and after it, I applied to Citigroup, the famous investment bank. Finally, I passed their competitive 10%-passed interview and work as a senior developer until now. 

### My work experience(2.5 years)
2.5 year is not a long time for a software developer, but I think it made me mature in software development. 

##### My first project
I started my career with a startup project, in which, we developed a powerful diagnostic tool for digital chip. The tool is quite complex. Just list some challenge things we met.
 
* We need to design a high performance data processing architecture sicne our tool collects signals from digital chip in a high frequency. Sophisticated parallel and synchronous logic is needed here.
* We need to design a dashboard and chart system with high refresh rate to let user visualize variable status in a running digital chip. The chart is even more complex since it has some complex interaction logic like drag and drop.  
* We need to generte dynamical GUI according to the user's runtime configuration. A typical case is that user can select the variables they want to watch and our tool just show them a chart with those variables' curves in the same plot.

As you can see, this is not an easy task. However, I think I always love challenges and the tough data processing issue just inspired my interest on parallel programming. I soon began my study on parallel programming myself. It's hard at beginning, but I had better and clear understanding after more and more practice. In this progress, I learned how to tuning the performance by using fine-grained lock and lock-free algorithm, learned how to use breakpoint trick to debug under multi-thread environment. To let my work mates also leverage my data processing algorithm, I learned how to encapsulate multi-thread logic into resusable thread-safe class. My interest on parallel programming finally leads me to a perfect data processing module. Everything goes well and finally I got a very positive feedback from my client. 

Though the project is successful,  I also met many design issue during it. For example, some of the classes I designed are big and complex. They were both hard to comphrehend and tough to test. Another common issue is my design is quite fragile to user's requirement changes. I need to change large portion of code to fullfill a small requirement change but I think there should be better way. To learn how to develop better, I began to read wide range of books such as OO design, Design Patterns, Enterprise Application Development, Test Driven Development, Refactor and Domain Driven Development. The constant learning and practicing last for half an year and help me setup up a solid understanding on enterprise level software development. With the help of this I finally got the chance to enter my dream company, Citigroup at 2014.


##### Days in Citigroup
The days in Citi is very exciting. It's my first time to see those giant systems and how difficult to build and maintain them. This inspired me to think the constant question: why software is so complex and how to decrease this complexity. After work and practice with those complex sysytem for 1.5 years, I gradually realized the core of software development is to decompose the problem you face into suitable pieces and try to enhance them individually.

I applied this logic in one of my data integeration framework. Before I developed on this framework, our programmers  tends to write specific program to do data integeration. Usually the code mixed up with the logic of data parsing, the logic of data-checking and the logic for parallel processing which caused it both hard to understood and maintained. For my solution, I first decomposed the data integration problem into several domains like parsing, parallel processing, data-checking. Then I used some advanced technology like meta-programming to enhance each domains to make it easy to use. For example, in parallel processing, I build a runtime engine to parallel the execution of data integeration automatically(user don't need to configure them). For parsing, I extract meta information from source data and let meta-program analysis them and generate the execution plan for the data integeration. I also build a GUI to let user input some necessary information for the parsing logic. The final result is, user can express their parsing logic in a code-free way. This reduced the development time dramatically. The framework got greate success and I won an Award in 2015 Citi's Innovation Competition for it. 

I tried many projects in this way when I working in Citi and I found I'm more and more fluent to solve complex problems! 

### Why I apply for this program
The knowledge and experience I learned in the past few years brought me to the exciting world of Software Engineering, but I still feel there are some essential areas I'm not familiar for enterprise level development, such as security and deployment. I really hope I could learn more broadly and deeply on Software Engineering. With great experience from industry, I thought it's really a good time to go back to school to learn I want. CMU SV is famous for its CS and it provides both the interesting courses and practical projects which just fit my needs. It's also near the Silicon Valley, so I had more chance to see my desire projects! That's why I decided to apply for this exciting program. I really hope I could have the honor to join it.


