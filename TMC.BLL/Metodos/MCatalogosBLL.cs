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
    public class MCatalogosBLL : MBase, ICatalogosBLL
    {
        public void Actualizar(TbCatalogos catalogo)
        {
            vCatalogos.Actualizar(catalogo);
        }

        public TbCatalogos Buscar(int idCatalogo)
        {
            return vCatalogos.Buscar(idCatalogo);
        }

        public int Eliminar(int idCatalogo)
        {
            //Validacion de relaciones con TbCatalogos_TbFotos
            ICatalogos_FotosBLL cCatalogosFotos = new MCatalogos_FotosBLL();
            List<TbCatalogos_TbFotos> listaCatalogosFotos = cCatalogosFotos.Mostrar();
            if (listaCatalogosFotos != null)
            {
                foreach (TbCatalogos_TbFotos i in listaCatalogosFotos)
                {
                    if (i.IDCatalogo == idCatalogo)
                    {
                        return 1;
                    }
                }
            }
            //Validacion de relaciones con TbServicios
            IServiciosBLL cServicios = new MServiciosBLL();
            List<TbServicios> listaServicios = cServicios.Mostrar();
            if (listaServicios != null)
            {
                foreach (TbServicios i in listaServicios)
                {
                    if (i.IDCatalogo == idCatalogo)
                    {
                        return 2;
                    }
                }
            }
            vCatalogos.Eliminar(idCatalogo);
            return 0;
        }

        public void Insertar(TbCatalogos catalogo)
        {
            vCatalogos.Insertar(catalogo);
        }

        public List<TbCatalogos> Mostrar()
        {
            return vCatalogos.Mostrar();
        }
    }
}
