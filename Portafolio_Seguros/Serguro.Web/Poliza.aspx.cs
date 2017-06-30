using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Serguro.Web
{
    public partial class Poliza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = (@"C:\Users\Public\poliza");
            path += Session.Contents["nombrePoliza"].ToString() + ".pdf";
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path);

            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
    }
}