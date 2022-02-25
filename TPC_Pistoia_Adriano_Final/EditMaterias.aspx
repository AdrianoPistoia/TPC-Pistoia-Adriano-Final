<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditMaterias.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.EditMaterias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2><%: "Administrar Materias" %>.</h2>
    
    <asp:UpdatePanel ID="Repeater" runat="server">
        <ContentTemplate>
        <div>
            <a ID="Aniadir" class="btn btn-dark"  OnClick="cambiarVisibilidad('Pnl_fromInsert')" >Añadir Materia</a>
            <a ID="Borrar"  class="btn btn-dark"  OnClick="cambiarVisibilidad('Pnl_fromBorrar')" >Borrar Materia</a>
            <a ID="InsertAlumn"  class="btn btn-dark"  OnClick="cambiarVisibilidad('Pnl_fromInsertAlm')" >Insertar Alumno a Materia</a>
            <a ID="BorrarAlumn"  class="btn btn-dark"  OnClick="cambiarVisibilidad('Pnl_fromBorrarAlm')" >Borrar Alumno de Materia</a>
        </div>
            <div id="Pnl_fromBorrar"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div  class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon7">ID de la Materia</span>
                        <asp:TextBox  CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_borrarMateria" placeholder="Ingresar ID de la materia a borrar" runat="server" />
                    </div>
                    <asp:Button  CssClass="btn btn-dark" ID="btn_borrarMateria" Text="Borrar de Base de Datos" OnClick="btn_borrarMateria_Click" OnClientClick="cambiarVisibilidad('Pnl_fromBorrar')" runat="server" />
                </div>
            </div>
            <div id="Pnl_fromInsert"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div id="escalame" class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon3">Nombre de la Materia</span>
                        <asp:TextBox  CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_nombre" placeholder="Ingresar Materia" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon4">Horario</span>
                        <asp:TextBox CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_horar" placeholder="Mañana / Noche" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon5">Legajo del profesor</span>
                        <asp:TextBox CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_legProf" placeholder="Legajo del Profesor" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon6">ID de Carrera a la que pertenece</span>
                        <asp:TextBox CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_idCarrera" placeholder="ID Carrera" runat="server" />
                    </div>
                    <asp:Button  CssClass="btn btn-dark" ID="Insert" Text="Añadir a Base de Datos" OnClick="Insert_Click" OnClientClick="cambiarVisibilidad('Pnl_fromInsert')" runat="server" />
                </div>
            </div>
            <div id="Pnl_fromInsertAlm"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div id="escalame2" class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon13">Legajo del Alumno</span>
                        <asp:TextBox  CssClass="form-control" style="background-color:black;color:aliceblue" ID="txb_LegajoAlm" placeholder="EJ.: 00356" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon14">ID de la Materia</span>
                        <asp:TextBox CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_IDMat" placeholder="EJ.: 12" runat="server" />
                    </div>
                    <asp:Button  CssClass="btn btn-dark" ID="Button1" Text="Añadir a Base de Datos" OnClick="InsertAlm_Click" OnClientClick="cambiarVisibilidad('Pnl_fromInsertAlm')" runat="server" />
                </div>
            </div>
            <div id="Pnl_fromBorrarAlm"  class="col-md-10" style="position:relative;display:none;background-color:black;border-radius:5px ">
                <div style="display:flex;flex-direction:column;padding:15px">
                    <div id="escalam2" class="input-group mb-3">
                        <span class="input-group-text" >Legajo del Alumno</span>
                        <asp:TextBox  CssClass="form-control" style="background-color:black;color:aliceblue" ID="txb_LegajoAlmB" placeholder="EJ.: 000356" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text" >ID de la Materia</span>
                        <asp:TextBox CssClass="form-control " style="background-color:black;color:aliceblue" ID="txb_IDMatB" placeholder="EJ.: 12" runat="server" />
                    </div>
                    <asp:Button  CssClass="btn btn-dark" ID="Button2" Text="Borrar a Base de Datos" OnClick="BorrarAlm_Click" OnClientClick="cambiarVisibilidad('Pnl_fromBorrarAlm')" runat="server" />
                </div>
            </div>    
            <p id="flag" style="visibility:hidden"  ></p>

                                

            <table class="table table-dark ">
              <thead>
                <tr>
                  <th scope="col">ID</th>
                  <th scope="col">Materia</th>
                  <th scope="col">Horario</th>
                  <th scope="col">|ID| Profesor</th>
                  <th scope="col">|ID|Carrera</th>
                </tr>
              </thead>
              <tbody>
                <asp:Repeater ID="tbl_repeaterMaterias" runat="server">
                    <ItemTemplate>
                        <tr >
                          <th scope="row">
                              <asp:Label ID="ID"  Text='<%#Eval("_idMateria")%>' runat="server" /></th>
                          <td>
                              <asp:Label ID="Nombre" Text='<%#Eval("_nombreMateria")%>' runat="server" /></td>
                          <td>
                              <asp:Label ID="horario" Text='<%# Eval("_horario") %>' runat="server" /></td>
                          <td>
                              |<asp:Label ID="Profesor" Text='<%#Eval("_idProfesor") %>' runat="server" />| <asp:Label ID="Label2" Text='<%#Eval("_profesor") %>' runat="server" /></td>
                            <td>
                              |<asp:Label ID="Carrera" Text='<%#Eval("_idCarrera")%>' runat="server" />| <asp:Label ID="Label1" Text='<%# Eval("_carrera") %>' runat="server" /></td>
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
