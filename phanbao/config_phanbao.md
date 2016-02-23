### Phanbao Grammar
```python
parserRule = [
  #root
  rule("grammar",
  [
    branch("0",[
      unit(RULE, "import",(0,1),(ASSIGN_PROP,"imports")),
      unit(RULE, "lexer",(1,1),(ASSIGN_PROP,"lexers")),
      unit(RULE, "parser",(1,1),(ASSIGN_PROP,"parsers"))
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
      unit(TOKEN,"ID",(1,1),(ASSIGN_PROP,"module"))
    ],False),
    branch("from",[
      unit(TOKEN, "FROM"),
      unit(TOKEN, "ID",(1,1),(ASSIGN_PROP,"module")),
      unit(TOKEN, "IMPORT"),
      unit(RULE, "import_identifier_list",(1,1),(ASSIGN_PROP,"imports")),
      unit(TOKEN, "EXCEPT"),
      unit(RULE, "import_identifier_list",(0,1),(ASSIGN_PROP,"excepts"))
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
      unit(RULE, "rule_stmt",(1,-1),(ASSIGN_ARRAY,"stmts")),
      unit(TOKEN,"DEDENT")
    ]),
    branch("empty",[
      unit(TOKEN,"PASS")
    ])
  ]),
  rule("rule_stmt",[
    branch("0",[
    unit(TOKEN, "ID",(1,1),(ASSIGN_PROP,"name")),
    unit(RULE "option_list", (0,1),(ASSIGN_PROP,"options")),
    unit(TOKEN,":"),
    unit(TOKEN, "INDENT"),
    unit(RULE, "branch_stmt",(1,-1),(ASSIGN_ARRAY,"branches")),
    unit(TOKEN, "DEDENT")
    ])
  ]),
  rule("branch_stmt",[
    branch("0",[
      unit(GROUP,[
        unit(TOKEN, "ID",(1,1),(ASSIGN_PROP,"name")),
        unit(RULE "option_list", (0,1),(ASSIGN_PROP,"options")),
        unit(TOKEN,":"),
      ],(0,1)),
      unit(RULE, "branch_unit",(1,-1),(ASSIGN_ARRAY,"units"))
    ])
  ]),
  rule("branch_unit",[
    branch("0",[
      unit(GROUP,[
        unit(TOKEN, "ID",(1,1),(ASSIGN_PROP,"prop")),
        unit(TOKEN, "AST_ASSIGN",(1,1),(ASSIGN_PROP,"assign_type"))
      ],(0,1)),
      unit(RULE,"branch_match_quantifier")
    ])
  ]),
  rule("branch_match_quantifier",[
    branch("0",[
      unit(RULE, "branch_match_unit",(1,1),(ASSIGN_PROP,"config")),
      unit(RULE, "quantifier",(0,1),(ASSIGN_PROP, "quantifier"))
    ])
  ]),
  rule("branch_match_unit",[
    branch("inline",[
      unit(RULE, "lexer_pattern")
    ]),
    branch("ref",[
      unit(TOKEN,"ID",(1,1),(ASSIGN_PROP))
    ],False),
    branch("group",[
      unit(TOKEN,"(")
      unit(RULE,"branch_unit",(1,-1),(ASSIGN_ARRAY,"units"))
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
      unit(RULE, "lexer_stmt",(1,-1),(ASSIGN_ARRAY, "stmts"))
      unit(TOKEN, "DEDENT")
    ]),
    branch("empty",[
      unit(TOKEN,"PASS")
    ])
  ]),
  rule("lexer_stmt",[
    branch("0",[
      unit(TOKEN,"ID",(1,1),(ASSIGN_PROP, "name")),
      unit(RULE, "option_list",(0,1),(ASSIGN_PROP,"options")),
      unit(GROUP,[
        unit(TOKEN,":"),
        unit(RULE,"lexer_pattern",(ASSIGN_PROP, "pattern"))
      ],(0,1))
    ])
  ]),
  rule("lexer_pattern",[
    branch("string_single",[
      unit(TOKEN, "STRING_SINGLE",(1,1),(ASSIGN_PROP, "value"))
    ],False),
    branch("string_double",[
      unit(TOKEN, "STRING_DOUBLE",(1,1),(ASSIGN_PROP, "value"))
    ],False),
    branch("regex",[
      unit(TOKEN, "REGEX",(1,1),(ASSIGN_PROP, "value"))
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
      unit(TOKEN,"ID",(1,1),(ASSIGN_PROP,"name")),
      unit(GROUP,[
        unit(TOKEN, "="),
        unit(TOKEN, "NUMBER", (1,1),(ASSIGN_PROP, "value"))
      ],(0,1))
    ],False)
  ])
]
```
