using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using DataSys;

namespace  DataManager
{
    public class SQLAction
    {
        
        public void insertar_Backlog(string accion, Examen examen, Usuario adm)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("INSERT INTO Backlog (usuario , horario, descripcion) VALUES   (@usuario , @horario ,@descripcion) ");
                trader.setearParametro("@usuario", adm._legajo);
                trader.setearParametro("@horario", DateTime.Now);
                if (accion == "insertar")
                {
                    trader.setearParametro("@descripcion", "Se ha insertado un examen para la materia [" + examen._nombreMateria + "] a Base de Datos");
                }
                if (accion == "borrar")
                {
                    trader.setearParametro("@descripcion", "Se ha borrado el examen de la materia [" + examen._nombreMateria + "] de Base de Datos |Baja logica|");
                }
                trader.ejecutarAccion();
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

        

        public void insertar_Backlog(string accion, string Legajo, string idMateria,Usuario adm)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("INSERT INTO Backlog (usuario , horario, descripcion) VALUES   (@usuario , @horario ,@descripcion) ");
                trader.setearParametro("@usuario", adm._legajo);
                trader.setearParametro("@horario", DateTime.Now);
                if (accion == "insertar")
                {
                    trader.setearParametro("@descripcion", "Se ha agregado al alumno ["+Legajo+"] a la materia ["+idMateria+"]");
                }
                if (accion == "borrar")
                {
                    trader.setearParametro("@descripcion", "Se ha dado de baja al alumno [" + Legajo + "] de la materia [" + idMateria + "]");
                }
                trader.ejecutarAccion();
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

        public void Cambio_Contra(string emaildir, int contra)
        {
            SQLTrader trader = new SQLTrader();
            Usuario usuario = usuarioPorEmail(emaildir);
            try
            {
                trader.setearConsulta(Diccionario.CAMBIO_CONTRA);
                trader.setearParametro("@idUsuario", usuario._idUsuario);
                trader.setearParametro("@contra", contra);
                trader.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                trader.cerrarConexion();
                insertar_Backlog("cambio", usuario);
            }
        }

        private void insertar_Backlog(string v, Usuario usuario)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("INSERT INTO Backlog (usuario , horario, descripcion) VALUES   (@usuario , @horario ,@descripcion) ");
                trader.setearParametro("@usuario", "N/A");
                trader.setearParametro("@horario", DateTime.Now);
                trader.setearParametro("@descripcion", "Se ha cambiado la contraseña del usuario [" + usuario._legajo + "]");
                trader.ejecutarAccion();
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

        private Usuario usuarioPorEmail(string emaildir)
        {
            SQLTrader trader = new SQLTrader();
            Usuario user = new Usuario();
            try
            {
                trader.setearConsulta("SELECT idUsuario, legajo FROM Usuario WHERE email = @email");
                trader.setearParametro("@email", emaildir);
                trader.ejecutarLectura();
                trader.Lector.Read();
                user._legajo = (string)trader.Lector["legajo"];
                user._idUsuario = (int)trader.Lector["idUsuario"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                trader.cerrarConexion();
            }
            return user;
        }

        public void ediar_MxU(string txb_LegajoAlm, string txb_IDMat, string accion, Usuario adm)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                if(accion == Diccionario.INSERTAR)
                {
                    trader.setearConsulta(Diccionario.INSERTAR_MATERIA_A_USUARIO);
                }
                else
                {
                    trader.setearConsulta(Diccionario.BORRAR_MATERIA_DE_USUARIO);
                }
                    trader.setearParametro("@idMateria",Int32.Parse(txb_IDMat));
                    trader.setearParametro("@Legajo",txb_LegajoAlm);
                    trader.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                trader.cerrarConexion();
                insertar_Backlog(accion,txb_LegajoAlm,txb_IDMat,adm);

            }

        }

