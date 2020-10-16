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
    public class MComprasBLL : MBase, IComprasBLL
    {
        public void Actualizar(TbCompras compra)
        {
            vCompras.Actualizar(compra);
        }

        public TbCompras Buscar(int idCompra)
        {
            return vCompras.Buscar(idCompra);
        }

        public void Eliminar(int idCompra)
        {
            vCompras.Eliminar(idCompra);
        }

        public void Insertar(TbCompras compra)
        {
            vCompras.Insertar(compra);
        }

        public List<TbCompras> Mostrar()
        {
            return vCompras.Mostrar();
        }
    }
}
