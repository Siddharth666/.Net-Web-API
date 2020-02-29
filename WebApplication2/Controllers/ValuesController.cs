using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using WebApplication2.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ClosedXML.Excel;
using System.IO;
using System.Configuration;
using System.Net.Mail;

namespace WebApplication2.Controllers
{
    public class ValuesController : ApiController
    {
        private SqlConnection _conn = new SqlConnection("data source = DESKTOP-3QNMV56\\SQLEXPRESS; Initial catalog = SCB; Integrated Security = true;");
        
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            
            return "value";
        }

        // POST api/values
        //[HttpPost]
        public string Post([FromBody]string value)
        {
            string to = "datamoulds2016@gmail.com";
            string from = "sidsin@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "Dot Net";
            message.Subject = "Dot Net";
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



            return "wsebh";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        
    }


}
