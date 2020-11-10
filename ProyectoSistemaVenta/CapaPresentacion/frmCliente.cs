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
    public partial class frmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private static frmCliente _Instancia;

        public static frmCliente GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmCliente();
            }
            return _Instancia;
        }
        public void setBarrio(string IdBarrio, string Barrio, string IdLocalidad, string Localidad)
        {
            this.txtIdBarrio.Text = IdBarrio;
            this.txtBarrio.Text = Barrio;
            this.txtIdLocalidad.Text = IdLocalidad;
            this.txtLocalidad.Text = Localidad;
        }
        public frmCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtApellido, "Ingrese Los Apellido del Cliente");
            this.ttMensaje.SetToolTip(this.txtDocumento, "Ingrese el Documento del Cliente");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Cliente");
            this.txtIdBarrio.Visible = false;
            this.txtBarrio.ReadOnly = true;
            this.txtIdLocalidad.Visible = false;
            this.txtLocalidad.ReadOnly = true;
        }
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            this.txtIdCliente.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCelular.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtBarrio.Text = string.Empty;
            this.txtLocalidad.Text = string.Empty;
            this.txtCodigoPostal.Text = string.Empty;

        }
        private void Habilitar(bool Valor)
        {
            this.txtIdCliente.ReadOnly = !Valor;
            this.txtNombre.ReadOnly = !Valor;
            this.txtApellido.ReadOnly = !Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.cboSexo.Enabled = Valor;
            this.dtpFechaNacimiento.Enabled = Valor;
            this.cboTipoDocumento.Enabled = Valor;
            this.txtDocumento.Enabled = Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.txtTelefono.ReadOnly = !Valor;
            this.txtCelular.ReadOnly = !Valor;
            this.txtCorreo.ReadOnly = !Valor;
            this.txtBarrio.Enabled = Valor;
            this.txtLocalidad.Enabled = Valor;
            this.txtCodigoPostal.ReadOnly = !Valor;
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
            this.DataListadoCliente.Columns[0].Visible = false;
            this.DataListadoCliente.Columns[1].Visible = false;
            this.DataListadoCliente.Columns[11].Visible = false;
            this.DataListadoCliente.Columns[9].Visible = false;
        }
        private void Mostrar()
        {
            this.DataListadoCliente.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(DataListadoCliente.Rows.Count);
        }
        private void BuscarCliente()
        {
            this.DataListadoCliente.DataSource = NCliente.BuscarCliente(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(DataListadoCliente.Rows.Count);
        }

     
        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
                this.BuscarCliente();
          
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            DataListadoCliente.DataSource = NCliente.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoCliente.Rows.Count);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarCliente();
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

                    foreach (DataGridViewRow row in DataListadoCliente.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se Eliminó Correctamente el registro");
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
                this.DataListadoCliente.Columns[0].Visible = true;
            }
            else
            {
                this.DataListadoCliente.Columns[0].Visible = false;
            }
        }

        private void DataListadoCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataListadoCliente.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                    (DataGridViewCheckBoxCell)DataListadoCliente.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void DataListadoCliente_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCliente.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Id Cliente"].Value);
            this.txtNombre.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Apellido"].Value);
            this.cboSexo.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Sexo"].Value);
            this.dtpFechaNacimiento.Value = Convert.ToDateTime(this.DataListadoCliente.CurrentRow.Cells["Fecha de nacimiento"].Value);
            this.cboTipoDocumento.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Tipo de documento"].Value);
            this.txtDocumento.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Direccion"].Value);
            this.txtIdBarrio.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Id Barrio"].Value);
            this.txtBarrio.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Barrio"].Value);
            this.txtLocalidad.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Localidad"].Value);
            this.txtCodigoPostal.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Codigo postal"].Value);
            this.txtTelefono.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Telefono"].Value);
            this.txtCelular.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Celular"].Value);
            this.txtCorreo.Text = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["Correo"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || txtDocumento.Text == string.Empty || txtDireccion.Text == string.Empty || txtDocumento.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese el nombe");
                    errorIcono.SetError(txtApellido, "Ingrese el apellido");
                    errorIcono.SetError(txtDocumento, "Ingrese el documento");
                    errorIcono.SetError(txtDireccion, "Ingrese el usuario");
                    errorIcono.SetError(txtDocumento, "Ingrese la contraseña");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        Rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellido.Text.Trim().ToUpper(), cboSexo.Text, dtpFechaNacimiento.Value, cboTipoDocumento.Text,
                        txtDocumento.Text, txtDireccion.Text, Convert.ToInt32(txtIdBarrio.Text), txtCodigoPostal.Text,
                        txtTelefono.Text, txtCelular.Text, txtCorreo.Text);

                    }
                    else
                    {
                        Rpta = NCliente.Editar(Convert.ToInt32(this.txtIdCliente.Text), this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellido.Text.Trim().ToUpper(), cboSexo.Text, dtpFechaNacimiento.Value, cboTipoDocumento.Text,
                        txtDocumento.Text, txtDireccion.Text, Convert.ToInt32(txtIdBarrio.Text), txtCodigoPostal.Text,
                        txtTelefono.Text, txtCelular.Text, txtCorreo.Text);
                    }
                    if (Rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.txtIdCliente.Text = "";
                }          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdCliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdCliente.Text = string.Empty;
        }

        private void txtBarrio_DoubleClick(object sender, EventArgs e)
        {
            frmVistaBarrioCliente frmVBC = new frmVistaBarrioCliente();
            frmVBC.ShowDialog();
        }
    }
}
