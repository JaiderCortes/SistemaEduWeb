<%@ Page Title="Reportes de avance por estudiante - EduWeb" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportesEstudiante.aspx.cs" Inherits="SistemaEduWeb.ReportesEstudiante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="p-1">
        <div class="card">
            <h5 class="card-header"><i class="fas fa-file-alt"></i> Reportes por estudiante</h5>
            <div class="card-body">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-12">
                                <p>En esta sección podra generar los reportes individuales por estudiante.</p>
                                <div class="row row-cols-lg-auto g-3 align-items-center">
                                    <div class="col-12">
                                        <label for="DDLEstudiantes" class="col-form-label">Seleccione un estudiante para generar el reporte de progreso: </label>
                                    </div>
                                    <div class="col-12">
                                        <asp:DropDownList ID="DDLEstudiantes" CssClass="form-select" runat="server" DataSourceID="SDSEstudiantes"
                                            DataTextField="Nombres" DataValueField="IdEstudiante"
                                            OnSelectedIndexChanged="DDLEstudiantes_SelectedIndexChanged"
                                            AutoPostBack="true">
                                            <asp:ListItem Enabled="false" Value="">Seleccione</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SDSEstudiantes" runat="server"></asp:SqlDataSource>
                                    </div>
                                    <div class="col-12">
                                        <asp:Button ID="BtnGenReport" runat="server" Text="Generar reporte" Visible="false" CssClass="btn btn-danger" OnClick="BtnGenReport_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="BtnGenReport" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </main>
</asp:Content>
