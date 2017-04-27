using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class Seguro
    {

        public string Id_seguro { get; set; }
        public int Valor { get; set; }
        public bool Activo { get; set; }
        public Cobertura Cobertura { get; set; }

        public Seguro()
        {

        }

        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM SEGURO WHERE ID_SEGURO = '" + this.Id_seguro + "'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);

                this.Valor = dr.GetInt32(1);
                this.Activo = dr.GetString(2).Equals("t");

                Cobertura cobertura = new Cobertura()
                {
                    Id_cobertura = dr.GetString(3)
                };
                cobertura.Leer();
                this.Cobertura = cobertura;

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
