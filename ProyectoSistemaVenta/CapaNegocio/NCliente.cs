using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCliente
    {
        public static string Insertar(string Nombre, string Apellido, string Sexo,
            DateTime FechaNacimiento, string TipoDocumento, string Documento, string Direccion,
            int IdBarrio,  string CodigoPostal, string Telefono, string Celular, string Correo)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = Nombre;
            Obj.Apellido = Apellido;
            Obj.Sexo = Sexo;
            Obj.FechaNacimiento = FechaNacimiento;
            Obj.TipoDocumento = TipoDocumento;
            Obj.Documento = Documento;
            Obj.Direccion = Direccion;
            Obj.IdBarrio = IdBarrio;
            Obj.CodigoPostal = CodigoPostal;
            Obj.Telefono = Telefono;
            Obj.Celular = Celular;
            Obj.Correo = Correo;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int IdCliente, string Nombre, string Apellido, string Sexo,
            DateTime FechaNacimiento, string TipoDocumento, string Documento, string Direccion,
            int IdBarrio, string CodigoPostal, string Telefono, string Celular, string Correo)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = IdCliente;
            Obj.Nombre = Nombre;
            Obj.Apellido = Apellido;
            Obj.Sexo = Sexo;
            Obj.FechaNacimiento = FechaNacimiento;
            Obj.TipoDocumento = TipoDocumento;
            Obj.Documento = Documento;
            Obj.Direccion = Direccion;
            Obj.IdBarrio = IdBarrio;
            Obj.CodigoPostal = CodigoPostal;
            Obj.Telefono = Telefono;
            Obj.Celular = Celular;
            Obj.Correo = Correo;
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int IdCliente)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = IdCliente;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        public static DataTable BuscarCliente(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCliente(Obj);
        }

      
    }
}
