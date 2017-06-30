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
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public string Patente { get; set; }
        public Empleado Empleado { get; set; }
        public Ciudad Ciudad { get; set; }
        public Taller Taller { get; set; }
        public MovimientoColeccion MovimientoColeccion { get; set; }


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
                this.Direccion = dr.GetString(3);
                this.Estado = dr.GetString(4);
                this.Patente = dr.GetString(7);

                Empleado empleado = new Empleado()
                {
                    Id_Empleado = dr.GetString(8)
                };
                empleado.Leer();
                this.Empleado = empleado;
                Ciudad ciudad = new Ciudad()
                {
                    Id_ciudad = dr.GetInt32(9)
                };
                ciudad.Leer();
                this.Ciudad = ciudad;
                Taller taller = new Taller()
                {
                    Id_Taller = dr.GetString(11)
                };
                taller.Leer();
                this.Taller = taller;

                MovimientoColeccion movimientoColeccion = new MovimientoColeccion();
                this.MovimientoColeccion = movimientoColeccion.LeerTodos(this.Id_Siniestro);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
