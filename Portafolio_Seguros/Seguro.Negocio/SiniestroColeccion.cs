using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Seguro.Negocio
{
    public class SiniestroColeccion : List<Siniestro>
    {
        
        public SiniestroColeccion()
        {

        }

        public SiniestroColeccion(string xml)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(SiniestroColeccion));
            StringReader reader = new StringReader(xml);
            SiniestroColeccion lista = (SiniestroColeccion)serializador.Deserialize(reader);
            this.AddRange(lista);
        }

        public string Serializar()        
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(SiniestroColeccion));
                StringWriter writer = new StringWriter();
                serializador.Serialize(writer, this);
                writer.Close();
                return writer.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public SiniestroColeccion LeerTodos(string idCliente)
        {
            try
            {
                SiniestroColeccion lista = new SiniestroColeccion();
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
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
