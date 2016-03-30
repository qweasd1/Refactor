# the design for Erha


### Question
* do we need to specially define fat string


### potential requirement
* multi-line value can remove the indent as the first line state: record col-offset on ErhaAst?

### Erha Grammar design
> grammar definition
```
// skip ' ','\t'
// fix last DEDENT
// fix last NEWLINE

//TOKEN:
NEWLINE: '\n'
INDENT : abstract, indent relative to previous line, added in ErhaLexer when parsing
DEDENT : abstract, dedent relative to previous indent, added in ErhaLexer when parsing



unit: annotation NEWLINE 
      entity NEWLINE 
	  (INDENT unit* DEDENT)?
annotation : '@' entity
entity : value ('(' props?  ')')?

props: prop (',' prop)*

prop: key = value '=' value = value

value: @start, @escape && !@end,  @end // userDefine block
	 | !'(' && !'NEWLINE'  //[1]       // raw Value

	 
//notes:
[1] remove the suffix '\r' if existing

```

> error definition
