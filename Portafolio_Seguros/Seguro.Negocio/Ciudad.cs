using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Ciudad
    {
        public int Id_ciudad { get; set; }
        public string Nombre { get; set; }
        public Region Region { get; set; }

        public Ciudad()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM CIUDAD WHERE ID_CIUDAD = "+this.Id_ciudad;
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Nombre = dr.GetString(1);

                Region region = new Region()
                {
                    Id_region = dr.GetInt32(2)
                };
                region.Leer();
                this.Region = region;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
