using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Empleado
    {
        public string Id_Empleado { get; set; }
        public string Rut { get; set; }
        public string Pass { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Fono { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public Ciudad Ciudad { get; set; }
        public Cargo Cargo { get; set; }

        public Empleado()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM EMPLEADO WHERE id_empleado = '" + this.Id_Empleado + "'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Rut = dr.GetString(1);
                this.Nombres = dr.GetString(3);
                this.Apellidos = dr.GetString(4);
                this.Correo = dr.GetString(5);
                this.Fono = dr.GetString(6);
                this.FechaNacimiento = dr.GetString(7);
                this.Direccion = dr.GetString(8);

                Ciudad ciudad = new Ciudad()
                {
                    Id_ciudad = dr.GetInt32(9)
                };
                ciudad.Leer();
                this.Ciudad = ciudad;
                Cargo cargo = new Cargo()
                {
                    Id_Cargo = dr.GetInt32(10)
                };

                Cargo.Leer();

                this.Cargo = cargo;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
