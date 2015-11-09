Dear Professors from Institute for Software Research, 
nice to meet you.My names is Tony wang. I'm from China and is now working as a programmer for Citigroup Services and Technology(China) Limited. (CSTC)
In this essay, I want to show my thoughts on Software Engineering.


What is Software Engineering?
First thing first, I want to show my own understanding of what software engineering is. In mind, software engineering is the standard, method, tools, principals that help people build software more better. But I'm not quite satisfied with the definition of Software Engineering since it's too broad and can't be measured. In my point of view, good things can be measure. So first we need divide developer.

To make clear the issue you want to solve.
First thing first, I think find a good issue for yourself is very important. During my work experience, I learned from many project and heard many ideas from different people.


On demand design:
Usually, we are not build a whole solution to solve all the issue. That will be extremely difficult. But we can think in another way. We best leverage our current environment and constraint and build for an easy understand framework.

Some important tech we need for SE
Understanding of Language. Language analysis is quite important for static analysis, refactor. Sometimes you need write your own language as well.




Software Engineering is efficient ways to controll the software complexity.

Complex situation.

Development tools: to make complex things not complex, to make time consuming things not time consuming, to reduce the duplicate things, to make migration transparent and easy.


The inner desgin.




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


