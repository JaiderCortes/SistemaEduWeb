<%@ Page Title="Actividades interactivas - EduWeb" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActividadesInteractivas.aspx.cs" Inherits="SistemaEduWeb.ActividadesInteractivas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="p-1">
        <div class="card">
            <h5 class="card-header"><i class="fas fa-puzzle-piece"></i>Actividades interactivas</h5>
            <div class="card-body">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-12">
                                <p>Bienvenido a las actividades interactivas. En esta sección encontrarás actividades en línea para fortalecer tus conocimientos.</p>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-12">
                                <div class="accordion" id="accordionActividades">
                                    <div class="accordion-item">
                                        <h2 class="accordion-header">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseMatematicas" aria-expanded="true" aria-controls="collapseMatematicas">
                                                Matematicas
                                            </button>
                                        </h2>
                                        <div id="collapseMatematicas" class="accordion-collapse collapse show" data-bs-parent="#accordionActividades">
                                            <div class="accordion-body">
                                                <iframe allow="autoplay; allow-top-navigation-by-user-activation" width="795" height="690" frameborder="0" src="https://es.educaplay.com/juego/14731877-evaluacion_numero_enteros.html"></iframe>
                                                <asp:Button ID="BtnProgMat" runat="server" Text="Registrar progreso" CssClass="btn btn-success" OnClick="BtnProgMat_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="accordion-item">
                                        <h2 class="accordion-header">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSociales" aria-expanded="false" aria-controls="collapseSociales">
                                                Ciencias sociales
                                            </button>
                                        </h2>
                                        <div id="collapseSociales" class="accordion-collapse collapse" data-bs-parent="#accordionActividades">
                                            <div class="accordion-body">
                                                <iframe allow="autoplay; allow-top-navigation-by-user-activation" width="795" height="690" frameborder="0" src="https://es.educaplay.com/juego/8702193-territorios_de_colombia.html"></iframe>
                                                <asp:Button ID="BtnProgSoc" runat="server" Text="Registrar progreso" CssClass="btn btn-success" OnClick="BtnProgSoc_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="accordion-item">
                                        <h2 class="accordion-header">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseNaturales" aria-expanded="false" aria-controls="collapseNaturales">
                                                Ciencias naturales
                                            </button>
                                        </h2>
                                        <div id="collapseNaturales" class="accordion-collapse collapse" data-bs-parent="#accordionActividades">
                                            <div class="accordion-body">
                                                <iframe allow="autoplay; allow-top-navigation-by-user-activation" width="795" height="690" frameborder="0" src="https://es.educaplay.com/juego/16300940-clasificacion_de_los_animales.html"></iframe>
                                                <asp:Button ID="BtnProgNat" runat="server" Text="Registrar progreso" CssClass="btn btn-success" OnClick="BtnProgNat_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="accordion-item">
                                        <h2 class="accordion-header">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseArtes" aria-expanded="false" aria-controls="collapseArtes">
                                                Artes
                                            </button>
                                        </h2>
                                        <div id="collapseArtes" class="accordion-collapse collapse" data-bs-parent="#accordionActividades">
                                            <div class="accordion-body">
                                                <iframe allow="autoplay; allow-top-navigation-by-user-activation" width="795" height="690" frameborder="0" src="https://es.educaplay.com/juego/6774127-instrumentos_musicales.html"></iframe>
                                                <asp:Button ID="BtnProgArt" runat="server" Text="Registrar progreso" CssClass="btn btn-success" OnClick="BtnProgArt_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="accordion-item">
                                        <h2 class="accordion-header">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseHumanidades" aria-expanded="false" aria-controls="collapseHumanidades">
                                                Humanidades
                                            </button>
                                        </h2>
                                        <div id="collapseHumanidades" class="accordion-collapse collapse" data-bs-parent="#accordionActividades">
                                            <div class="accordion-body">
                                                <iframe allow="autoplay; allow-top-navigation-by-user-activation" width="795" height="690" frameborder="0" src="https://es.educaplay.com/juego/12183041-conceptos_basicos.html"></iframe>
                                                <asp:Button ID="BtnProgHum" runat="server" Text="Registrar progreso" CssClass="btn btn-success" OnClick="BtnProgHum_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="accordion-item">
                                        <h2 class="accordion-header">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseCastellano" aria-expanded="false" aria-controls="collapseCastellano">
                                                Lengua castellana
                                            </button>
                                        </h2>
                                        <div id="collapseCastellano" class="accordion-collapse collapse" data-bs-parent="#accordionActividades">
                                            <div class="accordion-body">
                                                <iframe allow="autoplay; allow-top-navigation-by-user-activation" width="795" height="690" frameborder="0" src="https://es.educaplay.com/juego/8131851-parrafo.html"></iframe>
                                                <asp:Button ID="BtnProgCast" runat="server" Text="Registrar progreso" CssClass="btn btn-success" OnClick="BtnProgCast_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </main>
</asp:Content>
