using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections;
using System.Net;

namespace ConsoleApp1
{
    class Database
    {
        //声明一个连接对象
        public SqlConnection sqlconnection = new SqlConnection();

        public  Database()
        {
            //创建连接字符串对象
            SqlConnectionStringBuilder SCSB = new SqlConnectionStringBuilder();
            SCSB.DataSource = "LAPTOP-9QR1CH8Q";
            SCSB.UserID = "sa";
            SCSB.Password = "19981001";
            SCSB.InitialCatalog = "user_db";

            //连接至数据库
            this.sqlconnection = new SqlConnection(SCSB.ToString());

        } //初始化函数结束

        //接受并处理客户端传来的字符串
        public  int InsertNewUser(register res,string port)
        {
            //操作执行结果
            int flag;
            //数据库连接打开
            sqlconnection.Open();

            //首先判断账号是否存在
            string sqlStr1 = "select * from user_db.dbo.User_Information where ID =" + res.ID ;
            SqlCommand command1 = new SqlCommand(sqlStr1, sqlconnection);
            SqlDataReader reader = command1.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                return 0;
            }
   
            else
            {
                reader.Close();
                //创建SQL操作语句
                string sqlStr = "INSERT INTO [dbo].[User_Information] ([IPAddress] ,[ID] ,[Name] ,[Gender] ,[School] ,[Class] ,[Major] ,[Password],[Port]) VALUES (' " +
                                       res.IP + " ' , ' " + res.ID + " ' , ' " + res.Name + " ' , ' " + res.Gender + " ' , ' " + res.School + " ' , ' " + res.Class + " ' , ' " + res.Major + " ' , ' " 
                                        + res.Password + " ' , ' " + port + "')";
                //创建执行SQL语句的对象
                SqlCommand command = new SqlCommand(sqlStr, sqlconnection);
                //接收数据库操作语句的返回结果

                try
                {
                    int rc = command.ExecuteNonQuery();
                    if (rc == 1)//注册成功
                    {
                        flag = 1;
                    }
                    else//注册失败
                    {
                        flag = -1;
                    }

                    return flag;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                finally
                {
                    
                    sqlconnection.Close();
                }
            }


        }//InsertNewUsers函数结束

