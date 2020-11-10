using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DLocalidad
    {
        private int idLocalidad;
        private string localidad;
      //  private int idProvincia;
        private string textoBuscar;

        public DLocalidad(int idLocalidad, string localidad, /*int idProvincia*/ string textoBuscar)
        {
            this.idLocalidad = idLocalidad;
            this.localidad = localidad;
            /*this.idProvincia = idProvincia;*/
            this.textoBuscar = textoBuscar;
        }
        public DLocalidad()
        {
            this.idLocalidad = 0;
            this.localidad = "";
          //  this.idProvincia = 0;*/
            this.textoBuscar = "";
        }

        public int IdLocalidad { get => idLocalidad; set => idLocalidad = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        //public int IdProvincia { get => idProvincia; set => idProvincia = value; }
        public string TextoBuscar { get => textoBuscar; set => textoBuscar = value; }

        public string Insertar(DLocalidad Localidad)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_localidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdLocalidad = new SqlParameter();
                ParIdLocalidad.ParameterName = "@IdLocalidad";
                ParIdLocalidad.SqlDbType = SqlDbType.Int;
                ParIdLocalidad.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdLocalidad);

                SqlParameter ParLocalidad = new SqlParameter();
                ParLocalidad.ParameterName = "@Localidad";
                ParLocalidad.SqlDbType = SqlDbType.VarChar;
                ParLocalidad.Size = 150;
                ParLocalidad.Value = Localidad.Localidad;
                SqlCmd.Parameters.Add(ParLocalidad);

                //SqlParameter ParIdProvincia = new SqlParameter();
                //ParIdProvincia.ParameterName = "@IdProvincia";
                //ParIdProvincia.SqlDbType = SqlDbType.Int;
                //ParIdProvincia.Value = Localidad.IdProvincia;
                //SqlCmd.Parameters.Add(ParIdProvincia);


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

        public string Editar(DLocalidad Localidad)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_localidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdLocalidad = new SqlParameter();
                ParIdLocalidad.ParameterName = "@IdLocalidad";
                ParIdLocalidad.SqlDbType = SqlDbType.Int;
                ParIdLocalidad.Value = Localidad.IdLocalidad;
                SqlCmd.Parameters.Add(ParIdLocalidad);

                SqlParameter ParLocalidad = new SqlParameter();
                ParLocalidad.ParameterName = "@Localidad";
                ParLocalidad.SqlDbType = SqlDbType.VarChar;
                ParLocalidad.Size = 150;
                ParLocalidad.Value = Localidad.Localidad;
                SqlCmd.Parameters.Add(ParLocalidad);

                //SqlParameter ParIdProvincia = new SqlParameter();
                //ParIdProvincia.ParameterName = "@IdProvincia";
                //ParIdProvincia.SqlDbType = SqlDbType.Int;
                //ParIdProvincia.Value = Localidad.IdProvincia;
                //SqlCmd.Parameters.Add(ParIdProvincia);

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
        public string Eliminar(DLocalidad Localidad)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_localidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdLocalidad = new SqlParameter();
                ParIdLocalidad.ParameterName = "@IdLocalidad";
                ParIdLocalidad.SqlDbType = SqlDbType.Int;
                ParIdLocalidad.Value = Localidad.IdLocalidad;
                SqlCmd.Parameters.Add(ParIdLocalidad);

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
            DataTable DtResultado = new DataTable("Localidad");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_localidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        public DataTable BuscarLocalidad(DLocalidad Localidad)
        {
            DataTable DtResultado = new DataTable("Localidad");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_localidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Localidad.TextoBuscar;
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
