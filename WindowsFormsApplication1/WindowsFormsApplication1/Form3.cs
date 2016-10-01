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
        private static DatabaseConnection dbc_;
        public Form3(DatabaseConnection dbc)
        {
            InitializeComponent();
            dbc_ = dbc;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||
                textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("有数据字段为空！", "提示");
                return;
            }
            try
            {
                string[] str = new string[] { };
                str[0] = textBox1.Text;
                str[1] = textBox2.Text;
                str[2] = textBox3.Text;
                str[3] = textBox4.Text;
                str[4] = textBox5.Text;
                str[5] = textBox6.Text;
                if (dbc_.Update(str))
                {
                    MessageBox.Show("数据修改成功！", "提示");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据修改失败！" + ex, "提示", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                button2_Click_1(sender, e);
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
