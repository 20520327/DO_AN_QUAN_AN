using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QLQA.Model;

namespace QLQA
{
    public class SQL
    {
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
    }
}
