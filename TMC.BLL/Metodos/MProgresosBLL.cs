using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;
using TMC.DAL;
using TMC.BLL.Interfaces;
using TMC.DAL.Metodos;

namespace TMC.BLL.Metodos
{
    public class MProgresosBLL : MBase, IProgresosBLL
    {
        public void Actualizar(TbProgresos progreso)
        {
            vProgresos.Actualizar(progreso);
        }

        public TbProgresos Buscar(int idProgreso)
        {
            return vProgresos.Buscar(idProgreso);
        }

        public int Eliminar(int idProgreso)
        {
            //Validacion de relaciones con TbCitas
            ICitasBLL cCitas = new MCitasBLL();
            List<TbCitas> listaCitas = cCitas.Mostrar();
            if (listaCitas != null)
            {
                foreach (TbCitas i in listaCitas)
                {
                    if (i.IDProgreso == idProgreso)
                    {
                        return 1;
                    }
                }
            }
            vProgresos.Eliminar(idProgreso);
            return 0;
        }

        public void Insertar(TbProgresos progreso)
        {
            vProgresos.Insertar(progreso);
        }

        public List<TbProgresos> Mostrar()
        {
            return vProgresos.Mostrar();        }
    }
}
