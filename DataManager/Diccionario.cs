using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class Diccionario
    {
        public static string MAÑANA = "MAÑANA";
        public static string TARDE = "TARDE";
        public static string BORRAR = "borrar";
        public static string INSERTAR = "insertar";
        public static string CAMBIO_CONTRA = "UPDATE Usuario SET contrasenia = @contra WHERE idUsuario = @idUsuario;";
        public static string BORRAR_MATERIA_DE_USUARIO = "UPDATE MateriaXUsuario SET estado = '0' WHERE @idmateria = idMateria AND (SELECT idUsuario FROM Usuario WHERE @Legajo = legajo) = idUsuario";
        public static string INSERTAR_MATERIA_A_USUARIO = "INSERT INTO MateriaXUsuario (idMateria,idUsuario,categoria,estado,nota) VALUES (@idMateria,(SELECT idUsuario FROM Usuario WHERE @Legajo = legajo),'borrarCol',1 , 0)";
        public static string LISTAR_MAT_PARA_ADMIN = "SELECT U.idUsuario, M.nombreMateria, MxU.nota, U.nombreCompleto, MxU.idCXA FROM Usuario AS U JOIN MateriaXUsuario AS MxU on MxU.idUsuario = U.idUsuario JOIN Materia AS M ON M.idMateria = MxU.idMateria WHERE U.idPerfil = 3";
        public static string LISTAR_MAT_PARA_PROFE = "SELECT U.idUsuario, M.nombreMateria, MxU.nota, U.nombreCompleto, M.idMateria ,MxU.idCXA FROM Usuario AS U JOIN MateriaXUsuario AS MxU on MxU.idUsuario = U.idUsuario JOIN Materia AS M ON M.idMateria = MxU.idMateria WHERE U.idPerfil = 3 AND M.idProfesor = @profe";
        public static string LISTAR_MAT_PARA_ALUM = "SELECT U.idUsuario,M.idMateria, M.nombreMateria, MxU.nota, U.nombreCompleto, MxU.idCXA FROM Usuario AS U JOIN MateriaXUsuario AS MxU on MxU.idUsuario = U.idUsuario JOIN Materia AS M ON M.idMateria = MxU.idMateria WHERE U.idPerfil = 3 AND U.idUsuario = @profe";
        public static string CONEXION_SERVER = "server =.\\SQLEXPRESS; database=SystemaDeDatos; integrated security = true";
        public static string LISTAR_USUARIOS = "SELECT U.legajo, U.nombreCompleto, U.email, P.perfil as Perfil, U.contrasenia FROM Usuario AS U JOIN Perfil AS P ON U.idPerfil = P.idPerfil WHERE U.idPerfil = P.idPerfil AND U.estado = 1";
        public static string LISTAR_MATERIAS_DE_USUARIO = "SELECT M.idMateria, M.nombreMateria, M.nota, M.estado, M.horario, (SELECT U.nombreCompleto FROM Usuario AS U WHERE U.idUsuario = M.idProfesor) AS profesor FROM MateriaXUsuario AS MxU JOIN Materia AS M ON MxU.idMateria = M.idMateria JOIN Usuario AS U ON MxU.idUsuario = U.idUsuario WHERE M.estado != 0 AND U.idPerfil = 3 AND U.idUsuario =  @usuario";
        public static string CONTRASEÑA_POR_EMAIL = "SELECT U.contrasenia as Contra FROM Usuario AS U WHERE U.Email = @email";
        public static string SENTENCIA_INSERT_USUARIO = "|@horario|: @usuario ha insertado al usuario @legajo con perfil de @perfil";
        public static string SENTENCIA_BAJA_USUARIO = "|@horario|: @usuario ha hecho una baja logica del usuario @legajo";
        public static string SENTENCIA_ALTERAR_NOTA = "|@horario|: @usuario ha hecho un cambio en la nota de @legajo, ingresando el valor: @nota";
        //public static string WHERE_FAVORITOS_TRUE = " where P.Favorito = 1";
        //public static string WHERE_FAVORITOS_FALSE = " where P.Favorito = 0";

        //public static string UPDATE_FAVORITO = "update Producto set Favorito = @favorito where ID = @id";

        //public static string LISTAR_TODOS_ARTICULOS = "select P.Id, P.Codigo, P.Nombre, P.Descripcion, M.Descripcion as Marca, P.IdMarca, C.Descripcion as Categoria, P.Favorito, P.IdCategoria, P.IdImagen, I.Descripcion as ImDesc, I.Link as Link,  P.Precio, P.Cantidad " +
        //"from PRODUCTO P inner join MARCA M on M.Id = P.IdMarca inner join CATEGORIA C on C.Id = P.IdCategoria inner join Imagen I on I.ID = P.IdImagen";


    }
}
