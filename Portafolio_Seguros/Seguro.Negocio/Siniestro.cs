using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Siniestro
    {

        public string Id_Siniestro { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Fecha_termino { get; set; }
        public string Estado { get; set; }
        public int Deducible { get; set; }
        public int Costo { get; set; }
        public Liquidador Liquidador { get; set; }

        public Siniestro()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM SINIESTRO WHERE ID_SINIESTRO = '"+this.Id_Siniestro+"'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Fecha = dr.GetDateTime(1);
                this.Fecha_termino = dr.GetDateTime(2);
                this.Estado = dr.GetString(3);
                this.Deducible = dr.GetInt32(4);
                this.Costo = dr.GetInt32(5);

                Liquidador liquidador = new Liquidador()
                {
                    Id_liquidador = dr.GetString(8)
                };
                liquidador.Leer();
                this.Liquidador = liquidador;
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
