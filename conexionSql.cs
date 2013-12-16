using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace sismografoenlinea
{
    public class ConexionSql
    {

        Db_aspNetServicesDataContext db = new Db_aspNetServicesDataContext();
        mediciones m = new mediciones();
        alarmas a = new alarmas(); 
        
        public void guardar(int magnitud)
        {
            

            m.magnitud = magnitud;
            m.fecha = DateTime.Now;

            db.mediciones.InsertOnSubmit(m);
            db.SubmitChanges();


        }

        public int mostrarCantRegistros()
        {
           string valorLeido="";
           int cantRegistros;

           db.lecturasDelDia_CantRegistros(ref valorLeido);
           cantRegistros = Convert.ToInt32(valorLeido);
           return cantRegistros;

        }
        public int mostrarMagnitud(int id)
        {
           string valorLeido=" ";
           var consulta= db.lecturasDelDia(id,ref valorLeido);

           int valorRetorna = Convert.ToInt32(valorLeido);
           return valorRetorna;
                       
        }
        public int lastValueRead()
        {
            var consulta = from x in db.mediciones
                           orderby x.id descending
                           select x.id;    

            return ( consulta.First());            
        
        }

        public int consultaValoresMasActuales(int id, int antepenultimoId)
        {
            string valorLeido = " ";
            var consulta = db.mostrarRegistrosMasActuales(id, ref valorLeido, antepenultimoId);

            int valorRetorna = Convert.ToInt32(valorLeido);
       
            return valorRetorna;
        
        }

        //Los metodos relacionados con las alarmas
        public void mostrarAlarmas(ListBox lb, string username)
        {
            var consulta = from x in db.alarmas
                           where x.username==username
                           select x;
            foreach(alarmas al in consulta)
            {
                lb.Items.Add(al.nombre);
            }
        
        }
        public void guardarAlarma(string desde, string hasta,string nombre, string nombreUsuario)
        {                      

            a.nombre = nombre;
            a.desde = desde;
            a.hasta = hasta;
            a.username = nombreUsuario;
            
                        
            db.alarmas.InsertOnSubmit(a);
            db.SubmitChanges();
            
        }

        public void eliminaralarma(string nombre)
        {
            var consulta = from x in db.alarmas
                           where x.nombre == nombre
                           select x;
            foreach (alarmas al in consulta)
            {
                db.alarmas.DeleteOnSubmit(al);
            }
            db.SubmitChanges();
                              
        
        }

        public string GetMail(string username)
        {
            string valorLeido = "";

            db.GetEmailAddress(username, ref valorLeido);

            return valorLeido;

        }

        public int monitoreoMediciones(string username, double magnitud)
        {
            var consulta = from x in db.alarmas
                           where x.username== username
                           select x;
            foreach (alarmas al in consulta)
            {
                if (magnitud > Convert.ToDouble(al.desde) && magnitud < Convert.ToDouble(al.hasta))
                    return 1;
                
            }

            return 0;

        }



    }
}