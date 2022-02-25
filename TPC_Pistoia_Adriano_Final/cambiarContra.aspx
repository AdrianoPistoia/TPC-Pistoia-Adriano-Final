<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cambiarContra.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.cambiarContra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col card text-white bg-dark mb-3" style="max-width: 48rem;padding-bottom:20px;margin-top:20px;padding-top:10px">
            <asp:Panel ID="Paneloide" runat="server" CssClass="mb-3">
                <asp:Label  runat="server" ID="lbl_Email" class="form-label">Email</asp:Label>
                <div style="display:flex;flex-direction:row">
                    <asp:textbox runat="server" ID="txtEmail" cssclass="form-control"/>
                    <asp:Button ID="EnviarCodigo" CssClass="btn btn-primary" Text="Enviar Email" OnClick="EnviarCodigo_Click" Autopostback="False" runat="server" />
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="asunto" CssClass="mb-3">
                <label  class="form-label">Asunto</label>
                <asp:textbox runat="server" ID="txtAsunto" cssclass="form-control"/>
            </asp:Panel>
            <asp:Panel runat="server" ID="mensaje" CssClass="mb-3">
                <label class="form-label">Mensaje</label>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMensaje" cssclass="form-control"/>
            </asp:Panel>
            <asp:Panel runat="server" ID="Panel1" CssClass="mb-3">
                <label class="form-label">Codigo</label>
                <asp:TextBox TextMode="number" runat="server" ID="txb_Codigo" cssclass="form-control"/>
            </asp:Panel>
            <asp:Panel runat="server" ID="Panel2" CssClass="mb-3">
                <label class="form-label">Nueva Contraseña</label>
                <asp:TextBox TextMode="password" placeholder="Maximo 20 caracteres." runat="server" ID="txb_contra" cssclass="form-control"/>
            </asp:Panel>
            <asp:Button Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" ID="btnAceptar" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
    <script type="text/javascript">    
        if ( '<%:Session["Usuario"]%>' == null) {
            document.getElementById("asunto").style="visibility:hidden;max-height:0px"
        }
    </script>
</asp:Content>
