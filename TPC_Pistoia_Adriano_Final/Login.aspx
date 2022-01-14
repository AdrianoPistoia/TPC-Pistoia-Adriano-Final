<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<section class="vh-80 gradient-custom">
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
                    <asp:TextBox ID="TextBoxLegajo" placeholder="Legajo" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                  </div>

                  <div class="form-outline form-white mb-4">
                    <label class="form-label" for="typePasswordX">Contraseña</label>
                    <asp:TextBox ID="TextBoxContra" placeholder="Contraseña" Type="password" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                    
                  </div>

                  <asp:Button ID="LoginSubmit" CssClass="btn btn-outline-light btn-lg px-5"  type="submit" runat="server" OnClick="LoginSubmit_Click"   Text="Login" />
                    <p class="small mb-3 pb-lg-2"><a class="text-white-50" href="#!">Olvido su contraseña?</a></p>
                </div>

                <!--<div>
                  <p class="mb-0">No tenes una cuenta? <a href="#!" class="text-white-50 fw-bold">Registrate! (enrealidad no deberias poder...pero tengo que testearlo de alguna manera)</a></p>
                </div>--> 

              </div>
            </div>
          </div>
        </div>
      </div>

    </section>
    <script>    
        
    </script>
</asp:Content>
