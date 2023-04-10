using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using GetUserApi.Models;
using System.Configuration;

namespace GetUserApi.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        // GET: api/Users
        public IEnumerable<Users> Get()
        {
            string maincon = ConfigurationManager.ConnectionStrings["myconection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);
            DataTable dt = new DataTable();
            var query = "select * from USERS";
            SqlDataAdapter da = new SqlDataAdapter 
            {
                SelectCommand = new SqlCommand(query,con)
            };
            da.Fill(dt);
            List<Users> users = new List<Models.Users>(dt.Rows.Count);
            if (dt.Rows.Count>0)
            {
                foreach(DataRow userrecord in dt.Rows)
                {
                    users.Add(new ReadUsers(userrecord));
                }
            }
            return users;
        }

        [HttpGet]
        // GET: api/Users/5
        public IEnumerable<Users> Get(int id)
        {
            string maincon = ConfigurationManager.ConnectionStrings["myconection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);
            DataTable dt = new DataTable();
            var query = "select * from USERS where ID = "+id;
            SqlDataAdapter da = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            da.Fill(dt);
            List<Users> users = new List<Models.Users>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow userrecord in dt.Rows)
                {
                    users.Add(new ReadUsers(userrecord));
                }
            }
            return users;
         
        }

        //GetFinKod
        [HttpGet]
        public IEnumerable<Users> GetFin(string finkod)
        {
            string maincon = ConfigurationManager.ConnectionStrings["myconection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);
            DataTable dt = new DataTable();
            var query = "select * from USERS where FIN_KOD = " + finkod;
            SqlDataAdapter da = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            da.Fill(dt);
            List<Users> users = new List<Models.Users>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow userrecord in dt.Rows)
                {
                    users.Add(new ReadUsers(userrecord));
                }
            }
            return users;

        }


        //GetMenzilNo
        [HttpGet]
        public IEnumerable<Users> GetAprtmentNo(string menzilno)
        {
            string maincon = ConfigurationManager.ConnectionStrings["myconection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);
            DataTable dt = new DataTable();
            var query = "select * from USERS where APARTMENT_NO = " + menzilno;
            SqlDataAdapter da = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            da.Fill(dt);
            List<Users> users = new List<Models.Users>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow userrecord in dt.Rows)
                {
                    users.Add(new ReadUsers(userrecord));
                }
            }
            return users;

        }





        [HttpPost]
        // POST: api/Users
        public string Post([FromBody] createUsers value) 
        {
            string maincon = ConfigurationManager.ConnectionStrings["myconection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);
            var query = "insert into USERS values(upper(@finkod),upper(@ad),upper(@soyad),upper(@ataadi),upper(@menzilno),upper(@mebleg),upper(@qeyd),upper(getdate())) ";
            SqlCommand insertcommand =new SqlCommand(query, con);
            insertcommand.Parameters.AddWithValue("@finkod", value.FIN_KOD);
            insertcommand.Parameters.AddWithValue("@ad", value.NAME_);
            insertcommand.Parameters.AddWithValue("@soyad", value.SURNAME_);
            insertcommand.Parameters.AddWithValue("@ataadi", value.FATHER_NAME);
            insertcommand.Parameters.AddWithValue("@menzilno", value.APARTMENT_NO);
            insertcommand.Parameters.AddWithValue("@mebleg", value.SUM_);
            insertcommand.Parameters.AddWithValue("@qeyd", value.NOTE_);
            con.Open();
            int result=insertcommand.ExecuteNonQuery();
            if (result>0)
            {
                return "Inserted has been successfully!";
            }
            else
            {
                return "error!";
            }
        }

        public string Put(int id, [FromBody] createUsers value) 
        {
            try
            {

                string maincon = ConfigurationManager.ConnectionStrings["myconection"].ConnectionString;
                SqlConnection con = new SqlConnection(maincon);
                var query = "update USERS set FIN_KOD=@finkod,NAME_=@ad,SURNAME_=@soyad,FATHER_NAME=@ataadi,APARTMENT_NO=@menzilno,SUM_=@mebleg,NOTE_=@qeyd where ID=" + id;
                SqlCommand updatecommand = new SqlCommand(query, con);
                updatecommand.Parameters.AddWithValue("@finkod", value.FIN_KOD);
                updatecommand.Parameters.AddWithValue("@ad", value.NAME_);
                updatecommand.Parameters.AddWithValue("@soyad", value.SURNAME_);
                updatecommand.Parameters.AddWithValue("@ataadi", value.FATHER_NAME);
                updatecommand.Parameters.AddWithValue("@menzilno", value.APARTMENT_NO);
                updatecommand.Parameters.AddWithValue("@mebleg", value.SUM_);
                updatecommand.Parameters.AddWithValue("@qeyd", value.NOTE_);
                con.Open();
                int result = updatecommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return "Updated has been succesfully!";
                }
                else
                {
                    return "Error!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;

            } 

        }



        [HttpDelete]

        // DELETE: api/Users/5
        public string Delete(int id)
        {
            string maincon = ConfigurationManager.ConnectionStrings["myconection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);
            var query = "delete from USERS where ID="+id;
            SqlCommand deleteCommand = new SqlCommand(query, con);
            con.Open();
            int result = deleteCommand.ExecuteNonQuery();

            if (result > 0)
            {
                return "Deleted has been successfully!";
            }
            else
            {
                return "Error!";
            }

        }
    }
}
