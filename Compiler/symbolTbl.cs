using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{

    class symbolTbl
    {

        private static Hashtable hashtable = new Hashtable();
        private static Hashtable idrecord = new Hashtable();
        public static Hashtable allid = new Hashtable();
        private static int count = 0, count1 = 0;//记录标识符数
        public string identior, type, value;
        public int linenum = 0;
        public int domain = 0;//作用域编号
      

        public static Hashtable oldhash = new Hashtable();
        static Hashtable GetId_Type_hash(string Identior_Type, string Type)
        {
            hashtable.Add(Identior_Type, Type);
            return hashtable;
        }
        static Hashtable GetId_Name_hash(string Identior_Name, string Name)
        {
            hashtable.Add(Identior_Name, Name);
            return hashtable;
        }
        static Hashtable GetId_LineNum_hash(string Identior_LineNum, int LineNum)
        {
            hashtable.Add(Identior_LineNum, LineNum);
            return hashtable;
        }
        static Hashtable GetId_Value_hash(string Identior_Value, string Value)
        {
            hashtable.Add(Identior_Value, Value);
            return hashtable;
        }
        static Hashtable GetId_domain_hash(string Identior_domain, int domain)
        {
            hashtable.Add(Identior_domain, domain);
            return hashtable;
        }



            public void CreateSymbolTbl(string Identior/*标识符*/, string Type/*类型*/, int LineNum/*行号*/, string Value/*值*/, int domain/*作用域*/)
            {
                if (!hashtable.Contains(Identior + "." + domain + "_Name"))
                {
                    idrecord.Add(count, Identior + "." + domain);/*记录所有出现第一次的id*/
                    GetId_Name_hash(Identior + "." + domain + "_Name", Identior);
                    GetId_Type_hash(Identior + "." + domain + "_Type", Type);
                    GetId_LineNum_hash(Identior + "." + domain + "_LineNum", LineNum);
                    GetId_Value_hash(Identior + "." + domain + "_Value", Value);
                    GetId_domain_hash(Identior + "." + domain + "_domain", domain);
                    count++;

                }
            }

        public void setallID(string Identior)
        {
            if (!allid.ContainsValue(Identior))
            {
                allid.Add(count1, Identior);
                count1++;
            }
        }
        public void getSymbolTbl(int index)//获取符号表
        {
            if(idrecord.Contains(index))
                if (hashtable.Contains(idrecord[index].ToString() + "_Name"))
            {
                identior = hashtable[idrecord[index].ToString() + "_Name"].ToString();
                type = hashtable[idrecord[index].ToString() + "_Type"].ToString();
                linenum = (int)hashtable[idrecord[index].ToString() + "_LineNum"];
                value = hashtable[idrecord[index].ToString() + "_Value"].ToString();
                domain = (int)hashtable[idrecord[index].ToString() + "_domain"];
            }

        }
        public Hashtable gethash()
        {
            return allid;  
        }
        public int getsize()//符号表大小
        {   
            return idrecord.Count;
        }
        public int getallidsize()
        {
          
            return allid.Count;
        }
        public void clearsymboltbl()//清空符号表
        {
            hashtable.Clear();
            idrecord.Clear();
            allid.Clear();
            count = 0;
            count1 = 0;
        }
        public void updateValue(string identior/*标识符*/, string Value/*值*/, int domain/*作用域*/)//更新符号表的值
        {
            if (hashtable.Contains(identior + "." + domain + "_Name"))
                hashtable[identior + "." + domain + "_Value"] = Value;
            else return;
        }
        public void updateType(string identior/*标识符*/, string Type/*类型*/, int domain/*作用域*/)//更新类型
        {
            if (hashtable.Contains(identior + "." + domain + "_Name"))
                hashtable[identior + "." + domain + "_Type"] = Type;
            else return;
        }
        public void remove()
        {
            oldhash = hashtable;
            Semantic semantic=new Semantic();
            semantic.checkTypeError(oldhash);
            
            string str = null;
            string ch = null;
            Hashtable tmphash = new Hashtable();
            Hashtable tmphash1 = new Hashtable();
            foreach (DictionaryEntry de in hashtable)//登记无值无类型字符
            {
                if (de.Value.ToString() == "NoType" || de.Value.ToString() == "NoValue")
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
            foreach (DictionaryEntry id in idrecord)
            {
                foreach (DictionaryEntry de in tmphash)
                {
                    if (de.Key.ToString()==id.Value.ToString())
                        if (!tmphash1.Contains((int)id.Key))
                            tmphash1.Add((int)id.Key, (int)id.Key);
                }
            }
            foreach (DictionaryEntry de in tmphash)//清除无类型无值的异常符号表
            {
                
                if(hashtable[de.Key.ToString() + "_Type"].ToString()=="NoType"|| hashtable[de.Key.ToString() + "_Value"].ToString() == "NoValue"){
                hashtable.Remove(de.Key.ToString() + "_Name");
                hashtable.Remove(de.Key.ToString() + "_Type");
                hashtable.Remove(de.Key.ToString() + "_LineNum");
                hashtable.Remove(de.Key.ToString() + "_Value");
                hashtable.Remove(de.Key.ToString() + "_domain");
                    }
            }
            foreach (DictionaryEntry de in tmphash1)//移除原字符表中异常token
                idrecord.Remove((int)de.Key);

            tmphash.Clear();//清空临时哈希表
            foreach (DictionaryEntry de in idrecord)//将原字符表临时记录到临时哈希表中
            {
                tmphash.Add((int)de.Key, de.Value);
            }

            int n = tmphash.Count;
            idrecord.Clear();//清空原字符表
            foreach (DictionaryEntry de in tmphash)//重置字符表编号
            {
                n--;            
                idrecord.Add(n, de.Value); 
            }
            
        }//移除异常的符号表
    }
}



