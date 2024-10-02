using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Manager;

namespace TPWeb_Equipo3B
{
    public partial class Premios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloManager manager = new ArticuloManager();

           // ListarArticulos = manager.listarConSP();
        }
    }
}