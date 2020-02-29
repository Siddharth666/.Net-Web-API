using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http.Cors;
using System.Net.Mail;
using System.Text;

namespace WebApplication2.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {
        // GET api/values

        private SqlConnection _conn = new SqlConnection("data source = DESKTOP-3QNMV56\\SQLEXPRESS; Initial catalog = SCB; Integrated Security = true;");
        private SqlDataAdapter _dataAdapter;
        public IEnumerable<Student> Get()
        {
            //_conn = ;
            DataTable _dt = new DataTable();
            var query = "select Id, FirstName, LastName from Customer order by Id asc";
            _dataAdapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _dataAdapter.Fill(_dt);
            List<Student> students = new List<Models.Student>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow studentrecord in _dt.Rows)
                {
                    students.Add(new ReadStudent(studentrecord));
                }
            }
            return students;
        }

        // GET api/values/5
        public IEnumerable<Student> Get(int id)
        {
            _conn = new SqlConnection("data source = DESKTOP-3QNMV56\\SQLEXPRESS; Initial catalog = SCB; Integrated Security = true;");
            DataTable _dt = new DataTable();
            var query = "select Id, FirstName, LastName from Customer WHERE Id=" + id;
            _dataAdapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _dataAdapter.Fill(_dt);
            List<Student> students = new List<Models.Student>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow studentrecord in _dt.Rows)
                {
                    students.Add(new ReadStudent(studentrecord));
                }
            }
            return students;
        }

        // POST api/values


        public string Post([FromBody]CreateStudent value)
        {
            //CreateStudent cs = new CreateStudent();
            if (value.Flag != true)
            {
                var query = "INSERT INTO Customer (FirstName, LastName) values (@FirstName, @LastName)";
                SqlCommand insertcomm = new SqlCommand(query, _conn);
                insertcomm.Parameters.AddWithValue("@FirstName", value.FirstName);
                insertcomm.Parameters.AddWithValue("@LastName", value.LastName);
                _conn.Open();
                int n = insertcomm.ExecuteNonQuery();
                if (n > 0)
                {
                    return "Succesfull";
                }
                else
                {
                    return "Failed";
                }
            }
            else {
                string to = value.To;//"datamoulds2016@gmail.com";
                string from = "datamoulds@gmail.com"; //From address    
                MailMessage message = new MailMessage(from, to);

                string mailbody = value.Body;//"Dot Net";
                message.Subject = value.Subject;//"Dot Net";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("datamoulds@gmail.com", "Tombofstone1987$");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                try
                {
                    client.Send(message);
                }

                catch (Exception ex)
                {
                    throw ex;
                }



                return "Email Sent Properly";
            }

        }

        // PUT api/values/5
        public string Put(int id, [FromBody]CreateStudent value)
        {
            var query = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName WHERE Id =" + id;
            SqlCommand updatecomm = new SqlCommand(query, _conn);
            updatecomm.Parameters.AddWithValue("@FirstName", value.FirstName);
            updatecomm.Parameters.AddWithValue("@LastName", value.LastName);
            _conn.Open();
            int n = updatecomm.ExecuteNonQuery();
            if (n > 0)
            {
                return "Update Succesfull";
            }
            else
            {
                return "Update Failed";
            }
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            var query = "DELETE FROM CUSTOMER WHERE Id =" + id;
            SqlCommand delecomm = new SqlCommand(query, _conn);
            //updatecomm.Parameters.AddWithValue("@FirstName", value.FirstName);
            //updatecomm.Parameters.AddWithValue("@LastName", value.LastName);
            _conn.Open();
            int n = delecomm.ExecuteNonQuery();
            if (n > 0)
            {
                return "Update Succesfull";
            }
            else
            {
                return "Update Failed";
            }
        }

        public class EmailFunction
        {
        }
    }
}


//Video for above Web API
//https://www.youtube.com/watch?v=D4n3562z6F4
