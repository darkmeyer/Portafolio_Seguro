
using Seguro.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            btnVolverSiniestros.Visible = true;
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
            btnVolverSiniestros.Visible = false;
            GridView1.DataSource = cliente.SiniestroColeccion;
            GridView1.DataBind();
        }

        protected void btnVolverSiniestros_Click(object sender, EventArgs e)
        {
            Datos();
        }

        protected void btnPoliza_Click(object sender, EventArgs e)
        {

            if (cliente == null)
                cliente = (Cliente)Session.Contents["Cliente"];

            Response.Redirect("poliza.aspx");
        }

        protected void CustomersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (cliente == null)
                cliente = (Cliente)Session.Contents["Cliente"];

            if (e.CommandName == "Presupuesto")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Siniestro siniestro = cliente.SiniestroColeccion[index];
                string nombrePresupuesto = "pre";
                nombrePresupuesto += cliente.Id_cliente + "-" + siniestro.Id_Siniestro+".pdf";
                Session.Add("nombrePresupuesto", nombrePresupuesto);
                Response.Redirect("Presupuesto.aspx");
            }

        }
    }
}