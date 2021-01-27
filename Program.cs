using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Data;  
using System.Data.SqlClient;

namespace Arqueria
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            string connection = "Database=Arqueria;Server=localhost;user=root;password=;";
            CreateCommand("",connection);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void CreateCommand(string queryString,string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Coeasdasfdsafsedf"); 
               // SqlCommand command = new SqlCommand(queryString, connection);
                //command.Connection.Open();
                //command.ExecuteNonQuery();
            }
        }
    }
}
