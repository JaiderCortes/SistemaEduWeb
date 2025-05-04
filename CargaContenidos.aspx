<%@ Page Title="Carga de contenidos - EduWeb" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaContenidos.aspx.cs" Inherits="SistemaEduWeb.CargaContenidos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="p-1">
        <div class="card">
            <h5 class="card-header"><i class="fas fa-folder-plus"></i> Carga de contenidos</h5>
            <div class="card-body">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-12">
                                <p>En esta sección podra cargar los contenidos multimedia por área para los estudiantes.</p>
                                <p>Para cargar un contenido multimedia, seleccione el área correspondiente y haga clic en el botón "Nuevo".</p>
                                <p>Una vez que haya cargado el contenido, podrá eliminarlo en cualquier momento.</p>
                                <div class="row row-cols-lg-auto g-3 align-items-center">
                                    <div class="col-12">
                                        <label for="DDLAreas" class="col-form-label">Seleccione el área y el archivo: </label>
                                    </div>
                                    <div class="col-12">
                                        <asp:DropDownList ID="DDLAreas" CssClass="form-select" runat="server" Width="150px" DataSourceID="SDSAreas" DataTextField="Nombre" DataValueField="IdArea" AppendDataBoundItems="true"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SDSAreas" runat="server"></asp:SqlDataSource>
                                    </div>
                                    <div class="col-12">
                                        <asp:FileUpload ID="FileContenido" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-12">
                                        <asp:Button ID="BtnNuevoContenido" runat="server" Text="Agregar"  CssClass="btn btn-success" OnClick="BtnNuevoContenido_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-12">
                                <asp:GridView ID="GridViewArchivos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" OnRowCommand="GridViewArchivos_RowCommand" OnPageIndexChanging="GridViewArchivos_PageIndexChanging" AllowPaging="true" PageSize="5">
                                    <Columns>
                                        <asp:BoundField DataField="NombreArea" HeaderText="Área" />
                                        <asp:BoundField DataField="NombreArchivo" HeaderText="Archivo" />
                                        <asp:BoundField DataField="TamañoKB" HeaderText="Tamaño (KB)" />
                                        <asp:TemplateField HeaderText="Descargar">
                                            <ItemTemplate>
                                                <a href='<%# Eval("RutaRelativa") %>' target="_blank" class="btn btn-outline-primary btn-sm">
                                                    <i class="fas fa-download"></i> Descargar
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Acciones">
                                            <ItemTemplate>
                                                <asp:Button ID="BtnEliminar" runat="server" CommandName="EliminarArchivo" CommandArgument='<%# Eval("Id") %>' Text="Eliminar" CssClass="btn btn-danger btn-sm"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="BtnNuevoContenido" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </main>
</asp:Content>
