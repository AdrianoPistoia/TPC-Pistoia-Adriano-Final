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
    public partial class TablonMensajes : System.Web.UI.Page
    {
        
        public Usuario usuario = new Usuario();
        public Mensaje _mensaje = new Mensaje();
        public SQLAction trader = new SQLAction();
        public List<Mensaje> lst_usuarios = new List<Mensaje>();
        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = (Usuario)Session["Usuario"];
            if (Session["Usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            tbl_repeaterMaterias.DataSource = trader.listarMensajes();
            tbl_repeaterMaterias.DataBind();
        }

        public void Insert_Click(object sender, EventArgs e)
        {
            _mensaje.mensaje = txb_mensaje.Text;
            _mensaje.Asunto = txb_asunto.Text;
            trader.editar_mensaje(Diccionario.INSERTAR, _mensaje, usuario);
            tbl_repeaterMaterias.DataSource = trader.listarMensajes();
            tbl_repeaterMaterias.DataBind();
        }

        protected void btn_borrarMensaje_Click(object sender, EventArgs e)
        {
            _mensaje.id = Int32.Parse(txb_borrarMensaje.Text);
            trader.editar_mensaje(Diccionario.BORRAR, _mensaje, usuario);
            tbl_repeaterMaterias.DataSource = trader.listarMensajes();
            tbl_repeaterMaterias.DataBind();

        }
    }
    
}