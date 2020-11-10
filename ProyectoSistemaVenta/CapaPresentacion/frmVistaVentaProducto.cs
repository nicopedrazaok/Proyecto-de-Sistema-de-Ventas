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
    public partial class frmVistaVentaProducto : Form
    {
        public frmVistaVentaProducto()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        private void MostrarProducto_Venta_Nombre()
        {
            this.dataListado.DataSource = NVenta.MostrarProducto_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarProducto_Venta_Codigo()
        {
            this.dataListado.DataSource = NVenta.MostrarProducto_Venta_Codigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void frmVistaVentaProducto_Load(object sender, EventArgs e)
        {
            this.MostrarProducto_Venta_Nombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            decimal par3, par4;
            int par5;
            DateTime par6;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Id Detalle Ingreso"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Producto"].Value);
            par3 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["Precio de Compra"].Value);
            par4 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["Precio de Venta"].Value);
            par5 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Stock Actual"].Value);
            par6 = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha de Vencimiento"].Value);
            form.setProducto(par1, par2, par3, par4, par5, par6);
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Codigo"))
            {
                this.MostrarProducto_Venta_Codigo();
            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarProducto_Venta_Nombre();
            }
        }
    }
}
