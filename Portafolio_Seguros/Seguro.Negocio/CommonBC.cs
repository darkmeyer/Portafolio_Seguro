
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class CommonBC
    {
        
        private static OracleConnection _con;

        public static OracleConnection Con
        {
            get
            {
                _con = new OracleConnection();
                _con.ConnectionString = "data source=localhost:1521/xe;password=1234;user id=SEGURO";
                return _con;
            }
        }

        public static OracleConnection con;        

        public static OracleDataReader OracleDataReader(string cmdString)
        {
            con = CommonBC.Con;
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = cmdString;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return dr;
        }
    }
}
