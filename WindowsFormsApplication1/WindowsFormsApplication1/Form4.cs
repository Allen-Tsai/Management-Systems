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
        private MySqlConnection mysqlCon = null;
        private string sqlCmd = string.Empty;
        public string data;

        public SearchByID()
        {
            InitializeComponent();
            sqlCmd = string.Format("Server=127.0.0.1;Database=test;Uid=root;Pwd=;");
            mysqlCon = new MySqlConnection(sqlCmd);
            if (mysqlCon.State == ConnectionState.Closed)
            {
                mysqlCon.Open();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string sql = "SELECT SID,NAME,SEX,QQ,PHONUMBER,DORM FROM student WHERE SID = '" 
                + textBox1.Text+"'";
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                cmd = new MySqlCommand(sql, mysqlCon);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string str = null;
                    for (int i = 0; i <= 5; i++)
                    {
                        switch(i)
                        {
                            case 0: str += "学号："; break;
                            case 1: str += "姓名："; break;
                            case 2: str += "性别："; break;
                            case 3: str += "QQ号："; break;
                            case 4: str += "手机号："; break;
                            case 5: str += "宿舍："; break;
                        }
                        str += reader[i];
                        str += "|";
                    }
                    MessageBox.Show("数据检索成功！\n" + str, "提示");
                    flag = true;
                }
                if(flag==false)
                {
                    MessageBox.Show("未在数据库中查询到此数据！", "提示");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("查询错误！" + ex, "提示", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            finally
            {
                reader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}


