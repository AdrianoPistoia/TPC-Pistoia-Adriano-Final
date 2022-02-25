<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MatDictadas.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.MatDictadas" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: "Materias" %>.</h2>

                     
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <p id="flag" style="visibility:hidden"  ></p>

                                

            <table class="table table-dark ">
              <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">Materias</th>
                  <th scope="col">horario</th>
                </tr>
              </thead>
              <tbody>
                <asp:Repeater ID="tbl_repeaterMaterias" runat="server">
                    <ItemTemplate>
                        <tr >
                          <th scope="row">
                              <asp:Label ID="rowNumber"  Text='<%#Eval("_idMateria") %>' runat="server" /></th>
                          <td>
                              <asp:Label ID="nombreMateria" Text='<%#Eval("_nombreMateria")%>' runat="server" /></td>
                          <td>
                              <asp:Label ID="Profesor" Text='<%# Eval("_horario") %>' runat="server" /></td>
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

