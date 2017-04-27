using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Marca
    {
        public string Id_Marca { get; set; }
        public string Nombre { get; set; }


        public Marca()
        {

        }


        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM MARCA WHERE ID_MARCA = '" + this.Id_Marca + "'";
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
