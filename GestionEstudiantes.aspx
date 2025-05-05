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
                                <p>En esta sección podra administrar los datos de los estudiantes así como ver su progreso individual.</p>
                                <p>También puede crear nuevos estudiantes.</p>
                                <div class="row row-cols-lg-auto g-3 align-items-center">
                                    <div class="col-12">
                                        <label for="DDLEstudiantes" class="col-form-label">Seleccione un estudiante para ver sus datos y su progreso: </label>
                                    </div>
                                    <div class="col-12">
                                        <asp:DropDownList ID="DDLEstudiantes" CssClass="form-select" runat="server" DataSourceID="SDSEstudiantes"
                                            DataTextField="Nombres" DataValueField="IdEstudiante"
                                            OnSelectedIndexChanged="DDLEstudiantes_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SDSEstudiantes" runat="server"></asp:SqlDataSource>
                                    </div>
                                    <div class="col-12">
                                        <asp:Button ID="BtnNuevoEstudiante" runat="server" Text="Nuevo estudiante" CssClass="btn btn-success" OnClick="BtnNuevoEstudiante_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="PnlNuevEst" runat="server" CssClass="row bg-info rounded p-2 mt-2" Visible="false">
                            <div class="col-12">
                                <div class="row g-3">
                                    <h3>Datos nuevo estudiante</h3>
                                    <div class="col-md-3">
                                        <label for="TxtIdEstudianteNew" class="form-label">Identificación</label>
                                        <asp:TextBox ID="TxtIdEstudianteNew" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label for="TxtNombresNew" class="form-label">Nombres</label>
                                        <asp:TextBox ID="TxtNombresNew" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label for="TxtApellidosNew" class="form-label">Apellidos</label>
                                        <asp:TextBox ID="TxtApellidosNew" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label for="TxtFechNacNew" class="form-label">Fecha de nacimiento</label>
                                        <asp:TextBox ID="TxtFechNacNew" CssClass="form-control" runat="server" type="date"></asp:TextBox>
                                    </div>
                                    <div class="col-12">
                                        <asp:Button ID="BtnGuardarNuevo" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardarNuevo_Click" />
                                        <asp:Button ID="BtnCancelGuardarNuevo" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="BtnCancelGuardarNuevo_Click" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="row mt-3">
                            <div class="col-12">
                                <asp:Panel ID="PnlDatosEstudiante" runat="server" Visible="false">
                                    <div class="row g-3">
                                        <h3>Datos estudiante</h3>
                                        <div class="col-md-3">
                                            <label for="TxtIdEstudiante" class="form-label">Identificación</label>
                                            <asp:TextBox ID="TxtIdEstudiante" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <label for="TxtNombres" class="form-label">Nombres</label>
                                            <asp:TextBox ID="TxtNombres" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <label for="TxtApellidos" class="form-label">Apellidos</label>
                                            <asp:TextBox ID="TxtApellidos" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <label for="TxtFechNac" class="form-label">Fecha de nacimiento</label>
                                            <asp:TextBox ID="TxtFechNac" CssClass="form-control" runat="server" type="date"></asp:TextBox>
                                        </div>
                                        <div class="col-12">
                                            <asp:Button ID="BtnGuardarEst" runat="server" Text="Guardar datos" CssClass="btn btn-primary" OnClick="BtnGuardarEst_Click" />
                                            <asp:Button ID="BtnNuevRecom" runat="server" Text="Nueva recomendación" CssClass="btn btn-warning" OnClick="BtnNuevRecom_Click" />
                                        </div>
                                    </div>
                                    <asp:Panel ID="PnlRecomApoyo" runat="server" CssClass="row bg-info rounded p-2 mt-2" Visible="false">
                                        <div class="row">
                                            <h3>Nueva recomendación de apoyo</h3>
                                            <div class="col-md-12">
                                                <label for="DDLAreas" class="col-form-label">Area: </label>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="DDLAreas" CssClass="form-select" runat="server" Width="150px" DataSourceID="SDSAreas" DataTextField="Nombre" DataValueField="IdArea" AppendDataBoundItems="true"></asp:DropDownList>
                                                <asp:SqlDataSource ID="SDSAreas" runat="server"></asp:SqlDataSource>
                                            </div>
                                            <div class="col-md-12">
                                                <label for="TxtObsRecom" class="form-label">Observación</label>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TxtObsRecom" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12 mt-1">
                                                <asp:Button ID="BtnGuardRecom" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardRecom_Click" />
                                                <asp:Button ID="BtnCancelGuardRecom" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="BtnCancelGuardRecom_Click" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <div class="row g-3">
                                        <h3>Progreso estudiante</h3>
                                        <asp:GridView ID="GWProgresEst" DataSourceID="SDSProgresEst" runat="server" AutoGenerateColumns="false"
                                            CssClass="table table-striped table-bordered" AllowPaging="true" PageSize="5" EmptyDataText="Estudiante sin progreso registrado."
                                            OnPageIndexChanged="GWProgresEst_PageIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="NombreArea" HeaderText="Área" />
                                                <asp:BoundField DataField="ActividadesRealizadas" HeaderText="Cantidad de actividades realizadas" />
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SDSProgresEst" runat="server"></asp:SqlDataSource>
                                    </div>
                                    <div class="row g-3">
                                        <h3>Recomendaciones de apoyo</h3>
                                        <asp:GridView ID="GWRecomEst" DataSourceID="SDSRecomEst" runat="server" AutoGenerateColumns="false"
                                            CssClass="table table-striped table-bordered" AllowPaging="true" PageSize="5" EmptyDataText="Estudiante sin recomendaciones de apoyo."
                                            OnPageIndexChanged="GWRecomEst_PageIndexChanged">
                                            <Columns>
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
