using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPresentacion
    {
        public static string Insertar(string Nombre, string Descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = Nombre;
            Obj.Descripcion = Descripcion;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int IdPresentacion, string Nombre, string Descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = IdPresentacion;
            Obj.Nombre = Nombre;
            Obj.Descripcion = Descripcion;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int IdPresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = IdPresentacion;
            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }
        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}

