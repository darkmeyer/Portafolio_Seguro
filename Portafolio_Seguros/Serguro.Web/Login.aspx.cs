using Seguro.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Serguro.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Cliente cli = new Cliente()
            {
                Rut = Login1.UserName,
                Pass = Login1.Password
            };

            if (cli.validarCliente())
            {
                Session["rut"] = Login1.UserName;
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}