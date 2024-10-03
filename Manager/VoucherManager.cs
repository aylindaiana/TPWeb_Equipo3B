using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Manager
{
    public class VoucherManager
    {
        public Voucher BuscarVoucher(string CodigoVoucher) //pide el id y lista todas img de ese articulo
        {
            AccesoDatos datos = new AccesoDatos();
            Voucher aux = new Voucher();

            try
            {
                datos.SetearConsulta("SELECT CodigoVoucher,IdCliente,FechaCanje,IdArticulo FROM Vouchers WHERE UPPER(CodigoVoucher) = UPPER(@CodigoVoucher)");
                datos.SetearParametro("@CodigoVoucher", CodigoVoucher);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    aux.IdCliente = datos.Lector["IdCliente"] != DBNull.Value ? (int?)datos.Lector["IdCliente"] : null;
                    aux.IdArticulo = datos.Lector["IdArticulo"] != DBNull.Value ? (int?)datos.Lector["IdArticulo"] : null;
                    aux.FechaCanje = datos.Lector["FechaCanje"] != DBNull.Value ? (DateTime?)datos.Lector["FechaCanje"] : null;
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConeccion();
            }

        }
    }
}
