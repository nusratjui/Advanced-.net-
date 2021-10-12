using Product_Vone.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Product_Vone.Models.Tables
{
    public class Orders
    {
        SqlConnection conn;
        public Orders(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Add(Order order)
        {

            string query = String.Format("Insert into Orders values ('{0}','{1}','{2}')", order.ProductId, order.Price, order.Name );
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}