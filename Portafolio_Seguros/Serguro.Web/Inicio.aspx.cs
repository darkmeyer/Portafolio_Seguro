using Seguro.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Serguro.Web
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatosCliente();
        }


        private void DatosCliente()
        {

            ServicioSeguro.ServicioSeguroClient seguro = new ServicioSeguro.ServicioSeguroClient();

            string rut = (string)Session.Contents["rut"];

            Cliente cliente = new Cliente()
            {
                Rut = rut
            };

            string xml = cliente.Serializar();
            xml = seguro.leerCliente(xml);
            cliente = new Cliente(xml);

            lblNombre.Text = cliente.Nombres + " " + cliente.Apellidos;
            lblRut.Text = cliente.Rut;
            lblCiudad.Text = cliente.Ciudad.Nombre;
            lblRegion.Text = cliente.Ciudad.Region.Nombre;
            lblVehiculo.Text = cliente.Vehiculo.Modelo.Marca.Nombre + " " + cliente.Vehiculo.Modelo.Nombre + " " + cliente.Vehiculo.Anio;
            string perdidaTotal = cliente.Seguro.Cobertura.perdida_Total ? "Si" : "No";
            string danioTerceros = cliente.Seguro.Cobertura.Dano_Terceros ? "Si" : "No";
            lblSeguro.Text = string.Format("Perdida Total: {1}{0}  Daño Terceros: {2}", Environment.NewLine, perdidaTotal, danioTerceros);

            

            string xmlColeccion = seguro.leerSiniestros(cliente.Id_cliente);
            SiniestroColeccion col = new SiniestroColeccion(xmlColeccion);

            var siniestros =
                (from sin in col
                 select new {Fecha = sin.Fecha, Estado = sin.Estado, Costo = sin.Costo, 
                            Liquidador = sin.Liquidador.Nombres + " " + sin.Liquidador.Apellidos,
                            Correo = sin.Liquidador.Correo, Telefono = sin.Liquidador.Fono}
                 );

            GridView1.DataSource = siniestros;
            GridView1.DataBind();
        }

    }
}