### letter
Hi professor Claire Le Goues

Nice to meet you. I'm a developer currently working in industry and now I plan to apply for the ISR SE PHD program. Recently, I began to read your paper about auto-patch. I got some ideas after reading and I don't know  if it is suitable to include them as supplemental materials in my application. It's my first time to apply a PHD program with less experience so will really appreciate if you could give me some guide and advice. Thanks

Here are some of my ideas on auto-patch:



#### Can we combine design pattern with auot-patch? 
From my point of view, some specific bug might always occur along with some kind of design patterns. If we know what's the pattern the with-bug-program using, we might give our auto-patch program more hints to handle it by refer to the successful implemention of that design pattern. 

Also design pattern give us a better layer of abstraction comparing with AST,  we might have less options to try when we mutate our with-bug-program to fix it, which result in less time consuming. 

Morever, I've read a book called <Elemental Design Patterns> last year and one thing impress me a lot from the book is that the author is trying to let program to find design patterns from a given repository. If it's ture, then we can first let the pattern-detect program analysis our with-bug-program and then found related successful implementation of that pattern from a given repository. Then we can use the successful ones as guide to help our auto-patch-program to fix the bug.(It sounds like data-mining from codebase). The whole process now becomes automatically.


#### Can we let our program "memorize" or "sumarize" its experience on fix bug and save them for reuse
If we can have a cache or repository for our debug process or experience, they might help save our time on auto-patch since the auto-patch-program can leverage these information. Also, we can directly study on the cache data themselves to see can we find some pattern. By now I had few ideas on how to implement this, since I'm new to this area but I think I can get a good plan after learning more.


#### Can we skip the bug-fix but generate the implementation directly from the tests?
I thought we can also use this tech on auto-implementation, since the auto-patch and auto-implementation is very similar. They both generate a workable result from expected tests except auto-patch has an initial with-bug-program to modified, but auto-implementation doesn't have such an initial point. But in practical we can give it a start point(maybe an implementation from another repository) and then we face the same question. If we can auto-generate some components to fullfill all the expected tests, it's useful in practice. For example, we always need some mocks during development, and if we can generate those mock automatically from tests, it can really save us much time. Since mock is less complex than a real components, it might be a potential suitable situation to use auto-implementation.

#### Can we change the way we output?
By now, we might choose to output the first solution which pass all expected tests. However, sometimes there are several differernt workable solutions and the end user -- our developer might what to choose one from them to better fullfill their needs. Then our model can change to :
  input = tests
  output = some available solutions
But still there can be an improvement. The user can give more constraints or filter condition. And we return the best solution not only pass all tests but also fullfill all the constraints:
  input = tests + constraints
  output = the best solution
I thought maybe this model is more pracical thought it might much harder to implement.


So, that's my current ideas. I thought maybe they might be answered in your paper, but since I don't have much time to read them all, I list them here. If you think they are suitable to appear in the supplement materials, I will be happy to write them in more details.

BTW, I'm quite curious if there are any advanced auto-patch tools developed and used in industry? I'm really interested in real case and want to see their implementation.

One last thing, I haven't introduce myself a lot. My name is Tony Wang and I'm from China. I'm a developer currently work in ...  and have 2 years working experience after I got my Bachelor from USTC. My major is statistic, but I found I like software development at the last year of my university. So I became a self learner, experience a startup project and finally become a developer of.During the 2 years I've develop several complex systems with the challenge like multi-threading, complex and dynamical UI, mass heterogeneous data integration. I can't say I handle them perfectly but I learned a lot from them. I like to think innovation ideas and try to implement them in real world. The main reason for me to apply ISR SE PHD program is that I felt I still want to learn some more advanced topic and theory about software engineering, language design ,architecture etc and I really want to see the most advanced research. CMU's ISR is a good choice for this. Also there is a small reason that I got married this year and my wife is now reading a Master in the University of Pittsburg. I hope we can live together from next year. That's me. If you want to know more, I will prepare them well in my PS. Hope I could get a chance to join the big family of ISR!

Thanks
Tony Wang
