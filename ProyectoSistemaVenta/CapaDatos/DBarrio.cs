using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DBarrio
    {
        private int idBarrio;
        private string barrio;
        private int idLocalidad;
        private string textoBuscar;

        public DBarrio(int idBarrio, string barrio, int idLocalidad, string textoBuscar)
        {
            this.idBarrio = idBarrio;
            this.barrio = barrio;
            this.idLocalidad = idLocalidad;
            this.textoBuscar = textoBuscar;
        }
        public DBarrio()
        {
            this.idBarrio = 0;
            this.barrio = "";
            this.idLocalidad = 0;
            this.textoBuscar = "";
        }

        public int IdBarrio { get => idBarrio; set => idBarrio = value; }
        public string Barrio { get => barrio; set => barrio = value; }
        public int IdLocalidad { get => idLocalidad; set => idLocalidad = value; }
        public string TextoBuscar { get => textoBuscar; set => textoBuscar = value; }

        public string Insertar(DBarrio Barrio)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_barrio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdBarrio = new SqlParameter();
                ParIdBarrio.ParameterName = "@IdBarrio";
                ParIdBarrio.SqlDbType = SqlDbType.Int;
                ParIdBarrio.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdBarrio);

                SqlParameter ParBarrio = new SqlParameter();
                ParBarrio.ParameterName = "@Barrio";
                ParBarrio.SqlDbType = SqlDbType.VarChar;
                ParBarrio.Size = 250;
                ParBarrio.Value = Barrio.Barrio;
                SqlCmd.Parameters.Add(ParBarrio);

                SqlParameter ParIdLocalidad = new SqlParameter();
                ParIdLocalidad.ParameterName = "@IdLocalidad";
                ParIdLocalidad.SqlDbType = SqlDbType.Int;
                ParIdLocalidad.Value = Barrio.IdLocalidad;
                SqlCmd.Parameters.Add(ParIdLocalidad);


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

        public string Editar(DBarrio Barrio)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_barrio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdBarrio = new SqlParameter();
                ParIdBarrio.ParameterName = "@IdBarrio";
                ParIdBarrio.SqlDbType = SqlDbType.Int;
                ParIdBarrio.Value = Barrio.IdBarrio;
                SqlCmd.Parameters.Add(ParIdBarrio);

                SqlParameter ParBarrio = new SqlParameter();
                ParBarrio.ParameterName = "@Barrio";
                ParBarrio.SqlDbType = SqlDbType.VarChar;
                ParBarrio.Size = 250;
                ParBarrio.Value = Barrio.Barrio;
                SqlCmd.Parameters.Add(ParBarrio);

                SqlParameter ParIdLocalidad = new SqlParameter();
                ParIdLocalidad.ParameterName = "@IdLocalidad";
                ParIdLocalidad.SqlDbType = SqlDbType.Int;
                ParIdLocalidad.Value = Barrio.IdLocalidad;
                SqlCmd.Parameters.Add(ParIdLocalidad);


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
        public string Eliminar(DBarrio Barrio)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_barrio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdBarrio = new SqlParameter();
                ParIdBarrio.ParameterName = "@IdBarrio";
                ParIdBarrio.SqlDbType = SqlDbType.Int;
                ParIdBarrio.Value = Barrio.IdBarrio;
                SqlCmd.Parameters.Add(ParIdBarrio);

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
            DataTable DtResultado = new DataTable("Barrio");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_barrio";
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
        public DataTable BuscarBarrio(DBarrio Barrio)
        {
            DataTable DtResultado = new DataTable("Barrio");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = AccesoDatos.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_barrio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Barrio.TextoBuscar;
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
