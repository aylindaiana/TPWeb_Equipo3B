﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Manager;
using static TPWeb_Equipo3B.Premios;

namespace TPWeb_Equipo3B
{
    public partial class Premios : System.Web.UI.Page
    {
        public List<Articulo> articuloList { get; set; }
        public List<Imagen> imageList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ArticuloManager managerArticulo = new ArticuloManager();
                ImagenManager managerImagen = new ImagenManager();

                articuloList = managerArticulo.listar();
                imageList = managerImagen.listar();

                List<Imagen> imagenPorId = new List<Imagen>();

                var articuloXimagenes = new List<ArticuloConImagenes>();


                for (int i = 0; i < articuloList.Count; i++)
                {
                    imagenPorId = imageList.FindAll(
                    x => x.IdArticulo == articuloList[i].Id);

                }
                foreach (var articulo in articuloList)
                {
                    // Obtener las imágenes para el artículo actual
                    var imagenesDelArticulo = imageList.FindAll(x => x.IdArticulo == articulo.Id);
                    articuloXimagenes.Add(new ArticuloConImagenes
                    {
                        articulo = articulo,
                        imagen = imagenesDelArticulo
                    });
                }


                repRepetidor.DataSource = articuloXimagenes;
                repRepetidor.DataBind();
            }
        }
        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var articuloConImagenes = (ArticuloConImagenes)e.Item.DataItem;
                var repImagenes = (Repeater)e.Item.FindControl("repImagenes");
                repImagenes.DataSource = articuloConImagenes.imagen;
                repImagenes.DataBind();
            }
        }

        protected void btnYoTeElijo_Command(object sender, CommandEventArgs e)
        {
            // Obtener el ID del artículo
            int IdArticulo = Convert.ToInt32(e.CommandArgument);
            Session.Add("IdArticulo",IdArticulo);

            Response.Redirect("~/Registro.aspx");
        }

        public class ArticuloConImagenes
        {
            public Articulo articulo { get; set; }
            public List<Imagen> imagen { get; set; }
        }
    }
}