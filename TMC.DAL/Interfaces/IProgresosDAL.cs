using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.DAL.Interfaces
{
    public interface IProgresosDAL
    {
        //Insert del registro en la DB
        void Insertar(TbProgresos progreso);
        //Update registro en la DB
        void Actualizar(TbProgresos progreso);
        //Elimina un registro de la DB
        void Eliminar(int idProgreso);
        //Lista con todos los registros
        List<TbProgresos> Mostrar();
        //Busca un registro especifico
        TbProgresos Buscar(int idProgreso);
    }
}
