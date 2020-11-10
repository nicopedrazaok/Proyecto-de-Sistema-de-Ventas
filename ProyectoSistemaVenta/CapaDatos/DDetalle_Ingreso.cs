using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        private int iDdetalle_Ingreso;
        private int idIngreso;
        private int idProducto;
        private decimal precio_Compra;
        private decimal precio_Venta;
        private int stock_Inicial;
        private int stock_Actual;
        private DateTime fecha_Produccion;
        private DateTime fecha_Vencimiento;

        public DDetalle_Ingreso(int iDdetalle_Ingreso, int idIngreso, int idProducto, decimal precio_Compra, decimal precio_Venta,
                                 int stock_Inicial, int stock_Actual, DateTime fecha_Produccion, DateTime fecha_Vencimiento)
        {
            this.iDdetalle_Ingreso = iDdetalle_Ingreso;
            this.idIngreso = idIngreso;
            this.idProducto = idProducto;
            this.precio_Compra = precio_Compra;
            this.precio_Venta = precio_Venta;
            this.stock_Inicial = stock_Inicial;
            this.stock_Actual = stock_Actual;
            this.fecha_Produccion = fecha_Produccion;
            this.fecha_Vencimiento = fecha_Vencimiento;
        }
        public DDetalle_Ingreso()
        {
            this.iDdetalle_Ingreso = 0;
            this.idIngreso = 0;
            this.idProducto = 0;
            this.precio_Compra = 0;
            this.precio_Venta = 0;
            this.stock_Inicial = 0;
            this.stock_Actual = 0;
            this.fecha_Produccion = DateTime.Today;
            this.fecha_Vencimiento = DateTime.Today;
        }

        public int IDdetalle_Ingreso { get => iDdetalle_Ingreso; set => iDdetalle_Ingreso = value; }
        public int IdIngreso { get => idIngreso; set => idIngreso = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public decimal Precio_Compra { get => precio_Compra; set => precio_Compra = value; }
        public decimal Precio_Venta { get => precio_Venta; set => precio_Venta = value; }
        public int Stock_Inicial { get => stock_Inicial; set => stock_Inicial = value; }
        public int Stock_Actual { get => stock_Actual; set => stock_Actual = value; }
        public DateTime Fecha_Produccion { get => fecha_Produccion; set => fecha_Produccion = value; }
        public DateTime Fecha_Vencimiento { get => fecha_Vencimiento; set => fecha_Vencimiento = value; }

        public string Insertar(DDetalle_Ingreso Detalle_Ingreso,
           ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Ingreso = new SqlParameter();
                ParIddetalle_Ingreso.ParameterName = "@IdDetalle_Ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@IdIngreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Detalle_Ingreso.IdIngreso;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@IdProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Detalle_Ingreso.IdProducto;
                SqlCmd.Parameters.Add(ParIdProducto);


                SqlParameter ParPrecio_Compra = new SqlParameter();
                ParPrecio_Compra.ParameterName = "@precio_compra";
                ParPrecio_Compra.SqlDbType = SqlDbType.Money;
                ParPrecio_Compra.Value = Detalle_Ingreso.Precio_Compra;
                SqlCmd.Parameters.Add(ParPrecio_Compra);

                SqlParameter ParPrecio_Venta = new SqlParameter();
                ParPrecio_Venta.ParameterName = "@precio_venta";
                ParPrecio_Venta.SqlDbType = SqlDbType.Money;
                ParPrecio_Venta.Value = Detalle_Ingreso.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecio_Venta);


                SqlParameter ParStock_Actual = new SqlParameter();
                ParStock_Actual.ParameterName = "@stock_actual";
                ParStock_Actual.SqlDbType = SqlDbType.Int;
                ParStock_Actual.Value = Detalle_Ingreso.Stock_Actual;
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParStock_Inicial = new SqlParameter();
                ParStock_Inicial.ParameterName = "@stock_inicial";
                ParStock_Inicial.SqlDbType = SqlDbType.Int;
                ParStock_Inicial.Value = Detalle_Ingreso.Stock_Inicial;
                SqlCmd.Parameters.Add(ParStock_Inicial);

                SqlParameter ParFecha_Produccion = new SqlParameter();
                ParFecha_Produccion.ParameterName = "@fecha_produccion";
                ParFecha_Produccion.SqlDbType = SqlDbType.Date;
                ParFecha_Produccion.Value = Detalle_Ingreso.Fecha_Produccion;
                SqlCmd.Parameters.Add(ParFecha_Produccion);

                SqlParameter ParFecha_Vencimiento = new SqlParameter();
                ParFecha_Vencimiento.ParameterName = "@fecha_vencimiento";
                ParFecha_Vencimiento.SqlDbType = SqlDbType.Date;
                ParFecha_Vencimiento.Value = Detalle_Ingreso.Fecha_Vencimiento;
                SqlCmd.Parameters.Add(ParFecha_Vencimiento);

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
