GrammarMergeVisitor(GrammarVisitor):
  def __init__(self,grammar):
    self.g = grammar
  def visit_import_stmt_module(self,ast):
    module = ast.module
    self.g._loadGrammarContent(module)
  def visit_import_stmt_from(self,ast):
    #TODO: add detail logic here in the future
    module = ast.module
    self.g._loadGrammarContent(module)
  def visit_rule_stmt(self, ast):
    for r in g.parserRule:
      if r.name == ast.name:
        index = g.parserRule.index(r)
        g.parserRule[index] = ast

grammar:
  rootRule : string
  name: string
  self.lexerRule: [...]
  self.parserRule: [...]
  self.lexerRuleAst
  self.parserRuleAst
  
  
  
  
  loadGrammar(file):
  
  _loadGrammarContent(file):
    grammar_def = io.open(file).read()
    grammar_ast = parse(grammar_def)
     grammar_ast.imports
