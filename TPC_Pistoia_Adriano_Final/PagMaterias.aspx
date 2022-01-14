<%@ Page Title="Materias -" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagMaterias.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: "Materias" %>.</h2>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table class="table table-dark table-striped table-hover">
              <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">Materias</th>
                  <th scope="col">Notas</th>
                  <th scope="col">Promedio</th>
                </tr>
              </thead>
              <tbody>
                <asp:Repeater runat="server">
                    <ItemTemplate>
                        <tr>
                          <th scope="row">
                              <asp:Label ID="rowNumber" Text="N" runat="server" /></th>
                          <td>
                              <asp:Label ID="nombreMateria" Text="Mat" runat="server" /></td>
                          <td>
                              <asp:Label ID="notaMateria" Text="?" runat="server" /></td>
                          <td>
                              <asp:Label ID="promedioMateria" Text="?" runat="server" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
              </tbody>
            </table>
            <asp:Button ID="cambiarTest" Text="Cambiar" runat="server" OnClick="cambiarTest_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
