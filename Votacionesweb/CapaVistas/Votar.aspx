<%@ Page Title="" Language="C#" MasterPageFile="~/CapaVistas/Sitio1.Master" AutoEventWireup="true" CodeBehind="Votar.aspx.cs" Inherits="Votacionesweb.CapaVistas.Votar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-8 col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <h3 class="text-center">Registrar Voto</h3>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="ddlCandidatos" CssClass="form-label">Seleccionar Candidato</asp:Label>
                            <asp:DropDownList ID="ddlCandidatos" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>                           
                        <asp:Button ID="btnVotar" runat="server" Text="Votar" CssClass="btn btn-primary" OnClick="btnVotar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>