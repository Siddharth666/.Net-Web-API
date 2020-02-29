using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebApplication2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }

    public class ReadCustomer : Customer
    {
        public ReadCustomer(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            FirstName = row["FirstName"].ToString();
            LastName = row["LastName"].ToString();
            City = row["City"].ToString();
            Country = row["Country"].ToString();
            Phone = row["Phone"].ToString();
        }

        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string City { get; set; }
        //public string Country { get; set; }
        //public string Phone { get; set; }
    }

    public class ReadProducts : Customer
    {
        public ReadProducts(DataRow dr)
        {
            FirstName = dr["FirstName"].ToString();
            City = dr["City"].ToString();
            Phone = dr["Phone"].ToString();
            ProductName = dr["ProductName"].ToString();
            Package = dr["Package"].ToString();
            UnitPrice = Convert.ToDouble(dr["UnitPrice"]);
        }

        public string ProductName { get; set; }
        public string Package { get; set; }
        public double UnitPrice { get; set; }
    }
}