using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;


namespace TMC.DAL.Interfaces
{
    public interface IRoles_PermisosDAL
    {
        //Insert del registro en la DB
        void Insertar(TbRoles_TbPermisos rolPermiso);
        //Update registro en la DB
        void Actualizar(TbRoles_TbPermisos rolPermiso);
        //Desactiva el permiso de un rol
        void Desactivar(int idRolPermiso);
        //Lista con todos los registros
        List<TbRoles_TbPermisos> Mostrar();
        //Busca un registro especifico
        TbRoles_TbPermisos Buscar(int idRolPermiso);
    }
}
