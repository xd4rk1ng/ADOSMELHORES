using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES.Controls
{
    public partial class ControlInicio : UserControl
    {
        private readonly Empresa _empresa;
        public ControlInicio(Empresa empresa)
        {
            _empresa = empresa;
            InitializeComponent();
        }
    }
}
