* parserGenerator: single return branch should generate different ast(Type branch)
* ast branch should use a new name convention
* Indent rewrite logic should consider COMMENT
* should contains NEWLINE otherwise, will fail in (Can we remove NEWLINE in our config?)
* how to treat tail missing NEWLINE? (use token rewriter APPEND)
```
ID: ID
ID:
```

* Visitor: can we add a hook in Visitor, a method called at every branch
* Visitor: how to determine the visitor method?()
* Visitor: generate visit_rule  + visit_rule_branch: this shall give us opportunity to override rule level visit method
* PythonCodeGenerator: add support for template register and invoke
