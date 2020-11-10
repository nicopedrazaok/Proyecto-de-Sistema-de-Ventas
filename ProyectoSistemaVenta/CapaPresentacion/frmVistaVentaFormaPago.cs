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
    public partial class frmVistaVentaFormaPago : Form
    {
        public frmVistaVentaFormaPago()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.DataListadoFormaPago.Columns[0].Visible = false;
            // this.DataListadoCategoria.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.DataListadoFormaPago.DataSource = NFormaPago.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoFormaPago.Rows.Count);
        }

        private void BuscarFormaPago()
        {
            this.DataListadoFormaPago.DataSource = NFormaPago.BuscarFormaPago(this.txtBuscarFormaPago.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoFormaPago.Rows.Count);
        }
        private void txtBuscarFormaPago_TextChanged(object sender, EventArgs e)
        {
            this.BuscarFormaPago();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFormaPago();
        }
        private void frmVistaVentaFormaPago_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void DataListadoFormaPago_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2, par3;
            par1 = Convert.ToString(this.DataListadoFormaPago.CurrentRow.Cells["Id FormaPago"].Value);
            par2 = Convert.ToString(this.DataListadoFormaPago.CurrentRow.Cells["Forma de Pago"].Value);
            par3 = Convert.ToString(this.DataListadoFormaPago.CurrentRow.Cells["Detalles"].Value);
         
            form.setFormaPago(par1, par2, par3);
            this.Hide();
        }

     
    }
}
