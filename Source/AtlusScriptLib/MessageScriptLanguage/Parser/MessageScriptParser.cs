//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:\Users\smart\Documents\Visual Studio 2017\Projects\AtlusScriptToolchain\Source\AtlusScriptLib\MessageScriptLanguage\Parser\MessageScriptParser.g4 by ANTLR 4.6.4

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AtlusScriptLib.MessageScriptLanguage.Parser {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.4")]
[System.CLSCompliant(false)]
public partial class MessageScriptParser : Parser {
	public const int
		OpenCode=1, CloseText=2, Text=3, MessageDialogTagId=4, SelectionDialogTagId=5, 
		CloseCode=6, OpenText=7, IntLiteral=8, Identifier=9, Whitespace=10;
	public const int
		RULE_compilationUnit = 0, RULE_messageWindow = 1, RULE_dialogWindow = 2, 
		RULE_dialogWindowSpeakerName = 3, RULE_selectionWindow = 4, RULE_tagText = 5, 
		RULE_tag = 6;
	public static readonly string[] ruleNames = {
		"compilationUnit", "messageWindow", "dialogWindow", "dialogWindowSpeakerName", 
		"selectionWindow", "tagText", "tag"
	};

	private static readonly string[] _LiteralNames = {
		null, null, null, null, "'dlg'", "'sel'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "OpenCode", "CloseText", "Text", "MessageDialogTagId", "SelectionDialogTagId", 
		"CloseCode", "OpenText", "IntLiteral", "Identifier", "Whitespace"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "MessageScriptParser.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public MessageScriptParser(ITokenStream input)
		: base(input)
	{
		_interp = new ParserATNSimulator(this,_ATN);
	}
	public partial class CompilationUnitContext : ParserRuleContext {
		public ITerminalNode Eof() { return GetToken(MessageScriptParser.Eof, 0); }
		public MessageWindowContext[] messageWindow() {
			return GetRuleContexts<MessageWindowContext>();
		}
		public MessageWindowContext messageWindow(int i) {
			return GetRuleContext<MessageWindowContext>(i);
		}
		public CompilationUnitContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_compilationUnit; } }
		public override void EnterRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.EnterCompilationUnit(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.ExitCompilationUnit(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMessageScriptParserVisitor<TResult> typedVisitor = visitor as IMessageScriptParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCompilationUnit(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CompilationUnitContext compilationUnit() {
		CompilationUnitContext _localctx = new CompilationUnitContext(_ctx, State);
		EnterRule(_localctx, 0, RULE_compilationUnit);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 17;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==OpenCode) {
				{
				{
				State = 14; messageWindow();
				}
				}
				State = 19;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 20; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MessageWindowContext : ParserRuleContext {
		public DialogWindowContext dialogWindow() {
			return GetRuleContext<DialogWindowContext>(0);
		}
		public SelectionWindowContext selectionWindow() {
			return GetRuleContext<SelectionWindowContext>(0);
		}
		public MessageWindowContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_messageWindow; } }
		public override void EnterRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.EnterMessageWindow(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.ExitMessageWindow(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMessageScriptParserVisitor<TResult> typedVisitor = visitor as IMessageScriptParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMessageWindow(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MessageWindowContext messageWindow() {
		MessageWindowContext _localctx = new MessageWindowContext(_ctx, State);
		EnterRule(_localctx, 2, RULE_messageWindow);
		try {
			State = 24;
			_errHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(_input,1,_ctx) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 22; dialogWindow();
				}
				break;

			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 23; selectionWindow();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DialogWindowContext : ParserRuleContext {
		public ITerminalNode OpenCode() { return GetToken(MessageScriptParser.OpenCode, 0); }
		public ITerminalNode MessageDialogTagId() { return GetToken(MessageScriptParser.MessageDialogTagId, 0); }
		public ITerminalNode Identifier() { return GetToken(MessageScriptParser.Identifier, 0); }
		public ITerminalNode CloseCode() { return GetToken(MessageScriptParser.CloseCode, 0); }
		public TagTextContext tagText() {
			return GetRuleContext<TagTextContext>(0);
		}
		public DialogWindowSpeakerNameContext dialogWindowSpeakerName() {
			return GetRuleContext<DialogWindowSpeakerNameContext>(0);
		}
		public DialogWindowContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_dialogWindow; } }
		public override void EnterRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.EnterDialogWindow(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.ExitDialogWindow(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMessageScriptParserVisitor<TResult> typedVisitor = visitor as IMessageScriptParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDialogWindow(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DialogWindowContext dialogWindow() {
		DialogWindowContext _localctx = new DialogWindowContext(_ctx, State);
		EnterRule(_localctx, 4, RULE_dialogWindow);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 26; Match(OpenCode);
			State = 27; Match(MessageDialogTagId);
			State = 28; Match(Identifier);
			State = 30;
			_errHandler.Sync(this);
			_la = _input.La(1);
			if (_la==OpenText) {
				{
				State = 29; dialogWindowSpeakerName();
				}
			}

			State = 32; Match(CloseCode);
			State = 33; tagText();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DialogWindowSpeakerNameContext : ParserRuleContext {
		public ITerminalNode OpenText() { return GetToken(MessageScriptParser.OpenText, 0); }
		public TagTextContext tagText() {
			return GetRuleContext<TagTextContext>(0);
		}
		public ITerminalNode CloseText() { return GetToken(MessageScriptParser.CloseText, 0); }
		public DialogWindowSpeakerNameContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_dialogWindowSpeakerName; } }
		public override void EnterRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.EnterDialogWindowSpeakerName(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.ExitDialogWindowSpeakerName(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMessageScriptParserVisitor<TResult> typedVisitor = visitor as IMessageScriptParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDialogWindowSpeakerName(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DialogWindowSpeakerNameContext dialogWindowSpeakerName() {
		DialogWindowSpeakerNameContext _localctx = new DialogWindowSpeakerNameContext(_ctx, State);
		EnterRule(_localctx, 6, RULE_dialogWindowSpeakerName);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 35; Match(OpenText);
			State = 36; tagText();
			State = 37; Match(CloseText);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class SelectionWindowContext : ParserRuleContext {
		public ITerminalNode OpenCode() { return GetToken(MessageScriptParser.OpenCode, 0); }
		public ITerminalNode SelectionDialogTagId() { return GetToken(MessageScriptParser.SelectionDialogTagId, 0); }
		public ITerminalNode Identifier() { return GetToken(MessageScriptParser.Identifier, 0); }
		public ITerminalNode CloseCode() { return GetToken(MessageScriptParser.CloseCode, 0); }
		public TagTextContext tagText() {
			return GetRuleContext<TagTextContext>(0);
		}
		public SelectionWindowContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_selectionWindow; } }
		public override void EnterRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.EnterSelectionWindow(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.ExitSelectionWindow(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMessageScriptParserVisitor<TResult> typedVisitor = visitor as IMessageScriptParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSelectionWindow(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public SelectionWindowContext selectionWindow() {
		SelectionWindowContext _localctx = new SelectionWindowContext(_ctx, State);
		EnterRule(_localctx, 8, RULE_selectionWindow);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 39; Match(OpenCode);
			State = 40; Match(SelectionDialogTagId);
			State = 41; Match(Identifier);
			State = 42; Match(CloseCode);
			State = 43; tagText();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TagTextContext : ParserRuleContext {
		public TagContext[] tag() {
			return GetRuleContexts<TagContext>();
		}
		public TagContext tag(int i) {
			return GetRuleContext<TagContext>(i);
		}
		public ITerminalNode[] Text() { return GetTokens(MessageScriptParser.Text); }
		public ITerminalNode Text(int i) {
			return GetToken(MessageScriptParser.Text, i);
		}
		public TagTextContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_tagText; } }
		public override void EnterRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.EnterTagText(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.ExitTagText(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMessageScriptParserVisitor<TResult> typedVisitor = visitor as IMessageScriptParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTagText(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TagTextContext tagText() {
		TagTextContext _localctx = new TagTextContext(_ctx, State);
		EnterRule(_localctx, 10, RULE_tagText);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 49;
			_errHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(_input,4,_ctx);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.InvalidAltNumber ) {
				if ( _alt==1 ) {
					{
					State = 47;
					_errHandler.Sync(this);
					switch (_input.La(1)) {
					case OpenCode:
						{
						State = 45; tag();
						}
						break;
					case Text:
						{
						State = 46; Match(Text);
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					} 
				}
				State = 51;
				_errHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(_input,4,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TagContext : ParserRuleContext {
		public ITerminalNode OpenCode() { return GetToken(MessageScriptParser.OpenCode, 0); }
		public ITerminalNode Identifier() { return GetToken(MessageScriptParser.Identifier, 0); }
		public ITerminalNode CloseCode() { return GetToken(MessageScriptParser.CloseCode, 0); }
		public ITerminalNode[] IntLiteral() { return GetTokens(MessageScriptParser.IntLiteral); }
		public ITerminalNode IntLiteral(int i) {
			return GetToken(MessageScriptParser.IntLiteral, i);
		}
		public TagContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_tag; } }
		public override void EnterRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.EnterTag(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMessageScriptParserListener typedListener = listener as IMessageScriptParserListener;
			if (typedListener != null) typedListener.ExitTag(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMessageScriptParserVisitor<TResult> typedVisitor = visitor as IMessageScriptParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTag(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TagContext tag() {
		TagContext _localctx = new TagContext(_ctx, State);
		EnterRule(_localctx, 12, RULE_tag);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 52; Match(OpenCode);
			State = 53; Match(Identifier);
			State = 57;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==IntLiteral) {
				{
				{
				State = 54; Match(IntLiteral);
				}
				}
				State = 59;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 60; Match(CloseCode);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x3\f\x41\x4\x2\t\x2"+
		"\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x3\x2\a"+
		"\x2\x12\n\x2\f\x2\xE\x2\x15\v\x2\x3\x2\x3\x2\x3\x3\x3\x3\x5\x3\x1B\n\x3"+
		"\x3\x4\x3\x4\x3\x4\x3\x4\x5\x4!\n\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\a\x3\a\a\a\x32\n\a\f"+
		"\a\xE\a\x35\v\a\x3\b\x3\b\x3\b\a\b:\n\b\f\b\xE\b=\v\b\x3\b\x3\b\x3\b\x2"+
		"\x2\x2\t\x2\x2\x4\x2\x6\x2\b\x2\n\x2\f\x2\xE\x2\x2\x2?\x2\x13\x3\x2\x2"+
		"\x2\x4\x1A\x3\x2\x2\x2\x6\x1C\x3\x2\x2\x2\b%\x3\x2\x2\x2\n)\x3\x2\x2\x2"+
		"\f\x33\x3\x2\x2\x2\xE\x36\x3\x2\x2\x2\x10\x12\x5\x4\x3\x2\x11\x10\x3\x2"+
		"\x2\x2\x12\x15\x3\x2\x2\x2\x13\x11\x3\x2\x2\x2\x13\x14\x3\x2\x2\x2\x14"+
		"\x16\x3\x2\x2\x2\x15\x13\x3\x2\x2\x2\x16\x17\a\x2\x2\x3\x17\x3\x3\x2\x2"+
		"\x2\x18\x1B\x5\x6\x4\x2\x19\x1B\x5\n\x6\x2\x1A\x18\x3\x2\x2\x2\x1A\x19"+
		"\x3\x2\x2\x2\x1B\x5\x3\x2\x2\x2\x1C\x1D\a\x3\x2\x2\x1D\x1E\a\x6\x2\x2"+
		"\x1E \a\v\x2\x2\x1F!\x5\b\x5\x2 \x1F\x3\x2\x2\x2 !\x3\x2\x2\x2!\"\x3\x2"+
		"\x2\x2\"#\a\b\x2\x2#$\x5\f\a\x2$\a\x3\x2\x2\x2%&\a\t\x2\x2&\'\x5\f\a\x2"+
		"\'(\a\x4\x2\x2(\t\x3\x2\x2\x2)*\a\x3\x2\x2*+\a\a\x2\x2+,\a\v\x2\x2,-\a"+
		"\b\x2\x2-.\x5\f\a\x2.\v\x3\x2\x2\x2/\x32\x5\xE\b\x2\x30\x32\a\x5\x2\x2"+
		"\x31/\x3\x2\x2\x2\x31\x30\x3\x2\x2\x2\x32\x35\x3\x2\x2\x2\x33\x31\x3\x2"+
		"\x2\x2\x33\x34\x3\x2\x2\x2\x34\r\x3\x2\x2\x2\x35\x33\x3\x2\x2\x2\x36\x37"+
		"\a\x3\x2\x2\x37;\a\v\x2\x2\x38:\a\n\x2\x2\x39\x38\x3\x2\x2\x2:=\x3\x2"+
		"\x2\x2;\x39\x3\x2\x2\x2;<\x3\x2\x2\x2<>\x3\x2\x2\x2=;\x3\x2\x2\x2>?\a"+
		"\b\x2\x2?\xF\x3\x2\x2\x2\b\x13\x1A \x31\x33;";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace AtlusScriptLib.MessageScriptLanguage.Parser
