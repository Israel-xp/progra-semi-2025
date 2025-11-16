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
    public partial class Form1 : Form
    {
        public Form1()
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
            objDT = objDS.Tables["estudiante"];
            objDT.PrimaryKey = new DataColumn[] { objDT.Columns["Idestudiante"] };

            grdEstudiante.DataSource = objDT.DefaultView;

            mostrardatos();
        }
        private void mostrardatos()
        {
            if (objDT.Rows.Count>0)
            {
                lblID.Text = objDT.Rows[posicion]["Idestudiante"].ToString();
                txtCodigo.Text = objDT.Rows[posicion]["código"].ToString();
                txtNombre.Text = objDT.Rows[posicion]["nombre"].ToString();
                txtDireccion.Text = objDT.Rows[posicion]["dirección"].ToString();
                txtTelefono.Text = objDT.Rows[posicion]["teléfono"].ToString();

                lblCantidadResgis.Text = (posicion + 1) + " de " + objDT.Rows.Count;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            actualizarDS();
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (posicion < objDT.Rows.Count - 1)
            {
                posicion++;
                mostrardatos();
            }
            else
            {
                MessageBox.Show("Este es el último registro", "Navegación de estudiante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrardatos();
            }
            else
            {
                MessageBox.Show("Este es el primer registro", "Navegación de estudiante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            posicion = objDT.Rows.Count - 1;
            mostrardatos();
        }

        private void btnPrimer_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrardatos();
        }
        private void estadocontroles(Boolean estado)
        {
            grbDatos.Enabled = estado;
            grbNavegación.Enabled = !estado;
            btnEliminar.Enabled = !estado;
        }
        private void limpiarcontroles()
        {
            lblID.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if(btnNuevo.Text == "Nuevo")
            {
                btnNuevo.Text = "Guardar";
                btnModificar.Text = "Cancelar";
                estadocontroles(true);
                accion = "nuevo";
                limpiarcontroles();
            }
            else         
             
            {
                String[] estudiantes =
                {
                    lblID.Text, txtCodigo.Text, txtNombre.Text, txtDireccion.Text, txtTelefono.Text
                };
                String respuesta = objConex.administrardatos(estudiantes, accion);
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al guardar estudiante. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    estadocontroles(false);
                    btnNuevo.Text = "Nuevo";
                    btnModificar.Text = "Modificar";
                    actualizarDS();
                }
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnModificar.Text == "Modificar")
            {
                btnNuevo.Text = "Guardar";
                btnModificar.Text = "Cancelar";
                estadocontroles(true);
                accion = "Modificar";
            }
            else
            {
                mostrardatos();
                estadocontroles(false);
                btnNuevo.Text = "Nuevo";
                btnModificar.Text = "Modificar";
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar a " + txtNombre.Text,
                     "Eliminando alumnos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String respuesta = objConex.administrardatos(new string[] { lblID.Text, "", "", "", ""}, "Eliminar");
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al eliminar alumnos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    posicion = 0;
                    actualizarDS();
                }                      
                
            }
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            filtrardatos(txtBuscar.Text);
        }
        private void filtrardatos(String valor)
        {
            DataView objDV = objDT.DefaultView;
            objDV.RowFilter = "código like '%"+ valor +"%' OR nombre like '%" + valor + "%'";
            grdEstudiante.DataSource = objDV;
            selecionarestudiante(); 
        }
        private void selecionarestudiante()
        {
            posicion = objDT.Rows.IndexOf(objDT.Rows.Find(grdEstudiante.CurrentRow.Cells["ID"].Value));
            mostrardatos();
        }

        private void grdEstudiante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selecionarestudiante();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
