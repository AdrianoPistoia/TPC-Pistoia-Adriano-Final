using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;














namespace DataManager
{
    public static class Class1
    {
        public static Control PreviousControl(this Control control)
        {
            ControlCollection siblings = control.Parent.Controls;
            for (int i = siblings.IndexOf(control) - 1; i >= 0; i--)
            {
                if (siblings[i].GetType() != typeof(LiteralControl) && siblings[i].GetType().BaseType != typeof(LiteralControl))
                {
                    return siblings[i];
                }
            }
            return null;
        }
    }
}
