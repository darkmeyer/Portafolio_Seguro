using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Ciudad
    {
        public int Id_ciudad { get; set; }
        public string Nombre { get; set; }
        public int Id_region { get; set; }

        public Ciudad()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM CIUDAD WHERE ID_CIUDAD = "+this.Id_ciudad;
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Nombre = dr.GetString(1);
                this.Id_region = dr.GetInt32(2);
                CommonBC.con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
