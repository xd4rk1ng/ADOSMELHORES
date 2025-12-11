using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Corrigido: instanciando Empresa e passando para FormInicial
            var empresa = new Empresa("NomeDaEmpresa");
            Application.Run(new Forms.FormInicial(empresa));
        }
    }
}
