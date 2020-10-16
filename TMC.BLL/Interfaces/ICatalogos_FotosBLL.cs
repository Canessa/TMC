using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.BLL.Interfaces
{
    public interface ICatalogos_FotosBLL
    {
        //Insert del registro en la DB
        void Insertar(TbCatalogos_TbFotos catalogoFoto);
        //Update registro en la DB
        void Actualizar(TbCatalogos_TbFotos catalogoFoto);
        //eliminar registro en la DB
        void Eliminar(int idCatalogoFoto);
        //Lista con todos los registros
        List<TbCatalogos_TbFotos> Mostrar();
        //Busca un registro especifico
        TbCatalogos_TbFotos Buscar(int idCatalogoFoto);
    }
}
