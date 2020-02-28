using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimesheetWebAPI.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TimesheetWebAPI.Controllers
{
    public class TimesheetController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            string query = @"select TitleId, TitleName, Hours, 
                            convert(varchar(10), Date, 104) as Date from tblTimesheet";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDb"].ConnectionString))
            using(var cmd = new SqlCommand(query, con))
            using(var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dt);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }
    }
}
