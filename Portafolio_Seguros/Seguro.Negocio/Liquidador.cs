using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Liquidador
    {
        public string Id_liquidador { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }

        public Liquidador()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM LIQUIDADOR WHERE ID_LIQUIDADOR = '"+this.Id_liquidador+"'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Nombres = dr.GetString(3);
                this.Apellidos = dr.GetString(4);
                this.Correo = dr.GetString(5);

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
