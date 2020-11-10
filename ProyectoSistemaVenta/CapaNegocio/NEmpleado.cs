using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NEmpleado
    {
        public static string Insertar(string Nombre, string Apellidos, string Sexo,
            DateTime FechaNacimiento, string TipoDocumento, string Documento, string Direccion,
            string TipoUsuario, string Usuario, string Contraseña, string Telefono, string Celular, string Correo)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Nombre = Nombre;
            Obj.Apellidos = Apellidos;
            Obj.Sexo = Sexo;
            Obj.FechaNacimiento = FechaNacimiento;
            Obj.TipoDocumento = TipoDocumento;
            Obj.Documento = Documento;
            Obj.Direccion = Direccion;
            Obj.TipoUsuario = TipoUsuario;
            Obj.Usuario = Usuario;
            Obj.Contraseña = Contraseña;
            Obj.Telefono = Telefono;
            Obj.Celular = Celular;
            Obj.Correo = Correo;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int IdEmpleado, string Nombre, string Apellidos, string Sexo,
            DateTime FechaNacimiento,string TipoDocumento, string Documento, string Direccion,
            string TipoUsuario, string Usuario, string Contraseña, string Telefono, string Celular, string Correo  )
        {
            DEmpleado Obj = new DEmpleado();
            Obj.IdEmpleado = IdEmpleado;
            Obj.Nombre = Nombre;
            Obj.Apellidos = Apellidos;
            Obj.Sexo = Sexo;
            Obj.FechaNacimiento = FechaNacimiento;
            Obj.TipoDocumento = TipoDocumento;
            Obj.Documento = Documento;
            Obj.Direccion = Direccion;
            Obj.TipoUsuario = TipoUsuario;
            Obj.Usuario = Usuario;
            Obj.Contraseña = Contraseña;
            Obj.Telefono = Telefono;
            Obj.Celular= Celular;
            Obj.Correo = Correo;
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int IdEmpleado)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.IdEmpleado = IdEmpleado;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DEmpleado().Mostrar();
        }

        public static DataTable BuscarApellidos(string textobuscar)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);
        }

        public static DataTable BuscarDocumento(string textobuscar)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarDocumento(Obj);
        }

        public static DataTable Login(string Usuario, string Contraseña)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Usuario = Usuario;
            Obj.Contraseña = Contraseña;
            return Obj.Login(Obj);
        }
    }
}
