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
    public class MFotosBLL : MBase, IFotosBLL
    {
        public void Actualizar(TbFotos foto)
        {
            vFotos.Actualizar(foto);
        }

        public TbFotos Buscar(int idFoto)
        {
            return vFotos.Buscar(idFoto);
        }

        public int Eliminar(int idFoto)
        {
            //Validacion de relaciones con TbCatalogos_TbFotos
            ICatalogos_FotosBLL cCatalogosFotos = new MCatalogos_FotosBLL();
            List<TbCatalogos_TbFotos> listaCatalogosFotos = cCatalogosFotos.Mostrar();
            if (listaCatalogosFotos != null)
            {
                foreach (TbCatalogos_TbFotos i in listaCatalogosFotos)
                {
                    if (i.IDFoto == idFoto)
                    {
                        return 1;
                    }
                }
            }
            vFotos.Eliminar(idFoto);
            return 0;
        }

        public void Insertar(TbFotos foto)
        {
            vFotos.Insertar(foto);
        }

        public List<TbFotos> Mostrar()
        {
            return vFotos.Mostrar();
        }
    }
}
