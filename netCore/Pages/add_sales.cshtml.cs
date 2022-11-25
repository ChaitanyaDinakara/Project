using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Security.AccessControl;

namespace netCore.Pages
{
    public class add_salesModel : PageModel
    {
       public Sales_info infos = new Sales_info();
       public string success_msg = "";
        public string error_msg = "";
        public void OnPost()
        {
            try
            {
                string ConnectionString = "Data Source=INLPF3KJ0JJ\\MSSQLSERVER01;Initial Catalog=master;trusted_connection=true";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                
                infos.customer_id = Convert.ToInt32(Request.Form["id"]);
                infos.name = Request.Form["name"];
                infos.product_id = Request.Form["product_id"];
                infos.orderdate = Convert.ToDateTime(Request.Form["date"]);
                infos.amount = Convert.ToInt64(Request.Form["amount"]);
                infos.address = Request.Form["address"];
                infos.phone = Convert.ToInt64(Request.Form["phone"]);
                
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("create_order", sqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_cusid", System.Data.SqlDbType.Int).Value = infos.customer_id;
                cmd.Parameters.Add("@p_name", System.Data.SqlDbType.VarChar).Value = infos.name;
                cmd.Parameters.Add("@p_proid ", System.Data.SqlDbType.VarChar).Value = infos.product_id;
                cmd.Parameters.Add("@P_date", System.Data.SqlDbType.DateTime).Value = infos.orderdate;
                cmd.Parameters.Add("@p_amount", System.Data.SqlDbType.BigInt).Value = infos.amount;
                cmd.Parameters.Add("@p_address", System.Data.SqlDbType.VarChar).Value = infos.address;
                cmd.Parameters.Add("@p_phone", System.Data.SqlDbType.BigInt).Value = infos.phone;

                cmd.ExecuteNonQuery();



                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sql related problem");
                error_msg = ex.Message;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("C# related problem");
                error_msg=ex.Message;
                return;
            }
            infos.customer_id = 0;
            infos.name = " ";
            infos.product_id = " ";
            infos.address = "";
            infos.phone = 0;

             success_msg = "Successfully added";
            
   

        }
    }
}
