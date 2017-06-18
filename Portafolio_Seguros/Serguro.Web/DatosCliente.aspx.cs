
using Seguro.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Serguro.Web
{
    public partial class DatosCliente : System.Web.UI.Page
    {
        Cliente cliente = null;        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                    Datos();
            }
        }

        protected void Seleccionar(object sender, GridViewSelectEventArgs e)
        {
            if (cliente == null)
            {
                cliente = (Cliente)Session.Contents["Cliente"];
            }
            MovimientoColeccion listaMovimientos = cliente.SiniestroColeccion[e.NewSelectedIndex].MovimientoColeccion;
            GridView1.Visible = false;
            GridView2.Visible = true;
            GridView2.DataSource = listaMovimientos;
            GridView2.DataBind();
        }

        private void Datos()
        {
            cliente = (Cliente)Session.Contents["Cliente"];
            if (cliente == null)
            {
                ServicioSeguro.ServicioSeguroClient seguro = new ServicioSeguro.ServicioSeguroClient();

                string rut = User.Identity.Name;

                cliente = new Cliente()
                {
                    Rut = rut
                };

                string xml = cliente.Serializar();
                xml = seguro.leerCliente(xml);
                cliente = new Cliente(xml);
                Session.Add("Cliente", cliente);
            }
                lblNombre.Text = cliente.Nombres + " " + cliente.Apellidos;
                lblRut.Text = cliente.Rut;
                lblCiudad.Text = cliente.Ciudad.Nombre;
                lblRegion.Text = cliente.Ciudad.Region.Nombre;
                lblVehiculo.Text = "";
                lblEstado.Text = cliente.Activo ? "Activo" : "Inactivo";
                foreach (var aux in cliente.VehiculoColeccion)
                {
                    lblVehiculo.Text += aux.Modelo.Marca.Nombre + " " + aux.Modelo.Nombre + " " + aux.Anio + " Patente: " + aux.Patente + " \n";
                }
            

            GridView2.Visible = false;
            GridView1.Visible = true;
            GridView1.DataSource = cliente.SiniestroColeccion;
            GridView1.DataBind();
        }

        protected void btnVolverSiniestros_Click(object sender, EventArgs e)
        {
            Datos();
        }
    }
}