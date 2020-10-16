using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.BLL.Interfaces
{
    public interface ICatalogosBLL
    {
        //Insert del registro en la DB
        void Insertar(TbCatalogos catalogo);
        //Update registro en la DB
        void Actualizar(TbCatalogos catalogo);
        //Elimina un registro de la DB
        int Eliminar(int idCatalogo);
        //Lista con todos los registros
        List<TbCatalogos> Mostrar();
        //Busca un registro especifico
        TbCatalogos Buscar(int idCatalogo);
    }
}
