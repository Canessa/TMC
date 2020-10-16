using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.BLL.Interfaces;
using TMC.DATA;

namespace TMC.BLL.Metodos
{
    public class MEmpleadosBLL : MBase, IEmpleadosBLL
    {
        public void Actualizar(TbEmpleados empleado)
        {
            vEmpleados.Actualizar(empleado);
        }

        public TbEmpleados Buscar(int idEmpleado)
        {
            return vEmpleados.Buscar(idEmpleado);
        }

        public int Eliminar(int idEmpleado)
        {
            //Validacion de relaciones con TbEmpleados
            INotificacionesBLL cNotificaciones = new MNotificacionesBLL();
            List<TbNotificaciones> listaNotificaciones = cNotificaciones.Mostrar();
            if (listaNotificaciones != null)
            {
                foreach (TbNotificaciones i in listaNotificaciones)
                {
                    if (i.IDEmpleado == idEmpleado)
                    {
                        return 1;
                    }
                }
            }
            vEmpleados.Eliminar(idEmpleado);
            return 0;
        }

        public void Insertar(TbEmpleados empleado)
        {
            vEmpleados.Insertar(empleado);
        }

        public List<TbEmpleados> Mostrar()
        {
            return vEmpleados.Mostrar();
        }
    }
}
