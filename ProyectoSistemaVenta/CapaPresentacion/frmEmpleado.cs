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
//using System.Data;

namespace CapaPresentacion
{
    public partial class frmEmpleado : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmEmpleado()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Empleado");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese Los Apellidos del Empleado");
            this.ttMensaje.SetToolTip(this.txtDocumento, "Ingrese el Documento del Empleado");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Empleado");
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
            this.txtIdEmpleado.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCelular.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtContraseña.Text = string.Empty;

        }
        private void Habilitar(bool Valor)
        {
            this.txtIdEmpleado.ReadOnly = !Valor;
            this.txtNombre.ReadOnly = !Valor;
            this.txtApellidos.ReadOnly = !Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.cboSexo.Enabled = Valor;
            this.dtpFechaNacimiento.Enabled = Valor;
            this.cboTipoDocumento.Enabled = Valor;
            this.txtDocumento.Enabled = Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.txtTelefono.ReadOnly = !Valor;
            this.txtCelular.ReadOnly = !Valor;
            this.txtCorreo.ReadOnly = !Valor;
            this.cboTipoUsuario.Enabled = Valor;
            this.txtUsuario.ReadOnly = !Valor;
            this.txtContraseña.ReadOnly = !Valor;
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
            this.DataListadoEmpleado.Columns[0].Visible = false;
           // this.DataListadoEmpleado.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.DataListadoEmpleado.DataSource = NEmpleado.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(DataListadoEmpleado.Rows.Count);
        }
        private void BuscarApellidos()
        {
            this.DataListadoEmpleado.DataSource = NEmpleado.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(DataListadoEmpleado.Rows.Count);
        }

        private void BuscarDocumento()
        {
            this.DataListadoEmpleado.DataSource = NEmpleado.BuscarDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(DataListadoEmpleado.Rows.Count);
        }
        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (cboBuscar.Text.Equals("Documento"))
            {
                this.BuscarDocumento();
            }
        }
        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            DataListadoEmpleado.DataSource = NEmpleado.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(DataListadoEmpleado.Rows.Count);
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

                    foreach (DataGridViewRow row in DataListadoEmpleado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NEmpleado.Eliminar(Convert.ToInt32(Codigo));

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
                this.DataListadoEmpleado.Columns[0].Visible = true;
            }
            else
            {
                this.DataListadoEmpleado.Columns[0].Visible = false;
            }
        }

        private void DataListadoEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataListadoEmpleado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                    (DataGridViewCheckBoxCell)DataListadoEmpleado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void DataListadoEmpleado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdEmpleado.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Id Empleado"].Value);
            this.txtNombre.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Apellidos"].Value);
            this.cboSexo.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Sexo"].Value);
            this.dtpFechaNacimiento.Value = Convert.ToDateTime(this.DataListadoEmpleado.CurrentRow.Cells["Fecha de nacimiento"].Value);
            this.cboTipoDocumento.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Tipo de Documento"].Value);
            this.txtDocumento.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Direccion"].Value);
            this.cboTipoUsuario.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Tipo de usuario"].Value);
            this.txtUsuario.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Usuario"].Value);
            this.txtContraseña.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Contraseña"].Value);
            this.txtTelefono.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Telefono"].Value);
            this.txtCelular.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Celular"].Value);
            this.txtCorreo.Text = Convert.ToString(this.DataListadoEmpleado.CurrentRow.Cells["Correo"].Value);

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
                if (this.txtNombre.Text == string.Empty || this.txtApellidos.Text == string.Empty || txtDocumento.Text == string.Empty || txtUsuario.Text == string.Empty || txtContraseña.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese el nombe");
                    errorIcono.SetError(txtApellidos, "Ingrese el apellido");
                    errorIcono.SetError(txtDocumento, "Ingrese el documento");
                    errorIcono.SetError(txtUsuario, "Ingrese el usuario");
                    errorIcono.SetError(txtContraseña, "Ingrese la contraseña");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        Rpta = NEmpleado.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellidos.Text.Trim().ToUpper(), cboSexo.Text, dtpFechaNacimiento.Value, cboTipoDocumento.Text,
                        txtDocumento.Text, txtDireccion.Text, cboTipoUsuario.Text, txtUsuario.Text, txtContraseña.Text,
                        txtTelefono.Text, txtCelular.Text, txtCorreo.Text);

                    }
                    else
                    {
                        Rpta = NEmpleado.Editar(Convert.ToInt32(this.txtIdEmpleado.Text), this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellidos.Text.Trim().ToUpper(), cboSexo.Text, dtpFechaNacimiento.Value, cboTipoDocumento.Text,
                        txtDocumento.Text, txtDireccion.Text, cboTipoUsuario.Text, txtUsuario.Text, txtContraseña.Text,
                        txtTelefono.Text, txtCelular.Text, txtCorreo.Text ) ;
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
                    this.txtIdEmpleado.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdEmpleado.Text.Equals(""))
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
            this.txtIdEmpleado.Text = string.Empty;
        }
    }
}
