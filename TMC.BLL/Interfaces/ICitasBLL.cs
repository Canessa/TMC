using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.BLL.Interfaces
{
    public interface ICitasBLL
    {
        //Insert del registro en la DB
        void Insertar(TbCitas cita);
        //Update registro en la DB
        void Actualizar(TbCitas cita);
        //Cancela una cita
        int Cancelar(int idCita);
        //Lista con todos los registros
        List<TbCitas> Mostrar();
        //Busca un registro especifico
        TbCitas Buscar(int idCita);
    }
}
