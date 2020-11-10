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
    public partial class frmVistaIngresoProducto : Form
    {
        public frmVistaIngresoProducto()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {
            this.dataListadoProducto.Columns[0].Visible = false;
            this.dataListadoProducto.Columns[1].Visible = false;
            this.dataListadoProducto.Columns[6].Visible = false;
            this.dataListadoProducto.Columns[8].Visible = false;
        }
        private void Mostrar()
        {
            this.dataListadoProducto.DataSource = NProducto.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoProducto.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dataListadoProducto.DataSource = NProducto.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoProducto.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void frmVistaIngresoProducto_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void dataListadoProducto_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso form = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListadoProducto.CurrentRow.Cells["Id Producto"].Value);
            par2 = Convert.ToString(this.dataListadoProducto.CurrentRow.Cells["Producto"].Value);
            form.setProducto(par1, par2);
            this.Hide();
        }
    }
}
