using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
    }
}
