using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
        public static string Insertar(int IdEmpleado, int idproveedor, DateTime fecha,
            string tipoComprobante, string serie, string correlativo, decimal iva,
            string estado, DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.IdEmpleado = IdEmpleado;
            Obj.IdProveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.TipoComprobante = tipoComprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Iva = iva;
            Obj.Estado = estado;
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.IdProducto = Convert.ToInt32(row["Id Producto"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["Precio de compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["Precio de venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["Stock inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["Stock inicial"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["Fecha de produccion"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["Fecha de vencimiento"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.IdIngreso = idingreso;
            return Obj.Anular(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
