﻿using System;
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
        private static DatabaseConnection dbc_;
        public Form2(DatabaseConnection dbc)
        {
            InitializeComponent();
            dbc_ = dbc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||
                textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("有数据字段为空！", "提示");
                return;
            }
            try
            {
                string []str = new string[]{};
                str[0]=textBox1.Text;
                str[1]=textBox2.Text;
                str[2]=textBox3.Text;
                str[3]=textBox4.Text;
                str[4]=textBox5.Text;
                str[5]=textBox6.Text;
                if (dbc_.Insert(str))
                {
                    MessageBox.Show("数据添加成功！", "提示");
                    this.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("数据添加失败！"+ex, "提示", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                button2_Click(sender, e);
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
