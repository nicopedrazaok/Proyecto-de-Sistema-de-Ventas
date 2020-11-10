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
    public partial class frmVistaCategoriaProducto : Form
    {
        public frmVistaCategoriaProducto()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.DataListadoCategoria.Columns[0].Visible = false;
           // this.DataListadoCategoria.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.DataListadoCategoria.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoCategoria.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.DataListadoCategoria.DataSource = NCategoria.BuscarNombre(this.txtBuscarCategoria.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoCategoria.Rows.Count);
        }
        private void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }
        private void frmVistaCategoriaProducto_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        private void DataListadoCategoria_DoubleClick(object sender, EventArgs e)
        {
            frmProducto form = frmProducto.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.DataListadoCategoria.CurrentRow.Cells["Id Categoria"].Value);
            par2 = Convert.ToString(this.DataListadoCategoria.CurrentRow.Cells["Nombre"].Value);
            form.setCategoria(par1, par2);
            this.Hide();
        }

        
    }
}
