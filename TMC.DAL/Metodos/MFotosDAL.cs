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
    public class MFotosDAL : PrincipalBD, IFotosDAL
    {
        
        public void Actualizar(TbFotos foto)
        {
            try
            {
                client.UpdateAsync("TbFotos/" + foto.IDFoto, foto);
            }
            catch { };
        }

        public TbFotos Buscar(int idFoto)
        {
            var response = client.Get("TbFotos/" + idFoto);
            TbFotos valor = JsonConvert.DeserializeObject<TbFotos>(response.Body);
            return valor;
        }
        
        public void Eliminar(int idFoto)
        {
            try
            {
                client.DeleteAsync("TbFotos/" + idFoto);
            }
            catch { };
        }

        public void Insertar(TbFotos foto)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    foto.IDFoto = lista[lista.Count() - 1].IDFoto + 1;
                }
                else
                {
                    foto.IDFoto = 1;
                };
                client.SetAsync("TbFotos/" + foto.IDFoto, foto);

            }
            catch
            {

            }
        }

        public List<TbFotos> Mostrar()
        {
            var response = client.Get("TbFotos");
            TbFotos[] tabla = JsonConvert.DeserializeObject<TbFotos[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbFotos>();
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
