using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Negocio
{
    public class SiniestroColeccion : List<Siniestro>
    {
        
        public SiniestroColeccion()
        {

        }

        public List<Siniestro> LeerTodos(string idCliente)
        {
            try
            {
                List<Siniestro> lista = new List<Siniestro>();
                OracleConnection con;
                string conStr = "SELECT * FROM SINIESTRO WHERE CLIENTE_id_cliente = '" + idCliente + "'";
                con = CommonBC.Con;
                con.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = conStr;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Siniestro siniestro = new Siniestro()
                    {
                        Id_Siniestro = dr.GetString(0)
                    };
                    siniestro.Leer();
                    lista.Add(siniestro);
                }
                CommonBC.con.Close();
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
