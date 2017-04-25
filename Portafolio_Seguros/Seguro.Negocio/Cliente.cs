﻿using Oracle.DataAccess.Client;
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
        public string Rut { get; set; }
        public string Pass { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string IdVehiculo { get; set; }
        public string IdSeguro { get; set; }
        public Ciudad Ciudad { get; set; }



        public Cliente()
        {

        }

        public Cliente(string xml)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(Cliente));
            StringReader reader = new StringReader(xml);
            Cliente cliente = (Cliente)serializador.Deserialize(reader);
            this.Rut = cliente.Rut;
            this.Nombres = cliente.Nombres;
            this.Apellidos = cliente.Apellidos;
            this.Correo = cliente.Correo;
            this.FechaNacimiento = cliente.FechaNacimiento;
            this.Direccion = cliente.Direccion;
            this.IdVehiculo = cliente.IdVehiculo;
            this.IdSeguro = cliente.IdSeguro;
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
                this.FechaNacimiento = dr.GetDateTime(6);
                this.Direccion = dr.GetString(7);
                this.IdVehiculo = dr.GetString(8);
                this.IdSeguro = dr.GetString(9);

                Ciudad ciudad = new Ciudad()
                {
                    Id_ciudad = dr.GetInt32(10)
                };

                ciudad.Leer();

                this.Ciudad = ciudad;
                
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
                string cmd = "SELECT PKG_GETDATOS.F_LOGIN_CLIENTE('" + this.Rut + "'" + ",'" + this.Pass + "') from dual";
                OracleDataReader dr = CommonBC.OracleDataReader(cmd);                
                if (dr.GetString(0) == "T")
                {
                    CommonBC.con.Close();
                    return true;
                }
                else
                {
                    CommonBC.con.Close();
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