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
    public partial class frmFormaPago : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;
        public frmFormaPago()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtFormaPago, "Ingrese la Forma de Pago");
            this.ttMensaje.SetToolTip(this.txtDetalle, "Ingrese el Detalle de la Forma de Pago");
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
            this.txtFormaPago.Text = string.Empty;
            this.txtDetalle.Text = string.Empty;
            this.txtIdFormaPago.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtFormaPago.ReadOnly = !valor;
            this.txtDetalle.ReadOnly = !valor;
            this.txtIdFormaPago.ReadOnly = !valor;
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
            this.DataListadoFormaPago.Columns[0].Visible = false;
            this.DataListadoFormaPago.Columns[1].Visible = false;
          
        }
        private void Mostrar()
        {
            this.DataListadoFormaPago.DataSource = NFormaPago.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoFormaPago.Rows.Count);
        }

        private void frmFormaPago_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }


        private void BuscarFormaPago()
        {
            this.DataListadoFormaPago.DataSource = NFormaPago.BuscarFormaPago(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoFormaPago.Rows.Count);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarFormaPago();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFormaPago();
        }

        private void DataListadoFormaPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataListadoFormaPago.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DataListadoFormaPago.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.DataListadoFormaPago.Columns[0].Visible = true;
            }
            else
            {
                this.DataListadoFormaPago.Columns[0].Visible = false;
            }
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

                    foreach (DataGridViewRow row in DataListadoFormaPago.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NFormaPago.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente la forma de pago");
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
        private void DataListadoFormaPago_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdFormaPago.Text = Convert.ToString(this.DataListadoFormaPago.CurrentRow.Cells["Id FormaPago"].Value);
            this.txtFormaPago.Text = Convert.ToString(this.DataListadoFormaPago.CurrentRow.Cells["Forma de Pago"].Value);
            this.txtDetalle.Text = Convert.ToString(this.DataListadoFormaPago.CurrentRow.Cells["Detalles"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtFormaPago.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtFormaPago.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtFormaPago, "Ingrese la forma de Pago");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NFormaPago.Insertar(this.txtFormaPago.Text.Trim().ToUpper(), this.txtDetalle.Text);
                    }
                    else
                    {
                        rpta = NFormaPago.Editar(Convert.ToInt32(this.txtIdFormaPago.Text), this.txtFormaPago.Text.Trim().ToUpper(), this.txtDetalle.Text);
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
            if (!this.txtIdFormaPago.Text.Equals(""))
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
            this.Habilitar(false);
        }
    }
}
