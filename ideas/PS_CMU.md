Hi Professors from Institute for Software Research, nice to meet you.My names is Tony wang. I'm from China and is now working as a programmer for Citigroup Services and Technology(China) Limited. (CSTC) 
I've worked for 2 years after graduate. Though I didn't learn much CS class from school, I learned a lot myself during work. 
I really like computer science, especially for reusable module design,architecture, testing,design partterns, software development tools, language design and some other.
I will share my ideas on those areas in details in the following sections along with my working experience:
### software engineering
software engineering is a big topic. It includes architecture, test, continuous integration, one-click deployment... just to name 
a few. But at its heart, software engineering is quite simple: to build better software in better way. In the following sections, I
will try to share my own thought on some specific fields of software engineering and some ideas I thought could be useful.


### architecture
architecture is a long discuss topic during the past few decades. From the classic 3-layer architecture to the newer commer Onion
architecture, people wrote many books about the structure of differnt architectures. But few books explain where shall we start
from scratch. From a practical view, if we implement a specific architecture from scratch, it might be heavy weight! We need to
implement much more code than we expected and this will consume us a lot of time. It can also be hard to 


For architecture, there are many good books like Martin Fowler's <Patterns of Enterprise Application Architecture> to explain.
So, I don't want to repeat them again since we might be quite familiar with. What I want to show here is some thing I found 
during my daily work.

##### when you start to implement an architecture
Architecture are sometimes heavywieght and usually add overload for test when the project start. A good example is  

##### architecture transformation(from draft to mature)
software are always facing changes. Sometimes, the best way to fit the new change is to change the existing architecture. This
can be nightmare sometimes. But can we build a tool to help us automate this progress.

##### shared structure architecture
Architecture for different system looks similar many times. Moreover, sometimes we can even let very different system share
similar architecture by using some design strategy. Then why we need to make different system looks similar. Well, the benefit
is very big. From my observation. When systems become very very complex, even with goood document, good unit test, it takes much
more time to fully understand them and maintain. But if we implement the system in a familiar way as another system, people will
soon get ready to the new system. They just need to take care about what's diffeernt betweeen the 2 systems. Also, it's better
to let code analysis and auto-refactory program. ()

in citi

##### extend your framework


##### how to make your inovation idea easy to understand.


##### Error handling, monitor, error handling
When we build system. error handling is very very important, especially for batch system. During my work, system
with poor designed error handling mechanism
