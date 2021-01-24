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

namespace work_5
{
    public partial class Form5 : Form
    {
        public string Value;
        public string Value2;
        public Form5()
        {
            
            InitializeComponent();
            LoadData();
            label1.Text = "" + Form1.x;
            label2.Text = "" + Form1.xx;
        }


        private void LoadData()
        {
            string connectstring = @"Data Source=DESKTOP-HQTDFSB;Initial Catalog=AMONIC_AIRLINES;Integrated Security=True";
            SqlConnection myconnect = new SqlConnection(connectstring);
            myconnect.Open();
            string query = "SELECT * FROM РЕЙСЫ";
            SqlCommand command = new SqlCommand(query, myconnect);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
            }
            reader.Close();
            myconnect.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = "" + Form1.x;
            label2.Text = "" + Form1.xx;
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
