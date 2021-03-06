﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        private static DatabaseConnection dbc;
        public Form1()
        {
            InitializeComponent();
            //进行数据库初始化工作
            dbc = new DatabaseConnection();
            listBox1.Items.Add("学号\t\t姓名\t性别\tQQ\t\t手机号\t\t宿舍\t");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /* 检测数据库有没有连接成功 */
            try
            {
                MySqlConnection Mycon = dbc.GetConnection();
                MessageBox.Show("数据库连接成功！", "提示");
            }
            catch (Exception ex)
            {
                //this.mIsHandlerOK = true;
                MessageBox.Show("远程连接数据库失败!" + ex, "提示", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //显示全部
            
            try
            {
                List<string> list = new List<string>();
                list = dbc.ListAll();
                listBox1.Items.Clear();
                listBox1.Items.Add("学号\t\t姓名\t性别\tQQ\t\t手机号\t\t宿舍\t");
                foreach (string s in list)
                {
                    listBox1.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库还未连接！" + ex, "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            //刷新
            this.Refresh();
        }

        private void 添加数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dbc);
            form2.Show();
            //this.Hide();
        }

        private void 修改数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(dbc);
            form3.Show();
        }

        private void 删除数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(dbc);
            form5.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchByID sb = new SearchByID(dbc);
            sb.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(dbc);
            f6.Show();
        }

        private void 技术支持ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("谁他妈支持我的。都是我一个人做。");
        }

        private void 产品设计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Designed By：\n\n姓名：Allen Kaiser\n邮箱：chl19950429@gmail.com\nqq：1622546034\n欢迎勾搭",
                "提示");
        }

        private void 关于我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("姓名：Allen Kaiser\n邮箱：chl19950429@gmail.com\nqq：1622546034\n欢迎勾搭",
                "提示");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();

                list = dbc.ListAll();
                list.Sort();
                listBox1.Items.Clear();
                listBox1.Items.Add("学号\t\t姓名\t性别\tQQ\t\t手机号\t\t宿舍\t");
                foreach (string s in list)
                {
                    listBox1.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库还未连接！" + ex, "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}


