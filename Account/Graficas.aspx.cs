using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace sismografoenlinea.Account
{
    public partial class Graficas : System.Web.UI.Page
    {
        public int contador;
        private ConexionSql sqlConection = new ConexionSql();  
              
        public class InfoUsuario
        {
            public static string nombreUsuario;
            public static int contadorAlarmas = 0;
            public static int antepenultimoId;
            /* public static void sendMail(string email, string asunto, string mensaje)
             {
            

                 MailMessage message = new MailMessage();
                 message.From = new MailAddress("proyectomicro2@gmail.com");
                 message.To.Add(email);
                 message.Subject = asunto;

                 message.Body = mensaje;

                 SmtpClient client = new SmtpClient();

                 client.EnableSsl = true;

                 client.Send(message);

             }   */

        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se ejecuta cuando la pagina se carga por primera vez

            if (!Page.IsPostBack)
            {

                // Label2.Text = Convert.ToString(sqlConection.lastValueRead());
                contador = 0;
                InfoUsuario.antepenultimoId = sqlConection.lastValueRead();
                //       contadorAlarmas = 0;

                Label1.Text = Convert.ToString(contador);
                //    TextBox2.Text = Convert.ToString(contadorAlarmas);


            }
            else
            {
                /* contador = Convert.ToInt16(Label1.Text);
                 contadorAlarmas = Convert.ToInt32(TextBox2.Text);
                
              
                 TextBox1.Text = Convert.ToString(contador);
                 Label1.Text = Convert.ToString(contador);

                 TextBox2.Text = Convert.ToString(contadorAlarmas);

                 if (contador < sqlConection.mostrarCantRegistros())
                 contador++;

                 Label1.Text = Convert.ToString(contador);*/


            }
            

        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            int cantRegistros = sqlConection.mostrarCantRegistros();
            int magnitud;

            // Esto sirve para que no se recorra la base de datos si no ha se ha insertado una nueva medicion
            try
            {
                if (contador < cantRegistros)
                {
                    magnitud = sqlConection.consultaValoresMasActuales(contador + 1, InfoUsuario.antepenultimoId);

                    //Verifica si el valor leido esta dentro de los rangos de alarma  
                    //   alarma(magnitud, ref InfoUsuario.contadorAlarmas);

                    chtCategoriesProductCount.Series["Series1"].Points.AddXY(contador, magnitud);
                    //  Chart1.Series["Series1"].Points.AddXY(contador, magnitud);

                    // Remove points from the left chart side if number of points exceeds 100.
                    while (this.chtCategoriesProductCount.Series[0].Points.Count > 50)
                    {
                        // Remove series points
                        foreach (Series series in this.chtCategoriesProductCount.Series)
                        {
                            series.Points.RemoveAt(0);
                        }

                    }
                    double axisMinimum = this.chtCategoriesProductCount.Series[0].Points[0].XValue;
                    this.chtCategoriesProductCount.ChartAreas[0].AxisX.Minimum = axisMinimum;
                    this.chtCategoriesProductCount.ChartAreas[0].AxisX.Maximum = axisMinimum + 100;


                }

            }
            catch (Exception x)
            {
                TextBox3.Text = x.Message.ToString();
            }



        }
    }
}