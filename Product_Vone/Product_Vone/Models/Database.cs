using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Product_Vone.Models.Entities;
using Product_Vone.Models.Tables;

namespace Product_Vone.Models
{
    public class Database
    {
        SqlConnection conn;
        public Products Products { get; set; }
        public Database()
        {
            string connString = @"Server= DESKTOP-5B8CN0F\SQLEXPRESS; Database=UMS; Integrated Security=true";
            conn = new SqlConnection(connString);
            Products = new Products(conn);
        }
    }
}