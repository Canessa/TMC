using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.DAL.Interfaces
{
    public interface IFotosDAL
    {
        //Insert del registro en la DB
        void Insertar(TbFotos foto);
        //Update registro en la DB
        void Actualizar(TbFotos foto);
        //Elimina un registro de la DB
        void Eliminar(int idFoto);
        //Lista con todos los registros
        List<TbFotos> Mostrar();
        //Busca un registro especifico
        TbFotos Buscar(int idFoto);
    }
}
