using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Seguro.Negocio
{
    public class Cliente
    {
        public string Id_cliente { get; set; }
        private string _rut;

        public string Rut
        {
            get { return _rut; }
            set 
            { 
                string valor = value.Replace("-","");
                valor = valor.Replace(".", "");
                _rut = valor; 
            }
        }

        public string Pass { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Fono { get; set; }
        public string FechaNacimiento { get; set; }
        public bool Activo { get; set; }
        public string Direccion { get; set; }
        public VehiculoColeccion VehiculoColeccion { get; set; }
        public SiniestroColeccion SiniestroColeccion { get; set; }
        public Ciudad Ciudad { get; set; }



        public Cliente()
        {

        }

        public Cliente(string xml)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(Cliente));
            StringReader reader = new StringReader(xml);
            Cliente cliente = (Cliente)serializador.Deserialize(reader);
            this.Id_cliente = cliente.Id_cliente;
            this.Rut = cliente.Rut;
            this.Nombres = cliente.Nombres;
            this.Apellidos = cliente.Apellidos;
            this.Correo = cliente.Correo;
            this.Fono = cliente.Fono;
            this.FechaNacimiento = cliente.FechaNacimiento;
            this.Activo = cliente.Activo;
            this.Direccion = cliente.Direccion;
            this.VehiculoColeccion = cliente.VehiculoColeccion;
            this.SiniestroColeccion = cliente.SiniestroColeccion;
            this.Ciudad = cliente.Ciudad;
        }

        public string Serializar()
        {
            XmlSerializer serializador = new XmlSerializer(typeof(Cliente));
            StringWriter writer = new StringWriter();
            serializador.Serialize(writer, this);
            writer.Close();
            return writer.ToString();
        }


        public bool Leer()
        {
            try
            {
                string cmd = "SELECT * FROM CLIENTE WHERE RUT = '"+this.Rut+"'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                this.Id_cliente = dr.GetString(0);
                this.Nombres = dr.GetString(3);
                this.Apellidos = dr.GetString(4);
                this.Correo = dr.GetString(5);
                this.FechaNacimiento = dr.GetString(7);
                this.Activo = dr.GetString(8).Equals("t");
                this.Direccion = dr.GetString(9);

                Ciudad ciudad = new Ciudad()
                {
                    Id_ciudad = dr.GetInt32(10)
                };

                ciudad.Leer();

                this.Ciudad = ciudad;
                
                VehiculoColeccion vehiculoColeccion = new VehiculoColeccion();
                this.VehiculoColeccion = vehiculoColeccion.LeerTodos(this.Id_cliente);
                SiniestroColeccion siniestroColeccion = new SiniestroColeccion();
                this.SiniestroColeccion = siniestroColeccion.LeerTodos(this.Id_cliente);
                
                CommonBC.con.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool validarCliente()
        {
            try
            {
                string cmd = "SELECT * FROM CLIENTE WHERE RUT = '"+this.Rut+"'";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);
                string pass = dr.GetString(2);
                CommonBC.con.Close();
                if (BCrypt.Verify(this.Pass, pass))
                {
                    this.Pass = pass;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                CommonBC.con.Close();
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
