using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.BLL.Interfaces
{
    public interface INotificacionesBLL
    {
        //Insert del registro en la DB
        void Insertar(TbNotificaciones notificacion);
        //Update registro en la DB
        void Actualizar(TbNotificaciones notificacion);
        //da de baja un servicio
        void Eliminar(int idNotificacion);
        //Lista con todos los registros
        List<TbNotificaciones> Mostrar();
        //Busca un registro especifico
        TbNotificaciones Buscar(int idNotificacion);
    }
}
