using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compiler
{
    class ParserTblCreator
    {
        String[] rules;
        private List<List<String>> grammar = new List<List<string>>();
        private Dictionary<String, int> termDic = new Dictionary<String, int>();
        private Dictionary<String, int> nonTermDic = new Dictionary<String, int>();
        private List<Dictionary<int, int>> production = new List<Dictionary<int, int>>();
        int i, j, k,m;
        public ParserTblCreator(String[] arules)
        {
            rules = arules;
            InitTermDic();
            InitNonTermDic();

        }
        private void InitTermDic()
        {
            termDic.Add("INT", 1);
            termDic.Add("REAL",2);
            termDic.Add("ID",3);
            termDic.Add("+",4);
            termDic.Add("-",5);
            termDic.Add("/",6);
            termDic.Add("*",7);
            termDic.Add("=",8);
            termDic.Add("==",9);
            termDic.Add("<",10);
            termDic.Add("<=",11);
            termDic.Add(">",12);
            termDic.Add(">=",13);
            termDic.Add("!=",14);
            termDic.Add("(",15);
            termDic.Add(")",16);
            termDic.Add("{",17);
            termDic.Add("}",18);
            termDic.Add(";",19);
            termDic.Add(",",20);
            termDic.Add(".",21);
            termDic.Add("int", 30);
            termDic.Add("real", 31);
            termDic.Add("if", 32);
            termDic.Add("then", 33);
            termDic.Add("else", 34);
            termDic.Add("while", 35);
            termDic.Add("EPS", 36);
        }
        private void InitNonTermDic()
        {
            for(i=0;i<rules.Length;i++)
            {
                String[] str = Regex.Split(rules[i], "->", RegexOptions.IgnoreCase);
                nonTermDic.Add(str[0], i + 100);
                List<String> tmp = new List<String>();
                String[] rightStr = str[1].Split('|');
                for(int j=0;j<rightStr.Length;j++)
                {
                    tmp.Add(rightStr[j]);
                }
                grammar.Add(tmp);
            }
            int prodNum = 0;
            int nonTermNum = grammar.Count-1;
            List<List<List<int>>> formProd = new List<List<List<int>>>();          
            for (i = 0; i < grammar.Count; i++)
            {
                prodNum += grammar[i].Count;
                List<List<int>> grpProd = new List<List<int>>();
                for (j = 0; j < grammar[i].Count; j++)
                { 
                    String[] token = grammar[i][j].Split(' ');
                    List<int> oneProd = new List<int>();
                    for (k=0;k<token.Length;k++)
                    {                                
                        if (nonTermDic.ContainsKey(token[k]))               
                            oneProd.Add(nonTermDic[token[k]]);
                        if (termDic.ContainsKey(token[k]))
                            oneProd.Add(termDic[token[k]]);
                    }
                    grpProd.Add(oneProd);
                }
                formProd.Add(grpProd);
            }

            List<List<List<int>>> first = new List<List<List<int>>>();
            for (i=grammar.Count-1; i >= 0; i--)
            {
                List<List<int>> grpFir = new List<List<int>>();
                for (j = grammar[i].Count-1; j >= 0; j++)
                {
                    List<int> oneFir = new List<int>();
                    if (formProd[i][j][0] < 100)
                    {
                        oneFir.Add(formProd[i][j][0]);                      
                    }
                    else
                    {
                        int pos = formProd[i][j][0] - 100;
                        for (k = 0; k < first[nonTermNum - pos].Count; k++)
                            for(m=0;m<first[nonTermNum-pos][k].Count;k++)
                                oneFir.Add(first[nonTermNum - pos][k][m]);
                    }
                    grpFir.Add(oneFir);
                }
                first.Add(grpFir);
            }

            List<List<int>> follow = new List<List<int>>();
            List<int> onefollow = new List<int>();
            follow.Add(onefollow);              
            for (i=1;i<grammar.Count;i++)
            {
                for(int k=0;k<formProd.Count;k++)
                {
                    for(int l=0;l<formProd[k].Count;l++)
                    {
                        for(int m=0;m<formProd[k][l].Count;k++)
                        {
                            if(i+100 == formProd[k][l][m])
                            {
                                if()
                            }
                        }
                    }
                } 
            }
        }
    }
}
