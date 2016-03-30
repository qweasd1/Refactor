### how to write a CharStream

CharStream
```java
package org.dongbao.erha.parser;

import java.util.LinkedList;
import java.util.Queue;
import java.util.Stack;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CharStream {

	private String text;
	private int p;
	private int totalLength;

	private Stack<Integer> txStack;

	public CharStream(String text) {
		this.text = text;
		this.totalLength = text.length();

		this.p = 0;
		txStack = new Stack<Integer>();
	}

	public String nextString(String str) {
		int strLength = str.length();
		if (getMatchValue(strLength).equals(str)) {
			move(strLength);
			return str;
		} else {
			return null;
		}
	}

	public String nextRegex(String regexStr) {
		Pattern regex = Pattern.compile("^" + regexStr);
		return nextRegex(regex);
	}

	public String nextRegex(Pattern regex) {
		String rest = this.text.substring(this.p);
		Matcher matcher = regex.matcher(rest);
		if (matcher.find()) {
			String matchValue = matcher.group();
			move(matchValue.length());
			return matchValue;
		} else {
			return null;
		}
	}

	public String nextBlock(String start, String end, String escape,
			boolean isReserveBounder) {
		Pattern startPattern = Pattern.compile("^" + start);
		String rest = this.text.substring(this.p);
		Matcher matcher = startPattern.matcher(rest);

		if (!matcher.find()) {
			return null;
		}

		int leftBoundLength = matcher.group().length();
		int offset = leftBoundLength;
		if (checkEnd(offset)) {
			return null;
		}

		Pattern endPattern = Pattern.compile("^" + end);
		Pattern escapePattern = null;
		if (escape != null) {
			escapePattern = Pattern.compile("^" + escape);
		}

		while (true) {
			String rest_ = this.text.substring(this.p + offset);
			if (checkEnd(offset)) {
				return null;
			}

			if (escapePattern != null) {
				// match escape, if reach end then return no match, if success
				// then continue
				Matcher escapeMatcher = escapePattern.matcher(rest_);
				if (escapeMatcher.find()) {
					offset += escapeMatcher.group().length();
					if (checkEnd(offset)) {
						return null;
					} else {
						continue;
					}
				}
			}

			// no escape then match the content not the end

			Matcher endMatcher = endPattern.matcher(rest_);
			if (endMatcher.find()) {
				int rightBoundLength = endMatcher.group().length();
				offset += rightBoundLength;
				String matchValueWithBounder = getMatchValue(offset);
				String matchValue = isReserveBounder ? matchValueWithBounder : matchValueWithBounder.substring(leftBoundLength, offset - rightBoundLength);
				move(offset);
				return matchValue;
			}

			offset += 1;
		}

		// Matcher matcher = endPattern.matcher(rest);

	}

	public boolean checkEnd(int length) {
		return this.p + length >= totalLength;
	}

	public boolean isEnd() {
		return this.p >= totalLength;
	}

	public void beginTx() {
		this.txStack.push(this.p);
	}

	public void commit() {
		if (txStack.isEmpty()) {
			throw new CharStreamTransactionException(
					"you want to commit but these is nothing in transaction stack");
		}
		txStack.pop();
	}

	public void rollback() {
		if (txStack.isEmpty()) {
			throw new CharStreamTransactionException(
					"you want to rollback but these is nothing in transaction stack");
		}
		this.p = txStack.pop();
	}

	private String getMatchValue(int length) {
		return this.text.substring(this.p, this.p + length);
	}

	private void move(int length) {
		this.p += length;

	}

	public class CharStreamTransactionException extends RuntimeException {
		public CharStreamTransactionException(String message) {
			super(message);
		}
	}

}

```
lexer
```
package org.dongbao.erha.parser;

import java.util.List;

import org.dongbao.erha.ast.ErhaModel;
import org.dongbao.erha.ast.Value;
import org.dongbao.erha.parser.config.ErhaParserConfig;
import org.dongbao.erha.parser.config.ValueParseConfig;

public class ErhaLexer {
	private CharStream charStream;
	private ErhaParserConfig config;

	
	
	public ErhaLexer(CharStream charStream, ErhaParserConfig config) {
		this.charStream = charStream;
		this.config = config;
	}
	
	public List<ErhaModel> getModels() {
		return null;
	}
	
	public Value value() {
		for (ValueParseConfig config : config.valueParseConfigs) {
			Value result = userDefineValue(config);
			if (result != null) {
				return result;
			}
		}
		
		Value result = rawValue("\\n\\(");
		return result;
	}
	
	public Value userDefineValue(ValueParseConfig config) {
		String value = charStream.nextBlock(config.start, config.end, config.escape, false);
		if (value == null) {
			return null;
		}
		else {
			Value result = new Value();
			result.setValue(value);
			result.setType(config.type);
			return result;
		}
	}
	
	public Value rawValue(String endBound) {
		String value = charStream.nextRegex("[^" + endBound +  "]*");
	    if (value == null) {
			return null;
		}
	    else {
			Value result = new Value();
			result.setValue(value);
			return result;
		}
	}
	
	
}

```
