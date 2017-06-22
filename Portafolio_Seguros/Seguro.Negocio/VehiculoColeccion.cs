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
    public class VehiculoColeccion : List<Vehiculo>
    {

        public VehiculoColeccion ()
	    {

	    }

        public VehiculoColeccion(string xml)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(VehiculoColeccion));
            StringReader reader = new StringReader(xml);
            VehiculoColeccion lista = (VehiculoColeccion)serializador.Deserialize(reader);
            this.AddRange(lista);
        }

        public string Serializar()        
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(VehiculoColeccion));
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

        public VehiculoColeccion LeerTodos(string idCliente)
        {
            try
            {
                VehiculoColeccion lista = new VehiculoColeccion();
                OracleConnection con;
                string conStr = "SELECT * FROM VEHICULO WHERE CLIENTE_id_cliente = '" + idCliente + "'";
                con = CommonBC.Con;
                con.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = conStr;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Vehiculo ve = new Vehiculo()
                    {
                        Id_vehiculo = dr.GetString(0)
                    };
                    ve.Leer();
                    lista.Add(ve);
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
