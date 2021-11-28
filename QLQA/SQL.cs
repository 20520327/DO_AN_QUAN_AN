using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QLQA.Model;
using System.Data;
using UI;

namespace QLQA
{
    public class SQL
    {
        private static string Connectionstring = "Data Source=DESKTOP-68RLUI9\\SQLEXPRESS;Initial Catalog=QuanAn;Integrated Security=True";
        //Food
        static public bool getListFood(ref List<Food> ls)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            SqlCommand caulenh = new SqlCommand("select A.ID, A.NAME, B.NAME, A.PRICE from FOOD A inner join CATEGORY B on A.CATEid = B.ID", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Food a = new Food();
                    a.ID = kqtruyvan.GetInt32(0);
                    a.NAME = kqtruyvan[1].ToString();
                    a.CATEGORY_NAME = kqtruyvan[2].ToString();
                    a.PRICE = kqtruyvan.GetFloat(3);
                    ls.Add(a);
                }
            }
            catch(Exception es)
            {
                return false;
            }
            return true;
        }

        //Table
        static public bool getListTable(ref List<Table> ls)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            SqlCommand caulenh = new SqlCommand("select * from TABLEQA", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Table a = new Table();
                    a.ID = kqtruyvan.GetInt32(0);
                    a.NAME = kqtruyvan[1].ToString();
                    a.STATUS = kqtruyvan[2].ToString();
                    ls.Add(a);
                }
            }
            catch (Exception es)
            {
                return false;
            }
            return true;
        }

        //Employee
        static public bool getListEmployee(ref List<Employee> ls)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            SqlCommand caulenh = new SqlCommand("select * from EMPLOYEE", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Employee a = new Employee();
                    a.EID = kqtruyvan.GetInt32(0);
                    a.ENAME = kqtruyvan[1].ToString();
                    a.EPOSITION = kqtruyvan[2].ToString();
                    a.EADDRESS = kqtruyvan[3].ToString();
                    a.EPHONE = kqtruyvan[4].ToString();
                    a.ESEX = kqtruyvan[5].ToString();
                    a.EEMAIL = kqtruyvan[6].ToString();
                    ls.Add(a);
                }
            }
            catch (Exception es)
            {
                return false;
            }
            return true;
        }

        //Accont
        static public bool getListAccount(ref List<Account> ls)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            SqlCommand caulenh = new SqlCommand("select * from ACCOUNT", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Account a = new Account();
                    a.EMPLOYEEID = kqtruyvan.GetInt32(0);
                    int tempUSERROLE = kqtruyvan.GetInt32(1);
                    if(tempUSERROLE == 0)
                    {
                        a.USERROLE = "Người quản lí";
                    }
                    else
                    {
                        a.USERROLE = "Nhân viên";
                    }
                    a.USERNAME = kqtruyvan[2].ToString();
                    a.PASSWORD = kqtruyvan[3].ToString();
                    ls.Add(a);
                }
            }
            catch (Exception es)
            {
                return false;
            }
            return true;
        }

        //Category
        static public bool getListCategory(ref List<Category> ls)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            SqlCommand caulenh = new SqlCommand("select * from CATEGORY", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Category a = new Category();
                    a.ID = kqtruyvan.GetInt32(0);
                    a.NAME = kqtruyvan[1].ToString();
                    ls.Add(a);
                }
            }
            catch (Exception es)
            {
                return false;
            }
            return true;
        }
            
        //Login
        static public Login lg = new Login();
        static public bool CheckLogin(string user,string pass)
        {
            SqlConnection ketnoi = new SqlConnection(Connectionstring);
            ketnoi.Open();
            SqlCommand caulenh = new SqlCommand("select * from ACCOUNT WHERE USERNAME = N'" + user + "' AND PASSWORD = '" + pass +"'", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            List<Login> ls = new List<Login>();

            try
            {
                while (kqtruyvan.Read())
                {
                    lg.EMPLOYEEid = kqtruyvan.GetInt32(0);
                    lg.ROLEid = kqtruyvan.GetInt32(1);
                    lg.USERNAME = kqtruyvan[2].ToString();
                    lg.PASSWORD = kqtruyvan[3].ToString();
                    ls.Add(lg);
                }
                if (ls.Count() > 0)
                    return true;
                else return false;
            }
            catch(Exception es)
            {
                return false;
            }
        }
    }
}
