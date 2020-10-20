using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TMC.BLL.Metodos
{
    public class MBase
    {
        public TMC.DAL.Interfaces.IUsuariosDAL vUsuarios;
        public TMC.DAL.Interfaces.IServiciosDAL vServicios;
        public TMC.DAL.Interfaces.IRolesDAL vRoles;
        public TMC.DAL.Interfaces.IRoles_PermisosDAL vRolesPermisos;
        public TMC.DAL.Interfaces.IProgresosDAL vProgresos;
        public TMC.DAL.Interfaces.IPermisosDAL vPermisos;
        public TMC.DAL.Interfaces.IFotosDAL vFotos;
        public TMC.DAL.Interfaces.IComprasDAL vCompras;
        public TMC.DAL.Interfaces.ICitasDAL vCitas;
        public TMC.DAL.Interfaces.ICatalogosDAL vCatalogos;
        public TMC.DAL.Interfaces.ICatalogos_FotosDAL vCatalogosFotos;
        public TMC.DAL.Interfaces.IOcupacionesDAL vOcupaciones;
        public TMC.DAL.Interfaces.IEmpleadosDAL vEmpleados;
        public TMC.DAL.Interfaces.INotificacionesDAL vNotificaciones;

        public static string Llave = "jskruwiqhendmsud";



        public MBase()
        {
            vUsuarios = new TMC.DAL.Metodos.MUsuariosDAL();
            vServicios = new TMC.DAL.Metodos.MServiciosDAL();
            vRoles = new TMC.DAL.Metodos.MRolesDAL();
            vRolesPermisos = new TMC.DAL.Metodos.MRoles_PermisosDAL();
            vProgresos = new TMC.DAL.Metodos.MProgresosDAL();
            vPermisos = new TMC.DAL.Metodos.MPermisosDAL();
            vFotos = new TMC.DAL.Metodos.MFotosDAL();
            vCompras = new TMC.DAL.Metodos.MComprasDAL();
            vCitas = new TMC.DAL.Metodos.MCitasDAL();
            vCatalogos = new TMC.DAL.Metodos.MCatalogosDAL();
            vCatalogosFotos = new TMC.DAL.Metodos.MCatalogos_FotosDAL();
            vOcupaciones = new TMC.DAL.Metodos.MOcupacionesDAL();
            vEmpleados = new TMC.DAL.Metodos.MEmpleadosDAL();
            vNotificaciones = new TMC.DAL.Metodos.MNotificacionesDAL();
        }

        public static string Decriptar(string contra)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(Llave);
            byte[] encriptar = Convert.FromBase64String(contra);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultado = cTransform.TransformFinalBlock
                (encriptar, 0, encriptar.Length);
            return Encoding.UTF8.GetString(resultado);
        }

        public static string Encriptar(string contra)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(Llave);
            byte[] encriptar = Encoding.UTF8.GetBytes(contra);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultado = cTransform.TransformFinalBlock
                (encriptar, 0, encriptar.Length);
            return Convert.ToBase64String
                (resultado, 0, resultado.Length);
        }
    }
}
