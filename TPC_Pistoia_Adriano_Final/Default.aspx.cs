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
    public partial class _Default : Page
    {
        
        public Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = ((Usuario)Session["Usuario"]);
            if (Session["Usuario"] == null)
            {
                Response.Redirect("/Login.aspx",true);
            }
            
        }


    }
}