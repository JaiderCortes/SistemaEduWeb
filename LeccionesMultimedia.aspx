<%@ Page Title="Lecciones multimedia - EduWeb" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeccionesMultimedia.aspx.cs" Inherits="SistemaEduWeb.LeccionesMultimedia" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="p-1">
        <div class="card">
            <h5 class="card-header"><i class="fas fa-photo-video"></i> Lecciones multimedia</h5>
            <div class="card-body">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-12">
                                <p>Bienvenido a las lecciones multimedia destinadas para su aprendizaje y fortalecimiento de habilidades.</p>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-12">
                                <asp:GridView ID="GridLecciones" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" OnPageIndexChanging="GridLecciones_PageIndexChanging" AllowPaging="true" PageSize="5">
                                    <Columns>
                                        <asp:BoundField DataField="NombreArea" HeaderText="Área" />
                                        <asp:BoundField DataField="NombreArchivo" HeaderText="Archivo" />
                                        <asp:BoundField DataField="TamañoKB" HeaderText="Tamaño (KB)" />
                                        <asp:TemplateField HeaderText="Descargar">
                                            <ItemTemplate>
                                                <a href='<%# Eval("RutaRelativa") %>' target="_blank" class="btn btn-outline-primary btn-sm">
                                                    <i class="fas fa-download"></i>Descargar
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </main>
</asp:Content>
