using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Agenda
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            
            FechaAgenda f = new FechaAgenda(19,2,32);
            Bonificacion b = new Bonificacion(7,6,22,"Docente U.T.U.");
            FechaAgenda bonificacion = new FechaAgenda();
            bonificacion = b.devuelve_bonificacion(f);
           

            MessageBox.Show(bonificacion.ToString_periodo());
            
        }

       
    }
}
