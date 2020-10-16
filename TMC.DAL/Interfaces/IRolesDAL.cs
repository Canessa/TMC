using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.DAL.Interfaces
{
    public interface IRolesDAL
    {
        //Insert del registro en la DB
        void Insertar(TbRoles rol);
        //Update registro en la DB
        void Actualizar(TbRoles rol);
        //Elimina un registro de la DB
        void Eliminar(int idRol);
        //Lista con todos los registros
        List<TbRoles> Mostrar();
        //Busca un registro especifico
        TbRoles Buscar(int idRol);
    }
}
