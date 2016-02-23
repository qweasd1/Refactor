* parserGenerator: single return branch should generate different ast(Type branch)
* ast branch should use a new name convention
* Indent rewrite logic should consider COMMENT
* should contains NEWLINE otherwise, will fail in 
```
ID: ID
ID:
```
