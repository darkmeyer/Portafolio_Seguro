using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Modelo
    {
        public string Id_modelo { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }


        public Modelo()
        {

        }


        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM MODELO WHERE ID_MODELO = '" + this.Id_modelo + "'"; ;
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Nombre = dr.GetString(1);

                Marca marca = new Marca()
                {
                    Id_Marca = dr.GetString(2)
                };

                marca.Leer();

                this.Marca = marca;
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
