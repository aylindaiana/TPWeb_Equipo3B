<%@ Page Title="" Language="C#" MasterPageFile="~/SitioPrincipal.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="TPWeb_Equipo3B.Premios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h2>Aca visualiza los productos y elije UNO</h2>
        <h3>caja para el agregar dni </h3>

    <br />
 
        <div id="carousel<%# Eval("Id") %>">
        <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel"> 
             <div class="carousel-inner"  >
             
              <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate> 
                
                    <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>" >
                         <img src="<%# Eval("ImagenUrl")%>" class="d-block w-10" alt="unauna" style="height: 200px; width: 100%; object-fit: contain;">
                         <div class="carousel-caption d-none d-md-block">
                             
                            <h5 class="card-title"> <%# Eval("IdArticulo") %> </h5>
                            <p class="card-text">bbbb</p>
                         </div>
                     </div>     
                  
                 </ItemTemplate>
             </asp:Repeater>  
 
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="prev">
                 <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button> 
         </div>
    </div>
 
</asp:Content>
