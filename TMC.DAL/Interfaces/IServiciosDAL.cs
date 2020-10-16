using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.DAL.Interfaces
{
    public interface IServiciosDAL
    {
        //Insert del registro en la DB
        void Insertar(TbServicios servicio);
        //Update registro en la DB
        void Actualizar(TbServicios servicio);
        //da de baja un servicio
        void Desactivar(int idServicio);
        //Lista con todos los registros
        List<TbServicios> Mostrar();
        //Busca un registro especifico
        TbServicios Buscar(int idServicio);
    }
}
