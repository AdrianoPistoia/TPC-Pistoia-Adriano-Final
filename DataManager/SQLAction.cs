using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSys;

namespace  DataManager
{
    public class SQLAction
    {
        public string Recuperacion_Contra(string emaildir)
        {
            
                SQLTrader trader = new SQLTrader();
            try
            {

                trader.setearConsulta(Diccionario.CONTRASEÑA_POR_EMAIL);
                trader.setearParametro("@email", emaildir );
                trader.ejecutarAccion();

            if(trader.Lector.HasRows)
                {
                   
                    return trader.Lector["contrasenia"].ToString();
                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                trader.cerrarConexion();
            }
        }
    
        public List<Materia> ListarMateriasDelUser(Usuario user)
        {
            
            List<Materia> lista = new List<Materia>();  
            SQLTrader trader = new SQLTrader();
            try
            {

                

                trader.setearConsulta(Diccionario.LISTAR_MATERIAS_DE_USUARIO);
                trader.setearParametro("@usuario", user._idUsuario);
                trader.ejecutarLectura();

                while (trader.Lector.Read())
                {
                    Materia mat = new Materia();
                    mat._nombreMateria = (string)trader.Lector["nombreMateria"];
                    mat._idMateria = (int)trader.Lector["idMateria"];
                    mat._profesor = (string)trader.Lector["profesor"];
                    mat._nota = (int)trader.Lector["nota"];
                    mat._estado = (bool)trader.Lector["estado"];
                    lista.Add(mat);
                    
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            
            }
            finally
            {
                trader.cerrarConexion();
            }
        }
        public bool LoguearUser(Usuario _Usuario)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta   ("SELECT U.idUsuario, U.email, U.nombreCompleto, " +

                                        "   (SELECT P.perfil " +
                                            "FROM Perfil AS P " +
                                            "WHERE U.idPerfil = P.idPerfil ) " +
                                        "AS 'Perfil' " +
                                        "FROM Usuario as U " +
                                        "WHERE U.estado = 1 AND U.contrasenia = @contra AND U.legajo = @legajo");
                trader.setearParametro("@legajo",_Usuario._legajo);
                trader.setearParametro("@contra",_Usuario._contra);
                trader.ejecutarLectura();
                while (trader.Lector.Read())
                {
                    _Usuario._nombreCompleto    = (string)trader.Lector["nombreCompleto"];
                    _Usuario._email             = (string)trader.Lector["email"];
                    _Usuario._idUsuario         = (int)trader.Lector["idUsuario"];
                    _Usuario._perfil            = (string)trader.Lector["Perfil"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                trader.cerrarConexion();
            }
        }

        public void sql_eliminar_usuario(Usuario aModificar, int ToF)
        {
            SQLTrader datos = new SQLTrader();

            try
            {
               // datos.setearConsulta(Diccionario.UPDATE_FAVORITO);

                datos.setearParametro("@id", aModificar._idUsuario);
                datos.setearParametro("@Favorito", ToF);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Usuario> listar(string Lectura)//En caso de querer listar todos, dejar parametro vacio |!|-----!DEPRECATED!-----|!|
        {

            if (String.IsNullOrEmpty(Lectura) || Lectura == null)
            {
                Lectura = "";
            }
            List<Usuario> lista     = new List<Usuario>();
            SQLTrader datos         = new SQLTrader();

            try
            {
                datos.setearConsulta(Diccionario.LISTAR_USUARIOS + Lectura);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux         = new Usuario();
                    aux._idUsuario      = (int)datos.Lector["idUsuario"];
                    aux._legajo         = (string)datos.Lector["legajo"];
                    aux._email          = (string)datos.Lector["email"];
                    aux._nombreCompleto = (string)datos.Lector["nombreCompleto"];
                    aux._perfil         = (string)datos.Lector["Perfil"];
                    aux._contra         = (string)datos.Lector["contrasenia"];
                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
