using Dominio;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_Equipo3B
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            VoucherManager voucher_manager = new VoucherManager();
            Voucher voucherActual = new Voucher();

            try
            {
                voucherActual = voucher_manager.BuscarVoucher(txbIngresoVaucher.Text);
            }
            catch (Exception ex)
            {
                MensajeAviso(ex.ToString());
            }


            if (voucherActual.CodigoVoucher == null)
            {
                MensajeAviso("El voucher ingresado no es valido");
                return;
            }

            if (voucherActual.IdCliente != null)
            { 
                MensajeAviso("Voucher ya utilizado");
                return;
            }

            //Guardo datos del voucher
            Session.Add("voucher",voucherActual);
            Response.Redirect("~/Premios.aspx");
        }

        private void MensajeAviso(string data) 
        {
            string script = "alert('" + data.Replace("'", "\\'") + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", script, true);
        }
    }
}