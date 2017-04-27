using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Cobertura
    {
        public string Id_cobertura { get; set; }
        public bool perdida_Total { get; set; }
        public bool Dano_Terceros { get; set; }

        public Cobertura()
        {
            
        }


        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM COBERTURA WHERE ID_COBERTURA = '" + this.Id_cobertura + "'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);

                this.perdida_Total = dr.GetString(1).Equals("t");
                this.Dano_Terceros = dr.GetString(2).Equals("t");

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
