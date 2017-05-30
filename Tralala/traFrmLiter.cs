using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tralala
{
    public partial class traFrmLiter : Form
    {
        private Dictionary<string, string[]> firstSet;
        private Dictionary<string, string[]> followSet;
        private Dictionary<string, string[]> pairs;
        private Stack<string> followCallStack;
        private string oldInputs = "";
        private bool changed = false;
        public bool Changed
        {
            get { return changed; }
        }
        public Dictionary<string, string[]> FirstSet
        {
            get { return firstSet; }
        }
        public Dictionary<string, string[]> FollowSet
        {
            get { return followSet; }
        }
        public Dictionary<string, string[]> Pairs
        {
            get { return pairs; }
        }
        private char[] innerSpliter = new char[] { ' ' };
        private static string[] terminalSymbols = 
            { "{", "}", "if", "(", ")", "then", "else", "while", "ID",
            "=", ";", "int", "real", "<", ">", "<=", ">=", "==",
            "+", "-", "*", "/", ",", "NUM" };
        public traFrmLiter()
        {
            InitializeComponent();
            followCallStack = new Stack<string>();
        }

        private bool IsTerminal(string symbol)
        {
            return terminalSymbols.Contains(symbol);
        }

        private string[] FindFirst(string left)
        {
            if (firstSet.ContainsKey(left))
            {
                return firstSet[left];
            }
            string[] right;
            try
            {
                right = pairs[left];
            }
            catch (Exception)
            {
                throw new ArgumentException("无法识别的符号：" + left);
            }
            List<string> result = new List<string>(5);
            foreach (string thisRight in right)
            {
                string[] subRight = thisRight.Split(innerSpliter, StringSplitOptions.RemoveEmptyEntries);
                if (subRight.Length == 0)
                {
                    MessageBox.Show("非终结符\"" + left + "\"的产生式不合法！",
                        "文法错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new ArgumentException("");
                }
                if (IsTerminal(subRight[0]) || subRight[0] == "ε")
                {
                    result.Add(subRight[0]);
                }
                else
                {
                    if (firstSet.ContainsKey(subRight[0]))
                    {
                        result.AddRange(firstSet[subRight[0]]);
                    }
                    else
                    {
                        string[] tmpArr = FindFirst(subRight[0]);
                        result.AddRange(tmpArr);
                        firstSet.Add(subRight[0], tmpArr);
                    }
                }
            }
            return result.ToArray();
        }

        private string[] FindFollow(string left, bool isFirst = false)
        {
            if (followSet.ContainsKey(left))
            {
                return followSet[left];
            }
            followCallStack.Push(left);
            HashSet<string> result = new HashSet<string>();
            if (isFirst)
            {
                result.Add("$");
            }
            for (int it = 0; it < pairs.Count; it++)
            {
                KeyValuePair<string, string[]> thisPair = pairs.ElementAt(it);
                if (thisPair.Key == left)
                {
                    continue;
                }
                for (int idx = 0; idx < thisPair.Value.Length; idx++)
                {
                    string[] symbols = thisPair.Value[idx].Split(innerSpliter, StringSplitOptions.RemoveEmptyEntries);
                    for (int subIdx = 0; subIdx < symbols.Length; subIdx++)
                    {
                        if (symbols[subIdx] == left)
                        {
                            bool hasEndSym = false;
                            if (subIdx < symbols.Length - 1)
                            {
                                if (IsTerminal(symbols[subIdx + 1]))
                                {
                                    result.Add(symbols[subIdx + 1]);
                                    continue;
                                }
                                else if (firstSet.ContainsKey(symbols[subIdx + 1]))
                                {
                                    foreach (string str in firstSet[symbols[subIdx + 1]])
                                    {
                                        if (str == "ε")
                                        {
                                            hasEndSym = true;
                                        }
                                        else
                                        {
                                            result.Add(str);
                                        }
                                    }
                                }
                                else
                                {
                                    throw new ArgumentException("无法解析字符：" + symbols[subIdx + 1]);
                                }
                            }
                            if ((hasEndSym || subIdx == symbols.Length - 1) && !followCallStack.Contains(thisPair.Key))
                            {
                                string[] tmpSet = null;
                                if (followSet.ContainsKey(thisPair.Key))
                                {
                                    tmpSet = followSet[thisPair.Key];
                                }
                                else
                                {
                                    tmpSet = FindFollow(thisPair.Key);
                                }
                                foreach (string str in tmpSet)
                                {
                                    result.Add(str);
                                }
                            }
                        }
                    }
                }
            }
            followCallStack.Pop();
            return result.ToArray();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            int lines = input.Lines.Length;
            string[] spliter = new string[] { "->" };
            char[] subSpliter = new char[] { '|' };
            firstSet = new Dictionary<string, string[]>(lines);
            followSet = new Dictionary<string, string[]>(lines);
            pairs = new Dictionary<string, string[]>(lines);
            foreach (string str in input.Lines)
            {
                if (str == "")
                {
                    continue;
                }
                string[] result = str.Split(spliter, StringSplitOptions.RemoveEmptyEntries);
                if (result.Length != 2)
                {
                    MessageBox.Show("文法\"" + str + "\"不符合规则！",
                        "文法错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                pairs.Add(result[0].Trim(), result[1].Split(subSpliter, StringSplitOptions.RemoveEmptyEntries));
            }
            try
            {
                foreach (string thisKey in pairs.Keys)
                {
                    string[] ret = FindFirst(thisKey);
                    if (!firstSet.ContainsKey(thisKey))
                    {
                        firstSet.Add(thisKey, ret);
                    }
                }
                followSet.Add(pairs.ElementAt(0).Key, FindFollow(pairs.ElementAt(0).Key, true));
                foreach (string thisKey in pairs.Keys)
                {
                    followCallStack.Clear();
                    string[] ret = FindFollow(thisKey);
                    if (!followSet.ContainsKey(thisKey))
                    {
                        followSet.Add(thisKey, ret);
                    }
                }
                changed = true;
                oldInputs = input.Text;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message,
                    "文法错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void traFrmLiter_Load(object sender, EventArgs e)
        {
            changed = false;
        }

        private void traFrmLiter_FormClosing(object sender, FormClosingEventArgs e)
        {
            input.Text = oldInputs;
        }
    }
}
