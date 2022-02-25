using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DataManager;
using DataSys;

namespace TPC_Pistoia_Adriano_Final
{
    public partial class Login : System.Web.UI.Page
    {
        public SQLAction Manager = new SQLAction();
        protected void Page_Load(object sender, EventArgs e)
        {
                holi.Visible = false;
            if (Session["Usuario"] != null)
            {
                Response.Redirect("/Default.aspx");
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
                else
                {
                    holi.Visible = true;
                }
               
                Session.Add("Error", "Usuario o contraseña incorrecta!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Parent.Visible = false;
        }
    }
}