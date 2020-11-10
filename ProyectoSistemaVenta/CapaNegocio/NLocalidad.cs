using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NLocalidad
    {
        public static string Insertar(string Localidad/*, int IdProvincia*/)
        {
            DLocalidad Obj = new DLocalidad();
            Obj.Localidad = Localidad;
            //Obj.IdProvincia = IdProvincia;
            return Obj.Insertar(Obj);
        }
        public static string Editar(int IdLocalidad, string Localidad/*, int IdProvincia*/)
        {
            DLocalidad Obj = new DLocalidad();
            Obj.IdLocalidad = IdLocalidad;
            Obj.Localidad = Localidad;
            //Obj.IdProvincia = IdProvincia;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int IdLocalidad)
        {
            DLocalidad Obj = new DLocalidad();
            Obj.IdLocalidad = IdLocalidad;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DLocalidad().Mostrar();
        }

        public static DataTable BuscarLocalidad(string textobuscar)
        {
            DLocalidad Obj = new DLocalidad();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarLocalidad(Obj);
        }
    }
}
