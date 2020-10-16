using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.BLL.Interfaces
{
    public interface IProgresosBLL
    {
        //Insert del registro en la DB
        void Insertar(TbProgresos progreso);
        //Update registro en la DB
        void Actualizar(TbProgresos progreso);
        //Elimina un registro de la DB
        int Eliminar(int idProgreso);
        //Lista con todos los registros
        List<TbProgresos> Mostrar();
        //Busca un registro especifico
        TbProgresos Buscar(int idProgreso);
    }
}
