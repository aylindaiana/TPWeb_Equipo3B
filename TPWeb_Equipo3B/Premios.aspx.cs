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
        public List<Articulo> articuloList {  get; set; }
        public List<Imagen> imageList { get; set; }

        private void BuscarId(object sender, EventArgs e)
        {
            

            
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            if(!IsPostBack)
            {

                ArticuloManager managerArticulo = new ArticuloManager();

                ImagenManager managerImagen = new ImagenManager();

                articuloList = managerArticulo.listar(); 
                imageList = managerImagen.listar();

                List<Imagen> imagenPorId = new List<Imagen>();

                imagenPorId = imageList.FindAll(
                    x => x.IdArticulo == articuloList[0].Id );

                var articulosConImagenes = articuloList.Select(a => new
                {
                    a.Id,
                    Imagenes = imageList.Where(i => i.IdArticulo == a.Id).ToList() // Filtra imágenes para cada artículo
                }).ToList();

                repRepetidor.DataSource = articulosConImagenes;
                repRepetidor.DataBind();

                
            }
            
             
        }
    }
}