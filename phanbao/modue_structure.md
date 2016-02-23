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
GrammarVisitor

*LexerGenerator
*ignoreRuleGenerator
ParserGenerator
*VisitorGenerator(if one rule only have one branch, just generate visit method for that branch)

def parse()


### grammar design
grammar(grammar, grammarType = File/String):
  loadGrammar: import reference grammar, and current grammar. Post process them to make them ready to generate
  generate(HasVisitior=True, Standalone=False): write generate lexerRule and parser to a new file
  	HasVisitor: controls whether we generate visitor
  	Standalone: controls whether we package phanbao module into the package. When False, package all into the target grammar
 
### target package structure
*fileName: ${Grammar}Grammar.py

phanbao?
from phanbao import * ?

lexerRule = []
tokenRewriteRule = []

${Grammar}Parser
${Grammar}Visitor

def parse(source_code,root = ${RootRule}, match_cb = lambda x:x.value):
    lex = lexer(source_code,lexerRule)
    rewriter = token_rewriter(tokenRewriteRule)
    rewrite_tokens = rewriter.output(lex.alltokens())
    tm = transaction_token_manager(rewrite_tokens)
    parser = ${Grammar}Parser(tm, match_cb)
    return parser.parse(root)

 
