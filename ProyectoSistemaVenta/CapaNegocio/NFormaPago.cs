using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NFormaPago
    {
        public static string Insertar(string Nombre, string Detalle)
        {
            DFormaPago Obj = new DFormaPago();
            Obj.Nombre = Nombre;
            Obj.Detalle = Detalle;
            return Obj.Insertar(Obj);
        }
        public static string Editar(int idFormaPago, string Nombre, string Detalle)
        {
            DFormaPago Obj = new DFormaPago();
            Obj.IdFormaPago = idFormaPago;
            Obj.Nombre = Nombre;
            Obj.Detalle = Detalle;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idFormaPago)
        {
            DFormaPago Obj = new DFormaPago();
            Obj.IdFormaPago = idFormaPago;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DFormaPago().Mostrar();
        }

        public static DataTable BuscarFormaPago(string textobuscar)
        {
            DFormaPago Obj = new DFormaPago();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarFormaPago(Obj);
        }
    }
}
