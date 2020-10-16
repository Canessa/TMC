using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.BLL.Interfaces
{
    public interface IComprasBLL
    {
        //Insert del registro en la DB
        void Insertar(TbCompras compra);
        //Update registro en la DB
        void Actualizar(TbCompras compra);
        //Elimina un registro de la DB
        void Eliminar(int idCompra);
        //Lista con todos los registros
        List<TbCompras> Mostrar();
        //Busca un registro especifico
        TbCompras Buscar(int idCompra);
    }
}