        public void guardarNota(string v1, string v2, Usuario usuario)
        {
            Materia mat = new Materia();
            mat._nota = Int32.Parse(v1);
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("UPDATE MateriaXUsuario SET nota = @nota WHERE idCXA = @idMxU");
                trader.setearParametro("@nota",v1);
                trader.setearParametro("@idMxU",v2);
                trader.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                insertar_Backlog("UPDATE",mat,usuario);
                trader.cerrarConexion();
            }
        }

        public List<Materia> ListarMateriasXUser(Usuario usuario)
        {
            SQLTrader trader = new SQLTrader();
            List<Materia> lista = new List<Materia>();
            try
            {
                if (usuario._perfil == "Administrador")
                {
                    trader.setearConsulta(Diccionario.LISTAR_MAT_PARA_ADMIN);
                }
                else if (usuario._perfil == "Profesor")
                {
                    trader.setearConsulta(Diccionario.LISTAR_MAT_PARA_PROFE);
                }
                else
                {
                    trader.setearConsulta(Diccionario.LISTAR_MAT_PARA_ALUM);
                }
                trader.setearParametro("@profe",usuario._idUsuario);
                trader.ejecutarLectura();
                while (trader.Lector.Read())
                {
                    Materia carr = new Materia();
                    carr._idUsuario = (int)trader.Lector["idUsuario"];
                    carr._nombreAlumno = (string)trader.Lector["nombreCompleto"];
                    carr._nombreMateria = (string)trader.Lector["nombreMateria"];
                    carr._idMateria = (int)trader.Lector["idMateria"];
                    carr._idMxU = (int)trader.Lector["idCXA"];
                    carr._nota = (int)trader.Lector["nota"];
                    lista.Add(carr);
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

        public void insertar_Backlog(string accion, Mensaje mensaje, Usuario adm)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("INSERT INTO Backlog (usuario , horario, descripcion) VALUES   (@usuario , @horario ,@descripcion) ");
                trader.setearParametro("@usuario", adm._legajo);
                trader.setearParametro("@horario", DateTime.Now);
                if (accion == "insertar")
                {
                    trader.setearParametro("@descripcion", "Se ha insertado el anuncio [" + mensaje.Asunto+ "] a Base de Datos");
                    trader.ejecutarAccion();

                }
                if (accion == "borrar")
                {
                    trader.setearParametro("@descripcion", "Se ha borrado el anuncio [" + mensaje.Asunto + "] de Base de Datos |Baja logica|");
                    trader.ejecutarAccion();
                }
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

        public void editar_examen(string accion, Examen examen, Usuario usuario)
        {
            Examen aux = new Examen();
            SQLTrader trader = new SQLTrader();
            try
            {
                if (accion == "insertar")
                {

                    trader.setearConsulta(
                    "INSERT  INTO    Examen ( idMateria, horario, nota, estado)" +
                    "                VALUES  (@idmateria, @horario , '0' ,'1' )"
                    );
                    trader.setearParametro("@idMateria", examen._idMateria);
                    trader.setearParametro("@horario", examen._horario);

                }
                if (accion == "borrar")
                {
                    trader.setearConsulta("update Examen set estado = 0 where idExamen = @id");
                    trader.setearParametro("@id", examen._idExamen);
                }
                trader.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(accion == Diccionario.BORRAR)examen = listarExamenPorID(examen._idExamen);
                if (accion == Diccionario.INSERTAR) examen._nombreMateria = buscarNombreMateria(examen._idMateria);
                insertar_Backlog(accion, examen, usuario);
                trader.cerrarConexion();
            }
        }

        private string buscarNombreMateria(int idMateria)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("SELECT M.nombreMateria FROM Materias AS M WHERE M.idMateria =" + idMateria );
                trader.ejecutarLectura();
                trader.Lector.Read();
                return (string)trader.Lector["nombreMateria"];
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

        private Examen listarExamenPorID(int idExamen)
        {

            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("SELECT M.nombreMateria FROM Materia AS M WHERE M.idMateria = '" + idExamen + "'");
                trader.ejecutarLectura();
                trader.Lector.Read();

                Examen carr = new Examen();
                carr._nombreMateria = (string)trader.Lector["nombreMateria"];

                return carr;
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

        public object listarExamenes()
        {
            SQLTrader trader = new SQLTrader();
            List<Examen> lista = new List<Examen>();
            try
            {
                trader.setearConsulta("SELECT E.idExamen,E.idMateria,E.horario FROM Examen as E WHERE E.estado = 1");
                trader.ejecutarLectura();
                while (trader.Lector.Read() )
                {
                    Examen carr = new Examen();
                    carr._idExamen = (int)trader.Lector["idExamen"];
                    carr._idMateria = (int)trader.Lector["idMateria"];
                    carr._horario = (TimeSpan)trader.Lector["horario"];
                    carr._nombreMateria = listarExamenPorID(carr._idExamen)._nombreMateria;
                    lista.Add(carr);
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

        public object listarMensajes()
        {
            SQLTrader trader = new SQLTrader();
            List<Mensaje> lista = new List<Mensaje>();
            try
            {
                trader.setearConsulta("SELECT M.id, M.mensaje, M.Asunto, M.horario FROM Mensaje as M WHERE M.estado = 1");
                trader.ejecutarLectura();
                while (trader.Lector.Read() && lista.Count <= 4)
                {
                    Mensaje carr = new Mensaje();
                    carr.id = (int)trader.Lector["id"];
                    carr.mensaje = (string)trader.Lector["mensaje"];
                    carr.Asunto = (string)trader.Lector["Asunto"];
                    carr.horario = (DateTime)trader.Lector["horario"];

                    lista.Add(carr);
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

        public void insertar_Backlog(string accion, Carrera carrera, Usuario adm)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("INSERT INTO Backlog (usuario , horario, descripcion) VALUES   (@usuario , @horario ,@descripcion) ");
                trader.setearParametro("@usuario", adm._legajo);
                trader.setearParametro("@horario", DateTime.Now);
                if (accion == "insertar")
                {
                    trader.setearParametro("@descripcion", "Se ha insertado la carrera [" + carrera._nombreCarrera + "] a Base de Datos");
                    trader.ejecutarAccion();

                }
                if (accion == "borrar")
                {
                    trader.setearParametro("@descripcion", "Se ha borrado la carrera [" + carrera._nombreCarrera + "] de Base de Datos |Baja logica|");
                    trader.ejecutarAccion();
                }
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

        public void editar_mensaje(string accion, Mensaje mensaje, Usuario adm)
        {
            Mensaje aux = new Mensaje();
            SQLTrader trader = new SQLTrader();
            try
            {
                if (accion == "insertar")
                {

                    trader.setearConsulta(
                    "INSERT  INTO    Mensaje ( mensaje , Asunto , estado, horario)" +
                    "                VALUES  (@mensaje, @asunto , '1' , @horario)"
                    );
                    trader.setearParametro("@mensaje", mensaje.mensaje);
                    trader.setearParametro("@asunto", mensaje.Asunto);
                    trader.setearParametro("@horario", DateTime.Now);

                }
                if (accion == "borrar")
                {
                    trader.setearConsulta("update Mensaje set estado = 0 where id = @id");
                    trader.setearParametro("@id", mensaje.id);
                }
                trader.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (accion == Diccionario.BORRAR) mensaje= listarMensajePorID(mensaje.id);
                insertar_Backlog(accion, mensaje, adm);
                trader.cerrarConexion();
            }
        }

        private Mensaje listarMensajePorID(int mensajeid)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("SELECT M.Asunto FROM Mensaje AS M WHERE M.estado = 0 AND M.id = '" + mensajeid + "'");
                trader.ejecutarLectura();
                trader.Lector.Read();

                Mensaje carr = new Mensaje();
                carr.Asunto = (string)trader.Lector["Asunto"];

                return carr;
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

        public int listarProfePorLeg(string text)
        {
            SQLTrader trader = new SQLTrader();
            int ID = 0;
            try
            {
                trader.setearConsulta("SELECT U.idUsuario FROM Usuario AS U WHERE U.estado = 1 AND U.legajo = '" + text + "'");
                trader.ejecutarLectura();
                trader.Lector.Read();
                ID = (int)trader.Lector["idUsuario"];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                trader.cerrarConexion();
            }
            return ID;
        }

        public Usuario listarUsuarioPorLegajo(string and)
        {
            and = "AND U.legajo = '"+and+"'";
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("SELECT U.nombreCompleto FROM Usuario AS U WHERE U.estado = 0 " + and);
                trader.ejecutarLectura();
                trader.Lector.Read();

                Usuario carr = new Usuario();

                carr._nombreCompleto = (string)trader.Lector["nombreCompleto"];


                return carr;
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
        public Materia listarMateriaPorID(string and = "")
        {
            and = "AND M.idMateria = " + and;
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("SELECT M.idMateria, M.idProfesor , M.nombreMateria, M.idCarrera, U.nombreCompleto as Profesor, M.horario, C.nombreCarrera as Carrera FROM Materia AS M JOIN Usuario AS U ON M.idProfesor = U.idUsuario JOIN Carrera AS C ON M.idCarrera = C.idCarrera  WHERE M.estado = 1 AND U.estado = 1 AND C.estado = 1 " + and);
                trader.ejecutarLectura();
                trader.Lector.Read();

                    Materia carr = new Materia();
                    carr._idMateria = (int)trader.Lector["idMateria"];
                    carr._nombreMateria = (string)trader.Lector["nombreMateria"];
                    carr._idCarrera = (int)trader.Lector["idCarrera"];
                    carr._carrera = (string)trader.Lector["Carrera"];
                    carr._idProfesor = (int)trader.Lector["idProfesor"];
                    carr._profesor = (string)trader.Lector["Profesor"];
                    carr._horario = (TimeSpan)trader.Lector["horario"];

                return carr;
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

        public List<Materia> listarMaterias(string and = "")
        {
            
            SQLTrader trader = new SQLTrader();
            List<Materia> lista = new List<Materia>();
            try
            {
                trader.setearConsulta("SELECT M.idMateria, M.idProfesor , M.nombreMateria, M.idCarrera, U.nombreCompleto as Profesor, M.horario, C.nombreCarrera as Carrera FROM Materia AS M JOIN Usuario AS U ON M.idProfesor = U.idUsuario JOIN Carrera AS C ON M.idCarrera = C.idCarrera  WHERE M.estado = 1 AND U.estado = 1 AND C.estado = 1 "+and);
                trader.ejecutarLectura();
                while (trader.Lector.Read())
                {
                    Materia  carr = new Materia();
                    carr._idMateria = (int)trader.Lector["idMateria"];
                    carr._nombreMateria = (string)trader.Lector["nombreMateria"];
                    carr._idCarrera = (int)trader.Lector["idCarrera"];
                    carr._carrera = (string)trader.Lector["Carrera"];
                    carr._idProfesor = (int)trader.Lector["idProfesor"];
                    carr._profesor = (string)trader.Lector["Profesor"];
                    carr._horario = (TimeSpan)trader.Lector["horario"];

                    
                    lista.Add(carr);
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

        public void insertar_Backlog(string accion, Materia materia, Usuario adm)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("INSERT INTO Backlog (usuario , horario, descripcion) VALUES   (@usuario , @horario ,@descripcion) ");
                trader.setearParametro("@usuario", adm._legajo);
                trader.setearParametro("@horario", DateTime.Now);
                if (accion == "insertar")
                {
                    trader.setearParametro("@descripcion", "Se ha insertado un nueva materia [" + materia._nombreMateria + "] a Base de Datos");
                    trader.ejecutarAccion();

                }
                if (accion == "borrar")
                {
                    trader.setearParametro("@descripcion", "Se ha borrado una materia [" + materia._nombreMateria + "] de Base de Datos |Baja logica|");
                    trader.ejecutarAccion();
                }
                if (accion == "UPDATE")
                {
                    trader.setearParametro("@descripcion", "Se ha cambiado la nota de un alumno ["+materia._nota+"]");
                    trader.ejecutarAccion();
                }
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

        public void insertar_Backlog(string accion,Usuario usuario,Usuario adm)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("INSERT INTO Backlog (usuario , horario, descripcion) VALUES   (@usuario , @horario ,@descripcion) ");
                trader.setearParametro("@usuario", adm._legajo);
                trader.setearParametro("@horario", DateTime.Now);
                if (accion == "insertar")
                {
                    trader.setearParametro("@descripcion", "Se ha insertado un nuevo usuario [" + usuario._nombreCompleto + "] a Base de Datos");
                    trader.ejecutarAccion();

                }
                if (accion == "borrar")
                {
                    trader.setearParametro("@descripcion", "Se ha borrado un usuario [" + usuario._nombreCompleto + "] de Base de Datos |Baja logica|");
                    trader.ejecutarAccion();
                }
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

        public List<Carrera> listarCarreras()
        {
            SQLTrader trader = new SQLTrader();
            List<Carrera> lista = new List<Carrera>();
            try
            {
                trader.setearConsulta("Select * from Carrera where estado = 1");
                trader.ejecutarLectura();
                while (trader.Lector.Read())
                {
                    Carrera carr = new Carrera();
                    carr._idCarrera = (int)trader.Lector["idCarrera"];
                    carr._nombreCarrera = (string)trader.Lector["nombreCarrera"];
                    carr._categoria = (string)trader.Lector["categoria"];

                    lista.Add(carr);
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

        public void editar_materia(string accion, Materia materia, Usuario adm)
        {
            Materia aux = new Materia();
            SQLTrader trader = new SQLTrader();
            try
            {
                if (accion == "insertar")
                {

                    trader.setearConsulta(
                    "INSERT  INTO    Materia ( nombreMateria , horario, idCarrera, idProfesor, nota, estado)" +
                    "                VALUES  (@nombreMateria, @horario, @idCarrera, @idProfesor, '0' ,'1')"
                    );
                    trader.setearParametro("@nombreMateria", materia._nombreMateria);
                    trader.setearParametro("@horario", materia._horario);
                    trader.setearParametro("@idProfesor", materia._idProfesor);
                    trader.setearParametro("@idCarrera", materia._idCarrera);

                }
                if (accion == "borrar")
                {
                    trader.setearConsulta("update Materia set estado = 0 where idmateria = @idMateria");
                    trader.setearParametro("@idMateria", materia._idMateria);
                }
                trader.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                insertar_Backlog(accion, materia, adm);
                trader.cerrarConexion();
            }
        }

        public void editar_carrera(string accion, Carrera carrera, Usuario adm)
        {
            Carrera aux = new Carrera();
            SQLTrader trader = new SQLTrader();
            try
            {
                if (accion == "insertar")
                {

                    trader.setearConsulta(
                    "INSERT  INTO    Carrera ( nombreCarrera , categoria, estado)" +
                    "                VALUES  (@nombreCarrera, @categoria, '1')"
                    );
                    trader.setearParametro("@nombreCarrera", carrera._nombreCarrera);
                    trader.setearParametro("@categoria", carrera._categoria);
                }
                if (accion == "borrar")
                {
                    trader.setearConsulta("update Carrera set estado = 0 where idCarrera = @idCarrera");
                    trader.setearParametro("@idCarrera", carrera._idCarrera);
                }
                trader.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (accion == Diccionario.BORRAR) carrera = listarCarreraPorID(carrera._idCarrera);
                insertar_Backlog(accion, carrera, adm);
                trader.cerrarConexion();
            }
        }

        private Carrera listarCarreraPorID(int idCarrera)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("SELECT C.nombreCarrera FROM Carrera AS C WHERE C.estado = 0 AND C.idCarrera = '"+idCarrera+"'" );
                trader.ejecutarLectura();
                trader.Lector.Read();

                Carrera carr = new Carrera();
                carr._nombreCarrera = (string)trader.Lector["nombreCarrera"];

                return carr;
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

        public void editar_usuario(string accion,Usuario usuario,Usuario adm)
        {
            SQLTrader trader = new SQLTrader();
            try
            {
                if (accion == Diccionario.INSERTAR)
                {

                    usuario._legajo = ultLegajoMasUno();
                    trader.setearConsulta(
                    "INSERT  INTO    Usuario (legajo, nombreCompleto, email, idPerfil, estado, contrasenia)" +
                    "                VALUES  (@legajo, @nombreCompleto, @email, @idPerfil, '1', @contrasenia)"
                    );
                    trader.setearParametro("@legajo", usuario._legajo);
                    trader.setearParametro("@nombreCompleto", usuario._nombreCompleto);
                    trader.setearParametro("@email", usuario._email);
                    trader.setearParametro("@idPerfil", usuario._idPerfil);
                    trader.setearParametro("@contrasenia", usuario._contra);
                    //insert -- crear insteadof en sql
                }
                if (accion == Diccionario.BORRAR)
                {
                    trader.setearConsulta("update Usuario set estado = 0 where Legajo = @legajo");
                    trader.setearParametro("@legajo", usuario._legajo);
                }
                trader.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(accion == Diccionario.BORRAR) 
                    usuario = listarUsuarioPorLegajo(usuario._legajo);
                insertar_Backlog(accion, usuario, adm);
                trader.cerrarConexion();
            }
        }


        public string ultLegajoMasUno()
        {
            SQLTrader trader = new SQLTrader();
            trader.setearConsulta("SELECT  MAX(idUsuario) as idUsuario from Usuario");
            trader.ejecutarLectura();
            trader.Lector.Read();
            string leg = "";
            if (trader.Lector["idUsuario"].ToString().Length == 2) leg = "000" + trader.Lector["idUsuario"];
            if (trader.Lector["idUsuario"].ToString().Length == 3) leg = "00" + trader.Lector["idUsuario"];
            if (trader.Lector["idUsuario"].ToString().Length == 4) leg = "0" + trader.Lector["idUsuario"];
            if (trader.Lector["idUsuario"].ToString().Length == 5) leg = "" + trader.Lector["idUsuario"];
            trader.cerrarConexion();
            return leg;
        }

        public List<Usuario> listarUsuarios()
        {
            SQLTrader trader = new SQLTrader();
            List<Usuario> lista = new List<Usuario>();
            try
            {
                trader.setearConsulta("Select * from Usuario where estado = 1");
                trader.ejecutarLectura();
                while (trader.Lector.Read())
                {
                    Usuario user = new Usuario();
                    user._legajo = (string)trader.Lector["legajo"];
                    user._nombreCompleto = (string)trader.Lector["nombreCompleto"];
                    user._email = (string)trader.Lector["email"];

                    if ((int)trader.Lector["idPerfil"] == 1) user._perfil = "Administrador";
                    if ((int)trader.Lector["idPerfil"] == 2) user._perfil = "Profesor";
                    if ((int)trader.Lector["idPerfil"] == 3) user._perfil = "Alumno";

                    lista.Add(user);
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

        public string Recuperacion_Contra(string emaildir)
        {

            SQLTrader trader = new SQLTrader();
            try
            {

                trader.setearConsulta(Diccionario.CONTRASEÑA_POR_EMAIL);
                trader.setearParametro("@email", emaildir );
                trader.ejecutarLectura();

                trader.Lector.Read();
                return trader.Lector["Contra"].ToString();
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
        
        public List<Backlog> listarBacklog()
        {
            List<Backlog> lista = new List<Backlog>();
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("SELECT * FROM Backlog");
                trader.ejecutarLectura();
                while (trader.Lector.Read())
                {
                    Backlog back = new Backlog();
                    back.legajo =  (string)trader.Lector["usuario"];
                    back.horario = (DateTime)trader.Lector["horario"];
                    back.descripcion = (string)trader.Lector["descripcion"];
                    lista.Add(back);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                trader.cerrarConexion();
            }
            lista.Reverse();
            return lista;
        }

        public List<Materia> ListarMateriasDelUser(Usuario user)
        {
            List<Materia> lista = new List<Materia>();  
            SQLTrader trader = new SQLTrader();
            try
            {
                trader.setearConsulta("SELECT M.idMateria, M.nombreMateria, M.estado, M.horario, M.nota, (SELECT U.nombreCompleto FROM Usuario AS U WHERE U.idUsuario = M.idProfesor) AS profesor FROM MateriaXUsuario AS MxU JOIN Materia AS M ON MxU.idMateria = M.idMateria JOIN Usuario AS U ON MxU.idUsuario = U.idUsuario WHERE M.estado != 0  AND U.idUsuario =  @usuario");
                trader.setearParametro("@usuario", user._idUsuario);
                trader.ejecutarLectura();

                while (trader.Lector.Read())
                {
                    Materia mat = new Materia();
                    mat._idMateria = (int)trader.Lector["idMateria"];
                    mat._nombreMateria = (string)trader.Lector["nombreMateria"];
                    mat._profesor = (string)trader.Lector["profesor"];
                    mat._nota = (int)trader.Lector["nota"];
                    mat._estado = (bool)trader.Lector["estado"];
                    mat._horario = (TimeSpan)trader.Lector["horario"];
                    mat._profesor = (string)trader.Lector["profesor"];
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
            string aux = _Usuario._legajo;
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
                    if(_Usuario._legajo == aux)
                    {
                        return true;
                    }
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
