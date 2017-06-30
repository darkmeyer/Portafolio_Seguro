using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Taller
    {
        public string Id_Taller { get; set; }
        public string Nombre { get; set; }
        public string Fono { get; set; }
        public string Direccion { get; set; }
        public Ciudad Ciudad { get; set; }
        public Empleado Empleado { get; set; }


        public Taller()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM TALLER WHERE id_taller = " + "'"+this.Id_Taller+"'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Nombre = dr.GetString(1);
                this.Fono = dr.GetString(2);
                this.Direccion = dr.GetString(3);

                Ciudad ciudad = new Ciudad()
                {
                    Id_ciudad = dr.GetInt32(4)
                };
                ciudad.Leer();
                this.Ciudad = ciudad;
                
                Empleado empleado = new Empleado()
                {
                    Id_Empleado = dr.GetString(5)
                };
                empleado.Leer();
                this.Empleado = empleado;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
