using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.DAL.Interfaces
{
    public interface ITestimoniosDAL
    {
        //Insert del registro en la DB
        void Insertar(TbTestimonios testimonio);
        //Update registro en la DB
        void Actualizar(TbTestimonios testimonio);
        //Cancela una cita
        void Eliminar(int idTestimonio);
        //Lista con todos los registros
        List<TbTestimonios> Mostrar();
        //Busca un registro especifico
        TbTestimonios Buscar(int idTestimonio);
    }
}
