using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class Diccionario
    {
        public static string CONEXION_SERVER = "server =.\\SQLEXPRESS; database=SystemaDeDatos; integrated security = true";
        public static string LISTAR_USUARIOS = "SELECT U.legajo, U.nombreCompleto, U.email, P.perfil as Perfil, U.contrasenia FROM Usuario AS U JOIN Perfil AS P ON U.idPerfil = P.idPerfil WHERE U.idPerfil = P.idPerfil AND U.estado = 1";
        public static string LISTAR_MATERIAS_DE_USUARIO = "SELECT M.idMateria, M.nombreMateria, M.nota, M.estado, M.horario, M.idProfesor"
                                                        + "FROM MateriaXUsuario AS MxU JOIN Materia AS M  ON MxU.idMateria = M.idMateria JOIN Usuario AS U ON MxU.idUsuario = U.idUsuario"
                                                        + "WHERE U.idPerfil = 3 AND U.idUsuario =  @usuario";
        //public static string WHERE_FAVORITOS_TRUE = " where P.Favorito = 1";
        //public static string WHERE_FAVORITOS_FALSE = " where P.Favorito = 0";

        //public static string UPDATE_FAVORITO = "update Producto set Favorito = @favorito where ID = @id";

        //public static string LISTAR_TODOS_ARTICULOS = "select P.Id, P.Codigo, P.Nombre, P.Descripcion, M.Descripcion as Marca, P.IdMarca, C.Descripcion as Categoria, P.Favorito, P.IdCategoria, P.IdImagen, I.Descripcion as ImDesc, I.Link as Link,  P.Precio, P.Cantidad " +
        //"from PRODUCTO P inner join MARCA M on M.Id = P.IdMarca inner join CATEGORIA C on C.Id = P.IdCategoria inner join Imagen I on I.ID = P.IdImagen";


    }
}
