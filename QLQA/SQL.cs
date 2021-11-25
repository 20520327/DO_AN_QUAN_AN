using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QLQA.Model;
using UI;

namespace QLQA
{
    public class SQL
    {
        //Food
        static public bool getListFood(ref List<Food> ls)
        {
            SqlConnection ketnoi = new SqlConnection();
            ketnoi.Open();
            SqlCommand caulenh = new SqlCommand("select A.ID, A.NAME, B.NAME, A.PRICE from FOOD A inner join CATEGORY B on A.CATEid = B.ID", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Food a = new Food();
                    a.ID = kqtruyvan.GetInt32(0);
                    a.Name = kqtruyvan[1].ToString();
                    a.Category_name = kqtruyvan[2].ToString();
                    a.Price = kqtruyvan.GetFloat(3);
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
            SqlConnection ketnoi = new SqlConnection();
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
            SqlConnection ketnoi = new SqlConnection();
            ketnoi.Open();
            SqlCommand caulenh = new SqlCommand("select * from EMPLOYEE", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Employee a = new Employee();
                    a.ID = kqtruyvan.GetInt32(0);
                    a.NAME = kqtruyvan[1].ToString();
                    a.SEX = kqtruyvan[4].ToString();
                    a.PHONE = kqtruyvan[3].ToString();
                    a.ADDRESS = kqtruyvan[2].ToString();
                    a.EMAIL = kqtruyvan[5].ToString();
                    a.POSITION = kqtruyvan[6].ToString();
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
            SqlConnection ketnoi = new SqlConnection();
            ketnoi.Open();
            SqlCommand caulenh = new SqlCommand("select * from ACCOUNT", ketnoi);
            SqlDataReader kqtruyvan = caulenh.ExecuteReader();
            try
            {
                while (kqtruyvan.Read())
                {
                    Account a = new Account();
                    a.
                    ls.Add(a);
                }
            }
            catch (Exception es)
            {
                return false;
            }
            return true;
        }
    }
}
