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
    public class MCitasBLL : MBase, ICitasBLL
    {
        public void Actualizar(TbCitas cita)
        {
            vCitas.Actualizar(cita);
        }

        public TbCitas Buscar(int idCita)
        {
            return vCitas.Buscar(idCita);
        }

        public int Cancelar(int idCita)
        {
            //Validacion de progreso de una cita   
            ICitasBLL cCitas = new MCitasBLL();
            TbCitas cita = cCitas.Buscar(idCita);
            //Este progreso es provisional
            if (cita.IDProgreso > 10)
            {
                return 1;
            }           
            vCitas.Cancelar(idCita);
            return 0;
        }

        public void Insertar(TbCitas cita)
        {
            vCitas.Insertar(cita);
        }

        public List<TbCitas> Mostrar()
        {
            return vCitas.Mostrar();
        }
    }
}
