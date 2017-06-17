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
        public string Nombre { get; set; }
        public int Deducible { get; set; }
        public int Prima { get; set; }
        public string Id_vehiculo { get; set; }

        public Cobertura()
        {
            
        }


        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM COBERTURA WHERE VEHICULO_id_vehiculo = '" + this.Id_vehiculo + "'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);

                this.Id_cobertura = dr.GetString(0);
                this.Nombre = dr.GetString(1);
                this.Deducible = dr.GetInt32(2);
                this.Prima = dr.GetInt32(3);


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
