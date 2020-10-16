using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.BLL.Interfaces
{
    public interface IOcupacionesBLL
    {
        //Insert del registro en la DB
        void Insertar(TbOcupaciones ocupacion);
        //Update registro en la DB
        void Actualizar(TbOcupaciones ocupacion);
        //da de baja un servicio
        int Eliminar(int idOcupacion);
        //Lista con todos los registros
        List<TbOcupaciones> Mostrar();
        //Busca un registro especifico
        TbOcupaciones Buscar(int idOcupacion);
    }
}
