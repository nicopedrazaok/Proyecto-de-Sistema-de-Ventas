using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class NCategoria
   {
     public static string Insertar(string Nombre, string Descripcion)
     {
                DCategoria Obj = new DCategoria();
                Obj.Nombre = Nombre;
                Obj.Descripcion = Descripcion;
                return Obj.Insertar(Obj);
     }
     public static string Editar(int IdCategoria, string Nombre, string Descripcion)
     {
                DCategoria Obj = new DCategoria();
                Obj.IdCategoria = IdCategoria;
                Obj.Nombre = Nombre;
                Obj.Descripcion = Descripcion;
                return Obj.Editar(Obj);
     }

     public static string Eliminar(int IdCategoria)
     {
                DCategoria Obj = new DCategoria();
                Obj.IdCategoria = IdCategoria;
                return Obj.Eliminar(Obj);
     }

     public static DataTable Mostrar()
     {
                return new DCategoria().Mostrar();
     }

     public static DataTable BuscarNombre(string textobuscar)
     {
                DCategoria Obj = new DCategoria();
                Obj.TextoBuscar = textobuscar;
                return Obj.BuscarNombre(Obj);
     }
   }
}
