<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditExamen.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.EditExamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2 style="padding-top:15px"><%= (usuario._perfil == "Administrador" ? "Administrar Examenes" : "Fecha de Examenes") %>.</h2>
    
    <asp:UpdatePanel ID="Repeater" runat="server">
        <ContentTemplate>
        <div>
            <a ID="Aniadir" class="btn btn-dark Administrador"  OnClick="cambiarVisibilidad('Pnl_fromInsert')" >Añadir Examen</a>
            <a ID="Borrar"  class="btn btn-dark Administrador"  OnClick="cambiarVisibilidad('Pnl_fromBorrar')" >Borrar Examen</a>

        </div>
            <div id="Pnl_fromBorrar"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div  class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon7">ID de la Examen</span>
                        <asp:TextBox  CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_borrarExamen" placeholder="Ingresar id de la materia a borrar" runat="server" />
                    </div>
                    <asp:Button  CssClass="btn btn-dark" ID="btn_borrarCarrera" Text="Borrar de Base de Datos" OnClick="btn_borrarCarrera_Click" OnClientClick="cambiarVisibilidad('Pnl_fromBorrar')" runat="server" />
                </div>
            </div>
            <div id="Pnl_fromInsert"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div id="escalame" class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon3">Nombre de la Materia del examen</span>
                        <asp:TextBox  CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_idMateria" placeholder="Ingresar Carrera" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon4">Horario del examen</span>
                        <asp:TextBox CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_horario" placeholder="Tarde/Mañana" runat="server" />
                    </div>
                    <asp:Button  CssClass="btn btn-dark" ID="Insert" Text="Añadir a Base de Datos" OnClick="Insert_Click" OnClientClick="cambiarVisibilidad('Pnl_fromInsert')" runat="server" />
                </div>
            </div>           
            <p id="flag" style="visibility:hidden"  ></p>

                                

            <table class="table table-dark ">
              <thead>
                <tr>
                  <th scope="col">ID</th>
                  <th scope="col">Nombre de la Materia |ID|</th>
                  <th scope="col">Horario</th>
                </tr>
              </thead>
              <tbody>
                <asp:Repeater ID="tbl_repeaterMaterias" runat="server">
                    <ItemTemplate>
                        <tr >
                          <th scope="row">
                              <asp:Label ID="IDExamen" Text='<%#Eval("_idExamen")%>' runat="server" /></td>
                          <td scope="row">
                              <p><asp:Label ID="nombreMateria" Text='<%#Eval("_nombreMateria")%>' runat="server" />|<%# Eval("_idMateria")%>|</p></td>
                          <td>
                              <asp:Label ID="horario"  Text='<%#Eval("_horario")%>' runat="server" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
              </tbody>
            </table>
               
            
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
