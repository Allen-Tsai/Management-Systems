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
    public partial class Form3 : Form
    {
        private MySqlConnection mysqlCon = null;
        private string sqlCmd = string.Empty;

        public Form3()
        {
            InitializeComponent();
            sqlCmd = string.Format("Server=127.0.0.1;Database=test;Uid=root;Pwd=;Charset=utf8");
            mysqlCon = new MySqlConnection(sqlCmd);
            if (mysqlCon.State == ConnectionState.Closed)
            {
                mysqlCon.Open();
            }
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text==""||textBox2.Text==""||textBox3.Text==""||textBox4.Text==""||
                textBox5.Text==""||textBox6.Text=="")
            {
                MessageBox.Show("有数据字段为空！", "提示");
                return;
            }

            string sql = string.Format
                ("update STUDENT set NAME ='" + textBox2.Text + "', SEX ='" + textBox3.Text
                + "', QQ='" + textBox4.Text + "', PHONUMBER='" + textBox5.Text
                + "', DORM ='" + textBox6.Text + "' WHERE SID ='" + textBox1.Text+"'");
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("数据修改成功！", "提示");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据修改失败！" + ex, "提示", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
