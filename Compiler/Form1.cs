using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler
{
    public partial class Compiler : DMSkin.Main
    {
        public Compiler()
        {
            InitializeComponent();
        }

        private String[] lines;
        private Boolean windowsstate = false;
        private symbolTbl symtbl = new symbolTbl();//符号表对象 
        private Semantic semantic = new Semantic();
        public  string identior , type , value ;
        public int linenum = 0;
        public int domain = 0;
        private  List<Token> tokenList;
        private List<String> tree;
        private void dmButtonClose1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void dmButtonMin1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lexButton_Click(object sender, EventArgs e)
        {
            if (tokenList == null||tokenList.Count==0)
                MessageBox.Show("未进行编译，无法显示词法分析输出！\n请先进行编译！", "Compile Error");
            else
            {
                Form2 lexForm = new Form2();
                lexForm.label.Text = "Token列表";
                lexForm.Text = "词法分析输出";
                lexForm.Show();
                lexForm.textbox.Text += "词法单元           类型          行号  \n";
                foreach (Token token in tokenList)
                {
                    switch (token.getID())
                    {
                        case 1:
                        case 2:
                            lexForm.textbox.Text += "【" + token.getContent() + "】 " + "     |     numbers      |    " + token.getLineNum() + "\n";
                            break;
                        case 3:
                            lexForm.textbox.Text += "【" + token.getContent() + "】 " + "     |     identifiter     |    " + token.getLineNum() + "\n";
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            lexForm.textbox.Text += "【" + token.getContent() + "】 " + "     |     operator     |    " + token.getLineNum() + "\n";
                            break;
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                            lexForm.textbox.Text += "【" + token.getContent() + "】 " + "     |     delimiter     |    " + token.getLineNum() + "\n";
                            break;
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                            lexForm.textbox.Text += "【" + token.getContent() + "】 " + "     |     keyword     |    " + token.getLineNum() + "\n";
                            break;
                        default: break;
                    }
                }
            }
        }

        private void symbolButton_Click(object sender, EventArgs e)
        {
            int size = symtbl.getsize();
            if (size == 0)
                MessageBox.Show("未进行编译无法显示符号表！\n请先进行编译!", "Compile Error");
            else
            {
                Form2 symbolForm = new Form2();
                symbolForm.label.Text = "符号表";
                symbolForm.Text = "符号表显示";
                symbolForm.Show();
                /*下面为符号表显示代码*/
                symbolForm.textbox.Text = "标识符名称   " + "类型   " + "行号   " + "值   " + "作用域   \n";

                if (size != 0)
                    for (int i = 0; i < size; i++)
                    {
                      
                        symtbl.getSymbolTbl(i);
                        this.identior = symtbl.identior;
                        this.type = symtbl.type;
                        this.linenum = symtbl.linenum;
                        this.value = symtbl.value;
                        this.domain = symtbl.domain;
                      
                            symbolForm.textbox.AppendText(identior + "   |   " + type + "    |   " + linenum + "   |   " + value + "   |   " + domain + "\n");
                    }
                /*符号表显示代码结束*/
            }
        }

        private void parseButton_Click(object sender, EventArgs e)
        {
            if (tree == null||tree.Count==0)
                MessageBox.Show("还未进行编译无法显示语法树！\n请先进行编译！","Compile Error");
            else
            {
                Form2 parseForm = new Form2();
                parseForm.label.Text = "语法树";
                parseForm.Text = "语法树显示";
                parseForm.Show();

                foreach (String str in tree)
                {
                    parseForm.textbox.Text += str;

                }
            }
        }

        private void Compiler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (windowsstate == false)
            {
                this.WindowState = FormWindowState.Maximized;
                hirtreeTextBox.SetBounds(7,48,1300,300);
                label3.SetBounds(7,394+300-336,71,15);
                errrorTextBox.SetBounds(7, 412 + 300 - 336, 1300,440);
                fileButton.SetBounds(845 + 500, 48, 125, 45);
                startButton.SetBounds(845+500, 101, 125, 45);
                lexButton.SetBounds(845+500, 237,125,45);
                parseButton.SetBounds(845+500, 288, 125, 45);
                symbolButton.SetBounds(845+500, 339, 125, 45);
                dmButtonClose1.SetBounds(1506, 0, 30, 27);
                dmButtonMin1.SetBounds(1476, 0, 30, 27);
                windowsstate = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                hirtreeTextBox.SetBounds(7, 48, 800, 336);
                label3.SetBounds(7, 394 , 71, 15);
                errrorTextBox.SetBounds(7, 412 , 800, 150);
                fileButton.SetBounds(845 , 48, 125, 45);
                startButton.SetBounds(845, 101, 125, 45);
                lexButton.SetBounds(845, 237, 125, 45);
                parseButton.SetBounds(845, 288, 125, 45);
                symbolButton.SetBounds(845, 339, 125, 45);
                dmButtonClose1.SetBounds(970 , 0, 30, 27);
                dmButtonMin1.SetBounds(940 , 0, 30, 27);
                windowsstate = false;
            }
        }

        private void fileButton_Click(object sender, EventArgs e)
        {           
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() ==  DialogResult.OK)
            {
                hirtreeTextBox.Text = "";
                symtbl.clearsymboltbl();//清空符号表
                string path = ofd.FileName;
                lines = File.ReadAllLines(path, Encoding.GetEncoding("gb2312"));
                for(int i=0; i < lines.Length; i++)
                {
                    hirtreeTextBox.Text += lines[i] + '\n';
                }
            }         
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            symtbl.clearsymboltbl();//清空符号表
            semantic.clearerrorhsah();

            errrorTextBox.Text = "";

            tokenList = new List<Token>();
            List<KeyValuePair<int, String>> error = new List<KeyValuePair<int, string>>();
            String[] alines = hirtreeTextBox.Text.Split('\n');
            errrorTextBox.Text += "====================Start compile(compiler: WX compiler)====================\n";
            Lex lex = new Lex(error);
            Boolean err = true;
            for (int i = 0; i < alines.Length; i++)
            {
                List<Token> lineTokenList = new List<Token>();
                if (!lex.GenToken(lineTokenList, alines[i], i + 1))
                {
                    err = false;
                }
                tokenList.AddRange(lineTokenList);
            }
            lex.createSymtbl(tokenList);//创建符号表

            if (!err)
            {
                foreach (KeyValuePair<int, String> mst in error)
                {
                    errrorTextBox.Text += " Lexical Error in line:" + mst.Key + "    " + mst.Value;
                }
                errrorTextBox.Text += " lexical analysis error(s) have been detected.\n";
                errrorTextBox.Text += "====================compile finish====================\n";
                return;
            }
            errrorTextBox.Text += " lexical analysis pass!\n";
            errrorTextBox.Text += '\n';
            error.Clear();
            Parser parse = new Parser(tokenList, error);
            tree = parse.parseTree;
            if (parse.SyntaxParse())
                errrorTextBox.Text += " syntax analysis pass!\n";
            else
            {
                List<KeyValuePair<int, String>> tmpErr = new List<KeyValuePair<int, string>>();
                foreach (KeyValuePair<int, String> mst in error)
                {
                    if (!tmpErr.Contains(mst))
                        tmpErr.Add(mst);
                }

                foreach (KeyValuePair<int, String> mst in tmpErr)
                {
                    if (mst.Key != 0)
                    {           
                        errrorTextBox.Text += " syntax Error in line:" + mst.Key + "    " + mst.Value;
                    }
                    else
                        errrorTextBox.Text += mst.Value;
                }
                errrorTextBox.Text += " syntax analysis error(s) have been detected.\n";
            }

            errrorTextBox.Text += '\n';

            error.Clear();

            Dictionary<string, string> errorHash = new Dictionary<string, string>();
            semantic.checkNoTypeerror(tokenList);
            errorHash = semantic.geterrorhash();

            Dictionary<string, string> tmp = new Dictionary<string, string>();

            if (errorHash.Count != 0)
            {
                var dicSort = from objDic in errorHash orderby objDic.Key select objDic;//对报错处理排序
                foreach (KeyValuePair<string,string> seman_error in dicSort)
                {
                    tmp.Add(seman_error.Value.ToString(), seman_error.Value.ToString());
                    errrorTextBox.AppendText(seman_error.Value.ToString() + "\n");
                }
            
                errrorTextBox.Text += "Semantic analysis error(s) have been detected.\n";
            }
            else
                errrorTextBox.AppendText("Semantic analysis Sucessfully!!\n");

            errrorTextBox.Text += "====================compile finish====================\n";
            errrorTextBox.Text += '\n';
        }

       
    }
}

