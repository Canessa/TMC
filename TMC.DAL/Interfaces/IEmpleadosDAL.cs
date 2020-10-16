using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;


namespace TMC.DAL.Interfaces
{
    public interface IEmpleadosDAL
    {
        //Insert del registro en la DB
        void Insertar(TbEmpleados empleado);
        //Update registro en la DB
        void Actualizar(TbEmpleados empleado);
        //da de baja un servicio
        void Eliminar(int idEmpleado);
        //Lista con todos los registros
        List<TbEmpleados> Mostrar();
        //Busca un registro especifico
        TbEmpleados Buscar(int idEmpleado);
    }
}
