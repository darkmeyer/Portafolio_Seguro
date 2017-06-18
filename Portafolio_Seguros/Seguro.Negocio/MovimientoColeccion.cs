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
    public class MovimientoColeccion : List<Movimiento>
    {
        public MovimientoColeccion()
        {

        }

        public MovimientoColeccion(string xml)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(MovimientoColeccion));
            StringReader reader = new StringReader(xml);
            MovimientoColeccion lista = (MovimientoColeccion)serializador.Deserialize(reader);
            this.AddRange(lista);
        }

        public string Serializar()        
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(MovimientoColeccion));
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

        public MovimientoColeccion LeerTodos(string idSiniestro)
        {
            try
            {
                MovimientoColeccion lista = new MovimientoColeccion();
                OracleConnection con;
                string conStr = "SELECT * FROM MOVIMIENTO WHERE SINIESTRO_id_siniestro = '" + idSiniestro + "'";
                con = CommonBC.Con;
                con.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = conStr;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Movimiento mov = new Movimiento()
                    {
                        Id_Movimiento = dr.GetString(0)
                    };
                    mov.Leer();
                    lista.Add(mov);
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
