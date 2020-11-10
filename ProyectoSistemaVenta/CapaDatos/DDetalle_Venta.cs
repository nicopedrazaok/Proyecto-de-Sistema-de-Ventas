using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DDetalle_Venta
    {
        private int idDetalle_Venta;
        private int idVenta;
        private int idDetalle_Ingreso;
        private int cantidad;
        private decimal precioVenta;
        private decimal descuento;

        public DDetalle_Venta(int idDetalle_Venta, int idVenta, int idDetalle_Ingreso,
              int cantidad, decimal precioVenta, decimal descuento)
        {
            this.idDetalle_Venta = idDetalle_Venta;
            this.idVenta = idVenta;
            this.idDetalle_Ingreso = idDetalle_Ingreso;
            this.cantidad = cantidad;
            this.precioVenta = precioVenta;
            this.descuento = descuento;
        }
        public DDetalle_Venta()
        {
            this.idDetalle_Venta = 0;
            this.idVenta = 0;
            this.idDetalle_Ingreso = 0;
         
            this.cantidad = 0;
            this.precioVenta = 0;
            this.descuento = 0;
        }
        public int IdDetalle_Venta { get => idDetalle_Venta; set => idDetalle_Venta = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }
        public int IdDetalle_Ingreso { get => idDetalle_Ingreso; set => idDetalle_Ingreso = value; }
        
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }

        public string Insertar(DDetalle_Venta Detalle_Venta,
           ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Venta = new SqlParameter();
                ParIddetalle_Venta.ParameterName = "@IdDetalle_Venta";
                ParIddetalle_Venta.SqlDbType = SqlDbType.Int;
                ParIddetalle_Venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_Venta);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@IdVenta";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Detalle_Venta.IdVenta;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@IdDetalle_Ingreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Value = Detalle_Venta.IdDetalle_Ingreso;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_Venta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@Precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = Detalle_Venta.PrecioVenta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@Descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = Detalle_Venta.Descuento;
                SqlCmd.Parameters.Add(ParDescuento);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }
    }
}
