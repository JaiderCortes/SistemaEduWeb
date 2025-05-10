<%@ Page Title="Recomendaciones personalizadas de apoyo escolar - EduWeb" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecomendacionesPersonalizadas.aspx.cs" Inherits="SistemaEduWeb.RecomendacionesPersonalizadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="p-1">
        <div class="card">
            <h5 class="card-header"><i class="fas fa-sticky-note"></i> Recomendaciones personalizadas</h5>
            <div class="card-body">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-12">
                                <p>En esta sección podra ver las recomendaciones personalizadas del estudiante, proporcionadas por los docentes.</p>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-12">
                                <asp:Panel ID="PnlDatosEstudiante" runat="server">
                                    <div class="row g-3">
                                        <h3>Recomendaciones de apoyo</h3>
                                        <asp:GridView ID="GWRecomEst" DataSourceID="SDSRecomEst" runat="server" AutoGenerateColumns="false"
                                            CssClass="table table-striped table-bordered" AllowPaging="true" PageSize="5" EmptyDataText="Estudiante sin recomendaciones de apoyo."
                                            OnPageIndexChanged="GWRecomEst_PageIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="Docente" HeaderText="Docente" />
                                                <asp:BoundField DataField="NombreArea" HeaderText="Área" />
                                                <asp:BoundField DataField="Descripcion" HeaderText="Recomendación" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SDSRecomEst" runat="server"></asp:SqlDataSource>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </main>
</asp:Content>
