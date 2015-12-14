## Statement of Purpose

### About Me
  My name is Wang Zhendong. I'm a 24 year old Chinese boy who loves software development. I used to be a statistic student and got my bachelor degree from University of Science and Technology of China. But in 2012's summer, my interest on software development was fired when I developed my first software during my internship in BASF logistic department. Since I had very limit knowledge about software development at that time, I tried my best to absorb those knowledge during my last year at school. After I graduated in 2013, I joined a challenge startup program holded by my friend and work on it for 1 year. I learned a lot from this project and after it, I applied to Citigroup, the famous investment bank. Finally, I passed their competitive 10%-passed interview and work as a senior developer until now. 

### My 2.5 year work experience
2.5 year is not a long time for a software developer, but I think, I gained a lot during it. 

##### My first project
My first project is a startup project, in which, we need to develop a powerful diagnostic tool for digital chip. The tool is quite complex. Just list some challenge things I met.
 
* We need to design a high performance data processing architecture sicne our tool collects signals from digital chip in a high frequency. Sophisticated parallel and synchronous logic is needed.
* We need to design a dashboard and chart system with high refresh rate to let user visualize variable status in a running digital chip. The chart is even more complex since it has additional complex interaction logic.  
* We need to build dynamical GUI according to the user's runtime configuration. A typical case is that user can select the variables they want to watch and our tool just popup a chart with those variables' curves in the same plot.

As you can see, this is not an easy task. However, I think I always love challenges and the tough data processing issue inspired my interest on parallel programming. I soon began my study on parallel programming myself. It's hard at beginning, but I had better and clear understanding after more and more practice. It's very interesting to tuning the performance by using fine-grained lock or lock-free algorithm. The debug for unknown errors under multi-thread environment is also a tricky but attractive activity. To let my work mates also leverage my data processing algorithm, I learned how to encapsulate multi-thread logic in resusable thread-safe class. My interest on parallel programming finally leads me to a perfect data processing module. Everything goes well and finally I got a very positive feedback from my client. 

Though the project is successful,  I also met many design issue during it. For example, some of the classes I designed are big and complex. They were both hard to comphrehend and tough to test. Another common issue is my design is quite fragile to user's requirement changes. I need to change large portion of code  to fullfill a small requirement change but I think there should be better way. To learn how to develop better, I began to read wide range of books such as OO design, Design Patterns, Enterprise Application Development, Test Driven Development, Refactor and Domain Driven Development. The constant learning and practicing last for half an year and help me setup up a solid understanding on enterprise level software development. With the help of this I finally got the chance to enter my dream company, Citigroup at 2014.


##### Days in Citigroup
The days in Citi is very exciting. It's my first time to see those giant system and how difficult to build and maintain them. This inspired me to think the constant question: why software is so complex and how to decrease this complexity. After work and practice with those complex sysytem for 1.5 years, I gradually realized the core of software development is to decompose the problem you are facing into suitable pieces and try to enhance those pieces individually.

I applied this logic in a data integeration framework I developed recently. In traditional, the data integeration program tends to mixed up the logic of data parsing, the logic of data-checking and the logic for parallel processing. These programs are usually hard to understood and maintained. When working on such kind of project, I decided to try another way. I first decomposed the data integration problem into several domains like parsing, parallel processing, data-checking. Then I used some advanced technology like meta-programming to enhance each domains to make it easy to use. For example, in parallel processing, I build a runtime engine to parallel the execution of data integeration automatically. For parsing, I extract meta information from source data and let meta-program analysis them and generate the execution plan for the data integeration. I also build a GUI to let user input some necessary information for the parsing logic. The final result is, user can express their logic in a code-free way now. The framework got greate success since it simplified the data integration problem and I won an Award in Citi's Innovation Competition for it. 

I tried many projects in this way when I working in Citi and I found I'm more and more fluent to solve complex problems! 

### Why I apply for this program
The broad knowledge I learned in the past few years brought me to the exciting world of Software Engineering. I really hope I could learn more broadly and deeply on this area. With great experience from industry, I thought it's really a good time to go back to school to learn more. CMU SV is famous for its CS and it provides both the interesting courses and practical projects which just fit my needs. That's why I decided to apply for this exciting program. I really hope I could have the honor to join this program.


