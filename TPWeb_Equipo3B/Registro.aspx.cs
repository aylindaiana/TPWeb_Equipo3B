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

    public partial class Registro : System.Web.UI.Page
    {
        Cliente clienteActual = new Cliente();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBoxDNI_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente();

            if (clienteActual.Id != 0)
                MostrarDatosCliente(clienteActual);
        }

        protected void BotonParticipar_Click(object sender, EventArgs e)
        {
            if (CheckBoxTerminos.Checked == false)
            {
                MensajeAviso("Acepte los terminos y condiciones");
                return;
            }

            BuscarCliente();

            if (clienteActual.Id == 0)
                GuardarCliente();


            Response.Redirect("~/GraciasPorParticipar.aspx");
        }


        private void MostrarDatosCliente(Cliente clienteActual)
        {
            TextBoxNombre.Text = clienteActual.Nombre;
            TextBoxApellido.Text = clienteActual.Apellido;
            TextBoxEmail.Text = clienteActual.Email;
            TextBoxDireccion.Text = clienteActual.Direccion;
            TextBoxCiudad.Text = clienteActual.Ciudad;
            TextBoxCP.Text = clienteActual.CP.ToString();
        }

        private Cliente ObtenerDatosCliente()
        {
            Cliente aux = new Cliente();
            int cp;

            aux.Documento = TextBoxDNI.Text;
            aux.Nombre = TextBoxNombre.Text;
            aux.Apellido = TextBoxApellido.Text;
            aux.Email = TextBoxEmail.Text;
            aux.Direccion = TextBoxDireccion.Text;
            aux.Ciudad = TextBoxCiudad.Text;
            int.TryParse(TextBoxCP.Text, out cp);
            aux.CP = cp;

            return aux;
        }

        private void BuscarCliente()
        {
            ClienteManager clienteManager = new ClienteManager();

            try
            {
                clienteActual = clienteManager.BuscarCliente(TextBoxDNI.Text);
            }
            catch (Exception ex)
            {
                MensajeAviso(ex.ToString());
            }
        }

        private void GuardarCliente()
        {
            ClienteManager clienteManager = new ClienteManager();
            clienteActual = ObtenerDatosCliente();

            clienteManager.Agregar(clienteActual);
        }

        private void ActualizarVoucher()
        {
            //obtener el codigo del voucher obtenido
            //obtener el codigo del articulo elegido
            //Actualizar voucher
        }

        private void MensajeAviso(string data)
        {
            string script = "alert('" + data.Replace("'", "\\'") + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", script, true);
        }
    }
}