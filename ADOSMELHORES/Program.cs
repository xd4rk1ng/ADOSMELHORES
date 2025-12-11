using ADOSMELHORES.Modelos;
using ADOSMELHORES.Servicos;
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


            // Temporario, para testar
            //  -   provavelmente havera algo (funcao, classe) que carregara eestas informacoes, provavelmente da parte da db
            var _colaboradores = new List<Funcionario>();
            var _centrosCustos = new Dictionary<Type, CentroCusto>();
            _centrosCustos.Add(typeof(Exemplo), new CentroCusto());

            Application.Run(new Forms.FormInicial(new Empresa(
                _centrosCustos,
                _colaboradores,
                "AdosMelhores!"
                )));
        }
    }
}
