using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;
using TMC.DAL.Interfaces;
using FireSharp;
using FireSharp.Response;
using Newtonsoft.Json;

namespace TMC.DAL.Metodos
{
    public class MCatalogos_FotosDAL : PrincipalBD, ICatalogos_FotosDAL
    {
       
        public void Actualizar(TbCatalogos_TbFotos catalogoFoto)
        {
            try
            {
                client.UpdateAsync("TbCatalogos_TbFotos/" + catalogoFoto.IDCatalogoFoto, catalogoFoto);
            }
            catch { };
        }

        public TbCatalogos_TbFotos Buscar(int idCatalogoFoto)
        {
            var response = client.Get("TbCatalogos_TbFotos/" + idCatalogoFoto);
            TbCatalogos_TbFotos valor = JsonConvert.DeserializeObject<TbCatalogos_TbFotos>(response.Body);
            return valor;
        }
        

        public void Eliminar(int idCatalogoFoto)
        {
            try
            {
                client.DeleteAsync("TbCatalogos_TbFotos/" + idCatalogoFoto);
            }
            catch { };
        }

        public void Insertar(TbCatalogos_TbFotos catalogoFoto)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    catalogoFoto.IDCatalogoFoto = lista[lista.Count() - 1].IDCatalogoFoto + 1;
                }
                else
                {
                    catalogoFoto.IDCatalogoFoto = 1;
                };
                client.SetAsync("TbCatalogos_TbFotos/" + catalogoFoto.IDCatalogoFoto, catalogoFoto);

            }
            catch
            {

            }
        }

        public List<TbCatalogos_TbFotos> Mostrar()
        {
            var response = client.Get("TbCatalogos_TbFotos");
            TbCatalogos_TbFotos[] tabla = JsonConvert.DeserializeObject<TbCatalogos_TbFotos[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbCatalogos_TbFotos>();
            foreach (var item in tabla)
            {
                if (item != null)
                {
                    lista.Add(item);
                }
            }

            return lista;
        }
        
    }
}
