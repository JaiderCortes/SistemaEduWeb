<%@ Page Title="Gestión de alumnos y evaluación - EduWeb" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionEstudiantes.aspx.cs" Inherits="SistemaEduWeb.GestionEstudiantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="p-1">
        <div class="card">
    <h5 class="card-header"><i class="fas fa-pencil-ruler"></i> Gestión de alumnos y evaluación</h5>
    <div class="card-body">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-12">
                        <p>En esta sección podra gestionar a los estudiantes y calficar su desempeño en las actividades.</p>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-12">
                        <asp:GridView ID="GWEstudiantes" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" AllowPaging="true" PageSize="10">
                            <Columns>
                                <asp:BoundField DataField="IdEstudiante" HeaderText="Identificación estudiante" />
                                <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                                <asp:BoundField DataField="Area" HeaderText="Area" />
                                <asp:BoundField DataField="ActividadesRealizadas" HeaderText="Cantidad actividades" />
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
        </asp:UpdatePanel>
    </div>
</div>
    </main>
</asp:Content>
