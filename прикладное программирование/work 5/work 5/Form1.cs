using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

namespace work_5
{
    public partial class Form1 : Form
    {
        public static string login;

        public Form1()
        {
            InitializeComponent();
        }

        public static string x;
        public static string xx;


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        { string bb = "";
            x ="ваш логин " + textBox1.Text;
            xx ="ваш пароль " + textBox2.Text;
            bb=textBox1.Text;
            if (bb == "j.doe@amonic.com")
            {
                int last = -1;

                string connectionString = @"Data Source=DESKTOP-HQTDFSB;Initial Catalog=AMONIC_AIRLINES;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlCommand command = new SqlCommand("SELECT role FROM [USERS]", cnn);
                SqlDataReader sqlReader = null;
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    last = Convert.ToInt32(sqlReader["role"]);
                }
                sqlReader.Close();

                if (textBox1.Text != "" )
                {
                    login = textBox1.Text;
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                   
                }
                else
                    MessageBox.Show("Введите ваш ussername and password!");
            }
            else
            {
                Form5 f5 = new Form5();
                f5.Show();
            }
           
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
        }
    }
}
