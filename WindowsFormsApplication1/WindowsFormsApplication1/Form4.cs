using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WindowsFormsApplication1
{
    public partial class SearchByID : Form
    {
        private static DatabaseConnection dbc_;

        public SearchByID(DatabaseConnection dbc)
        {
            InitializeComponent();
            dbc_ = dbc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = dbc_.SearchByID(textBox1.Text);
                if (str != null) 
                {
                    MessageBox.Show("数据检索成功！\n" + str, "提示");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("未在数据库中查询到此数据！", "提示");
                    button2_Click(sender, e);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("查询错误！" + ex, "提示", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}


