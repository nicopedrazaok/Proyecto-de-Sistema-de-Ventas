using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DProvincia
    {
        private int idProvincia;
        private string provincia;
        private string textoBuscar;

        public DProvincia(int idProvincia, string provincia, string textoBuscar)
        {
            this.idProvincia = idProvincia;
            this.provincia = provincia;
            this.textoBuscar = textoBuscar;
        }
        public DProvincia()
        {
            this.idProvincia = 0;
            this.provincia = "";
            this.textoBuscar = "";
        }

        public int IdProvincia { get => idProvincia; set => idProvincia = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string TextoBuscar { get => textoBuscar; set => textoBuscar = value; }
        public string Insertar(DProvincia Provincia)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_provincia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProvincia = new SqlParameter();
                ParIdProvincia.ParameterName = "@IdProvincia";
                ParIdProvincia.SqlDbType = SqlDbType.Int;
                ParIdProvincia.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdProvincia);

                SqlParameter ParProvincia = new SqlParameter();
                ParProvincia.ParameterName = "@Provincia";
                ParProvincia.SqlDbType = SqlDbType.VarChar;
                ParProvincia.Size = 150;
                ParProvincia.Value = Provincia.Provincia;
                SqlCmd.Parameters.Add(ParProvincia);


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
        public string Editar(DProvincia Provincia)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_provincia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProvincia = new SqlParameter();
                ParIdProvincia.ParameterName = "@IdProvincia";
                ParIdProvincia.SqlDbType = SqlDbType.Int;
                ParIdProvincia.Value = Provincia.IdProvincia;
                SqlCmd.Parameters.Add(ParIdProvincia);

                SqlParameter ParProvincia = new SqlParameter();
                ParProvincia.ParameterName = "@Provincia";
                ParProvincia.SqlDbType = SqlDbType.VarChar;
                ParProvincia.Size = 150;
                ParProvincia.Value = Provincia.Provincia;
                SqlCmd.Parameters.Add(ParProvincia);


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
        public string Eliminar(DProvincia Provincia)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_provincia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProvincia = new SqlParameter();
                ParIdProvincia.ParameterName = "@IdProvincia";
                ParIdProvincia.SqlDbType = SqlDbType.Int;
                ParIdProvincia.Value = Provincia.IdProvincia;
                SqlCmd.Parameters.Add(ParIdProvincia);

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
            DataTable DtResultado = new DataTable("Provincia");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_provincia";
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
        public DataTable BuscarProvincia(DProvincia Provincia)
        {
            DataTable DtResultado = new DataTable("Provincia");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_provincia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Provincia.TextoBuscar;
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
