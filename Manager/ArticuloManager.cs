using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Manager
{
    public class ArticuloManager
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS MarcaDescripcion, A.IdCategoria, C.Descripcion AS CategoriaDescripcion, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id and A.IdCategoria = C.Id and Precio > 0");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.TipoMarca = new Marca();
                    aux.TipoMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.TipoMarca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    aux.TipoCategoria = new Categoria();
                    aux.TipoCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.TipoCategoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Precio = Math.Round(aux.Precio, 2);

                    lista.Add(aux);
                }

                return lista;
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


        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.SetearParametro("@Codigo", nuevo.Codigo);
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Descripcion", nuevo.Descripcion);
                datos.SetearParametro("@IdMarca", nuevo.TipoMarca.Id);
                datos.SetearParametro("@IdCategoria", nuevo.TipoCategoria.Id);
                datos.SetearParametro("@Precio", nuevo.Precio);
                datos.ejecutarAccion();
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

        public void modificar(Articulo arti)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update  ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdCategoria = @IdCategoria, IdMarca = @IdMarca, Precio = @Precio  Where Id = @id");
                datos.SetearParametro("@Codigo", arti.Codigo);
                datos.SetearParametro("@Nombre", arti.Nombre);
                datos.SetearParametro("@Descripcion", arti.Descripcion);
                datos.SetearParametro("@IdMarca", arti.TipoMarca.Id);
                datos.SetearParametro("@IdCategoria", arti.TipoCategoria.Id);
                datos.SetearParametro("@Precio", arti.Precio);
                datos.SetearParametro("@id", arti.Id);

                datos.ejecutarAccion();
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

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("delete from ARTICULOS where id = @id");
                datos.SetearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarLogico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("update ARTICULOS set Precio = 0 Where id = @id");
                datos.SetearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {                      //no indique que traiga la imagen para que podamos definir primero como vamos a hacer
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS MarcaDescripcion, A.IdCategoria, C.Descripcion AS CategoriaDescripcion, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id and A.IdCategoria = C.Id and Precio > 0 AND ";
                if (campo == "precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "A.Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "A.Precio < " + filtro;
                            break;
                        default:
                            consulta += "A.Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.TipoMarca = new Marca();
                    aux.TipoMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.TipoMarca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    aux.TipoCategoria = new Categoria();
                    aux.TipoCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.TipoCategoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];


                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

