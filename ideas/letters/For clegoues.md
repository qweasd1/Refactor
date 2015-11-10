### letter
Hi professor Claire Le Goues

Nice to meet you. I'm a developer currently working in industryand now I plan to apply for the ISR SE PHD program. Recently, I began to read your paper about auto-patch. I got some ideas after reading and hope you could kindly suggest if it is suitable to include those ideas as supplemental materials in my application. It's my first time to apply a PHD program with less experience so will really appreciate if you could give me some guide.

Here are my ideas:

#### Can we let our program "memorize" or "sumarize" its experience on debug and save them for reuse
If we can have a cache or reposioty for our debug process or experience, they might help save our time on auto-patch and made it more practical.


#### Can we combine design pattern with auot-patch? 
From my point of view, some specific bug might always occur along with some kind of design patterns. If we can know what's the pattern the program under bug is currently using, we might give our auto-patch program more hint to handle it by refer to the successful implemention of that design pattern. 

Also design pattern give us a better layer of abstraction comparing with AST,  we might have less option to try when we mutate our program to fix the bug, which result in less time consuming. 

Morever, I've read a book called <Elemental Design Patterns> last year and one thing impress me a lot from the book is that the author is trying to let program to find design patterns from a given repository. If it's ture, then we can first let the pattern-detect program analysis our with-bug-program and then found related successful implementation of that pattern. We can use the successful ones as guide to help our auto-patch-program to fix the bug.(It sounds like data-mining from codebase)


#### Can we skip the bug-fix but directly generate the implementation directly from the tests?
I thought we can also use this tech on auto-implementation, since the auto-patch and auto-implementation is very similar, except auto-patch has a with-bug-program to modified, but auto-implementation doesn't have such a start point. But in practical we can give it a start point and then we face the same question. If we can auto-generate some components to fullfill the tests, it's useful in practice. For example, we always need some mocks during development, and if we can generate those mock automatically from tests, it can really save us much time. Since mock is not complex, it might be a potential practical situation to use our technology.



So, that's my current ideas. If you think they are suitable to appear in the supplement materials, I will be happy to write them in more details.

BTW, I'm quite curious if there are any advanced auto-patch tools developed and used in industry? I'm really interested in real case and see their implementation.

One last thing, I haven't introduce myself a lot. I'm a developer currently work in ... I have 2 years working experience after I got my Bachelor from USTC. My major is statistic, but I found I like software development at the last year of my university. So I became a self learner, experience a startup project and finally become a developer of. I've develop several complex systems and I'm one of the major designer. I like to think innovation ideas and try to implement them in real world. 


