using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Data;
using System.Data.Sql;

namespace WindowsFormsApplication1
{
    public class DatabaseConnection
    {
        private MySqlConnection mysqlCon = null;
        private string sqlCmd = string.Empty;
        public DatabaseConnection()
        {
            try
            {
                //进行数据库初始化工作
                sqlCmd = string.Format("Server=127.0.0.1;Database=test;Uid=root;Pwd=;Charset=utf8");
                mysqlCon = new MySqlConnection(sqlCmd);
                mysqlCon.Open();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public MySqlConnection GetConnection()
        {
            if (mysqlCon.State == ConnectionState.Closed)
            {
                try
                {
                    mysqlCon.Open();
                }catch(Exception ex)
                {
                    throw ex;
                }
            }
            return mysqlCon;   
        }
        public void CloseConnection()
        {
            mysqlCon.Close();
        }

        /**直接在数据层实现增删改查操作**/
        public Boolean Insert(string []str)
        {
            //增加
            string sql = string.Format
                ("insert into STUDENT(SID,NAME,SEX,QQ,PHONUMBER,DORM) values('" +
                str[0] + "','" + str[1] + "', '" + str[2] + "', '"
                + str[3] + "', '" + str[4] + "', '" + str[5] + "')");
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public Boolean Update(string []str)
        {
            //修改
            string sql = string.Format
                ("update STUDENT set NAME ='" + str[1] + "', SEX ='" + str[2]
                + "', QQ='" + str[3] + "', PHONUMBER='" + str[4]
                + "', DORM ='" + str[5] + "' WHERE SID ='" + str[0] + "'");
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public Boolean Delete(string id)
        {
            //删除
            string sql = string.Format
                ("DELETE FROM STUDENT WHERE SID='" + id + "'");
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
        
        public string SearchByID(string id)
        {
            //按学号查询
            string str = null;
            string sql = "SELECT SID,NAME,SEX,QQ,PHONUMBER,DORM FROM student WHERE SID = '"
                + id + "'";
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                cmd = new MySqlCommand(sql, mysqlCon);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        switch (i)
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
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();  
            }
            return str;
        }

        public string SearchByName(string id)
        {
            //按姓名查询
            string str = null;
            string sql = "SELECT SID,NAME,SEX,QQ,PHONUMBER,DORM FROM student WHERE NAME = '"
                + id + "'";
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                cmd = new MySqlCommand(sql, mysqlCon);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        switch (i)
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
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
            }
            return str;
        }

        public List<string> ListAll()
        {
            //列出全部
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            string sql = "select SID,NAME,SEX,QQ,PHONUMBER,DORM from student ";

            try
            {
                cmd = new MySqlCommand(sql, mysqlCon);
                List<string> list = new List<string>();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string str = null;
                    for (int i = 0; i <= 5; i++)
                    {
                        str += reader[i];
                        str += "\t";
                    }
                    list.Add(str);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


