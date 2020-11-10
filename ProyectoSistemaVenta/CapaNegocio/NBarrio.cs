using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NBarrio
    {
        public static string Insertar(string Barrio, int IdLocalidad)
        {
            DBarrio Obj = new DBarrio();
            Obj.Barrio = Barrio;
            Obj.IdLocalidad = IdLocalidad;
            return Obj.Insertar(Obj);
        }
        public static string Editar(int IdBarrio, string Barrio, int IdLocalidad)
        {
            DBarrio Obj = new DBarrio();
            Obj.IdBarrio = IdBarrio;
            Obj.Barrio = Barrio;
            Obj.IdLocalidad = IdLocalidad;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int IdBarrio)
        {
            DBarrio Obj = new DBarrio();
            Obj.IdBarrio = IdBarrio;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DBarrio().Mostrar();
        }

        public static DataTable BuscarBarrio(string textobuscar)
        {
            DBarrio Obj = new DBarrio();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarBarrio(Obj);
        }
    }
}
