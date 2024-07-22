<%@ Page Title="" Language="C#" MasterPageFile="~/CapaVistas/Sitio1.Master" AutoEventWireup="true" CodeBehind="RegistroCandidatos.aspx.cs" Inherits="Votacionesweb.CapaVistas.RegistroCandidatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-8 col-lg-6">
            <div class="card">
                <div class="card-header">
                    <h3 class="text-center">Registro de Candidato</h3>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtNombre" CssClass="form-label">Nombre del Candidato</asp:Label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" required="required" />
                    </div>
                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtApellido" CssClass="form-label">Apellido del Candidato</asp:Label>
                        <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" required="required" />
                    </div>
                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtNumTelf" CssClass="form-label">Numero Telefono</asp:Label>
                        <asp:TextBox runat="server" ID="txtNumTelf" CssClass="form-control" TextMode="Phone" required="required" />
                    </div>                                
                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtPlataforma" CssClass="form-label">Plataforma</asp:Label>
                        <asp:TextBox runat="server" ID="txtPlataforma" CssClass="form-control" required="required" />
                    </div>                                     
                    <div class="mb-3">
                        <label class="form-label">ID Partido:</label>
                        <asp:DropDownList ID="ddlPartido" CssClass="form-control" class="form-control form-control-sm d-inline-block w-50" runat="server" EnableViewState="true" >
                        </asp:DropDownList>
                    </div>
                    <hr />
                    <div class="d-grid gap-2">
                        <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                        <asp:LinkButton runat="server" PostBackUrl="~/CapaVistas/Inicio.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
