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
    public partial class frmVistaIngresoProveedor : Form
    {
        public frmVistaIngresoProveedor()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.DataListadoProveedor.Columns[0].Visible = false;
            this.DataListadoProveedor.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.DataListadoProveedor.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoProveedor.Rows.Count);
        }

        private void BuscarProveedor()
        {
            this.DataListadoProveedor.DataSource = NProveedor.BuscarProveedor(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoProveedor.Rows.Count);
        }

        //private void BuscarDocumento()
        //{
        //    this.DataListadoProveedor.DataSource = NProveedor.BuscarDocumento(this.txtBuscar.Text);
        //    this.OcultarColumnas();
        //    lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoProveedor.Rows.Count);
        //}

        private void frmVistaIngresoProveedor_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
             this.BuscarProveedor();
           
        }

        private void DataListadoProveedor_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso form = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Id Proveedor"].Value);
            par2 = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Razon Social"].Value);
            form.setProveedor(par1, par2);
            this.Hide();
        }
    }
}
