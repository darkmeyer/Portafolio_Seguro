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
            lblCiudad.Text = cliente.Ciudad.Nombre;

            SiniestroColeccion col = new SiniestroColeccion();
            List<Siniestro> lista = col.LeerTodos(cliente.Id_cliente);

            GridView1.DataSource = lista.Select(o => new { o.Fecha, o.Estado, o.Costo, o.Liquidador.Nombres, o.Liquidador.Apellidos, o.Liquidador.Correo, o.Liquidador.Fono });
            GridView1.DataBind();
        }

    }
}