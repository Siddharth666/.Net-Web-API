using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Boolean Flag { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }

    public class CreateStudent: Student
    {

    }

    public class ReadStudent : Student
    {
        public ReadStudent(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            FirstName = row["FirstName"].ToString();
            LastName = row["LastName"].ToString();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    //public class Record

    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string City { get; set; }
    //    public string Country { get; set; }
    //    public string PhoneNo { get; set; }

    //}

    //public class ReadRecord : Record

    //{
    //    public ReadRecord(DataRow row)
    //    {
    //        Id = Convert.ToInt32(row["Id"]);
    //        FirstName = row["FirstName"].ToString();
    //        LastName = row["LastName"].ToString();
    //        City = row["City"].ToString();
    //        Country = row["Country"].ToString();
    //        PhoneNo = row["Phone"].ToString();
    //    }

    //    public int Id { get; set; }
    //}
}