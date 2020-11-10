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
    public partial class frmLocalidad : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;
        public frmLocalidad()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtLocalidad, "Seleccione la Localidad");
            //this.ttMensaje.SetToolTip(this.cboProvincia, "Seleccione la provincia");

            //this.LlenarComboProvincia();
        }
        //private void LlenarComboProvincia()
        //{
        //    cboProvincia.DataSource = NProvincia.Mostrar();
        //    cboProvincia.ValueMember = "Id Provincia";
        //    cboProvincia.DisplayMember = "Provincia";
        //}
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
            this.txtLocalidad.Text = string.Empty;
            this.txtIdLocalidad.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtLocalidad.ReadOnly = !valor;
            //this.cboProvincia.Enabled = valor;
            this.txtIdLocalidad.ReadOnly = !valor;
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
            this.DataListadoLocalidad.Columns[0].Visible = false;
            this.DataListadoLocalidad.Columns[1].Visible = false;
            //this.DataListadoLocalidad.Columns[3].Visible = false;
            //this.DataListadoProducto.Columns[8].Visible = false;
        }
        private void Mostrar()
        {
            this.DataListadoLocalidad.DataSource = NLocalidad.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoLocalidad.Rows.Count);
        }
        private void BuscarLocalidad()
        {
            this.DataListadoLocalidad.DataSource = NLocalidad.BuscarLocalidad(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoLocalidad.Rows.Count);
        }

        private void frmLocalidad_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarLocalidad();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarLocalidad();
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

                    foreach (DataGridViewRow row in DataListadoLocalidad.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NLocalidad.Eliminar(Convert.ToInt32(Codigo));

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
                this.DataListadoLocalidad.Columns[0].Visible = true;
            }
            else
            {
                this.DataListadoLocalidad.Columns[0].Visible = false;
            }
        }

        private void DataListadoLocalidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataListadoLocalidad.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DataListadoLocalidad.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void DataListadoLocalidad_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdLocalidad.Text = Convert.ToString(this.DataListadoLocalidad.CurrentRow.Cells["Id Localidad"].Value);
            this.txtLocalidad.Text = Convert.ToString(this.DataListadoLocalidad.CurrentRow.Cells["Localidad"].Value);
            //this.cboProvincia.SelectedValue = Convert.ToString(this.DataListadoLocalidad.CurrentRow.Cells["Id Provincia"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtLocalidad.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtLocalidad.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtLocalidad, "Ingrese la Localidad");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NLocalidad.Insertar(this.txtLocalidad.Text.Trim().ToUpper()/*, Convert.ToInt32(this.cboProvincia.SelectedValue)*/);
                    }
                    else
                    {
                        rpta = NLocalidad.Editar(Convert.ToInt32(this.txtIdLocalidad.Text),
                            this.txtLocalidad.Text.Trim().ToUpper()/*, Convert.ToInt32(this.cboProvincia.SelectedValue)*/);
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
            if (!this.txtIdLocalidad.Text.Equals(""))
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
