<%@ Page Title="Materias -" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagMaterias.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: "Materias" %>.</h2>

            <button type="button" id="editButton" onclick="editarNotas" class="btn btn-secondary Profesor">Editar Notas <i  class="bi bi-pencil" aria-hidden="true" ></i></button>            
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <p id="flag" style="visibility:hidden"  ></p>

                                

            <table class="table table-dark ">
              <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">Materias</th>
                  <th scope="col">Notas</th>
                  <th scope="col">Promedio</th>
                </tr>
              </thead>
              <tbody>
                <asp:Repeater ID="tbl_repeaterMaterias" runat="server">
                    <ItemTemplate>
                        <tr >
                          <th scope="row">
                              <asp:Label ID="rowNumber"  Text="N" runat="server" /></th>
                            
                          <td>
                              <asp:Label ID="nombreMateria" Text='<%#Eval("_nombreMateria")%>' runat="server" /></td>
                          <td>                           
                              <asp:TextBox ID="inputNotas"  min="0" max="10" disabled="true" CssClass="shdw inputNotas" style="background-color:inherit;color:aliceblue;outline:none;border:0px;"  value='<%#Eval("_nota") %>' runat="server"></asp:TextBox>
                              
                              <asp:LinkButton runat="server"  CssClass="offset-md-5" ID="cambiarTest"  style="color:antiquewhite;">
                              </asp:LinkButton>
                          </td>
                          <td>
                              <asp:Label ID="Profesor" Text='<%# Eval("_profesor") %>' runat="server" /></td>
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
