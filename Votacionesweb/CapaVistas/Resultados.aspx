<%@ Page Title="" Language="C#" MasterPageFile="~/CapaVistas/Sitio1.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="Votacionesweb.CapaVistas.Resultados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <!-- Card Container -->
                <div class="card">
                    <!-- Card Header -->
                    <div class="card-header bg-primary text-white">
                        <h1 class="mb-0">Resultados de la Votación</h1>
                    </div>
                    <!-- Card Body -->
                    <div class="card-body">
                        <h2>Ganador: <asp:Literal ID="litGanador" runat="server"></asp:Literal></h2>
                        <br />
                        <asp:GridView ID="gvResultados" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
                            <Columns>
                                <asp:BoundField DataField="NombreCompleto" HeaderText="Candidato" />
                                <asp:BoundField DataField="VotosRecibidos" HeaderText="Votos" />
                                <asp:BoundField DataField="PorcentajeVotos" HeaderText="Porcentaje" DataFormatString="{0:P2}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <!-- End Card Container -->
            </div>
        </div>
    </div>
</asp:Content>


