
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

function editarNotas() {
    if (document.getElementById("flag").getAttribute("flag") == null) {
        document.getElementById("flag").setAttribute("flag", "true")
    }

    if (document.getElementById("flag").getAttribute("flag").match("true")) {
        document.getElementById("flag").setAttribute("flag", "false")
        for (var i = 0; i < document.getElementsByClassName("inputNotas").length; i++) {
            document.getElementsByClassName("inputNotas")[i].removeAttribute("disabled");
            document.getElementsByClassName("inputNotas")[i].style = "background-color:#435C59";
            document.getElementById("editButton").innerText = "Guardar Notas";
        }
    } else {
        document.getElementById("flag").setAttribute("flag", "true")
        for (var i = 0; i < document.getElementsByClassName("inputNotas").length; i++) {
            document.getElementsByClassName("inputNotas")[i].setAttribute("disabled", "true");
            document.getElementsByClassName("inputNotas")[i].style = "background-color:#212529;outline:none;border:0px";
            document.getElementById("editButton").innerText = "Editar Notas";

        }
    }
}

function verificacion() {
    txb_legajo = document.getElementsByClassName("legajo");
    btn_login = document.getElementsByClassName("login");
    if (txb_legajo.length == 5) {
        btn_login
    }
}
function translateValue() {
    this.setAttribute("value", this.value);
}
window.onload = function () {
    
    elements = document.getElementsByClassName("inputNotas");
    for (var i = 0; i < elements.length; i++) {
        elements[i].addEventListener("blur", translateValue, true);
    }
};




