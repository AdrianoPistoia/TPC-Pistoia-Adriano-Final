using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSys;
using DataManager;

namespace TPC_Pistoia_Adriano_Final
{
    public partial class PagEditar : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        public Usuario aux = new Usuario();
        public SQLAction trader = new SQLAction();
        public List<Usuario> lst_usuarios = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            usuario = (Usuario)Session["Usuario"];
            if (Session["Usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            tbl_repeaterMaterias.DataSource = trader.listarUsuarios();
            tbl_repeaterMaterias.DataBind();
        }



        public void Insert_Click(object sender, EventArgs e)
        {
            aux._contra = txb_contra.Text;
            aux._email = txb_email.Text;
            aux._nombreCompleto = txb_nombre.Text;
            aux._idPerfil = Int32.Parse(txb_perfil.Text) ;
            trader.editar_usuario(Diccionario.INSERTAR, aux, usuario);
            tbl_repeaterMaterias.DataSource = trader.listarUsuarios();
            tbl_repeaterMaterias.DataBind();


        }

        protected void btn_borrarUser_Click(object sender, EventArgs e)
        {
            aux._legajo = txb_borrarLegajo.Text;

            trader.editar_usuario(Diccionario.BORRAR,aux,usuario);
            
            tbl_repeaterMaterias.DataSource = trader.listarUsuarios();
            tbl_repeaterMaterias.DataBind();

        }
    }
}