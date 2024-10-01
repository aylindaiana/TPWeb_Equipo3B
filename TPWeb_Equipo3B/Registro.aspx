<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SitePrincipal.Master" CodeBehind="Registro.aspx.vb" Inherits="TPWeb_Equipo3B.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col">
            <hr />
            <div class="mb-3">
                <h1>Ingresa tus datos</h1>
                <div class="mb-3">
                    <label for="TextBoxDNI" class="form-label">DNI</label>
                    <asp:TextBox ID="TextBoxDNI" runat="server" CssClass="form-control" Placeholder="Ingrese su DNI" required Style="width: 235px;"></asp:TextBox>
                </div>
                <div class="row mb-3">
                    <div class="col">
                        <label for="TextBoxNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" Placeholder="Ingrese su nombre" required></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="TextBoxApellido" class="form-label">Apellido</label>
                        <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control" Placeholder="Ingrese su apellido" required></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="TextBoxEmail" class="form-label">Email</label>
                        <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control" Placeholder="Ingrese su email" TextMode="Email" required></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col">
                        <label for="TextBoxDireccion" class="form-label">Dirección</label>
                        <asp:TextBox ID="TextBoxDireccion" runat="server" CssClass="form-control" Placeholder="Ingrese su dirección" required></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="TextBoxCiudad" class="form-label">Ciudad</label>
                        <asp:TextBox ID="TextBoxCiudad" runat="server" CssClass="form-control" Placeholder="Ingrese su ciudad" required></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="TextBoxCP" class="form-label">Código Postal (CP)</label>
                        <asp:TextBox ID="TextBoxCP" runat="server" CssClass="form-control" Placeholder="Ingrese su código postal" required></asp:TextBox>
                    </div>
                </div>

                <div class="form-check mb-3">
                    <asp:CheckBox ID="CheckBoxTerminos" runat="server" CssClass="form-check-input" required />
                    <label class="form-check-label" for="CheckBoxTerminos">Acepto todos los términos</label>
                </div>

                <asp:Button ID="BotonParticipar" runat="server" Text="Participar" CssClass="btn btn-primary" />
            </div>
        </div>
        <div class="col-3"></div>
    </div>
</asp:Content>

