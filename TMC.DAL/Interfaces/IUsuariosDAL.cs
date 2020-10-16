using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.DAL.Interfaces
{
    public interface IUsuariosDAL
    {
        //Insert del registro en la DB
        void Insertar(TbUsuarios usuario);
        //Update registro en la DB
        void Actualizar(TbUsuarios usuario);
        //Desactivar usuario cambiando estado
        void Desactivar(int idUsuario);
        //Lista con todos los registros
        List<TbUsuarios> Mostrar();
        //Busca un registro especifico
        TbUsuarios Buscar(int idUsuario);

    }
}
