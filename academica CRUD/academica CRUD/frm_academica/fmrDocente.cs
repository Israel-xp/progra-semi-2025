using Formulario_Academica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class fmrDocente : Form
    {
        public fmrDocente()
        {
            InitializeComponent();
        }
        conexión objConex = new conexión();
        DataSet objDs = new DataSet();
        DataTable objDT = new DataTable();

        public int posicion = 0;
        public string accion = "nuevo";
        private void actualizarDS()
        {
            objDs.Clear();
            objDs = objConex.obtenerdatos();
            objDT = objDs.Tables["Docente"];
            objDT.PrimaryKey = new DataColumn[] { objDT.Columns["IdDocente"] };

            grdDocente.DataSource = objDT.DefaultView;

            MostrarDatos();
        }
        private void MostrarDatos()
        {
            if (objDT.Rows.Count > 0)
            {
                lblIdDocente.Text = objDT.Rows[posicion]["IdDocente"].ToString();
                txtCodigoDocente.Text = objDT.Rows[posicion]["codigo"].ToString();
                txtNombreDocente.Text = objDT.Rows[posicion]["nombre"].ToString();
                txtDireccionDocente.Text = objDT.Rows[posicion]["direccion"].ToString();
                txtTelefonoDocente.Text = objDT.Rows[posicion]["telefono"].ToString();

                lblCantRegDocente.Text = (posicion + 1) + " de " + objDT.Rows.Count;
            }
        } 
        private void fmrDocente_Load(object sender, EventArgs e)
        {
            actualizarDS();
        }

        private void btnSiguienteDocente_Click(object sender, EventArgs e)
        {
            if (posicion < objDT.Rows.Count - 1)
            {
                posicion++;
                MostrarDatos();
            }
            else
            {
                MessageBox.Show("Este es el último registro", "Navegación de docente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrimerDocente_Click(object sender, EventArgs e)
        {
            posicion = 0;
            MostrarDatos();
        }

        private void btnAnteriorDocente_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                MostrarDatos();
            }
            else
            {
                MessageBox.Show("Este es el primer registro", "Navegación de docente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUltimoDocente_Click(object sender, EventArgs e)
        {
            posicion = objDT.Rows.Count - 1;
            MostrarDatos();
        }
        private void estadocontroles(Boolean estado)
        {
            grbDatosDocente.Enabled = estado;
            grbNavegación.Enabled = !estado;
            btnEliminarDocente.Enabled = !estado;
        }
        private void limpiarControles()
        {
            lblIdDocente.Text = "";
            txtCodigoDocente.Text = "";
            txtNombreDocente.Text = "";
            txtDireccionDocente.Text = "";
            txtTelefonoDocente.Text = "";
        }

        private void btnNuevoDocente_Click(object sender, EventArgs e)
        {
            if (btnNuevoDocente.Text == "Nuevo")
            {
                btnNuevoDocente.Text = "Guardar";
                btnModificarDocente.Text = "Cancelar";
                estadocontroles(true);
                accion = "nuevo";
                limpiarControles();
            }
            else

            {
                String[] docente =
                {
                    lblIdDocente.Text, txtCodigoDocente.Text, txtNombreDocente.Text, txtDireccionDocente.Text, txtTelefonoDocente.Text
                };
                String respuesta = objConex.administrardatosDocentes(docente, accion);
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al guardar Docente. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    estadocontroles(false);
                    btnNuevoDocente.Text = "Nuevo";
                    btnModificarDocente.Text = "Modificar";
                    actualizarDS();
                }
            }
        }
        private void btnModificarDocente_Click(object sender, EventArgs e)
        {
            if (btnModificarDocente.Text == "Modificar")
            {
                btnNuevoDocente.Text = "Guardar";
                btnModificarDocente.Text = "Cancelar";
                estadocontroles(true);
                accion = "Modificar";
            }
            else
            {
                MostrarDatos();
                estadocontroles(false);
                btnNuevoDocente.Text = "Nuevo";
                btnModificarDocente.Text = "Modificar";
            }
        }

        private void btnEliminarDocente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar a " + txtNombreDocente.Text,
                    "Eliminando Docente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String respuesta = objConex.administrardatosDocentes(new string[] { lblIdDocente.Text, "", "", "", "" }, "Eliminar");
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al eliminar Docente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    posicion = 0;
                    actualizarDS();
                }

            }
        }
        private void txtBuscarDocente_KeyUp(object sender, KeyEventArgs e)
        {
            filtrarDatos(txtBuscarDocente.Text);
        }
        private void filtrarDatos(String valor)
        {
            DataView objDV = objDT.DefaultView;
            objDV.RowFilter = "codigo like '%" + valor + "%' OR nombre like '%" + valor + "%'";
            grdDocente.DataSource = objDV;
            selecionarDocente();
        }
        private void selecionarDocente()
        {
            posicion = objDT.Rows.IndexOf(objDT.Rows.Find(grdDocente.CurrentRow.Cells["IdDocente"].Value));
            MostrarDatos();
        }

        private void grdDocente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selecionarDocente();
        }
    }
}
