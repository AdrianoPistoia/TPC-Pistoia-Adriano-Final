<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCarreras.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.EditCarreras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2><%: "Administrar Carreras" %>.</h2>
    
    <asp:UpdatePanel ID="Repeater" runat="server">
        <ContentTemplate>
        <div>
            <a ID="Aniadir" class="btn btn-dark"  OnClick="cambiarVisibilidad('Pnl_fromInsert')" >Añadir Carrera</a>
            <a ID="Borrar"  class="btn btn-dark"  OnClick="cambiarVisibilidad('Pnl_fromBorrar')" >Borrar Carrera</a>
        </div>
            <div id="Pnl_fromBorrar"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div  class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon7">ID de la Carrera</span>
                        <asp:TextBox  CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_borrarCarrera" required pattern="[0-9]?{2}" placeholder="Ingresar id de la carrera a borrar" runat="server" />
                    </div>
                    <asp:Button  CssClass="btn btn-dark" ID="btn_borrarCarrera" Text="Borrar de Base de Datos" OnClick="btn_borrarCarrera_Click" OnClientClick="cambiarVisibilidad('Pnl_fromBorrar')" runat="server" />
                </div>
            </div>
            <div id="Pnl_fromInsert"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div id="escalame" class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon3">Nombre de la Carrera</span>
                        <asp:TextBox  CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_carrera" requierd pattern="/^[a-z ,.'-]+$/i" maxlength="79" placeholder="Ingresar Carrera" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon4">Categoria de la Carrera</span>
                        <asp:TextBox CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_categoria" required pattern="[A-Z][a-z]{20}" placeholder="Tecnicatura/Licenciatura/Grado" runat="server" />
                    </div>
                    <asp:Button  CssClass="btn btn-dark" ID="Insert" Text="Añadir a Base de Datos" OnClick="Insert_Click" OnClientClick="cambiarVisibilidad('Pnl_fromInsert')" runat="server" />
                </div>
            </div>           
            <p id="flag" style="visibility:hidden"  ></p>

                                

            <table class="table table-dark ">
              <thead>
                <tr>
                  <th scope="col">ID</th>
                  <th scope="col">Categoria</th>
                  <th scope="col">Carrera</th>
                </tr>
              </thead>
              <tbody>
                <asp:Repeater ID="tbl_repeaterMaterias" runat="server">
                    <ItemTemplate>
                        <tr >
                          <th scope="row">
                              <asp:Label ID="IDCarrera" Text='<%#Eval("_idCarrera")%>' runat="server" /></td>
                          <td scope="row">
                              <asp:Label ID="Categoria" Text='<%#Eval("_categoria ")%>' runat="server" /></td>
                          <td>
                              <asp:Label ID="Carrera"  Text='<%#Eval("_nombreCarrera")%>' runat="server" /></td>
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
