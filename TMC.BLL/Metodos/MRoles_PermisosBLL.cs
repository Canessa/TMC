using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;
using TMC.DAL;
using TMC.BLL.Interfaces;
using TMC.DAL.Metodos;

namespace TMC.BLL.Metodos
{
    public class MRoles_PermisosBLL : MBase, IRoles_PermisosBLL
    {
        public void Actualizar(TbRoles_TbPermisos rolPermiso)
        {
            vRolesPermisos.Actualizar(rolPermiso);
        }

        public TbRoles_TbPermisos Buscar(int idRolPermiso)
        {
            return vRolesPermisos.Buscar(idRolPermiso);
        }

        public void Desactivar(int idRolPermiso)
        {
            vRolesPermisos.Desactivar(idRolPermiso);
        }

        public void Insertar(TbRoles_TbPermisos rolPermiso)
        {
            vRolesPermisos.Insertar(rolPermiso);
        }

        public List<TbRoles_TbPermisos> Mostrar()
        {
            return vRolesPermisos.Mostrar();
        }
    }
}
