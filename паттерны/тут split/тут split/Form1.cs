using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace тут_split
{
    public partial class Form1 : Form
    {
        private Class1 cls;
        public Form1()
        {
            InitializeComponent();
            cls = new Class1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = "";
            string aa = "";
            string aaa = "";

            string s = (textBox1.Text);
            string[] strmass = s.Split(',');
            a = strmass[0];
            aa = strmass[1];
            aaa = strmass[2];
            MessageBox.Show(a);
            cls.Showtext();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            cls.Ontextchanged(textBox1.Text);
            
           
        }
    }
    class Class1
        {
        public String TEXT;
            public string text
            {
                get { return TEXT; }
                set
                {
                    if (value.Length > 6) MessageBox.Show("вы ввели недопустимое значение");
                    TEXT = value;
                }
            }

            public void Ontextchanged(string TEXT)
            {
                text = TEXT;
            }

            public void Showtext()
            {
                MessageBox.Show(text);
            }
        }
    
}
