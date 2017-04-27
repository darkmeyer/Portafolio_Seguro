using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Vehiculo
    {
        public string Id_vehiculo { get; set; }
        public string Patente { get; set; }
        public int Anio { get; set; }
        public int Valor_fiscal { get; set; }
        public Modelo Modelo { get; set; }


        public Vehiculo()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM VEHICULO WHERE ID_VEHICULO = '" + this.Id_vehiculo +"'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Patente = dr.GetString(1);
                this.Anio = dr.GetInt32(2);
                this.Valor_fiscal = dr.GetInt32(3);
                Modelo modelo = new Modelo()
                {
                    Id_modelo = dr.GetString(4)
                };
                modelo.Leer();
                this.Modelo = modelo;
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
