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
    public partial class frmVistaVentaCliente : Form
    {
        public frmVistaVentaCliente()
        {
            InitializeComponent();
            
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarCliente()
        {
            this.dataListado.DataSource = NCliente.BuscarCliente(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
       
        private void frmVistaVentaCliente_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
              this.BuscarCliente();
           
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Id Cliente"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido"].Value) + ", " +
                Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            form.setCliente(par1, par2);
            this.Hide();
        }
    }
}
