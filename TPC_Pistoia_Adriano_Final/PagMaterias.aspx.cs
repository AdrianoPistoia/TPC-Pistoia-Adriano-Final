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
    public partial class About : Page
    {
        public Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
        SQLAction Manager = new SQLAction();
            
            usuario = (Usuario)Session["Usuario"];
            if(Session["Usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            List<Materia> lst_materiasDelUser = Manager.ListarMateriasDelUser(usuario);
            tbl_repeaterMaterias.DataSource = lst_materiasDelUser;
            tbl_repeaterMaterias.DataBind();
            
        }

        protected void cambiarTest_Click(object sender, EventArgs e)
        {
            
        }
    }
}