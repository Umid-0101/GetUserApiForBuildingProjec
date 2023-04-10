using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace GetUserApi.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string FIN_KOD { get; set; }
        public string NAME_ { get; set; }
        public string SURNAME_ { get; set; }
        public string FATHER_NAME { get; set; }
        public string APARTMENT_NO { get; set; }
        public float SUM_ { get; set; }
        public string NOTE_ { get; set; }
        public DateTime CREATEDATE_USER { get; set; }
    }
    public class createUsers : Users
    {
    }
    public class ReadUsers : Users
    {
        public ReadUsers(DataRow row)
        {
            ID = Convert.ToInt32(row["id"]);
            FIN_KOD = row["FIN_KOD"].ToString();
            NAME_ = row["NAME_"].ToString();
            SURNAME_ = row["SURNAME_"].ToString();
            FATHER_NAME = row["FATHER_NAME"].ToString();
            APARTMENT_NO = row["APARTMENT_NO"].ToString();
            SUM_ = (float)Convert.ToDouble(row["SUM_"]);
            NOTE_ = row["NOTE_"].ToString();
            CREATEDATE_USER = Convert.ToDateTime(row["CREATEDATE_USER"]);
        }
    }
}