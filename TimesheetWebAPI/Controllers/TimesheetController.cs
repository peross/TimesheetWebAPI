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

        public string Post(Timesheet ts)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"insert into tblTimesheet (TitleName, Hours, Date) 
                                Values
                                (
                                 '" + ts.TitleName + @"' 
                                  ,'" + ts.Hours + @"'
                                  ,'" + ts.Date + @"'
                                )";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);
                }

                return "Added Successfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Put(Timesheet ts)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"update tblTimesheet set 
                                TitleName='" + ts.TitleName + @"'
                                ,Hours='" + ts.Hours + @"'
                                ,Date='" + ts.Date + @"'
                                where TitleId=" +ts.TitleId +@"";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);
                }

                return "Updated Successfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"delete from tblTimesheet where TitleId=" + id;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);
                }

                return "Deleted Successfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
