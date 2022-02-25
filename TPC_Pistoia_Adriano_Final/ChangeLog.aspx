<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeLog.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.ChangeLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <p id="flag" style="visibility:hidden"  ></p>
            <table class="table table-dark ">
              <thead>
                <tr>
                  <th scope="col">Horario</th>
                  <th scope="col">Descripcion</th>
                  <th scope="col">Causante</th>
                </tr>
              </thead>
              <tbody>
                <asp:Repeater ID="tbl_repeaterSentencias" runat="server">
                    <ItemTemplate>
                        <tr >
                          <th scope="row">
                              <asp:Label ID="Hour"  Text='<%#Eval("horario")%>' runat="server" /></th>
                          <td>
                              <asp:Label ID="Descripcion" Text='<%#Eval("descripcion")%>' runat="server" /></td>
                          <td>
                              <asp:Label ID="Changer" Text='<%# Eval("legajo") %>' runat="server" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
              </tbody>
            </table>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

    </script>
</asp:Content>
