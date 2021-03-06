﻿using System;
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
    public partial class Form5 : Form
    {
        private static DatabaseConnection dbc_;
        public Form5(DatabaseConnection dbc)
        {
            InitializeComponent();
            dbc_ = dbc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("有数据字段为空！", "提示");
                return;
            }
            try
            {
                if (dbc_.Delete(textBox1.Text))
                {
                    MessageBox.Show("数据删除成功！", "提示");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据删除失败！" + ex, "提示", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                button2_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
