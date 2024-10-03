<%@ Page Title="" Language="C#" MasterPageFile="~/SitioPrincipal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_Equipo3B.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form>
     <div class="row">
         <div class="col-3"></div>
         <div class="col">
             <hr />
             <div class="mb-3">
                 <label for="exampleInputEmail1" class="form-label fw-bold">Ingresa el código de tu boucher</label>
                 <asp:TextBox ID="txbIngresoVaucher" runat="server" class="form-control"/>
             </div>
             <asp:Button ID="btnAceptar" runat="server" Text="Siguiente" CssClass="btn btn-primary" OnClick="btnAceptar_Click1" />
         </div>
         <div class="col-3"></div>
     </div>
 </form>
</asp:Content>
