###GrammarMergeVisitor
```python
class GrammarMergeVisitor(GrammarVisitor):
  def __init__(self):
    self.importLexerRuleASTs = []
    self.importParserRuleASTs = []
    self.lexerRule=  []
    self.parserRule = []
    
  def loadImport(module):
    grammar_def = io.open(module).read()
    grammar_ast = parse(grammar_def)
    visitor = GrammarMergeVisitor()
    visitor.visit(grammar_ast)
    return visitor.createMergedImports()
  def visit_import_stmt_module(self,ast):
    module = ast.module
    lexerRuleAST, parserRuleAST = self.g._loadGrammarContent(module)
    self.importLexerRuleASTs.append(lexerRuleAST)
    self.importParserRuleASTs.append(parserRuleAST)
    
  def visit_import_stmt_from(self,ast):
    #TODO: add detail logic here in the future
    #module = ast.module
    #asts_to_import =  self.g._loadGrammarContent(module)
    #self.imports.append(asts_to_import)
  def visit_lexer_stmt(self, ast):
    imported_asts = []
    
    for lrules in importLexerRuleASTs:
        for l in lrules:
          if l.name == ast.name:
            imported_asts.append(lrules, lrules.index(l), l)
    if len(imported_asts) > 0:
      last_ast =  imported_ast[-1][2]
      if ast.config == None:
        self.lexerRule.append(last_ast)
    else:
      self.lexerRule.append(ast)
    #delete ast not used
    for l,i,_ in imported_asts:
      del l[i]
  def visit_parser_stmt(self, ast):
    imported_asts = []
    for prules in importParserRuleASTs:
        for p in prules:
          if p.name == ast.name:
            imported_asts.append(prules, prules.index(p))
    self.parserRule.append(ast)
    #delete ast not used
    for l,i,_ in imported_asts:
      del l[i]
      
  def createMergedImports(self):
    #lexer
    #TODO: check here, if import1 has lexerRule1, import2 has lexerRule1, we will use import1's lexerRule1's position. Check if it's correct
    restLexerCollectors = OrderedDict()
    for lrules in self.importLexerRuleASTs:
      for l in lrules:
        restLexerCollectors.update({l.name:l})
    values = restLexerCollectors.values()
    self.lexerRule.extend(values.reverse())
    
    #parser
    restParserCollectors = OrderedDict()
    for prules in self. importParserRuleASTs:
      for p in prules:
        restParserCollectors.update({p.name:p})
    values = restParserCollectors.values()
    self.ParserRule.extend(values())
    
    return (self.lexerRule, self.ParserRule)
```

### grammar
```python
class grammar():

  def loadGrammar(grammarFile):
  	self.name = grammarFile[0:grammarFile.index('.')]
  	visitor = GrammarMergeVisitor()
  	lexerRuleASTs, parserRuleASTs =  visitor.loadImport()
  	self.rootRule = parserRuleASTs[0].name
  	
```
