using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tralala
{
    enum tokenType
    {
        INVALID = 0,
        COMMENT = 1,
        NUMBER = 2,
        SUBNUM1 = 3,
        SUBNUM2 = 4,
        KEYWORD = 5,
        IDENTIFIER = 6,
        OPERATOR = 7,
        DELIMITER = 8
    };

    class Token
    {
        public string value;
        public tokenType type;
        public int lineNumber;
        public int index;
        public string[] toStrArr()
        {
            string str = "";
            switch (type)
            {
                case tokenType.COMMENT:
                    str = "注释";
                    break;
                case tokenType.NUMBER:
                case tokenType.SUBNUM1:
                case tokenType.SUBNUM2:
                    str = "数字";
                    break;
                case tokenType.KEYWORD:
                    str = "关键词";
                    break;
                case tokenType.IDENTIFIER:
                    str = "标识符";
                    break;
                case tokenType.OPERATOR:
                    str = "操作符";
                    break;
                case tokenType.DELIMITER:
                    str = "分隔符";
                    break;
            }
            return new string[] { value, str, lineNumber.ToString(), (index + 1).ToString() };
        }
    }
}
