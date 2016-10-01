using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class 用户登录 : Form
    {
        public 用户登录()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**用户名 密码**/
            if (textBox1.Text == "caihaolun" && textBox2.Text == "1234")
            {
                MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("用户名或密码不能为空！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.button2_Click(sender,e);
            }
            else
            {
                MessageBox.Show("用户名或密码输入错误！请重试！", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.button2_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

    }
}
