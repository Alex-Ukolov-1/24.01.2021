using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace вспоминаем_аксессоры_и_метод_split
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
            get { return TEXT;}
            set
            {
                if (value.Length > 2) MessageBox.Show("вы ввели недопустимый этаж");
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
