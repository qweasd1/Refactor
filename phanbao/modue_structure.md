### phanbao

Exception:*
enum:
lexer:
	token
	lexer
	token_rewriter
	token_manager
	transaction_token_manager
parser:
	Parser	
	astbuilder
	ast

###python_code_builder
PythonBuilder


### phanbao.grammar
grammar
rule
branch
unit

grammarLexerRule
GrammarParser


*LexerGenerator
*ignoreRuleGenerator
ParserGenerator
VisitorGenerator


### grammar design
grammar(grammar, grammarType = File/String):
  loadGrammar: import reference grammar, and current grammar. Post process them to make them ready to generate
  generate(HasVisitior=True, Standalone=False): write generate lexerRule and parser to a new file
  	HasVisitor: controls whether we generate visitor
  	Standalone: controls whether we package phanbao module into the package. When False, package all into the target grammar
 
### target package structure
#fileName: ${Grammar}Grammar.py

phanbao?
from phanbao import * ?

lexerRule = []
ignoreRule = []

${Grammar}Parser
${Grammar}Visitor

def parse(source_code, match_cb = lambda x:x.value):
    
  
