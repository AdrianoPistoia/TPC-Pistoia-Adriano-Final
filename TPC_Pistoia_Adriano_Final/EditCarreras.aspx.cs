using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManager;
using DataSys;

namespace TPC_Pistoia_Adriano_Final
{
    public partial class EditCarreras : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        public Carrera carrera = new Carrera();
        public SQLAction trader = new SQLAction();
        public List<Carrera> lst_usuarios = new List<Carrera>();
        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = (Usuario)Session["Usuario"];
            if (Session["Usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            tbl_repeaterMaterias.DataSource = trader.listarCarreras();
            tbl_repeaterMaterias.DataBind();
        }

        public void Insert_Click(object sender, EventArgs e)
        {

            carrera._nombreCarrera= txb_carrera.Text;
            carrera._categoria = txb_categoria.Text;
            trader.editar_carrera(Diccionario.INSERTAR, carrera, usuario);
            tbl_repeaterMaterias.DataSource = trader.listarCarreras();
            tbl_repeaterMaterias.DataBind();
        }

        protected void btn_borrarCarrera_Click(object sender, EventArgs e)
        {
            carrera._idCarrera = Int32.Parse(txb_borrarCarrera.Text);
            trader.editar_carrera(Diccionario.BORRAR, carrera, usuario);
            tbl_repeaterMaterias.DataSource = trader.listarCarreras();
            tbl_repeaterMaterias.DataBind();

        }
    }
}