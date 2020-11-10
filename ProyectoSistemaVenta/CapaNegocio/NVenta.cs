using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NVenta
    {
        public static string Insertar(int idcliente, int idEmpleado, DateTime fecha,
           string tipoComprobante, string serie, string correlativo, decimal iva,int idFormaPago,
           DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();
            Obj.IdCliente = idcliente;
            Obj.IdEmpleado = idEmpleado;
            Obj.Fecha = fecha;
            Obj.TipoComprobante = tipoComprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Iva = iva;
            Obj.IdFormaPago = idFormaPago;
            List<DDetalle_Venta> detalles = new List<DDetalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Venta detalle = new DDetalle_Venta();
                detalle.IdDetalle_Ingreso = Convert.ToInt32(row["Id DetalleIngreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["Precio de venta"].ToString());
               
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        public static string Eliminar(int idventa)
        {
            DVenta Obj = new DVenta();
            Obj.Idventa = idventa;
            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(textobuscar);
        }
        public static DataTable MostrarProducto_Venta_Nombre(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarProducto_Venta_Nombre(textobuscar);
        }
        public static DataTable MostrarProducto_Venta_Codigo(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarProducto_Venta_codigo(textobuscar);
        }
    }
}
