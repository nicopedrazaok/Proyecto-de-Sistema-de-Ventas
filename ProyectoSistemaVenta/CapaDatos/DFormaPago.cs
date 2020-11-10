using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DFormaPago
    {
        private int idFormaPago;
        private string nombre;
        private string detalle;
        private string textoBuscar;

        public DFormaPago(int idFormaPago, string nombre, string detalle, string textoBuscar)
        {
            this.idFormaPago = idFormaPago;
            this.nombre = nombre;
            this.detalle = detalle;
            this.textoBuscar = textoBuscar;
        }
        public DFormaPago()
        {
            this.idFormaPago = 0;
            this.nombre = "";
            this.detalle = "";
            this.textoBuscar = "";
        }

        public int IdFormaPago { get => idFormaPago; set => idFormaPago = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public string TextoBuscar { get => textoBuscar; set => textoBuscar = value; }

        public string Insertar(DFormaPago FormaPago)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_FormaPago";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdFormaPago = new SqlParameter();
                ParIdFormaPago.ParameterName = "@IdFormaPago";
                ParIdFormaPago.SqlDbType = SqlDbType.Int;
                ParIdFormaPago.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdFormaPago);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = FormaPago.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDetalle = new SqlParameter();
                ParDetalle.ParameterName = "@Detalle";
                ParDetalle.SqlDbType = SqlDbType.VarChar;
                ParDetalle.Size = 50;
                ParDetalle.Value = FormaPago.Detalle;
                SqlCmd.Parameters.Add(ParDetalle);


                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        public string Editar(DFormaPago FormaPago)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_FormaPago";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdFormaPago = new SqlParameter();
                ParIdFormaPago.ParameterName = "@IdFormaPago";
                ParIdFormaPago.SqlDbType = SqlDbType.Int;
                ParIdFormaPago.Value = FormaPago.IdFormaPago;
                SqlCmd.Parameters.Add(ParIdFormaPago);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = FormaPago.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDetalle = new SqlParameter();
                ParDetalle.ParameterName = "@Detalle";
                ParDetalle.SqlDbType = SqlDbType.VarChar;
                ParDetalle.Size = 150;
                ParDetalle.Value = FormaPago.Detalle;
                SqlCmd.Parameters.Add(ParDetalle);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        public string Eliminar(DFormaPago FormaPago)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_FormaPago";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdFormaPago = new SqlParameter();
                ParIdFormaPago.ParameterName = "@IdFormaPago";
                ParIdFormaPago.SqlDbType = SqlDbType.Int;
                ParIdFormaPago.Value = FormaPago.IdFormaPago;
                SqlCmd.Parameters.Add(ParIdFormaPago);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("FormaPago");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_FormaPago";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        public DataTable BuscarFormaPago(DFormaPago FormaPago)
        {
            DataTable DtResultado = new DataTable("FormaPago");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_FormaPago";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = FormaPago.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
