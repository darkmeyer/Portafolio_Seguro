using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Movimiento
    {
        public string Id_Movimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }


        public Movimiento()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM MOVIMIENTO WHERE id_movimiento = " + this.Id_Movimiento;
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Fecha = dr.GetDateTime(1);
                this.Descripcion = dr.GetString(2);
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
