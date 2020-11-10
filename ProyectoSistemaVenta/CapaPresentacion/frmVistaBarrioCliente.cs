using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVistaBarrioCliente : Form
    {
        public frmVistaBarrioCliente()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.dataListadoBarrio.Columns[0].Visible = false;
            this.dataListadoBarrio.Columns[2].Visible = false;
        }
        private void Mostrar()
        {
            this.dataListadoBarrio.DataSource = NBarrio.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoBarrio.Rows.Count);
        }

        private void BuscarBarrio()
        {
            this.dataListadoBarrio.DataSource = NBarrio.BuscarBarrio(this.txtBuscarBarrio.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoBarrio.Rows.Count);
        }
        private void txtBuscarBarrio_TextChanged(object sender, EventArgs e)
        {
            this.BuscarBarrio();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarBarrio();
        }
        private void frmVistaBarrioCliente_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        
        private void dataListadoBarrio_DoubleClick_1(object sender, EventArgs e)
        {
            frmCliente form = frmCliente.GetInstancia();
            string par1, par2, par3, par4;
            par1 = Convert.ToString(this.dataListadoBarrio.CurrentRow.Cells["Id Barrio"].Value);
            par2 = Convert.ToString(this.dataListadoBarrio.CurrentRow.Cells["Barrio"].Value);
            par3 = Convert.ToString(this.dataListadoBarrio.CurrentRow.Cells["Id Localidad"].Value);
            par4 = Convert.ToString(this.dataListadoBarrio.CurrentRow.Cells["Localidad"].Value);
            form.setBarrio(par1, par2, par3, par4);
            this.Hide();
        }
    }
}
