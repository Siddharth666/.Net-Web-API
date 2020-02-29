using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerController : ApiController
    {
        private SqlConnection _conn = new SqlConnection("data source = DESKTOP-3QNMV56\\SQLEXPRESS; Initial catalog = SCB; Integrated Security = true;");
        private SqlDataAdapter _dataAdapter;

        public IEnumerable<Customer> Get()
        {
            //_conn = ;
            DataTable _dt = new DataTable();
            var query = "select Id, FirstName, LastName, City, Country, Phone from Customer order by Id asc";
            _dataAdapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _dataAdapter.Fill(_dt);
            List<Customer> customers = new List<Models.Customer>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow customerrecord in _dt.Rows)
                {
                    customers.Add(new ReadCustomer(customerrecord));
                }
            }
            return customers;
        }

        public IEnumerable<Customer> Get(int id)
        {
            _conn = new SqlConnection("data source = DESKTOP-3QNMV56\\SQLEXPRESS; Initial catalog = SCB; Integrated Security = true;");
            DataTable _dt = new DataTable();
            // var query = "select Id, FirstName, LastName from Customer WHERE Id=" + id;
            var query = "select CUS.FirstName, CUS.City, CUS.Phone, PDT.ProductName, PDT.Package, PDT.UnitPrice from customer CUS " +
                         "INNER JOIN[Order] ORD ON CUS.Id = ORD.CustomerId " +
                         "INNER JOIN[OrderItem] ORDTM ON ORD.Id = ORDTM.OrderId " +
                         "INNER JOIN Product PDT ON ORDTM.ProductId = PDT.Id " +
                         "where CUS.Id = "+id;
            _dataAdapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _dataAdapter.Fill(_dt);
            List<Customer> customers = new List<Models.Customer>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow studentrecord in _dt.Rows)
                {
                    customers.Add(new ReadProducts(studentrecord));
                }
            }
            return customers;
        }
    }
}
