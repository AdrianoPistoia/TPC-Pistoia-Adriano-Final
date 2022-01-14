﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="display:flex;justify-content:center;flex-direction:row">
        <h1>BIENVENIDO/A <%:usuario._nombreCompleto%></h1>
        <asp:Button ID="CerrarSesion" OnClick="CerrarSesion_Click" CssClass="btn btn-dark btn-lg" style="position:absolute;right:10px" runat="server" Text="Cerrar sesion" />
    </div>
    <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                <div class="card bg-dark text-white" style="border-radius: 1rem;">
                    <div class="card-body p-5 text-center">
                        <div class="btn-group-vertical" role="group" style="font-weight: bolder;justify-content:center" aria-label="Button group with nested dropdown">
                            <% if (usuario._perfil == "Alumno" )
                            {%>
                                <button type="button" class="btn btn-dark alumno"><p>Materias de la Carrera</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Tu estado Academico/Encuestas</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Fechas de examen</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Mensajes</p></button>
                            <%}%>
                            <% if (usuario._perfil == "Profesor" ){%>
                                <button type="button" class="btn btn-dark alumno"><p>Materias dictadas</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Editar notas de alumnos</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Editar Materias</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Editar Fechas de examen</p></button>
                            <% }%>
                            <% if (usuario._perfil == "Administrador" ){%>
                                <button type="button" class="btn btn-dark alumno"><p>Editar Usuarios</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Editar Carreras</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Editar Materias</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Editar Mensajes</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Editar Examenes</p></button>
                                <button type="button" class="btn btn-dark alumno"><p>Editar Notas</p></button>  
                            <%}%>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">    

       
        if ('<%: usuario._perfil %>' == "Profesor") { FiltoParaProfes(); }
    </script>
</asp:Content>