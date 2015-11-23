My understand on language design and implementation.
In my view, language design consists of several differetn part:
- develop Underlying Model
- Language Syntax(share similar syntax between different language)
- Language Composition
- extensiveness of a language
- Assist Develop Tool(Antlr XText Reuse test)
- Single responsibility Principle(implement your goals)
- What kind of model is not suitable for a language to describe?
- Assistant tools(IDE support)
- 
- Context aware language(script language)
- Language Suit
- Who read your code?
- semi-structure code
- 

Before discussing anything about Language design, I want to first explain what language is. As I consider, **language is the tool used to express a specific domain model**. So actually language is just like a wrapper around your core domain model. But this wrapper is very important, a good designed language can let you write less but express more, or it can let you express your model more easily. 
> TODO: add martin fowler's saying on DSL

#### Model design(Express what?)
The real part who made a language essentially powerful

#### Syntax design(How to express)
But there are some essentially contradict in language design.
A language can't be both quick to write and easy to maintain. Though many language try to do this(like groovy, it makes itself as much possible as it can to compatible with Java and this dramatically increase the difficulty when implement the compiler. What's worse is when both java and groovy's syntax change ,groovy needs to react to the new change. This kind of issues remind me of the well-known principle: Single Responsibility Principle.) No matter what Kind of language you are designing, don't give it too much purpose. Have a clear goal in my mind and try to use the syntax design to achive your goal.
There are many tricks when design syntax, so I just list some I know here:

Syntax design is very pratical and useful, to let other people more easily to use your language, you must consider your syntax design! 


#### Language Composite
Some time you can't wrap all good feature in a single language, so a good choice might write different DSL and find a way to composite them together. A good sample might be Professor An...'s wyeaz language. There are also

#### Language View
Language view is different syntax of a same language model. for example one view is used for quick development, another view is more readable. So in this way, we can develop with quick mode and after that we directly get a readble version for free. We can even study the common thing when implement different view for the same lanugage model and develop some auto generation tool.




Though language is extremely powerful and complex, There are still some kind of model it is not suitable to express some kind of model: graph


#### Some none classical Langiage design
