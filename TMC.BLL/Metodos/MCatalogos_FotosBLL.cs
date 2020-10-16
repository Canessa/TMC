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
    public class MCatalogos_FotosBLL : MBase, ICatalogos_FotosBLL
    {
        public void Actualizar(TbCatalogos_TbFotos catalogoFoto)
        {
            vCatalogosFotos.Actualizar(catalogoFoto);
        }

        public TbCatalogos_TbFotos Buscar(int idCatalogoFoto)
        {
            return vCatalogosFotos.Buscar(idCatalogoFoto);
        }

        public void Eliminar(int idCatalogoFoto)
        {
            vCatalogosFotos.Eliminar(idCatalogoFoto);
        }

        public void Insertar(TbCatalogos_TbFotos catalogoFoto)
        {
            vCatalogosFotos.Insertar(catalogoFoto);
        }

        public List<TbCatalogos_TbFotos> Mostrar()
        {
            return vCatalogosFotos.Mostrar();
        }
    }
}
