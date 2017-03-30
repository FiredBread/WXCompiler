using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class IntDeliver
    {
        private int pass;
        public IntDeliver(int a)
        {
            pass = a;
        }
        public void setPass(int a)
        {
            pass = a;
        }
        public int getPass()
        {
            return pass;
        }
    }
}
