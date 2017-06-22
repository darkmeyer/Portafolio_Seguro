using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Cargo
    {
        public int Id_Cargo { get; set; }
        public string Nombre { get; set; }

        public Cargo()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM CARGO WHERE id_Cargo = '" + this.Id_Cargo + "'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Nombre = dr.GetString(1);

                CommonBC.con.Close();
                CommonBC.con.Dispose();
                return true;
            }
            catch (Exception)
            {
                CommonBC.con.Close();
                CommonBC.con.Dispose();
                return false;
            }
        }
    }
}
