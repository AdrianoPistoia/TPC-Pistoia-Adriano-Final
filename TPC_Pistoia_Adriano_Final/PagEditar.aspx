<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagEditar.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.PagEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2><%: "Administrar Usuarios" %>.</h2>
    
    <asp:UpdatePanel ID="Repeater" runat="server">
        <ContentTemplate>
        <div>
            <a ID="Aniadir" class="btn btn-dark"  OnClick="cambiarVisibilidad('Pnl_fromInsert')" >Añadir Usuario</a>
            <a ID="Borrar"  class="btn btn-dark"  OnClick="cambiarVisibilidad('Pnl_fromBorrar')" >Borrar Usuario</a>

        </div>
            <div id="Pnl_fromBorrar"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div  class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon7">Legajo del Usuario</span>
                        <asp:TextBox  CssClass="form-control" style="background-color:black;color:aliceblue" ID="txb_borrarLegajo" pattern="[0-9]{5}"  placeholder="Ingresar legajo del usuario a borrar" runat="server" />
                    </div>
                    <asp:Button  CssClass="btn btn-dark" ID="btn_borrarUser" Text="Borrar de Base de Datos" OnClick="btn_borrarUser_Click" OnClientClick="cambiarVisibilidad('Pnl_fromBorrar')" runat="server" />
                </div>
            </div>
            <div id="Pnl_fromInsert"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div id="escalame" class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon3">Perfil de Acceso</span>
                        <asp:TextBox  CssClass="form-control " style="background-color:black;color:aliceblue"  pattern="[1-3]" ID="txb_perfil" placeholder="Ingresar '1'/'2'/'3' para Admin/Profesor/Alumno respectivamente" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon4">Direccion de Email</span>
                        <asp:TextBox CssClass="form-control " style="background-color:black;color:aliceblue"  ID="txb_email"   placeholder="Email" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text"  id="basic-addon5">Contraseña Temporal</span>
                        <asp:TextBox CssClass="form-control " type="password" maxlenght="19" style="background-color:black;color:aliceblue"  ID="txb_contra" placeholder="DNI como su contraseña temporal" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon6">Nombre Completo</span>
                        <asp:TextBox CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_nombre"  placeholder="Nombre comlpeto con espacios" runat="server" />
                    </div>
                    <asp:Button  CssClass="btn btn-dark" ID="Insert" Text="Añadir a Base de Datos" OnClick="Insert_Click" OnClientClick="cambiarVisibilidad('Pnl_fromInsert')" runat="server" />
                </div>
            </div>           
            <p id="flag" style="visibility:hidden"  ></p>
            <table class="table table-dark ">
              <thead>
                <tr>
                  <th scope="col">Perfil</th>
                  <th scope="col">Nombre Completo</th>
                  <th scope="col">Email</th>
                  <th scope="col">Legajo</th>
                </tr>
              </thead>
              <tbody>
                <asp:Repeater ID="tbl_repeaterMaterias" runat="server">
                    <ItemTemplate>
                        <tr >
                          <th scope="row">
                              <asp:Label ID="Perfil"  Text='<%#Eval("_perfil")%>' runat="server" /></th>
                          <td>
                              <asp:Label ID="Nombre" Text='<%#Eval("_nombreCompleto")%>' runat="server" /></td>
                          <td>
                              <asp:Label ID="Email" Text='<%# Eval("_email") %>' runat="server" /></td>
                          <td>
                              <asp:Label ID="Legajo" Text='<%# Eval("_legajo") %>' runat="server" /></td>
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
                //for (i = 0; i < document.getElementsByClassName("form-control").length; i++) {
                //    document.getElementById(document.getElementsByClassName("form-control")[i].getAttribute("required").replace("required","")
                //}
            }
            else {
                document.getElementById(string).style.display = "none"
                document.getElementById(string).style.position = "relative"
            }
        }

    </script>
</asp:Content>
