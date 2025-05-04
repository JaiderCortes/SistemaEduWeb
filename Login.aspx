<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaEduWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ingreso - EduWeb</title>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/Content/css") %>
    </asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="sweetalert.min.js" Assembly="System.Web" Path="~/Scripts/sweetalert.min.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
            </Scripts>
        </asp:ScriptManager>
        <div class="container py-5">
            <div class="row justify-content-center">
                <div class="col-md-7">
                    <div class="card shadow">
                        <div class="card-header">
                            <h3 class="text-center font-weight-light my-4">Ingreso EduWeb</h3>
                            <hr />
                            <ul class="nav nav-tabs card-header-tabs" id="loginTabs" role="tablist">
                                <li class="nav-item">
                                    <button class="nav-link active text-primary" id="estudiantes-tab" data-bs-toggle="tab" data-bs-target="#estudiantes" type="button" role="tab"><i class="fas fa-user-graduate"></i> Ingreso Estudiantes</button>
                                </li>
                                <li class="nav-item">
                                    <button class="nav-link text-success" id="docentes-tab" data-bs-toggle="tab" data-bs-target="#docentes" type="button" role="tab"><i class="fas fa-chalkboard-teacher"></i> Ingreso Docentes</button>
                                </li>
                                <li class="nav-item">
                                    <button class="nav-link text-warning" id="padres-tab" data-bs-toggle="tab" data-bs-target="#padres" type="button" role="tab"><i class="fas fa-users"></i> Ingreso Padres de Familia</button>
                                </li>
                            </ul>
                        </div>
                        <div class="card-body">
                            <div class="tab-content" id="loginTabsContent">
                                <!-- Estudiantes -->
                                <div class="tab-pane fade show active" id="estudiantes" role="tabpanel">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="TxtIdEstudiante" runat="server" AutoCompleteType="Disabled" type="text" placeholder="Número de documento" CssClass="form-control"></asp:TextBox>
                                                <label for="TxtIdEstudiante">Número de documento</label>
                                            </div>
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="TxtPassEstudiante" runat="server" AutoCompleteType="Disabled" type="password" placeholder="Contraseña" CssClass="form-control"></asp:TextBox>
                                                <label for="TxtPassEstudiante">Contraseña</label>
                                            </div>
                                            <asp:Button ID="BtnIngresoEstudiante" runat="server" Text="Iniciar Sesión" type="submit" class="btn btn-primary w-100" OnClick="BtnIngresoEstudiante_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                                <!-- Docentes -->
                                <div class="tab-pane fade" id="docentes" role="tabpanel">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="TxtIdDocente" runat="server" AutoCompleteType="Disabled" type="text" placeholder="Número de documento" CssClass="form-control"></asp:TextBox>
                                                <label for="TxtIdDocente">Número de documento</label>
                                            </div>
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="TxtPassDocente" runat="server" AutoCompleteType="Disabled" type="password" placeholder="Contraseña" CssClass="form-control"></asp:TextBox>
                                                <label for="TxtPassDocente">Contraseña</label>
                                            </div>
                                            <asp:Button ID="BtnIngresoDocente" runat="server" Text="Iniciar Sesión" type="submit" class="btn btn-success w-100" OnClick="BtnIngresoDocente_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                                <!-- Padres de Familia -->
                                <div class="tab-pane fade" id="padres" role="tabpanel">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="TxtIdPadre" runat="server" AutoCompleteType="Disabled" type="text" placeholder="Número de documento" CssClass="form-control"></asp:TextBox>
                                                <label for="TxtIdPadre">Número de documento</label>
                                            </div>
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="TxtPassPadre" runat="server" AutoCompleteType="Disabled" type="password" placeholder="Contraseña" CssClass="form-control"></asp:TextBox>
                                                <label for="TxtPassPadre">Contraseña</label>
                                            </div>
                                            <asp:Button ID="BtnIngresoPadre" runat="server" Text="Iniciar Sesión" type="submit" class="btn btn-warning w-100" OnClick="BtnIngresoPadre_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/Scripts/bootstrap.bundle.js") %>
        <%: Scripts.Render("~/Scripts/scripts.js") %>
        <%: Scripts.Render("~/Scripts/fontawesome/all.min.js") %>
    </asp:PlaceHolder>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            const estudianteInputs = document.querySelectorAll('#estudiantes input');
            const docenteInputs = document.querySelectorAll('#docentes input');
            const padreInputs = document.querySelectorAll('#padres input');

            function setupEnterHandler(inputs, buttonId) {
                inputs.forEach(input => {
                    input.addEventListener('keypress', function (event) {
                        if (event.key === 'Enter') {
                            event.preventDefault();
                            document.getElementById(buttonId).click();
                        }
                    });
                });
            }

            setupEnterHandler(estudianteInputs, '<%= BtnIngresoEstudiante.ClientID %>');
            setupEnterHandler(docenteInputs, '<%= BtnIngresoDocente.ClientID %>');
            setupEnterHandler(padreInputs, '<%= BtnIngresoPadre.ClientID %>');
        });
    </script>

</body>
</html>
