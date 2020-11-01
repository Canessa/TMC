using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.BLL.Interfaces;
using TMC.DATA;

namespace TMC.BLL.Metodos
{
    public class MTestimoniosBLL : MBase, ITestimoniosBLL
    {
        public void Actualizar(TbTestimonios testimonio)
        {
            vTestimonios.Actualizar(testimonio);
        }

        public TbTestimonios Buscar(int idTestimonio)
        {
            return vTestimonios.Buscar(idTestimonio);
        }

        public void Eliminar(int idTestimonio)
        {
            vTestimonios.Eliminar(idTestimonio);
        }

        public void Insertar(TbTestimonios testimonio)
        {
            vTestimonios.Insertar(testimonio);
        }

        public List<TbTestimonios> Mostrar()
        {
            return vTestimonios.Mostrar();
        }
    }
}
