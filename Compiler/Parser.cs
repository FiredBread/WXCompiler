using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Parser
    {
        private int[,] parseTbl = new int[19, 36];//LL表
        private List<String> productList = new List<String>();//LL表联合使用
        private Stack<KeyValuePair<int, int>> parseStack = new Stack<KeyValuePair<int, int>>();//语法栈
        private List<Token> tokenList;
        private List<KeyValuePair<int, String>> error;
        KeyValuePair<int, String> parseErr;
        private Dictionary<int, String> cat = new Dictionary<int, string>();
        private KeyValuePair<int, int> treeTab;
        private String[] nonTerm = new String[19];
        private symbolTbl symbtab = new symbolTbl();
        private int domain = 0;//作用域判断
        private int tmp = 0;//临时记domain
  

        public List<String> parseTree = new List<String>();//语法树
        private String oneOfTree="";

        private void InitNonTerm()
        {
            nonTerm[1] = "program";
            nonTerm[2] = "stmt";
            nonTerm[3] = "compoundstmt";
            nonTerm[4] = "stmts";
            nonTerm[5] = "ifstmt";
            nonTerm[6] = "whilestmt";
            nonTerm[7] = "assgstmt";
            nonTerm[8] = "decl";
            nonTerm[9] = "type";
            nonTerm[10] = "list";
            nonTerm[11] = "list1";
            nonTerm[12] = "boolexpr ";
            nonTerm[13] = "boolop";
            nonTerm[14] = "arithexpr";
             nonTerm[15] = "arithexprprime";
            nonTerm[16] = "multexpr";
            nonTerm[17] = "multexprprime";
            nonTerm[18] = "simpleexpr";
        }

        private void InitParseTbl()//产生式横坐标表示编号，纵坐标表示种别码
        {
            int i, j;
            for (i = 0; i < 19; i++)
                for (j = 0; j < 36; j++)
                    parseTbl[i, j] = -1;
            parseTbl[1,18]=1;
            parseTbl[2,30]=2;
            parseTbl[2,31]=2;
            parseTbl[2,18]=6;
            parseTbl[2,32]=3;
            parseTbl[2,35]=4;
            parseTbl[2,3]=5;
            parseTbl[3,18]=7;
            parseTbl[4,18]=8;
            parseTbl[4,19]=9;
            parseTbl[4,30]=8;
            parseTbl[4,31]=8;
            parseTbl[4,32]=8;
            parseTbl[4,35]=8;
            parseTbl[4,3]=8;
            parseTbl[5,32]=10;
            parseTbl[6,35]=11;
            parseTbl[7,3]=12;
            parseTbl[8,30]=13;
            parseTbl[8,31]=13;
            parseTbl[9,30]=14;
            parseTbl[9,31]=15;
            parseTbl[10,3]=16;
            parseTbl[11,21]=17;
            parseTbl[11,20]=18;
            parseTbl[12,16]=19;
            parseTbl[12,3]=19;
            parseTbl[12,1]=19;
            parseTbl[12,2]=19;
            parseTbl[13,11]=20;
            parseTbl[13,13]=21;
            parseTbl[13,12]=22;
            parseTbl[13,14]=23;
            parseTbl[13,10]=24;
            parseTbl[13,15]=37;
            parseTbl[14,16]=25;
            parseTbl[14,3]=25;
            parseTbl[14,1]=25;
            parseTbl[14,2]=25;
            parseTbl[15,17]=28;
            parseTbl[15,20]=28;
            parseTbl[15,10]=28;
            parseTbl[15,11]=28;
            parseTbl[15,12]=28;
            parseTbl[15,13]=28;
            parseTbl[15,14]=28;
            parseTbl[15,15] = 28;
            parseTbl[15,4]=26;
            parseTbl[15,5]=27;
            parseTbl[16,16]=29;
            parseTbl[16,3]=29;
            parseTbl[16,1]=29;
            parseTbl[16,2]=29;
            parseTbl[17,17]=32;
            parseTbl[17,4]=32;
            parseTbl[17,5]=32;
            parseTbl[17,20]=32;
            parseTbl[17,10]=32;
            parseTbl[17,11]=32;
            parseTbl[17,12]=32;
            parseTbl[17,13]=32;
            parseTbl[17,14]=32;
            parseTbl[17, 15] = 32;
            parseTbl[17,8]=30;
            parseTbl[17,6]=31;
            parseTbl[18,16]=36;
            parseTbl[18,3]=33;
            parseTbl[18,1]=34;
            parseTbl[18,2]=35;       
        }

        private void InitProductList()//共37条产生式 数字代表的是产生式右边的内容101在下面用的时候初始化
        {/*这里找对应产生式的行编号，传递到parseTbl里面去找下一个产生式的编号返回到这里对应产生式编号的list值，然后继续像前面一样*/
            productList.Add("103");//1>>3
            productList.Add("108");//2>>8
            productList.Add("105");//3>>5
            productList.Add("106");//4>>6
            productList.Add("107");//5>>7
            productList.Add("103");//6>>3
            productList.Add("018104019");//7>>4
            productList.Add("102104");//8>> 2&4
            productList.Add("000");//9>>空
            productList.Add("032016112017033102034102");//10>>12&2&2
            productList.Add("035016112017102");//11>>12&2
            productList.Add("003009114020");//12>>14
            productList.Add("109110020");//13>>9&10
            productList.Add("030");//14>>int
            productList.Add("031");//15>>real
            productList.Add("003111");//16>>11
            productList.Add("021110");//17>>10
            productList.Add("000");//18>>空
            productList.Add("114113114");//19>>14&13&14
            productList.Add("011");//20>> <
            productList.Add("013");//21>> >
            productList.Add("012");//22>> <=
            productList.Add("014");//23>> >=
            productList.Add("010");//24>> ==
            productList.Add("116115");//25>>16&15
            productList.Add("004116115");//26>>16&15
            productList.Add("005116115");//27>>16&15
            productList.Add("000");//28>>空
            productList.Add("118117");//29>>18&17
            productList.Add("008118117");//30>>18&&17
            productList.Add("006118117");//31>>18&17
            productList.Add("000");//32>>空
            productList.Add("003");//33>> ID
            productList.Add("001");//34>> INT
            productList.Add("002");//35>> REAL
            productList.Add("016114017");//36>>14
            productList.Add("015");//37>> !=
        }

        private void InitCat()//种别码
        {
            cat.Add(1,"INT");
            cat.Add(2, "REAL");
            cat.Add(3, "ID");
            cat.Add(4, "+");
            cat.Add(5, "-");
            cat.Add(6, "/");
            cat.Add(7, "//");
            cat.Add(8, "*");
            cat.Add(9, "=");
            cat.Add(10, "==");
            cat.Add(11, "<");
            cat.Add(12, "<=");
            cat.Add(13, ">");
            cat.Add(14, ">=");
            cat.Add(15, "!=");
            cat.Add(16, "(");
            cat.Add(17, ")");
            cat.Add(18, "{");
            cat.Add(19, "}");
            cat.Add(20, ";");
            cat.Add(21, ",");
            cat.Add(22, ".");
            cat.Add(30, "int");
            cat.Add(31, "real");
            cat.Add(32, "if");
            cat.Add(33, "then");
            cat.Add(34, "else");
            cat.Add(35, "while");
        }

        public Parser(List<Token> aToken, List<KeyValuePair<int,String>> aError)
        {
            InitParseTbl();
            InitProductList();
            InitNonTerm();
            InitCat();
            tokenList = aToken;
            error = aError;
            
              
        }
      

        private void EnStack(String product, int tabNum)
        {
            if (product.Length <= 0)
            {
                return;
            }
            for (int i = product.Length - 3; i >= 0; i = i - 3)
            {
                treeTab = new KeyValuePair<int, int>(Convert.ToInt32(product.Substring(i, 3)), tabNum);
                parseStack.Push(treeTab);
            }
        }//压栈

        private Boolean DeStack(IntDeliver top, IntDeliver tab)
        {
            if (parseStack.Count == 0)
                return false;
            else
            {
                treeTab = parseStack.Pop();
                top.setPass(treeTab.Key);
                tab.setPass(treeTab.Value);
                return true;
            }
        }//弹栈

        
        public Boolean SyntaxParse()//语法分析
        {
            Boolean bTag = true;
            int row = 0;
            int col = 0;
            IntDeliver val = new IntDeliver(0);
            IntDeliver valNum = new IntDeliver(0);
            int pos = 0;
            int afterOne = 0;
            parseStack.Clear();
            EnStack(productList[0], 0);
            if (tokenList.Count == 0)
            {
                Console.WriteLine("请输入代码");
                parseErr = new KeyValuePair<int, string>(0, " There have no code to compile.\n");
                error.Add(parseErr);
                return false;
            }
            while (parseStack.Count > 0 && pos < tokenList.Count)
            {
                if (DeStack(val, valNum))
                {
                    if (val.getPass() == 0)
                    {
                        for (int num = 0; num < valNum.getPass(); num++)
                            oneOfTree += "    ";
                        oneOfTree += "&\n";
                        parseTree.Add(oneOfTree);
                        oneOfTree = "";
                        continue;
                    }

                    else if (val.getPass() < 100)
                    {

                        if (val.getPass() == tokenList[pos].getID())
                        {
                            for (int num = 0; num < valNum.getPass(); num++)
                                oneOfTree += "    ";
                            oneOfTree += tokenList[pos].getContent() + '\n';
                            parseTree.Add(oneOfTree);
                            oneOfTree = "";

                            pos++;
                        }
                        else
                        {

                            int num = tokenList[pos - 1].getLineNum();
                            String str = cat[val.getPass()];
                            parseErr = new KeyValuePair<int, string>(num, "Expects " + str + " behind " + tokenList[pos - 1].getContent() + '\n');
                            error.Add(parseErr);
                            bTag = false;
                            if (val.getPass() != 20)
                            {
                                while (DeStack(val, valNum))
                                {
                                    if (val.getPass() < 100)
                                        afterOne++;
                                    if (val.getPass() == 20)
                                        break;
                                }
                                if (tokenList[pos].getID() != 20 && afterOne != 1)
                                    pos++;
                                if (tokenList[pos].getID() == 20)
                                    pos++;
                                afterOne = 0;
                            }
                        }
                    }

                    else if (val.getPass() >= 101 && val.getPass() < 200)
                    {
                        col = tokenList[pos].getID();
                        row = val.getPass() - 100;

                        int tmp = parseTbl[row, col];
                        if (tmp == -1)
                        {

                            getErr(row, pos);
                            if (val.getPass() != 20)
                            {
                                while (DeStack(val, valNum))
                                {
                                    if (val.getPass() < 100)
                                        afterOne++;
                                    if (val.getPass() == 20)
                                        break;
                                }
                                if (tokenList[pos].getID() != 20 && afterOne != 1)
                                    pos++;
                                if (tokenList[pos].getID() == 20)
                                    pos++;
                                afterOne = 0;
                            }
                            if (row == 1)
                            {
                                EnStack(productList[0], 0);
                            }
                            bTag = false;
                        }
                        else
                        {
                            EnStack(productList[tmp - 1], valNum.getPass() + 1);
                            for (int num = 0; num < valNum.getPass(); num++)
                                oneOfTree += "    ";
                            oneOfTree += nonTerm[val.getPass() - 100] + '\n';
                            parseTree.Add(oneOfTree);
                            oneOfTree = "";
                        }
                    }
                }
            }
            while (DeStack(val, valNum))
            {
                bTag = false;
                if (val.getPass() < 100)
                {
                    int num = tokenList[pos - 1].getLineNum();
                    Console.WriteLine(val.getPass());
                    String str = cat[val.getPass()];
                    parseErr = new KeyValuePair<int, string>(num, "Expects " + str + " behind " + tokenList[pos - 1].getContent() + '\n');
                    error.Add(parseErr);
                }


            }
            updatesymtbl();//语法检测完后更新符号表
            symbtab.remove();//移除异常


            return bTag;
        }
        private void getErr(int row, int pos)
        {
            int num = pos == 0 ? tokenList[pos].getLineNum() : tokenList[pos - 1].getLineNum();
            switch(row)
            {
                case 1:
                    parseErr = new KeyValuePair<int, string>(num, "Code must start with \'{\'.\n");
                    break;
                case 2:
                    parseErr = new KeyValuePair<int, string>(num, "2Expect  decl | ifstmt  |  whilestmt  |  assgstmt  |  compoundstmt behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
                case 3:
                    parseErr = new KeyValuePair<int, string>(num, "Expect \'{\' in front of " + tokenList[pos].getContent() + '\n');
                    break;
                case 4:
                    parseErr = new KeyValuePair<int, string>(num, "4Expect  decl | ifstmt  |  whilestmt  |  assgstmt  |  compoundstmt or \'{\' behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
                case 5:
                    parseErr = new KeyValuePair<int, string>(num, "Expect ifstmt behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
                case 6:
                    parseErr = new KeyValuePair<int, string>(num, "Expect whilestmt behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
                case 7:
                    parseErr = new KeyValuePair<int, string>(num, "Expect assignment behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
                case 8:
                    parseErr = new KeyValuePair<int, string>(num, "Expect declaration behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
                case 9:
                    parseErr = new KeyValuePair<int, string>(num, "Expect \"int\" or \"real\" behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
                case 10:
                    parseErr = new KeyValuePair<int, string>(num, "Expect identitor behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
                case 11:
                    parseErr = new KeyValuePair<int, string>(num, "Expect \',\' or \';\' behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
                case 12:
                case 13:
                    parseErr = new KeyValuePair<int, string>(num, "Expect comparison expression behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
           
                case 18:
                    parseErr = new KeyValuePair<int, string>(num, "Expect identitor number or \'(\' behind " + tokenList[pos - 1].getContent() + '\n');
                    break;
                case 14:            
                case 15:
                case 16:
                case 17:
                    parseErr = new KeyValuePair<int, string>(num, "Expect arithmetic expression or \';\' behind " + tokenList[pos - 1].getContent() + '\n');
                    break;          
            }
            error.Add(parseErr);
        }//语法报错处理

        private void updatesymtbl()//更新符号表
        {
            int pos = 0;
            int count = 0;//对while后面小括号匹配对数计数
            int tmppos = 0;//临时计数while小括号token
            while (pos < tokenList.Count)
            {
               
                if (tokenList[pos].getID() == 18)
                {
                    domain++;
                    tmp = domain;
                }
                else if ((tokenList[pos].getID() == 33 || tokenList[pos].getID() == 34) && tokenList[pos + 1].getID() != 18)
                {
                    domain++;
                    tmp = domain;
                }
                else if (tokenList[pos].getID() == 35)
                {
                    if (tokenList[pos + 1].getID() == 16)
                    {
                        count = 1;
                        tmppos = 1;
                    }
                    while (count != 0)
                    {
                        if (tokenList[pos + tmppos + 1].getID() == 16)
                            count++;
                        else if (tokenList[pos + tmppos + 1].getID() == 17)
                            count--;
                        tmppos++;
                        if (pos + tmppos + 1 >= tokenList.Count)
                            break;
                    }
                    tmppos = pos + tmppos +1; 
                }
                else if (tokenList[pos].getID() == 19)
                    tmp = domain - 1;
               else if (pos == tmppos && pos != 0 && tokenList[pos ].getID() != 18)
                {
                    domain++;
                    tmp = domain;
                }

                if (tokenList[pos].getID() == 3 && tokenList[pos + 1].getID() == 9 && (tokenList[pos + 2].getID() == 1 || tokenList[pos + 2].getID() == 2) && tokenList[pos + 3].getID() == 20)//判断是否为赋值语句
                    symbtab.updateValue(tokenList[pos].getContent(), tokenList[pos + 2].getContent(), tmp);
                else if ((tokenList[pos].getID() == 30 || tokenList[pos].getID() == 31) && tokenList[pos + 1].getID() == 3) {
                    symbtab.updateType(tokenList[pos + 1].getContent(), tokenList[pos].getContent(), tmp);
                    int i = 1;
                    while (tokenList[pos + i+1].getID() !=20)
                    {                       
                        symbtab.updateType(tokenList[pos + i+2].getContent(), tokenList[pos].getContent(), tmp);
                        i += 2;
                    }
                }
                pos++;

            }
        }

     
     
    }
}
