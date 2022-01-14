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
    public partial class Login : System.Web.UI.Page
    {
        
        public SQLAction Manager = new SQLAction();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (!IsPostBack)
            {
                

            }


        }

        protected void LoginSubmit_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            try
            {
                usuario._legajo = TextBoxLegajo.Text;
                usuario._contra = TextBoxContra.Text;
                if (Manager.LoguearUser(usuario))
                {
                    Session.Add("Usuario", usuario);
                    Response.Redirect("Default.aspx");
                }
                Session.Add("Error", "Usuario o contraseña incorrecta!");
                ///suario)Session["Usuario"])._legajo = "00022";    
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}