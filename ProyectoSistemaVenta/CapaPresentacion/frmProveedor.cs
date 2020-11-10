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
    public partial class frmProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public frmProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRazonSocial, "Ingrese Razón Social del Proveedor");
            this.ttMensaje.SetToolTip(this.txtDocumento, "Ingrese Número de Documento del Proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la dirección del Proveedor");
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            this.txtRazonSocial.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCelular.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;

        }
        private void Habilitar(bool valor)
        {
            this.txtRazonSocial.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cboSectorComercial.Enabled = valor;
            this.cboTipoDocumento.Enabled = valor;
            this.txtDocumento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtCelular.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;
            this.txtIdProveedor.ReadOnly = !valor;
        }
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
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
            this.DataListadoProveedor.DataSource = NProveedor.BuscarProveedor(this.txtBuscarProveedor.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoProveedor.Rows.Count);
        }
     
        private void frmProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {   
                this.BuscarProveedor();  
        }
        private void txtBuscarProveedor_TextChanged(object sender, EventArgs e)
        {
            this.BuscarProveedor();
        }
        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            DataListadoProveedor.DataSource = NProveedor.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoProveedor.Rows.Count);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in DataListadoProveedor.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.DataListadoProveedor.Columns[0].Visible = true;
            }
            else
            {
                this.DataListadoProveedor.Columns[0].Visible = false;
            }
        }

        private void DataListadoProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataListadoProveedor.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DataListadoProveedor.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void DataListadoProveedor_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdProveedor.Text = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Id Proveedor"].Value);
            this.txtRazonSocial.Text = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Razon Social"].Value);
            this.cboSectorComercial.Text = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Sector Comercial"].Value);
            this.txtDireccion.Text = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Direccion"].Value);
            this.txtCorreo.Text = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Correo"].Value);
            this.txtTelefono.Text = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Telefono"].Value);
            this.txtCelular.Text = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Celular"].Value);
            this.cboTipoDocumento.Text = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Tipo de documento"].Value);
            this.txtDocumento.Text = Convert.ToString(this.DataListadoProveedor.CurrentRow.Cells["Documento"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazonSocial.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtRazonSocial.Text == string.Empty || this.txtDocumento.Text == string.Empty
                    || this.txtDireccion.Text == string.Empty || this.cboSectorComercial.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtRazonSocial, "Ingrese la Razon Social");
                    errorIcono.SetError(cboSectorComercial, "Ingrese el Sector Comercial");
                    errorIcono.SetError(txtDocumento, "Ingrese el Documento");
                    errorIcono.SetError(txtDireccion, "Ingrese Direccion");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProveedor.Insertar(this.txtRazonSocial.Text.Trim().ToUpper(),
                            this.cboSectorComercial.Text, txtDireccion.Text, txtCorreo.Text, txtTelefono.Text, txtCelular.Text,
                            cboTipoDocumento.Text, txtDocumento.Text);

                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdProveedor.Text),
                            this.txtRazonSocial.Text.Trim().ToUpper(),
                            this.cboSectorComercial.Text, txtDireccion.Text, txtCorreo.Text, txtTelefono.Text, txtCelular.Text,
                            cboTipoDocumento.Text,txtDocumento.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdProveedor.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdProveedor.Text = string.Empty;
        }

      
    }
}
