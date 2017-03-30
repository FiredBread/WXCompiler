using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Lex
    {
        private static int[,] lexTbl=new int[30,128];
	    private Dictionary<String, int> keyWordTbl = new Dictionary<String, int>();
        private String buffer; //保存token
        private int nonTerminal; //非终结状态编号
        private int pos,npos; //当前扫描到的位置
        public List<Token> mToken;//识别好的token存放列表
        private List<KeyValuePair<int, String>> error;
        KeyValuePair<int, String> lexErr;
        private int lineNum;
        private string type="NoType",value="NoValue";//类型和标识符和值
        private int domain = 0;//作用域
        private int tmp = 0;//临时记domain
        private int nnpos;

        private symbolTbl symtbl = new symbolTbl();//符号表对象 
        
        private void getErr(int row)
        {
            switch (row)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    lexErr = new KeyValuePair<int, string>(lineNum, "Wrong digital format.\n");
                    break;
                case 22:
                    lexErr = new KeyValuePair<int, string>(lineNum, "behind \'!\' must be \'=\'\n");
                    break;
            }
            error.Add(lexErr);
        }
        
        private int SearchKeyWord(String keyWord)
        {
            if (keyWordTbl.ContainsKey(keyWord))
                return keyWordTbl[keyWord];
            return -1;
        }

        //将识别好的token加入列表
        private void EmitToken(int id, String content, int num)
        {
            mToken.Add(new Token(id, content, num));
        }

        //识别过程 isNote 判断是否有//
        private Boolean Process(int row,int col,IntDeliver isNote)
        {
            Boolean isTrue = true;
            int iTag = lexTbl[row,col];
            int tmp = -1;
            
            if (iTag == -99)
            {
                getErr(row);
                isTrue = false;
            }
            if (iTag == 0)
            {
                buffer = buffer.Substring(0, buffer.Length - 1);
            }
            if (iTag < 0)   
            {
                buffer = buffer.Substring(0, buffer.Length - 1);
                pos--;
                if (iTag == -3)
                {
                    if (buffer.Length > 64)
                    {
                        lexErr = new KeyValuePair<int, string>(lineNum, "The maximum length of an identifier is 64 characters.\n");
                        error.Add(lexErr);
                        isTrue = false;
                    }
                    tmp = -1;
                    tmp = SearchKeyWord(buffer);
                    if (tmp >= 30)
                    {
                        EmitToken(tmp, buffer, lineNum);
                    }
                    else
                    {
                        EmitToken(3, buffer, lineNum);
           
                    }
                }
                else if (iTag == -7)
                    isNote.setPass(1);   
                else
                {
                    EmitToken(-iTag, buffer, lineNum);
                }
                buffer = "";
                nonTerminal = 0;
            }
            else
                nonTerminal = iTag;
            return isTrue;
        }

        //总的识别过程
        public Boolean GenToken(List<Token> aToken, String sql,int alineNum)
        {
            
            lineNum = alineNum;
            Boolean bTag = true;
            pos = 0;
            mToken = aToken;
           
            sql += ' ';
            nonTerminal = 0;
            buffer = "";
            mToken.Clear();
            
            while (pos < sql.Length)
            {
                
                buffer += sql[pos];
                int num = (int)sql[pos];
                Boolean tmpTag = true;
                IntDeliver val = new IntDeliver(0);
                tmpTag = Process(nonTerminal,num,val); 
                
 
                if(val.getPass() == 1)
                {
                    return true;
                }
                else if (!tmpTag)
                {
                    Console.WriteLine("词法分析错误，请检查单词拼写\n");
                    bTag = tmpTag;
                }
                pos++;
                
            }

            return bTag;
        }

        private void InitLex()
        {
            int i, j;
            for (i = 0; i < 30; i++)
            {
                for (j = 0; j < 128; j++)
                    lexTbl[i, j] = -99;
            }

            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[0, j] = 1;
            for (j = (int)('A'); j <= (int)('Z'); j++)
                lexTbl[0, j] = 10;
            for (j = (int)('a'); j <= (int)('z'); j++)
                lexTbl[0, j] = 10;
            lexTbl[0, (int)(' ')] = 0;
            lexTbl[0, 9] = 0;
            lexTbl[0, (int)('+')] = 11;
            lexTbl[0, (int)('-')] = 12;
            lexTbl[0, (int)('/')] = 13;
            lexTbl[0, (int)('*')] = 15;
            lexTbl[0, (int)('=')] = 16;
            lexTbl[0, (int)('<')] = 18;
            lexTbl[0, (int)('>')] = 20;
            lexTbl[0, (int)('!')] = 22;
            lexTbl[0, (int)('(')] = 24;
            lexTbl[0, (int)(')')] = 25;
            lexTbl[0, (int)('{')] = 26;
            lexTbl[0, (int)('}')] = 27;
            lexTbl[0, (int)(';')] = 28;
            lexTbl[0, (int)(',')] = 29;



            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[1, j] = 1;
            lexTbl[1, (int)('.')] = 2;
            lexTbl[1, (int)('E')] = 4;
            lexTbl[1, (int)('e')] = 4;
            lexTbl[1, 9] = -1;
            lexTbl[1, (int)(' ')] = -1;
            lexTbl[1, (int)('+')] = -1;
            lexTbl[1, (int)('-')] = -1;
            lexTbl[1, (int)('/')] = -1;
            lexTbl[1, (int)('*')] = -1;
            lexTbl[1, (int)('=')] = -1;
            lexTbl[1, (int)('<')] = -1;
            lexTbl[1, (int)('>')] = -1;
            lexTbl[1, (int)('!')] = -1;
            lexTbl[1, (int)(')')] = -1;
            lexTbl[1, (int)(';')] = -1;
            lexTbl[1, (int)('(')] = -1;
            lexTbl[1, (int)('{')] = -1;
            lexTbl[1, (int)('}')] = -1;
            lexTbl[1, (int)(',')] = -1;


            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[2, j] = 3;

            lexTbl[3, 9] = -2;
            lexTbl[3, (int)(' ')] = -2;
            lexTbl[3, (int)('+')] = -2;
            lexTbl[3, (int)('-')] = -2;
            lexTbl[3, (int)('/')] = -2;
            lexTbl[3, (int)('*')] = -2;
            lexTbl[3, (int)('=')] = -2;
            lexTbl[3, (int)('<')] = -2;
            lexTbl[3, (int)('>')] = -2;
            lexTbl[3, (int)('!')] = -2;
            lexTbl[3, (int)(')')] = -2;
            lexTbl[3, (int)(';')] = -2;
            lexTbl[3, (int)('(')] = -2;
            lexTbl[3, (int)('{')] = -2;
            lexTbl[3, (int)('}')] = -2;
            lexTbl[3, (int)(',')] = -2;
            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[3, j] = 3;
            lexTbl[3, (int)('e')] = 4;
            lexTbl[3, (int)('E')] = 4;

            lexTbl[4, (int)('+')] = 5;
            lexTbl[4, (int)('-')] = 7;
            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[4, j] = 9;

            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[5, j] = 6;

            lexTbl[6, 9] = -2;
            lexTbl[6, (int)(' ')] = -2;
            lexTbl[6, (int)('+')] = -2;
            lexTbl[6, (int)('-')] = -2;
            lexTbl[6, (int)('/')] = -2;
            lexTbl[6, (int)('*')] = -2;
            lexTbl[6, (int)('=')] = -2;
            lexTbl[6, (int)('<')] = -2;
            lexTbl[6, (int)('>')] = -2;
            lexTbl[6, (int)('!')] = -2;
            lexTbl[6, (int)(')')] = -2;
            lexTbl[6, (int)(';')] = -2;
            lexTbl[6, (int)('(')] = -2;
            lexTbl[6, (int)('{')] = -2;
            lexTbl[6, (int)('}')] = -2;
            lexTbl[6, (int)(',')] = -2;
            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[6, j] = 6;

            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[7, j] = 8;

            lexTbl[8, 9] = -2;
            lexTbl[8, (int)(' ')] = -2;
            lexTbl[8, (int)('+')] = -2;
            lexTbl[8, (int)('-')] = -2;
            lexTbl[8, (int)('/')] = -2;
            lexTbl[8, (int)('*')] = -2;
            lexTbl[8, (int)('=')] = -2;
            lexTbl[8, (int)('<')] = -2;
            lexTbl[8, (int)('>')] = -2;
            lexTbl[8, (int)('!')] = -2;
            lexTbl[8, (int)(')')] = -2;
            lexTbl[8, (int)(';')] = -2;
            lexTbl[8, (int)('(')] = -2;
            lexTbl[8, (int)('{')] = -2;
            lexTbl[8, (int)('}')] = -2;
            lexTbl[8, (int)(',')] = -2;
            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[8, j] = 8;

            lexTbl[9, 9] = -2;
            lexTbl[9, (int)(' ')] = -2;
            lexTbl[9, (int)('+')] = -2;
            lexTbl[9, (int)('-')] = -2;
            lexTbl[9, (int)('/')] = -2;
            lexTbl[9, (int)('*')] = -2;
            lexTbl[9, (int)('=')] = -2;
            lexTbl[9, (int)('<')] = -2;
            lexTbl[9, (int)('>')] = -2;
            lexTbl[9, (int)('!')] = -2;
            lexTbl[9, (int)(')')] = -2;
            lexTbl[9, (int)(';')] = -2;
            lexTbl[9, (int)('(')] = -2;
            lexTbl[9, (int)('{')] = -2;
            lexTbl[9, (int)('}')] = -2;
            lexTbl[9, (int)(',')] = -2;
            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[9, j] = 9;

            for (j = 0; j < 128; j++)
                lexTbl[10, j] = -3;
            for (j = (int)('0'); j <= (int)('9'); j++)
                lexTbl[10, j] = 10;
            for (j = (int)('a'); j <= (int)('z'); j++)
                lexTbl[10, j] = 10;
            for (j = (int)('A'); j <= (int)('Z'); j++)
                lexTbl[10, j] = 10;


            for (j = 0; j < 128; j++)
                lexTbl[11, j] = -4;

            for (j = 0; j < 128; j++)
                lexTbl[12, j] = -5;

            for (j = 0; j < 128; j++)
                lexTbl[13, j] = -6;
            lexTbl[13, (int)('/')] = 14;

            for (j = 0; j < 128; j++)
                lexTbl[14, j] = -7;

            for (j = 0; j < 128; j++)
                lexTbl[15, j] = -8;

            for (j = 0; j < 128; j++)
                lexTbl[16, j] = -9;
            lexTbl[16, (int)('=')] = 17;

            for (j = 0; j < 128; j++)
                lexTbl[17, j] = -10;

            for (j = 0; j < 128; j++)
                lexTbl[18, j] = -11;
            lexTbl[18, (int)('=')] = 19;

            for (j = 0; j < 128; j++)
                lexTbl[19, j] = -12;

            for (j = 0; j < 128; j++)
                lexTbl[20, j] = -13;
            lexTbl[20, (int)('=')] = 21;

            for (j = 0; j < 128; j++)
                lexTbl[21, j] = -14;

            lexTbl[22, (int)('=')] = 23;

            for (j = 0; j < 128; j++)
                lexTbl[23, j] = -15;

            lexTbl[24, (int)(' ')] = -16;
            for (j = 0; j < 128; j++)
                lexTbl[24, j] = -16;

            for (j = 0; j < 128; j++)
                lexTbl[25, j] = -17;

            for (j = 0; j < 128; j++)
                lexTbl[26, j] = -18;

            for (j = 0; j < 128; j++)
                lexTbl[27, j] = -19;

            for (j = 0; j < 128; j++)
                lexTbl[28, j] = -20;

            for (j = 0; j < 128; j++)
                lexTbl[29, j] = -21;
        }
        private void InitKeyWord()
        {
            keyWordTbl.Add("int", 30);
            keyWordTbl.Add("real", 31);
            keyWordTbl.Add("if", 32);
            keyWordTbl.Add("then", 33);
            keyWordTbl.Add("else", 34);
            keyWordTbl.Add("while", 35);


        }
        public Lex(List<KeyValuePair<int, String>> aError)
        {
            InitLex();
            InitKeyWord();
            error = aError;
           
        }

       public void createSymtbl(List<Token> tokenList)//创建符号表
        {
            
            int count = 0;//对while后面小括号匹配对数计数
            int tmppos = 0;//临时计数while小括号token
            while (npos < tokenList.Count())
            {
               
                if (tokenList[npos].getID() == 18)
                {
                    domain++;
                    tmp = domain;
                }
                else if ((tokenList[npos].getID() == 33 || tokenList[npos].getID() == 34) && tokenList[npos + 1].getID() != 18)
                {
                    domain++;
                    tmp = domain;
                    
                }
                else if (tokenList[npos].getID() == 35)
                {
                    if (tokenList[npos + 1].getID() == 16)
                    {
                        count = 1;
                        tmppos = 1;
                    }
              
                    while (count != 0)
                    {
                            
                            if (tokenList[npos + tmppos + 1].getID() == 16)
                                count++;
                            else if (tokenList[npos + tmppos + 1].getID() == 17)
                                count--;
                            tmppos++;
                        if (npos + tmppos + 1 >= tokenList.Count)
                            break;
                        
                    }
                    nnpos = npos + tmppos +1;
                   
                }
                else if (tokenList[npos].getID() == 19)
                    tmp = domain - 1;
               else if (npos == nnpos && tokenList[npos ].getID() != 18)
                {
                    domain++;
                    tmp = domain;
                    
                }

                if ((tokenList[npos].getID() == 30 || tokenList[npos].getID() == 31) && tokenList[npos + 1].getID() == 3)
                {
                    symtbl.CreateSymbolTbl(tokenList[npos+1].getContent(), type, tokenList[npos+1].getLineNum(), value, tmp);
                    
                    int i = 1;
                    while (tokenList[npos + i + 1].getID() != 20)
                    {
                        symtbl.CreateSymbolTbl(tokenList[npos + i+2].getContent(), type, tokenList[npos+i+2].getLineNum(), value, tmp);
                       
                        i += 2;
                    }
                }

                if (tokenList[npos].getID() == 3)        
                     symtbl.setallID(tokenList[npos].getContent());
                npos++;
            }
        }
    }
}
