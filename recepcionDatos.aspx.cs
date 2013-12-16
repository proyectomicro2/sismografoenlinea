using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sismografoenlinea;

namespace sismografoenlinea
{
    public partial class recepcionDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConexionSql linqObject = new ConexionSql();
            int magnitud = Convert.ToInt32 ( Request.QueryString["m"]);
            linqObject.guardar(magnitud);                   


        }
    }
}