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
    public class MServiciosDAL : PrincipalBD, IServiciosDAL
    {
        
        public  void Actualizar(TbServicios servicio)
        {
            try
            {
                client.UpdateAsync("TbServicios/" + servicio.IDServicio, servicio);
            }
            catch { };
        }

        public TbServicios Buscar(int idServicio)
        {
            var response = client.Get("TbServicios/" + idServicio);
            TbServicios valor = JsonConvert.DeserializeObject<TbServicios>(response.Body);
            return valor;
        }
        
        public void Desactivar(int idServicio)
        {
            try
            {
                
                var busqueda = Buscar(idServicio);
                busqueda.estado = 0;
                Actualizar(busqueda);
            }
            catch { };
        }

        public  void Insertar(TbServicios servicio)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    servicio.IDServicio = lista[lista.Count() - 1].IDServicio + 1;
                }
                else
                {
                    servicio.IDServicio = 1;
                };
                client.SetAsync("TbServicios/" + servicio.IDServicio, servicio);

            }
            catch
            {

            }
        }

        public List<TbServicios> Mostrar()
        {
            var response = client.Get("TbServicios");
            TbServicios[] tabla = JsonConvert.DeserializeObject<TbServicios[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbServicios>();
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
