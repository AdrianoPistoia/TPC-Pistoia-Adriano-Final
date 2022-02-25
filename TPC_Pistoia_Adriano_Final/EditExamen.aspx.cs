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
    public partial class EditExamen : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        public Examen examen = new Examen();
        public SQLAction trader = new SQLAction();
        public List<Examen> lst_examenes = new List<Examen>();
        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = (Usuario)Session["Usuario"];
            if (Session["Usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            tbl_repeaterMaterias.DataSource = trader.listarExamenes();
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
            return new TimeSpan(0, 00, 00, 00);
        }

        public void Insert_Click(object sender, EventArgs e)
        {
            examen._idMateria = Int32.Parse(txb_idMateria.Text);
            examen._horario = parse_horario(txb_horario.Text);
            trader.editar_examen(Diccionario.INSERTAR, examen, usuario);
            tbl_repeaterMaterias.DataSource = trader.listarExamenes();
            tbl_repeaterMaterias.DataBind();
        }

        protected void btn_borrarCarrera_Click(object sender, EventArgs e)
        {
            examen._idExamen = Int32.Parse(txb_borrarExamen.Text);
            trader.editar_examen(Diccionario.BORRAR, examen, usuario);
            tbl_repeaterMaterias.DataSource = trader.listarExamenes();
            tbl_repeaterMaterias.DataBind();

        }
    }
}