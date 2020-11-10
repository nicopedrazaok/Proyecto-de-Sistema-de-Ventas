using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NProvincia
    {
        public static string Insertar(string Provincia)
        {
            DProvincia Obj = new DProvincia();
            Obj.Provincia = Provincia;
            return Obj.Insertar(Obj);
        }
        public static string Editar(int IdProvincia, string Provincia)
        {
            DProvincia Obj = new DProvincia();
            Obj.IdProvincia = IdProvincia;
            Obj.Provincia = Provincia;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int IdProvincia)
        {
            DProvincia Obj = new DProvincia();
            Obj.IdProvincia= IdProvincia;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DProvincia().Mostrar();
        }

        public static DataTable BuscarProvincia(string textobuscar)
        {
            DProvincia Obj = new DProvincia();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProvincia(Obj);
        }
    }
}
