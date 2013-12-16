using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sismografoenlinea
{
    public partial class NivelesSeguridad : System.Web.UI.Page
    {
        ConexionSql sqConexion = new ConexionSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                sqConexion.mostrarAlarmas(lbEliminar0, sismografoenlinea.Account.Graficas.InfoUsuario.nombreUsuario);


            }

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            try
            {
                sqConexion.guardarAlarma(txtDesde0.Text, txtHasta0.Text, txtNombreAlarm0.Text, sismografoenlinea.Account.Graficas.InfoUsuario.nombreUsuario);
                txtDesde0.Text = "";
                txtHasta0.Text = "";
                txtNombreAlarm0.Text = "";
                Response.Redirect("~/NivelesSeguridad.aspx");
            }
            catch (Exception x)
            {
               // TextBox1.Text = x.Message.ToString();

            }
        }

        protected void Lbmostrar0_Load(object sender, EventArgs e)
        {
            Lbmostrar0.Items.Clear();
            sqConexion.mostrarAlarmas(Lbmostrar0, sismografoenlinea.Account.Graficas.InfoUsuario.nombreUsuario);
        }

        protected void btnBodyOk_Click(object sender, EventArgs e)
        {
            ConexionSql conectSq = new ConexionSql();
            try
            {
            conectSq.eliminaralarma(lbEliminar0.SelectedItem.ToString());
          
            }
            catch (Exception x)
            {
                // TextBox1.Text = x.Message.ToString();

            }
            
        }
    }
}