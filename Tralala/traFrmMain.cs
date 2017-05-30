using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Tralala
{
    enum LogType { INFO, WARNING, ERROR };

    public partial class traFrmMain : Form
    {
        private Regex mainReg;
        private List<Token> tokenList;
        private List<Token> symbolTable;
        private traFrmLiter frmLiter;
        private bool isColorChanged = false;
        private char[] innerSpliter = new char[] { ' ' };
        private static string[] terminalSymbols =
        { "{", "}", "if", "(", ")", "then", "else", "while", "ID",
            "=", ";", "int", "real", "<", ">", "<=", ">=", "==",
            "+", "-", "*", "/", ",", "NUM" };

        public traFrmMain()
        {
            InitializeComponent();
            frmLiter = new traFrmLiter();
            tokenList = new List<Token>(200);
            symbolTable = new List<Token>(30);
            tokens.Columns.Add("字段", 110, HorizontalAlignment.Left);
            tokens.Columns.Add("类型", 80, HorizontalAlignment.Left);
            tokens.Columns.Add("行", 40, HorizontalAlignment.Left);
            tokens.Columns.Add("列", 40, HorizontalAlignment.Left);
            syntaxs.Columns.Add("非终结符", 80, HorizontalAlignment.Left);
            syntaxs.Columns.Add("First", 95, HorizontalAlignment.Left);
            syntaxs.Columns.Add("Follow", 95, HorizontalAlignment.Left);
            mainReg = new Regex(@"(//.*)|(\d+(\.\d+)?([Ee][\+\-]?\d+)?)"
                                + @"|(int|real|if|then|else|while)|(\w[\w\d]{0,63})"
                                + @"|(>=|<=|!=|==|[><=\+\-\*/])|([\(\)\{\};])|(\S+?)");
        }

        private bool IsTerminal(string symbol)
        {
            return terminalSymbols.Contains(symbol);
        }

        private void traFrmMain_Resize(object sender, EventArgs e)
        {
            rootSpliter.Height = Height - 85;
        }

        private int lexicalAnalysis(string[] lines)
        {
            int lexicalErrors = 0;
            int pos = codes.SelectionStart;
            isColorChanged = false;
            tokenList.Clear();
            tokens.Items.Clear();
            codes.SelectAll();
            codes.SelectionBackColor = Color.White;
            codes.SelectionLength = 0;
            List<int> errorLineNumbers = new List<int>(10);
            for (int lineIdx = 0; lineIdx < lines.Length; lineIdx++)
            {
                bool errCaused = false;
                MatchCollection matches = mainReg.Matches(lines[lineIdx]);
                foreach (Match match in matches)
                {
                    bool isFound = false;
                    for (int idx = 1; idx <= 8; idx++)
                    {
                        if (match.Groups[idx].Success)
                        {
                            isFound = true;
                            Token token = new Token();
                            token.value = match.Value;
                            token.lineNumber = lineIdx;
                            token.index = match.Index;
                            token.type = (tokenType)idx;
                            tokenList.Add(token);
                            tokens.Items.Add(new ListViewItem(token.toStrArr()));
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        lexicalErrors++;
                        errCaused = true;
                        showLog("错误（第 " + (lineIdx + 1) + " 行第 " + (match.Index + 1)
                            + " 列）：无效字符\"" + match.Value + "\"。", false, LogType.ERROR);
                    }
                }
                if (errCaused)
                {
                    errorLineNumbers.Add(lineIdx);
                }
            }
            if (lexicalErrors > 0)
            {
                isColorChanged = true;
                foreach (int line in errorLineNumbers)
                {
                    int begin = codes.GetFirstCharIndexFromLine(line);
                    int end = 0;
                    if (line == codes.Lines.Length - 1)
                    {
                        end = codes.Text.Length;
                    }
                    else
                    {
                        end = codes.GetFirstCharIndexFromLine(line + 1) - 1;
                    }
                    codes.Select(begin, end - begin + 1);
                    codes.SelectionBackColor = Color.Yellow;
                }
            }
            Token endToken = new Token();
            endToken.value = "$";
            endToken.type = tokenType.DELIMITER;
            endToken.lineNumber = 0;
            endToken.index = 0;
            tokenList.Add(endToken);
            codes.SelectionStart = pos;
            codes.SelectionLength = 0;
            codes.SelectionBackColor = Color.White;
            return lexicalErrors;
        }

        private int syntaxAnalysis()
        {
            int errorCount = 0;
            int pos = codes.SelectionStart;
            List<int> errorLineNumbers = new List<int>(10);
            Stack<string> tokenStack = new Stack<string>();
            tokenStack.Push("$");
            tokenStack.Push(frmLiter.Pairs.ElementAt(0).Key);
            for (int tokenIdx = 0; tokenIdx < tokenList.Count;)
            {
                Token token = tokenList[tokenIdx];
                string topToken = tokenStack.Peek();
                string nickName = token.value;
                switch (token.type)
                {
                    case tokenType.NUMBER:
                        nickName = "NUM";
                        break;
                    case tokenType.IDENTIFIER:
                        nickName = "ID";
                        break;
                    default:
                        break;
                }
                if (nickName == topToken)
                {
                    if (token.value != "$")
                    {
                        showLog("匹配：" + token.value, false);
                    }
                    tokenStack.Pop();
                    tokenIdx++;
                    continue;
                }
                bool isFound = false;
                string[] firstTokens = null;
                try
                {
                    firstTokens = frmLiter.FirstSet[topToken];
                }
                catch (Exception)
                {
                    errorCount++;
                    string errMsg = "";
                    bool isSplitSymbol = false;
                    switch (tokenStack.Peek())
                    {
                        case "ID":
                            errMsg = "\"" + token.value + "\"不是一个标识符。";
                            break;
                        case "=":
                            errMsg = "\"" + token.value + "\"应为赋值操作符。";
                            break;
                        case ";":
                            errMsg = "\"" + token.value + "\"前面缺少分号。";
                            break;
                        case "}":
                        case ")":
                            isSplitSymbol = true;
                            errMsg = "\"" + token.value + "\"应为语句结束。";
                            break;
                        default:
                            errMsg = "无法识别字符\"" + token.value + "\"。" + tokenStack.Peek();
                            break;
                    }
                    if (!errorLineNumbers.Contains(token.lineNumber))
                    {
                        errorLineNumbers.Add(token.lineNumber);
                    }
                    showLog("错误（第 " + (token.lineNumber + 1) + " 行第 " 
                        + (token.index + 1) + " 列）：" + errMsg, false, LogType.ERROR);
                    if (tokenStack.Count > 1 && !isSplitSymbol)
                    {
                        tokenStack.Pop();
                    }
                    else
                    {
                        tokenIdx++;
                    }
                    continue;
                }
                for (int idx = 0; idx < firstTokens.Length; idx++)
                {
                    if (firstTokens[idx] == nickName)
                    {
                        string another = "";
                        foreach (string subToken in frmLiter.Pairs[topToken])
                        {
                            string innerFirst = subToken.Split(innerSpliter,
                                StringSplitOptions.RemoveEmptyEntries)[0];
                            if (innerFirst == nickName || (!IsTerminal(innerFirst)
                                && frmLiter.FirstSet[innerFirst].Contains(nickName)))
                            {
                                another = subToken;
                                break;
                            }
                        }
                        isFound = true;
                        tokenStack.Pop();
                        string[] pushArr = another.Split(innerSpliter,
                            StringSplitOptions.RemoveEmptyEntries);
                        for (int pushIdx = pushArr.Length - 1; pushIdx >= 0; pushIdx--)
                        {
                            tokenStack.Push(pushArr[pushIdx]);
                        }
                        showLog("转换：" + topToken + "->" + another, false);
                        break;
                    }
                }
                if (!isFound)
                {
                    tokenStack.Pop();
                    string[] followTokens = frmLiter.FollowSet[topToken];
                    if (followTokens.Contains(nickName))
                    {
                        showLog("转换：" + topToken + "->ε", false);
                    }
                    else if (token.value == "$")
                    {
                        errorCount++;
                        showLog("代码未能匹配到终结符。", false, LogType.ERROR);
                    }
                }
            }
            if (errorCount > 0)
            {
                isColorChanged = true;
                foreach (int line in errorLineNumbers)
                {
                    int begin = codes.GetFirstCharIndexFromLine(line);
                    int end = 0;
                    if (line == codes.Lines.Length - 1)
                    {
                        end = codes.Text.Length;
                    }
                    else
                    {
                        end = codes.GetFirstCharIndexFromLine(line + 1) - 1;
                    }
                    codes.Select(begin, end - begin + 1);
                    codes.SelectionBackColor = Color.Yellow;
                }
            }
            codes.SelectionStart = pos;
            codes.SelectionLength = 0;
            codes.SelectionBackColor = Color.White;
            return errorCount;
        }

        private void cmdLexical_Click(object sender, EventArgs e)
        {
            if (codes.Text.Length == 0)
            {
                showLog("您还没有输入任何代码！", true, LogType.ERROR);
                return;
            }
            showLog("开始对代码进行词法分析。");
            int result = lexicalAnalysis(codes.Lines);
            if (result == 0)
            {
                showLog("词法分析结束，没有发现错误。", true, LogType.INFO);
            }
            else
            {
                showLog("词法分析结束，发现了" + result.ToString()
                    + "个错误。", true, LogType.ERROR);
            }
        }

        private void showLog(string log, bool showTime = true,
            LogType type = LogType.INFO)
        {
            switch (type)
            {
                case LogType.INFO:
                    logs.SelectionColor = Color.Black;
                    break;
                case LogType.WARNING:
                    logs.SelectionColor = Color.Yellow;
                    break;
                case LogType.ERROR:
                    logs.SelectionColor = Color.Red;
                    break;
            }
            if (showTime)
            {
                logs.AppendText(DateTime.Now + "：" + log + "\n");
            }
            else
            {
                logs.AppendText(log + "\n");
            }
        }

        private void cmdCopyLog_Click(object sender, EventArgs e)
        {
            if (logs.Text == "")
            {
                return;
            }
            Clipboard.SetText(logs.Text);
        }

        private void cmdClearLog_Click(object sender, EventArgs e)
        {
            logs.Text = "";
        }

        private void cmdSyntax_Click(object sender, EventArgs e)
        {
            if (frmLiter == null || frmLiter.FirstSet == null
                || frmLiter.FollowSet == null || frmLiter.Pairs == null)
            {
                showLog("无法分析，您还没有指定文法。", true, LogType.ERROR);
                return;
            }
            if (codes.Text.Length == 0)
            {
                showLog("您还没有输入任何代码！", true, LogType.ERROR);
            }
            codes.Enabled = false;
            showLog("开始对代码进行词法分析。");
            int result = lexicalAnalysis(codes.Lines);
            if (result == 0)
            {
                showLog("词法分析结束，没有发现错误，开始语法分析。"
                    , true, LogType.INFO);
                int synResult = syntaxAnalysis();
                if (synResult == 0)
                {
                    showLog("语法分析结束，没有发现错误。", true, LogType.INFO);
                }
                else
                {
                    showLog("语法分析结束，发现了" + synResult.ToString()
                        + "个错误。", true, LogType.ERROR);
                }
            }
            else
            {
                showLog("词法分析结束，发现了" + result.ToString()
                    + "个错误，无法继续语法分析。", true, LogType.ERROR);
            }
            codes.Enabled = true;
        }

        private void codes_SelectionChanged(object sender, EventArgs e)
        {
            tips.Text = "行 " + (codes.GetLineFromCharIndex(codes.SelectionStart)
                + 1).ToString() + "    列 " + (codes.SelectionStart - codes
                .GetFirstCharIndexOfCurrentLine() + 1).ToString();
        }

        private void codes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isColorChanged && (e.KeyChar == 8
                || (e.KeyChar >= 32 && e.KeyChar <= 126)))
            {
                isColorChanged = false;
                int pos = codes.SelectionStart;
                codes.SelectAll();
                codes.SelectionBackColor = Color.White;
                codes.Select(pos, 0);
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdImportCode_Click(object sender, EventArgs e)
        {
            opener.Title = "请选择一个文本文件";
            opener.ShowDialog();
            string path = opener.FileName;
            if (path == null || path == "")
            {
                return;
            }
            try
            {
                FileStream stream = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(stream);
                codes.Text = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                showLog("成功导入文件\"" + path + "\"。");
            }
            catch (Exception)
            {
                showLog("无法打开文件\"" + path + "\"，请重试。", true, LogType.ERROR);
            }
        }

        private void cmdExportLog_Click(object sender, EventArgs e)
        {
            saver.Title = "请选择需要保存到的位置";
            saver.ShowDialog();
            string path = saver.FileName;
            if (path == null || path == "")
            {
                return;
            }
            try
            {
                FileStream stream = new FileStream(path, FileMode.Create);
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(logs.Text);
                writer.Close();
                stream.Close();
                showLog("已将日志保存到\"" + path + "\"。");
            }
            catch (Exception)
            {
                showLog("无法保存到文件\"" + path + "\"，请重试。", true, LogType.ERROR);
            }
        }

        private void GetLiters()
        {
            syntaxs.Items.Clear();
            showLog("已对您输入的文法进行分析。");
            int keyCount = frmLiter.Pairs.Count;
            for (int idx = 0; idx < keyCount; idx++)
            {
                string thisKey = frmLiter.Pairs.Keys.ElementAt(idx);
                string[] first = frmLiter.FirstSet[thisKey];
                string[] follow = frmLiter.FollowSet[thisKey];
                string[] valToAdd = new string[3];
                valToAdd[0] = thisKey;
                foreach (string val in first)
                {
                    valToAdd[1] += val + " ";
                }
                foreach (string val in follow)
                {
                    valToAdd[2] += val + " ";
                }
                syntaxs.Items.Add(new ListViewItem(valToAdd));
            }
        }

        private void CmdInputLit_Click(object sender, EventArgs e)
        {
            frmLiter.ShowDialog();
            if (!frmLiter.Changed)
            {
                return;
            }
            GetLiters();
        }

        private void CmdImportLit_Click(object sender, EventArgs e)
        {
            opener.Title = "请选择一个文本文件";
            opener.ShowDialog();
            string path = opener.FileName;
            if (path == null || path == "")
            {
                return;
            }
            try
            {
                FileStream stream = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(stream);
                frmLiter.input.Text = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                showLog("成功导入文件\"" + path + "\"。");
                frmLiter.ShowDialog();
                if (!frmLiter.Changed)
                {
                    return;
                }
                GetLiters();
            }
            catch (Exception)
            {
                showLog("无法打开文件\"" + path + "\"，请重试。", true, LogType.ERROR);
            }
        }
    }
}
/*
program->compoundstmt
stmt->decl | ifstmt | whilestmt | assgstmt | compoundstmt
compoundstmt->{ stmts }
stmts->stmt stmts | ε
ifstmt->if ( boolexpr ) then stmt else stmt
whilestmt->while ( boolexpr ) stmt
assgstmt->ID = arithexpr ;
decl->type list ;
type->int | real
list->ID list1
list1->, list | ε
boolexpr->arithexpr boolop arithexpr
boolop->< | > | <= | >= | ==
arithexpr->multexpr arithexprprime
arithexprprime->+ multexpr arithexprprime | - multexpr arithexprprime | ε
multexpr->simpleexpr multexprprime
multexprprime->* simpleexpr multexprprime | / simpleexpr multexprprime | ε
simpleexpr->ID | NUM | ( arithexpr )
  */


/*
E->T E'
E'->+ T E' | ε
T->F T'
T'->* F T' | ε
F->( E ) | ID
 */
