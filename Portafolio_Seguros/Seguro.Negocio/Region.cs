using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Region
    {
        public int Id_region { get; set; }
        public string Nombre { get; set; }


        public Region()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM REGION WHERE ID_REGION = "+this.Id_region;
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Nombre = dr.GetString(1);
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
