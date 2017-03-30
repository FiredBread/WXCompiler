using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Token
    {
        private int id;
        private String content;
        private int lineNum;

        public Token()
        {

        }
        public Token(int id, String content, int lineNum)
        {
            this.id = id;
            this.content = content;
            this.lineNum = lineNum;
        }
        public int getID()
        {
            return id;
        }
        public void setID(int id)
        {
            this.id = id;
        }
        public String getContent()
        {
            return content;
        }
        public void setContent(String content)
        {
            this.content = content;
        }
        public int getLineNum()
        {
            return lineNum;
        }
        public void setLineNum(int lineNum)
        {
            this.lineNum = lineNum;
        }
    }
}
