using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Semantic
    {
        private symbolTbl symboltable = new symbolTbl();
        private static Hashtable table = new Hashtable();
        private static Hashtable allid = new Hashtable();
        public static Dictionary<string, string> errorHash = new Dictionary<string, string>();
       
        private string semanticErr;

        public Semantic()
        {

            allid = symboltable.gethash(); 
        }
        public void checkTypeError(Hashtable hashtable)
        {
            string str = null;
            string ch = null;
            Hashtable tmphash = new Hashtable();
          
            
            foreach (DictionaryEntry de in hashtable)//登记无值无类型字符
            {
                table.Add(de.Key, de.Value);
                if (de.Value.ToString() == "NoValue")
                {
                    str = de.Key.ToString();
                    for (int i = 0; i < str.Length; i++)
                    {
                        ch = str.Substring(i, 1);
                        if (ch == "_")
                        {
                            str = str.Substring(0, i);
                           
                            if (!tmphash.Contains(str))
                                tmphash.Add(str, str);
                            break;
                        }
                    }
                }
            }
          
                foreach (DictionaryEntry de in tmphash)
            {
               
                semanticErr = "Semantic Error in Line :" + hashtable[de.Key.ToString() + "_LineNum"].ToString() + " 声明的变量 " + hashtable[de.Key.ToString() + "_Name"] + " 未进行初始化";
                errorHash.Add(semanticErr, semanticErr);   
            }
          
            tmphash.Clear();
           
        }
        public void checkNoTypeerror(List<Token> tokenList)
        {
            
                if (tokenList != null)
                foreach (DictionaryEntry de in allid)
                {
                    int pos = tokenList.Count - 1;
                    if (!table.ContainsValue(de.Value.ToString()))
                    {
                        while (pos>=0)
                        {
                            if (tokenList[pos].getContent() == de.Value.ToString())
                            {
                                semanticErr = "Semantic Error in Line :" + tokenList[pos].getLineNum() + " 变量 " + de.Value + " 未进行声明";
                                break;
                            }
                            pos--;
                        }
                        errorHash.Add(semanticErr, semanticErr);
                    }
                }
        }
        public Dictionary<string,string> geterrorhash()
        {
            return errorHash;
        }
        public void clearerrorhsah()
        {
            errorHash.Clear();
            table.Clear();
            allid.Clear();
        }
    }
}
