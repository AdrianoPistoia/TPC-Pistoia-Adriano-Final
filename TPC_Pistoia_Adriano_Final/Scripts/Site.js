

function FiltoParaAlumnos() {
    for (var i = 0; i < document.getElementsByClassName("Administrador").length; i++) {
        document.getElementsByClassName("Administrador")[i].style = "visibility:hidden"
    }
    for (var i = 0; i < document.getElementsByClassName("Profesor").length; i++) {
        document.getElementsByClassName("Profesor")[i].style = "visibility:hidden"
    }

}
function FiltoParaProfes() {
    for (var i = 0; i < document.getElementsByClassName("Administrador").length; i++) {
        document.getElementsByClassName("Administrador")[i].style = "visibility:hidden"
    }
}