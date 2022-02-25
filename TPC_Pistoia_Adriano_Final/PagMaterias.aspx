<%@ Page Title="Materias -" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagMaterias.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: "Materias" %>.</h2>
            <button type="button" id="editButton" onclick="editarNotas()" class="btn btn-dark Profesor">Editar Notas <i  class="bi bi-pencil" aria-hidden="true" ></i></button>            
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <p id="flag" style="visibility:hidden"  ></p>
            <table class="table table-dark ">
              <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">Alumno</th>
                  <th scope="col">Materias</th>
                  <th scope="col">Notas</th>
                </tr>
              </thead>
              <tbody>
                <asp:Repeater ID="tbl_repeaterMaterias" runat="server">
                    <ItemTemplate>
                        <tr >
                          <th scope="row">
                              <asp:Label ID="rowNumber"  Text='<%#Eval("_idMateria")%>' runat="server" /></th>
                          <td>
                              <asp:Label ID="nombreMateria" Text='<%#Eval("_nombreAlumno")%>' runat="server" /></td>
                          <td>
                              <asp:Label ID="Label1" Text='<%#Eval("_nombreMateria")%>' runat="server" /></td>
                          <td>                           
                              <asp:TextBox ID="InputNotas" id_user='<%#Eval("_idMxU")%>' value=''  min="0" max="10" disabled="true" Text='<%#Eval("_nota") %>' CssClass="shdw inputNotas" style="background-color:inherit;color:aliceblue;outline:none;border:0px;" runat="server"></asp:TextBox>
                              
                              <asp:LinkButton runat="server" value='' CssClass="btn btn-dark Profesor" ID="guardarTest" OnClick="guardarTest_Click" style="color:antiquewhite;" >Guardar</asp:LinkButton>
                          </td>
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
       
        

    </script>
</asp:Content>
