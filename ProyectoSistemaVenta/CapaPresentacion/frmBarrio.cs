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
    public partial class frmBarrio : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;
        public frmBarrio()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtBarrio, "Seleccione el barrio");
           this.ttMensaje.SetToolTip(this.cboLocalidad, "Seleccione la Localidad");

           this.LlenarComboLocalidad();
        }
        private void LlenarComboLocalidad()
        {
            cboLocalidad.DataSource = NLocalidad.Mostrar();
            cboLocalidad.ValueMember = "Id Localidad";
            cboLocalidad.DisplayMember = "Localidad";
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
            this.txtBarrio.Text = string.Empty;
            this.txtIdBarrio.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtBarrio.ReadOnly = !valor;
            this.cboLocalidad.Enabled = valor;
            this.txtIdBarrio.ReadOnly = !valor;
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
            this.DataListadoBarrio.Columns[0].Visible = false;
            this.DataListadoBarrio.Columns[1].Visible = false;
            this.DataListadoBarrio.Columns[3].Visible = false;
        }
        private void Mostrar()
        {
            this.DataListadoBarrio.DataSource = NBarrio.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoBarrio.Rows.Count);
        }
        private void BuscarBarrio()
        {
            this.DataListadoBarrio.DataSource = NBarrio.BuscarBarrio(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoBarrio.Rows.Count);
        }

        private void frmBarrio_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarBarrio();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarBarrio();
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

                    foreach (DataGridViewRow row in DataListadoBarrio.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NBarrio.Eliminar(Convert.ToInt32(Codigo));

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
                this.DataListadoBarrio.Columns[0].Visible = true;
            }
            else
            {
                this.DataListadoBarrio.Columns[0].Visible = false;
            }
        }

        private void DataListadoBarrio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataListadoBarrio.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DataListadoBarrio.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void DataListadoBarrio_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdBarrio.Text = Convert.ToString(this.DataListadoBarrio.CurrentRow.Cells["Id Barrio"].Value);
            this.txtBarrio.Text = Convert.ToString(this.DataListadoBarrio.CurrentRow.Cells["Barrio"].Value);
            this.cboLocalidad.SelectedValue = Convert.ToString(this.DataListadoBarrio.CurrentRow.Cells["Id Localidad"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtBarrio.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtBarrio.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtBarrio, "Ingrese el Barrio");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NBarrio.Insertar(this.txtBarrio.Text.Trim().ToUpper(), Convert.ToInt32(this.cboLocalidad.SelectedValue));
                    }
                    else
                    {
                        rpta = NBarrio.Editar(Convert.ToInt32(this.txtIdBarrio.Text),
                            this.txtBarrio.Text.Trim().ToUpper(), Convert.ToInt32(this.cboLocalidad.SelectedValue));
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
            if (!this.txtIdBarrio.Text.Equals(""))
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
