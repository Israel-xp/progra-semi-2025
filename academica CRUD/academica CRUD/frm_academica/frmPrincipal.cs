using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Formulario_Academica
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 objAlumnos = new Form1();
            objAlumnos.MdiParent = this;
            objAlumnos.Show();
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaterias objMaterias = new frmMaterias();
            objMaterias.MdiParent = this;
            objMaterias.Show();
        }

        private void periodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeriodos objPeriodos = new frmPeriodos();
            objPeriodos.MdiParent = this;
            objPeriodos.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void docenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrDocente objDocente = new fmrDocente();
            objDocente.MdiParent = this;
            objDocente.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
