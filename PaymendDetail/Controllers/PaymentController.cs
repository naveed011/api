using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using PaymendDetail.Models;

namespace PaymendDetail.Controllers
{
    public class PaymentController : ApiController
    {
        public HttpResponseMessage get()
        {
            string query = @"select * from dbo.PaymentTbl";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["ConnStringDb1"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Payment emp)
        {
            try
            {
                string query = @"Insert into dbo.PaymentTbl values
                                (
                                '" + emp.CardOwner + @"'
                                ,'" + emp.CardNumber + @"'
                                ,'" + emp.ExpDate + @"'
                                ,'" + emp.SecurityCode + @"'
                                )";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ConnStringDb1"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully";
            }
            catch (Exception ex)
            {

                return "Failed to add";
            }

        }

        public string Put(Payment emp)
        {
            try
            {
                string query = @"Update dbo.PaymentTbl set 
                                    
                                    CardOwner = '" + emp.CardOwner + @"',
                                    CardNumber = '" + emp.CardNumber + @"',
                                    ExpDate = '" + emp.ExpDate + @"',
                                    SecurityCode = '" + emp.SecurityCode + @"'
                                    WHERE PaymentId = " + emp.PaymentId + @" ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ConnStringDb1"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Update Successfully";
            }
            catch (Exception)
            {

                return "Failed to update";
            }

        }

        public string Delete(int id)
        {
            try
            {
                string query = @"DELETE from dbo.PaymentTbl WHERE PaymentId = " + id + @" ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ConnStringDb1"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Delete Successfully";
            }
            catch (Exception)
            {

                return "Failed to delete";
            }

        }
    }
}
