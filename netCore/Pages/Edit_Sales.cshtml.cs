using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Net;
using System.Numerics;

namespace netCore.Pages
{
    public class Edit_SalesModel : PageModel
    {
        public List<Sales_info> list_name = new List<Sales_info>();
        public Sales_info update = new Sales_info();
        public string success_msg = "";
        public string error_msg = "";
        public void OnGet()
        {

            try
            {
                update.customer_id = Convert.ToInt32(Request.Query["id"]);

                //Console.Write(update.s_id);
                // string s_id = Request.Query["id"];
                //Console.Write("s_id="+s_id);

                string ConnectionString = "Data Source=INLPF3KJ0JJ\\MSSQLSERVER01;Initial Catalog=master;trusted_connection=true";
                // string ConnectionString1 = _configuration.GetConnectionString("DefaultConnection");
                ;
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                string query = "select * from  CUSTOMERDETAILS where customer_id=@id";
                //name,product_id,orderdate,amount,address,phone from

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = update.customer_id;
                // cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    update.customer_id = reader.GetInt32(0);
                    update.name = reader.GetString(1);
                    update.product_id = reader.GetString(2);
                    update.orderdate = reader.GetDateTime(3);
                    update.amount = reader.GetInt64(4);
                    update.address = reader.GetString(5);
                    update.phone = reader.GetInt64(6);



                    list_name.Add(update);


                }
                list_name.ForEach(x => Console.WriteLine(x.customer_id + " " + x.name + " " + x.product_id + " " + x.orderdate + " " + x.amount + " " + x.address + " " + x.phone));

                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sql related problem");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("C# related problem");
            }
        }


        public void OnPost()
        {
            try
            {
                update.customer_id = Convert.ToInt32(Request.Query["id"]);


                string ConnectionString = "Data Source=INLPF3KJ0JJ\\MSSQLSERVER01;Initial Catalog=master;trusted_connection=true";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);

                Console.WriteLine("OnPost");

                update.customer_id = Convert.ToInt32(Request.Form["id"]);
                update.name = Request.Form["name"];
                update.product_id = Request.Form["product_id"];
                update.orderdate = Convert.ToDateTime(Request.Form["date"]);
                update.amount = Convert.ToInt64(Request.Form["amount"]);
                update.address = Request.Form["address"];
                update.phone = Convert.ToInt64(Request.Form["phone"]);


                Console.WriteLine(update.customer_id);
                Console.WriteLine(update.name);
                Console.WriteLine(update.product_id);
                Console.WriteLine(update.orderdate);
                Console.WriteLine(update.amount);
                Console.WriteLine(update.address);
                Console.WriteLine(update.phone);

                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("update_order", sqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                // cmd.ExecuteNonQuery();
                cmd.Parameters.Add("@p_cusid", System.Data.SqlDbType.Int).Value = update.customer_id;
                cmd.Parameters.Add("@p_name", System.Data.SqlDbType.VarChar).Value = update.name;
                cmd.Parameters.Add("@p_proid", System.Data.SqlDbType.VarChar).Value = update.product_id;
                cmd.Parameters.Add("@p_date", System.Data.SqlDbType.DateTime).Value = update.orderdate;
                cmd.Parameters.Add("@p_amount", System.Data.SqlDbType.BigInt).Value = update.amount;
                cmd.Parameters.Add("@p_address", System.Data.SqlDbType.VarChar).Value = update.address;
                cmd.Parameters.Add("@p_phone", System.Data.SqlDbType.BigInt).Value = update.phone;



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
                error_msg = ex.Message;
                return;
            }
            update.customer_id = 0;
            update.name = " ";
            update.product_id = "";
            update.amount = 0;
            update.address = " ";
            update.phone = 0;

            success_msg = "Successfully added";
            

            //Response.Redirect("/sales");

        }

    }
}
   

