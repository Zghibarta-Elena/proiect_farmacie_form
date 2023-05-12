using System;
using System.Windows.Forms;

namespace proiect_farmacie
{
    public static class Program
    { 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

        var farmacie = new Farmacie();

        farmacie.AdaugMed(new Medicament(1, "Paracetamol", 10));
        farmacie.AdaugMed(new Medicament(2, "Vidan", 104));
        farmacie.AdaugMed(new Medicament(3, "Aspirna", 130));
        farmacie.AdaugMed(new Medicament(4, "Aulin", 102));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(farmacie));
        }
    }
}
