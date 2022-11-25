using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace netCore.Pages
{
    public class salesModel : PageModel
    {

        public List<Sales_info> list_name = new List<Sales_info>();

        public void OnGet()
        {
            try
            {

                string ConnectionString = "Data Source=INLPF3KJ0JJ\\MSSQLSERVER01;Initial Catalog=master;trusted_connection=true";
                // string ConnectionString1 = _configuration.GetConnectionString("DefaultConnection");
                ;
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                string query = "select * from CUSTOMERDETAILS";

                SqlCommand cmd = new SqlCommand(query, sqlCon);
                // cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //cmd.ExecuteNonQuery();
                

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Sales_info info = new Sales_info();
                    info.customer_id = reader.GetInt32(0);
                    info.name = reader.GetString(1);
                    info.product_id = reader.GetString(2);
                    info.orderdate = reader.GetDateTime(3);
                    info.amount = reader.GetInt64(4);
                    info.address = reader.GetString(5);
                    info.phone = reader.GetInt64(6);

                    list_name.Add(info);


                }
                list_name.ForEach(x => Console.WriteLine(x.customer_id + " " + x.name + " " + x.product_id + " " + x.orderdate + " " + x.amount + " " + x.address + " " + x.phone));

                //Console.Log(list_name);
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


    }


    public class Sales_info
    {
        public int customer_id;
        public string product_id, name, address;
        public long amount, phone;
        public DateTime orderdate;

    }
}



