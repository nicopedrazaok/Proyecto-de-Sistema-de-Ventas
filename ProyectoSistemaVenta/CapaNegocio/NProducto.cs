using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NProducto
    {
        public static string Insertar(string Codigo, string Nombre,
                                    string Descripcion, byte[] Imagen, int IdCategoria,
                                    int IdPresentacion)
        {
            DProducto Obj = new DProducto();
            Obj.Codigo = Codigo;
            Obj.Nombre = Nombre;
            Obj.Descripcion = Descripcion;
            Obj.Imagen = Imagen;
            Obj.IdCategoria = IdCategoria;
            Obj.IdPresentacion = IdPresentacion;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int IdProducto, string Codigo, string Nombre,
                                    string Descripcion, byte[] Imagen, int IdCategoria,
                                    int IdPresentacion)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = IdProducto;
            Obj.Codigo = Codigo;
            Obj.Nombre = Nombre;
            Obj.Descripcion = Descripcion;
            Obj.Imagen = Imagen;
            Obj.IdCategoria = IdCategoria;
            Obj.IdPresentacion = IdPresentacion;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int IdProducto)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = IdProducto;
            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DProducto().Mostrar();
        }
        public static DataTable BuscarNombre(string textobuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
