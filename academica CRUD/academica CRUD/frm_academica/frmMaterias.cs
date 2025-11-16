using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario_Academica
{
    public partial class frmMaterias : Form
    {
        public frmMaterias()
        {
            InitializeComponent();
        }
        conexión objConex = new conexión();
        DataSet objDS = new DataSet();
        DataTable objDT = new DataTable();

        public int posicion = 0;
        public string accion = "nuevo";

        private void actualizarDS()
        {
            objDS.Clear();
            objDS = objConex.obtenerdatos();
            objDT = objDS.Tables["materias"];
            objDT.PrimaryKey = new DataColumn[] { objDT.Columns["Idateria"] };

            grdMateria.DataSource = objDT.DefaultView;

            mostrardatos();
        }
        private void mostrardatos()
        {
            if (objDT.Rows.Count > 0)
            {
                lblIDMateria.Text = objDT.Rows[posicion]["Idmateria"].ToString();
                txtCodigoMateria.Text = objDT.Rows[posicion]["codigo"].ToString();
                txtNombreMateria.Text = objDT.Rows[posicion]["nombre"].ToString();
                txtUvMateria.Text = objDT.Rows[posicion]["uv"].ToString();
               
                lblCantidadResgisMateria.Text = (posicion + 1) + " de " + objDT.Rows.Count;
            }
        }

        private void frmMaterias_Load(object sender, EventArgs e)
        {
            actualizarDS();
            cboBuscarMateria.SelectedIndex = 1;
        }

        private void btnPrimerMateria_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrardatos();
        }

        private void btnSiguienteMateria_Click(object sender, EventArgs e)
        {
            if (posicion < objDT.Rows.Count - 1)
            {
                posicion++;
                mostrardatos();
            }
            else
            {
                MessageBox.Show("Este es el último registro", "Navegación de Materias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnteriorMateria_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrardatos();
            }
            else
            {
                MessageBox.Show("Este es el primer registro", "Navegación de Materias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUltimoMateria_Click(object sender, EventArgs e)
        {
            posicion = objDT.Rows.Count - 1;
            mostrardatos();
        }
        private void estadoControles(Boolean estado)
        {
            grbDatosMateria.Enabled = estado;
            grbNavegacionMateria.Enabled = !estado;
            btnEliminarMateria.Enabled = !estado;
        }
        private void limpiarControles()
        {
            lblIDMateria.Text = "";
            txtCodigoMateria.Text = "";
            txtNombreMateria.Text = "";
            txtUvMateria.Text = "";
           
        }
        private void btnNuevoMateria_Click(object sender, EventArgs e)
        {
            if (btnNuevoMateria.Text == "Nuevo")
            {
                btnNuevoMateria.Text = "Guardar";
                btnModificarMateria.Text = "Cancelar";
                estadoControles(true);
                accion = "nuevo";
                limpiarControles();
            }
            else

            {
                String[] materia =
                {
                    lblIDMateria.Text, txtCodigoMateria.Text, txtNombreMateria.Text, txtUvMateria.Text,
                };
                String respuesta = objConex.administrardatosMateria(materia, accion);
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al guardar materia. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    estadoControles(false);
                    btnNuevoMateria.Text = "Nuevo";
                    btnModificarMateria.Text = "Modificar";
                    actualizarDS();
                }
            }
        }

        private void btnModificarMateria_Click(object sender, EventArgs e)
        {
            if (btnModificarMateria.Text == "Modificar")
            {
                btnNuevoMateria.Text = "Guardar";
                btnModificarMateria.Text = "Cancelar";
                estadoControles(true);
                accion = "Modificar";
            }
            else
            {
                mostrardatos();
                estadoControles(false);
                btnNuevoMateria.Text = "Nuevo";
                btnModificarMateria.Text = "Modificar";
            }
        }

        private void btnEliminarMateria_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar a " + txtNombreMateria.Text,
                    "Eliminando Materia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String respuesta = objConex.administrardatosMateria(new string[] { lblIDMateria.Text, "", "", "", "" }, "Eliminar");
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al eliminar Materia.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    posicion = 0;
                    actualizarDS();
                }

            }
        }
        private void txtBuscarMateria_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                filtrarDatos(txtBuscarMateria.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void filtrarDatos(String valor)
        {
            try
            {
                DataView objDv = objDT.DefaultView;
                switch (cboBuscarMateria.SelectedIndex)
                {
                    case 0:
                        objDv.RowFilter = "codigo= " + valor;
                        break;
                    case 1: objDv.RowFilter = "nombre like '%" + valor +"%'";
                        break;
                }
               
                grdMateria.DataSource = objDv;
                seleccionarMateria();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void seleccionarMateria()
        {
            try
            {
                if (grdMateria.CurrentRow == null)
                {
                    //MessageBox.Show("No hay filas");
                    return;
                }
                string id = grdMateria.CurrentRow.Cells["idmateria"].Value.ToString();
                posicion = objDT.Rows.IndexOf(objDT.Rows.Find(id));
                mostrardatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void grdMateria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarMateria();
        }
    }
}
