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
    public class MCatalogosDAL : PrincipalBD, ICatalogosDAL
    {
        
        public void Actualizar(TbCatalogos catalogo)
        {
            try
            {
                client.UpdateAsync("TbCatalogos/" + catalogo.IDCatalogo, catalogo);
            }
            catch { };
        }

        public TbCatalogos Buscar(int idCatalogo)
        {
            var response = client.Get("TbCatalogos/" + idCatalogo);
            TbCatalogos valor = JsonConvert.DeserializeObject<TbCatalogos>(response.Body);
            return valor;
        }
        
        public  void Eliminar(int idCatalogo)
        {
            try
            {
                client.DeleteAsync("TbCatalogos/" + idCatalogo);
            }
            catch { };
        }

        public void Insertar(TbCatalogos catalogo)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    catalogo.IDCatalogo = lista[lista.Count() - 1].IDCatalogo + 1;
                }
                else
                {
                    catalogo.IDCatalogo = 1;
                };
                client.SetAsync("TbCatalogos/" + catalogo.IDCatalogo, catalogo);

            }
            catch
            {

            }
        }

        public List<TbCatalogos> Mostrar()
        {
            var response = client.Get("TbCatalogos");
            TbCatalogos[] tabla = JsonConvert.DeserializeObject<TbCatalogos[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbCatalogos>();
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
