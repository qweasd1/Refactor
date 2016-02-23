### Phanbao Grammar
```python
### Phanbao Grammar
```python
parserRule = [
  #root
  rule("grammar",
  [
    branch("0",[
      unit(RULE, "import",("imports",ASSIGN_PROP),(0,1)),
      unit(RULE, "lexer",("lexers",ASSIGN_PROP),(1,1)),
      unit(RULE, "parser",("parsers",ASSIGN_PROP),(1,1))
    ])
  ]
  ),
  #import
  rule("import",[
    branch("0",[
      unit(RULE, "import_stmt",(1,-1))
    ])
  ]),
  rule("import_stmt",[
    branch("module",[
      unit(TOKEN,"IMPORT"),
      unit(TOKEN,"ID",("module",ASSIGN_PROP),(1,1))
    ],False),
    branch("from",[
      unit(TOKEN, "FROM"),
      unit(TOKEN, "ID",("module",ASSIGN_PROP),(1,1)),
      unit(TOKEN, "IMPORT"),
      unit(RULE, "import_identifier_list",("imports",ASSIGN_PROP),(1,1)),
      unit(TOKEN, "EXCEPT"),
      unit(RULE, "import_identifier_list",("excepts",ASSIGN_PROP),(0,1))
    ])
  ]),
  rule("import_identifier_list",[
    branch("0",[
      unit(RULE, "import_identifier"),
      unit(GROUP,[
        unit(TOKEN,","),
        unit(RULE, "import_identifier")
      ],(0,-1))
    ])
  ]),
  rule("import_identifier",[
    branch("0",[
      unit(TOKEN, "ID")
    ]),
    branch("1",[
      unit(TOKEN,"*")
    ])
  ]),
  #parser:
  rule("parser",[
    branch("noneEmpty",[
      unit(TOKEN,"PARSER"),
      unit(TOKEN,":"),
      unit(TOKEN,"INDENT"),
      unit(RULE, "rule_stmt",("stmts",ASSIGN_ARRAY),(1,-1)),
      unit(TOKEN,"DEDENT")
    ]),
    branch("empty",[
      unit(TOKEN,"PASS")
    ])
  ]),
  rule("rule_stmt",[
    branch("0",[
    unit(TOKEN, "ID",("name",ASSIGN_PROP),(1,1)),
    unit(RULE "option_list", ("options",ASSIGN_PROP),(0,1)),
    unit(TOKEN,":"),
    unit(TOKEN, "INDENT"),
    unit(RULE, "branch_stmt",("branches",ASSIGN_ARRAY),(1,-1)),
    unit(TOKEN, "DEDENT")
    ])
  ]),
  rule("branch_stmt",[
    branch("0",[
      unit(GROUP,[
        unit(TOKEN, "ID",("name",ASSIGN_PROP),(1,1)),
        unit(RULE "option_list", ("options",ASSIGN_PROP),(0,1)),
        unit(TOKEN,":"),
      ],(0,1)),
      unit(RULE, "branch_unit",("units",ASSIGN_ARRAY),(1,-1))
    ])
  ]),
  rule("branch_unit",[
    branch("0",[
      unit(GROUP,[
        unit(TOKEN, "ID",("prop",ASSIGN_PROP),(1,1)),
        unit(TOKEN, "AST_ASSIGN",("assign_type",ASSIGN_PROP),(1,1))
      ],(0,1)),
      unit(RULE,"branch_match_quantifier")
    ])
  ]),
  rule("branch_match_quantifier",[
    branch("0",[
      unit(RULE, "branch_match_unit",("config",ASSIGN_PROP),(1,1)),
      unit(RULE, "quantifier",("quantifier",ASSIGN_PROP),(0,1))
    ])
  ]),
  rule("branch_match_unit",[
    branch("inline",[
      unit(RULE, "lexer_pattern")
    ]),
    branch("ref",[
      unit(TOKEN,"ID",(ASSIGN_PROP),(1,1))
    ],False),
    branch("group",[
      unit(TOKEN,"(")
      unit(RULE,"branch_unit",("units",ASSIGN_ARRAY),(1,-1))
      unit(TOKEN,")")
    ],False)
  ]),
  rule("quantifier",[
    branch("plus",[
      unit(TOKEN,"+")
    ],False),
    branch("star",[
      unit(TOKEN,"*")
    ],False),
    branch("question",[
      unit(TOKEN,"?")
    ],False)
  ]),
  
  #lexer:
  rule("lexer",[
    branch("noneEmpty",[
      unit(TOKEN, "LEXER"),
      unit(TOKEN, ":"),
      unit(TOKEN, "INDENT"),
      unit(RULE, "lexer_stmt",("stmts",ASSIGN_ARRAY),(1,-1))
      unit(TOKEN, "DEDENT")
    ]),
    branch("empty",[
      unit(TOKEN,"PASS")
    ])
  ]),
  rule("lexer_stmt",[
    branch("0",[
      unit(TOKEN,"ID",("name",ASSIGN_PROP),(1,1)),
      unit(RULE, "option_list",("options",ASSIGN_PROP),(0,1)),
      unit(GROUP,[
        unit(TOKEN,":"),
        unit(RULE,"lexer_pattern",("pattern",ASSIGN_PROP))
      ],(0,1))
    ])
  ]),
  rule("lexer_pattern",[
    branch("string_single",[
      unit(TOKEN, "STRING_SINGLE",("value",ASSIGN_PROP),(1,1))
    ],False),
    branch("string_double",[
      unit(TOKEN, "STRING_DOUBLE",("value",ASSIGN_PROP),(1,1))
    ],False),
    branch("regex",[
      unit(TOKEN, "REGEX",("value",ASSIGN_PROP),(1,1))
    ],False)
  ]),
  rule("option_list",[
    branch("0",[
      unit(TOKEN, "("),
      unit(RULE, "option"),
      unit(GROUP, [
        unit(TOKEN,","),
        unit(RULE, "option")
      ],(0,-1))
      unit(TOKEN, ")")
    ])
  ]),
  rule("option",[
    branch("0",[
      unit(TOKEN,"ID",("name",ASSIGN_PROP),(1,1)),
      unit(GROUP,[
        unit(TOKEN, "="),
        unit(TOKEN, "NUMBER", ("value",ASSIGN_PROP),(1,1))
      ],(0,1))
    ],False)
  ])
]
```

```
