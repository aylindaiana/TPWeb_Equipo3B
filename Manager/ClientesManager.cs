﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ClientesManager
    {

        public Cliente BuscarCliente(string Documento) //pide el id y lista todas img de ese articulo
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente aux = new Cliente();

            try
            {
                datos.SetearConsulta("SELECT Id,Documento,Nombre,Apellido,Email,Direccion,Ciudad,CP FROM Clientes WHERE Documento = @Documento");
                datos.SetearParametro("@Documento", Documento);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Documento = (string)datos.Lector["Documento"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Ciudad = (string)datos.Lector["Ciudad"];
                    aux.CP = (int)datos.Lector["CP"];
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
