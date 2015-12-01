### Unit test
- code snippet
  - import junit, Guice(static stuff)
    - **import static extension org.junit.Assert.***
  - import domain related item
  - test method
  - test class
  - assert
    - assertEquals


### Lexer
- How can we specify lexer rule to avoid override origin lexer rule
- when terminal string return it has been automatically escape the content
- How to create case ignore keyword(like t-sql key word)

### Parser
- How to rewrite AST to create KVP pairs? (when parsing ArgumentList or JSON object Literal)
- [important]Auto generate the treeLiteral method when generate classes

### Language Structue
- for left factor algorithm, how we can organize our code structure
- How to quick construct Expression (using left factor)


### Checker 
- code snippet
  - check method


### Quick Fix
- code snippet
  - fix method


### Questions
- ```{Test}```Can we remove: org.eclipse.xtext.common.Terminals 
- ```error(211): ../org.xtext.example.mydsl/src-gen/org/xtext/example/mydsl/parser/antlr/internal/InternalMyDsl.g:941:1: [fatal] rule ruleArgumentList has non-LL(*) decision due to recursive rule invocations reachable from alts 1,2.  Resolve by left-factoring or using syntactic predicates or using backtrack=true option.```
