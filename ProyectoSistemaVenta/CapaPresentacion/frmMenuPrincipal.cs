using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmMenuPrincipal : Form
    {
        private int childFormNumber = 0;
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void articuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmProducto frmP = frmProducto.GetInstancia();
          //  frmP.MdiParent = this;
            frmP.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria frmC = new frmCategoria();
            frmC.Show();
        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPresentacion frmPre = new frmPresentacion();
            frmPre.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frmPro = new frmProveedor();
            frmPro.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleado frmE = new frmEmpleado();
            frmE.Show();
        }

        private void provinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProvincia frmProv = new frmProvincia();
            frmProv.Show();
        }

        private void barrioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarrio frmB = new frmBarrio();
            frmB.Show();
        }

        private void localidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalidad frmL = new frmLocalidad();
            frmL.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frmC = frmCliente.GetInstancia();
            //  frmP.MdiParent = this;
            frmC.Show();
        }
    }
}
