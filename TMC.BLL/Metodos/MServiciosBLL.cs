using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;
using TMC.DAL;
using TMC.BLL.Interfaces;

namespace TMC.BLL.Metodos
{
    public class MServiciosBLL : MBase, IServiciosBLL
    {
        public void Actualizar(TbServicios servicio)
        {
            vServicios.Actualizar(servicio);
        }

        public TbServicios Buscar(int idServicio)
        {
            return vServicios.Buscar(idServicio);
        }

        public void Desactivar(int idServicio)
        {
            vServicios.Desactivar(idServicio);
        }

        public void Insertar(TbServicios servicio)
        {
            vServicios.Insertar(servicio);
        }

        public List<TbServicios> Mostrar()
        {
            return vServicios.Mostrar();
        }
    }
}
