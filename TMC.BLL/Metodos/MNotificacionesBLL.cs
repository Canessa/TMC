using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.BLL.Interfaces;
using TMC.DATA;

namespace TMC.BLL.Metodos
{
    public class MNotificacionesBLL : MBase, INotificacionesBLL
    {
        public void Actualizar(TbNotificaciones notificacion)
        {
            vNotificaciones.Actualizar(notificacion);
        }

        public TbNotificaciones Buscar(int idNotificacion)
        {
            return vNotificaciones.Buscar(idNotificacion);
        }

        public void Eliminar(int idNotificacion)
        {
            vNotificaciones.Eliminar(idNotificacion);
        }

        public void Insertar(TbNotificaciones notificacion)
        {
            vNotificaciones.Insertar(notificacion);
        }

        public List<TbNotificaciones> Mostrar()
        {
            return vNotificaciones.Mostrar();
        }
    }
}
