using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private MySqlConnection mysqlCon = null;
        private string sqlCmd = string.Empty;

        public Form2()
        {
            InitializeComponent();
            sqlCmd = string.Format("Server=127.0.0.1;Database=test;Uid=root;Pwd=;Charset=utf8");
            mysqlCon = new MySqlConnection(sqlCmd);
            if (mysqlCon.State == ConnectionState.Closed)
            {
                mysqlCon.Open();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||
                textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("有数据字段为空！", "提示");
                return;
            }
            string sql = string.Format
                ("insert into STUDENT(SID,NAME,SEX,QQ,PHONUMBER,DORM) values('"+
                textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '"
                + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text+"')");
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("数据添加成功！", "提示");
                    this.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("数据添加失败！"+ex, "提示", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
