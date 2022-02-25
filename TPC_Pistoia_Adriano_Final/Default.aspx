<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Pistoia_Adriano_Final._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="display:flex;justify-content:center;flex-direction:row">
        <h1>BIENVENIDO/A <%:usuario._nombreCompleto%></h1>
    </div>
    <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                <div class="card bg-dark text-white" style="border-radius: 1rem;">
                    <div class="card-body p-5 text-center">
                        <div class="btn-group-vertical" role="group" style="font-weight:bolder;justify-content:center;font-size:18px" >
                            <% if (usuario._perfil == "Alumno" )
                            {%>
                                <a type="button" href="PagMaterias.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey"> Materias de la Carrera</p></a>
                                <a type="button" href="EditExamen.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Fechas de examen</p></a>
                                <a type="button" href="TablonMensajes.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Mensajes</p></a>
                            <%}%>
                            <% if (usuario._perfil == "Profesor" ){%>
                                <a type="button" href="MatDictadas.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Materias dictadas</p></a>
                                <a type="button" href="PagMaterias.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Editar notas de alumnos</p></a>
                                <a type="button" href="EditMaterias.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Editar Materias</p></a>
                                <a type="button" href="EditExamen.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Editar Fechas de examen</p></a>
                                <a type="button" href="TablonMensajes.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Mensajes</p></a>
                                
                            <% }%>
                            <% if (usuario._perfil == "Administrador" ){%>
                                <a type="button" href="PagEditar.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Editar Usuarios</p></a>
                                <a type="button" href="EditCarreras.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Editar Carreras</p></a>
                                <a type="button" href="EditMaterias.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Editar Materias</p></a>
                                <a type="button" href="TablonMensajes.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Editar Mensajes</p></a>
                                <a type="button" href="EditExamen.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Editar Examenes</p></a>
                                <a type="button" href="PagMaterias.aspx" class="btn btn-dark alumno"><p style="font-weight:bolder;font-size:18px;color:darkgrey">Editar Notas</p></a>  
                            <%}%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">    

       
        if ('<%: usuario._perfil %>' == "Alumno") { FiltoParaAlumnos(); }
        if ('<%: usuario._perfil %>' == "Profesor") { FiltoParaProfes(); }
    </script>
</asp:Content>
