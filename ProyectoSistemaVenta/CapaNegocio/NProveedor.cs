using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NProveedor
    {
        public static string Insertar(string RazonSocial, string SectorComercial, string Direccion,
                                    string Correo, string Telefono, string Celular, string TipoDocumento, string Documento)
        {
            DProveedor Obj = new DProveedor();
            Obj.RazonSocial = RazonSocial;
            Obj.SectorComercial = SectorComercial;
            Obj.Direccion = Direccion;
            Obj.Correo = Correo;
            Obj.Telefono = Telefono;
            Obj.Celular = Celular;
            Obj.TipoDocumento = TipoDocumento;
            Obj.Documento = Documento;

            return Obj.Insertar(Obj);
        }
        public static string Editar(int IdProveedor, string RazonSocial, string SectorComercial, string Direccion,
                                    string Correo, string Telefono, string Celular,string TipoDocumento, string Documento)
        {
            DProveedor Obj = new DProveedor();
            Obj.IdProveedor = IdProveedor;
            Obj.RazonSocial = RazonSocial;
            Obj.SectorComercial = SectorComercial;
            Obj.Direccion = Direccion;
            Obj.Correo = Correo;
            Obj.Telefono = Telefono;
            Obj.Celular = Celular;
            Obj.TipoDocumento = TipoDocumento;
            Obj.Documento = Documento;
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int IdProveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.IdProveedor = IdProveedor;
            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }
        public static DataTable BuscarProveedor(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProveedor(Obj);
        }
      
    }
}
