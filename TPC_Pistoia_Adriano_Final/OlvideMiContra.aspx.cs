using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManager;
using DataSys;

namespace TPC_Pistoia_Adriano_Final
{
    public partial class OlvideMiContra : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        
        Random r = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if((Usuario)Session["Usuario"] != null)
            {
                usuario = (Usuario)Session["Usuario"];
            }
            else
            {
                
                HtmlGenericControl lbl = new HtmlGenericControl("label");
                lbl.InnerText = "Se le enviara un mail, con un codigo, a la direccion de correo ingresada. Una vez obtenido el codigo, ingreselo en la siguiente casilla.";

                asunto.Attributes.CssStyle.Add("visibility", "hidden");
                asunto.Attributes.CssStyle.Add("max-height", "0px");
                mensaje.Attributes.CssStyle.Add("visibility", "hidden");
                mensaje.Attributes.CssStyle.Add("max-height", "0px");
                lbl_Email.Text = "ingrese su Email";
                Paneloide.Controls.Add(lbl);
            }
            

            
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            SQLAction act = new SQLAction();
            string txbVal = txb_Codigo.Text;
            string contra = new string();
            contra = act.Recuperacion_Contra(txtEmail.Text);
            
            if (Int32.Parse(txbVal) == (int)Session["Codigo"])
            {
                EmailService emailService = new EmailService();
                //SQLTrader trader = new SQLTrader();
                //try
                //{

                //    trader.setearConsulta(Diccionario.CONTRASEÑA_POR_EMAIL);
                //    trader.setearParametro("@email", txtEmail.Text);
                //    trader.ejecutarLectura();

                    
                //        trader.Lector.Read();
                //        contra = trader.Lector["contrasenia"].ToString();
                    

                   
                //}
                //catch (Exception ex)
                //{

                //    throw ex;

                //}
                //finally
                //{
                //    trader.cerrarConexion();
                //}




                emailService.enviarContra(txtEmail.Text,contra);
            }
            ///pop-up "el email ingresado no existe en nuestra base de datos, intente devuelta con otro o corrige el mismo!"
        }

        protected void EnviarCodigo_Click(object sender, EventArgs e)
        {
            
            Session.Add("Codigo", r.Next(100000, 200001));
            EmailService emailService = new EmailService();
            emailService.enviarCodigo(txtEmail.Text, (int)Session["Codigo"]);
            int codigo = (int)Session["Codigo"];
            try
            {
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}
