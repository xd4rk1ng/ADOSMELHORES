using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ADOSMELHORES.Controls;
using ADOSMELHORES.Database;
using ADOSMELHORES.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ADOSMELHORES.Forms
{
    public partial class FormInicialWIP : Form
    {
        private AppDBContext _dbContext;

        ControlInicio _ctrlInicio;
        ControlGestao _ctrlGestao;
        public FormInicialWIP(Empresa empresa)
        {
            InitializeComponent();

            // Inicialização de todos os user controls
            _ctrlInicio = new ControlInicio(empresa);
            _ctrlGestao = new ControlGestao(empresa);
        }

        // ao abrir o formulario carregar a base de dados
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _dbContext = new AppDBContext();
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            // apresenta por defeito o controlo de inicio
            MostrarControl(_ctrlInicio);
        }

        // Para garantir que a conexao a base de dados e fechada quando o formulario e fechado
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            _dbContext?.Dispose();
            _dbContext = null;
        }

        private void MostrarControl(UserControl userControl)
        {
            if (!panel1.Controls.Contains(userControl))
                panel1.Controls.Add(userControl);

            // Facilitar centralização
            userControl.Dock = DockStyle.None;
            userControl.Anchor = AnchorStyles.None;

            // Centrar controlo
            userControl.Location = new Point(
                (panel1.Width - userControl.Width) / 2,
                (panel1.Height - userControl.Height) / 2
                );

            // Remover transparência
            userControl.BackColor = Color.Transparent;
            userControl.BringToFront();

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarControl(_ctrlInicio);
        }

        private void btnGerir_Click(object sender, EventArgs e)
        {
            MostrarControl(_ctrlGestao);
        }
    }
}