        // 数据库处理登录数据
        public int UsersLogin(login log,string port)
        {
            //操作执行结果
            int flag;
            //数据库连接打开
            sqlconnection.Open();

            try
            {
                //首先判断账号是否存在
                string sqlStr1 = "select * from user_db.dbo.User_Information where ID =" + log.ID;
                SqlCommand command1 = new SqlCommand(sqlStr1, sqlconnection);
                SqlDataReader reader1 = command1.ExecuteReader();
                if (reader1.Read())
                {
                    
                    //判断输入密码与已有密码是否相同
                    if (reader1["Password"].ToString().Equals(" "+ log.Password + " ") )
                    {
                        flag = 1;
                        //更新用户的IP地址和端口号
                        string sqlStr2 = "UPDATE [dbo].[User_Information] SET Port = ' " + port + " ' , IPAddress = ' " + log.IP + " ' WHERE ID = " + log.ID;
                        Console.WriteLine(sqlStr2);
                        SqlCommand command2 = new SqlCommand(sqlStr2, sqlconnection);
                        try
                        {
                            reader1.Close();
                            int rc = command2.ExecuteNonQuery();
                            if (rc == 1) Console.WriteLine("更新用户IP和端口号成功！");
                            else Console.WriteLine("更新用户IP和端口号失败！");
                            
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("更新用户数据发生异常！");
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        reader1.Close();
                        flag = -1;
                    }
                    
                    return flag;
                }
                else
                {
                    reader1.Close();
                    return 0;
                }
            }catch(Exception ex)
            {
                Console.WriteLine("登录申请发生异常！");
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                sqlconnection.Close();
            }
            
        }   //UserLogin函数结束

        public void StateOfUserChange(string IP, string Port, string state)
        {
            string sqlStr1 = "UPDATE [dbo].[User_Information] SET State = ' " + state + " ' WHERE IPAddress = ' " + IP + 
                                      " ' and Port = ' " + Port + " '";
            //数据库连接打开
            if (sqlconnection.State == ConnectionState.Closed)
            {
                //Console.WriteLine("重新打开数据库");
                sqlconnection.Open();
                try
                {
                    
                    Console.WriteLine(sqlStr1);
                    SqlCommand command1 = new SqlCommand(sqlStr1, sqlconnection);

                    int rc = command1.ExecuteNonQuery();
                    if (rc == 1) Console.WriteLine("更新用户状态成功！");
                    else Console.WriteLine("更新用户状态失败！");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(sqlStr1);
                    Console.WriteLine("更新用户状态发生异常！");
                }
                finally
                {
                    if (state == "离线")
                    {
                        //Console.WriteLine("修改用户下线状态，数据库关闭！");
                        sqlconnection.Close();
                    }
                }
            }
            //如果数据库已连接，则直接更新数据
            else
            {
                try
                {
                    //string sqlStr1 = "UPDATE [dbo].[User_Information] SET State = ' " + state + " ' WHERE ID = " + ID;
                    Console.WriteLine(sqlStr1);
                    SqlCommand command1 = new SqlCommand(sqlStr1, sqlconnection);

                    int rc = command1.ExecuteNonQuery();
                    if (rc == 1) Console.WriteLine("更新用户状态成功！");
                    else Console.WriteLine("更新用户状态失败！");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(sqlStr1);
                    Console.WriteLine("更新用户状态发生异常！");
                }
                finally
                {
                    if(state == "离线")
                    {
                        //Console.WriteLine("修改用户下线状态，数据库关闭！");
                        sqlconnection.Close();
                    }
                }
            }

        }   //  StateOfUserChange函数结束

        //用户登录成功后的刷新函数
        public List<User> Userrefresh()
        {
            List<User> userList = new List<User>();
            Console.WriteLine("正在申请更新数据");
            //打开数据库连接
            if (sqlconnection.State == ConnectionState.Closed)
            {
                sqlconnection.Open();
            }
            string sqlStr1 = "SELECT * from user_db.dbo.User_Information WHERE State = ' 在线 ' ";
            SqlCommand command1 = new SqlCommand(sqlStr1, sqlconnection);
            SqlDataReader reader1 = command1.ExecuteReader();
            try
            {
                //从数据库中读取数据,将数据放入列表中
                while (reader1.Read()) 
                {
                    //新声明一个用户对象，并将从数据库读取的数据加入列表
                    User usertemp = new User();
                    usertemp.ID = reader1["ID"].ToString();
                    usertemp.Name = reader1["Name"].ToString();
                    Console.WriteLine(reader1["Name"].ToString());
                    usertemp.Gender = reader1["Gender"].ToString();
                    usertemp.School = reader1["School"].ToString();
                    usertemp.Class = reader1["Class"].ToString();
                    usertemp.Major = reader1["Major"].ToString();
                  
                    userList.Add(usertemp);
                }
                
                return userList;

            }
            catch(Exception ex)
            {
                Console.WriteLine("刷新异常！");
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                reader1.Close();
                sqlconnection.Close();
            }
        }   //Userrefresh函数结束

        //获取指定学号的IP地址和端口号
        public IPEndPoint GetTargetIPandPort(string ID)
        {
            IPAddress ip = IPAddress.Parse("192.168.0.0");
            int port = 0;

            if (sqlconnection.State == ConnectionState.Closed)
            {
                sqlconnection.Open();
            }
            string sqlStr1 = "SELECT IPAddress,Port from user_db.dbo.User_Information WHERE ID = " + ID;
            Console.WriteLine(sqlStr1);
            SqlCommand command1 = new SqlCommand(sqlStr1, sqlconnection);
            SqlDataReader reader1 = command1.ExecuteReader();
            try
            {
                
                while(reader1.Read())
                {
                    ip = IPAddress.Parse(reader1["IPAddress"].ToString().Trim());
                    port = Convert.ToInt32(reader1["Port"].ToString());

                    Console.WriteLine("查询到用户{0}的IP地址为{1}，端口号为{2}", ID, ip, port);
                }
                IPEndPoint iPEndPoint = new IPEndPoint(ip, port);
                
                return iPEndPoint;

            }
            catch (Exception ex)
            {
                Console.WriteLine("查询指定IP和端口异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine("hhh");
                return null;
            }
            finally
            {
                reader1.Close();
                sqlconnection.Close();
            }

            
        }





    }
}
