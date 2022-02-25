<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<section class="vh-80 gradient-custom">
    <asp:Panel id="holi" class="container py-5 h-100 col-md-10" style=";position:absolute;z-index:9999;display:flex;justify-content:center;background-color:rgba(0,0,0,0.8);border-radius:5px " runat="server">
        <div  style="padding-top:40px;padding-left:10px;flex-direction:column;border-radius:10%;background-color:rgba(255,255,255,0.8);height:80%;width:80%;z-index:99999;display:flex;align-self:center">
            <h1 style="justify-items:center">Error en las credenciales ingresadas!</h1>
            <h3 style="padding-top:40px;padding-left:10px">Intente ingresar las credenciales correctamente.</h3>
            <asp:Button Text="Aceptar" OnClick="Unnamed_Click" runat="server" />
        </div>
    </asp:Panel>
      <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
          <div class="col-12 col-md-8 col-lg-6 col-xl-5">
            <div class="card bg-dark text-white" style="border-radius: 1rem;">
              <div class="card-body p-5 text-center">
                <div class="mb-md-5 mt-md-4 pb-5">
                  <h2 class="fw-bold mb-2 text-uppercase"><%:Page.Title%></h2>
                  <p class="text-white-50 mb-5" style="font-size:24px;">Ingrese sus credenciales!</p>
                  <div class="form-outline form-white mb-4">
                    <label class="form-label" for="typeEmailX">Legajo</label>
                    <asp:TextBox ID="TextBoxLegajo" placeholder="Legajo" pattern="([0-9]||admin){5}" required="false" CssClass="form-control form-control-lg legajo" runat="server"></asp:TextBox>
                  </div>
                  <div class="form-outline form-white mb-4">
                    <label class="form-label" for="typePasswordX">Contraseña</label>
                    <asp:TextBox ID="TextBoxContra" placeholder="Contraseña" Type="password" maxlenght="19" required="false" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                  </div>
                  <asp:Button ID="LoginSubmit" CssClass="btn btn-outline-light btn-lg px-5 login"  type="submit" runat="server" OnClick="LoginSubmit_Click"   Text="Login" />
                    <p class="small mb-3 pb-lg-2"><a class="text-white-50" href="/OlvideMiContra.aspx">Olvido su contraseña?</a></p>
                </div>
                <div>
                  <p class="mb-0"><a href="/cambiarContra" class="text-white-50 fw-bold">Cambia tu contraseña!</a></p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

    </section>
    <script>
        
    </script>
</asp:Content>
