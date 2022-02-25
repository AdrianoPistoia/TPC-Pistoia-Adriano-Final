<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TablonMensajes.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.TablonMensajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2><%: "Tablon de anuncios" %>.</h2>
    
    <asp:UpdatePanel ID="Repeater" runat="server" >
        <ContentTemplate>
            <div></div>
        <div class="col col-6" style="display:flex">
            <a ID="Aniadir" class="btn btn-dark Profesor"  OnClick="cambiarVisibilidad('Pnl_fromInsert')" >Añadir Mensaje</a>
            <a ID="Borrar"  class="btn btn-dark Profesor"  OnClick="cambiarVisibilidad('Pnl_fromBorrar')" >Borrar Mensaje</a>

        </div>
            <div id="Pnl_fromBorrar"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div  class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon7">ID del Mensaje</span>
                        <asp:TextBox  CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_borrarMensaje" placeholder="Ingresar id del mensaje a borrar" runat="server" />
                    </div>
                        <asp:Button  CssClass="btn btn-dark" ID="btn_borrarMensaje" Text="Borrar de Base de Datos" OnClick="btn_borrarMensaje_Click" OnClientClick="cambiarVisibilidad('Pnl_fromBorrar')" runat="server" />
                </div>
            </div>
            <div id="Pnl_fromInsert"  class="col-md-10 " style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div  class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon4">Asunto</span>
                        <asp:TextBox  CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_asunto" placeholder="Ingresar Asunto" runat="server" />
                    </div
                    <div id="escalame" class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon3">Mensaje</span>
                        <asp:TextBox  CssClass="form-control " TextMode="MultiLine" style="background-color:black;color:aliceblue" ID="txb_mensaje"  placeholder="Ingresar mensaje" runat="server" />
                        <asp:Button  CssClass="btn btn-dark" type="text" ID="Insert" Text="Añadir a Base de Datos" OnClick="Insert_Click" OnClientClick="cambiarVisibilidad('Pnl_fromInsert')" runat="server" />
                    </div
                </div>
            </div>           
            <p id="flag" style="visibility:hidden"  ></p>

                <asp:Repeater ID="tbl_repeaterMaterias" runat="server">
                    <ItemTemplate>
                        <div class="card" style="width: 24rem;z-index:-999999">
                          <div class="card-body btn btn-secondary">
                              <div style="display:flex; flex-direction:row">
                                <p class="btn btn-warning btn-outline-light" style=" color:black;font-weight:bold;font-size:12px">|<%# Eval("id") %>|</p>
                                <h5 class="card-title btn btn-dark col-10" ><%# Eval("Asunto") %></h5>
                              </div>
                            <p class="card-text btn btn-dark col-12" style="align-items:start" ><%# Eval("mensaje") %></p>
                            <p class="card-subtitle mb-2 text-muted" style="color:black !important">Enviado por <%:usuario._nombreCompleto%> [<%#Eval("horario") %>]  </p>
                          </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        if ('<%: usuario._perfil %>' == "Alumno") { FiltoParaAlumnos(); }
        if ('<%: usuario._perfil %>' == "Profesor") { FiltoParaProfes(); }

        function cambiarVisibilidad(string) {

            if (document.getElementById(string).style.display == "none")
            {
                document.getElementById(string).style.display = "inherit"
                document.getElementById(string).style.position = "absolute"
            }
            else {
                document.getElementById(string).style.display = "none"
                document.getElementById(string).style.position = "relative"
            }
        }

    </script>
</asp:Content>
