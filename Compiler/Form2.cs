using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler
{
    public partial class Form2 : DMSkin.Main
    {
        private static Form2 _instance;
        public Form2()
        {
            _instance = this;
            InitializeComponent();
        }
        public static Form2 getInstance()
        {
            return Form2._instance;
        }

        private void dmButtonClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dmButtonMin1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
