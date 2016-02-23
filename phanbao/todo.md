* parserGenerator: single return branch should generate different ast(Type branch)
* ast branch should use a new name convention
* Indent rewrite logic should consider COMMENT
* should contains NEWLINE otherwise, will fail in 
* how to treat tail missing NEWLINE? (use token rewriter APPEND)
```
ID: ID
ID:
```
