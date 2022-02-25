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
    public partial class EditMaterias : System.Web.UI.Page
    {

        public Usuario usuario = new Usuario();
        public Materia aux = new Materia();
        public SQLAction trader = new SQLAction();
        public SQLTrader manager = new SQLTrader();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["Usuario"];
            if (Session["Usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            tbl_repeaterMaterias.DataSource = trader.listarMaterias();
            tbl_repeaterMaterias.DataBind();
        }
        public void InsertAlm_Click(object sender, EventArgs e)
        {
            trader.ediar_MxU(txb_LegajoAlm.Text, txb_IDMat.Text, Diccionario.INSERTAR,usuario);
            tbl_repeaterMaterias.DataSource = trader.listarMaterias();
            tbl_repeaterMaterias.DataBind();
        }
        public void BorrarAlm_Click(object sender, EventArgs e)
        {
            trader.ediar_MxU(txb_LegajoAlmB.Text, txb_IDMatB.Text, Diccionario.BORRAR,usuario);
            tbl_repeaterMaterias.DataSource = trader.listarMaterias();
            tbl_repeaterMaterias.DataBind();
        }

        public void Insert_Click(object sender, EventArgs e)
        {
            aux._nombreMateria = txb_nombre.Text;
            aux._horario = parse_horario(txb_horar.Text);
            aux._profesor = txb_legProf.Text;
            aux._idProfesor = trader.listarProfePorLeg(txb_legProf.Text);
            aux._idCarrera = Int32.Parse(txb_idCarrera.Text);
            trader.editar_materia(Diccionario.INSERTAR, aux, usuario);
            tbl_repeaterMaterias.DataSource = trader.listarMaterias();
            tbl_repeaterMaterias.DataBind();
        }



        private TimeSpan parse_horario(string text)
        {
            if (text.ToUpper() == Diccionario.TARDE)
            {
                return new TimeSpan(0, 18, 00, 00);
            }
            if (text.ToUpper() == Diccionario.MAÑANA)
            {
                return new TimeSpan(0, 09, 00, 00);
            }
            return new TimeSpan(0, 00,00,00);
        }

        protected void btn_borrarMateria_Click(object sender, EventArgs e)
        {
            aux = trader.listarMateriaPorID(txb_borrarMateria.Text);
            trader.editar_materia(Diccionario.BORRAR, aux, usuario);
            tbl_repeaterMaterias.DataSource = trader.listarMaterias();
            tbl_repeaterMaterias.DataBind();

        }
    }
    
}