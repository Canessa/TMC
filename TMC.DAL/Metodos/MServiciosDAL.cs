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
                busqueda.estado = false;
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
                    TbCatalogos catalogo = new MCatalogosDAL().Buscar(item.IDCatalogo);
                    item.NombreCatalogo = catalogo.nombre;
                    lista.Add(item);
                }
            }

            return lista;
        }

        public List<TbServicios> obtenerServiciosCliente(Nullable<int> id)
        {
            var lista = new List<TbServicios>();
            if (id != null)
            {
                var response = client.Get("TbUsuarios_TbServicios");
                TbServicios[] tabla = JsonConvert.DeserializeObject<TbServicios[]>(response.Body);
                if (tabla == null) { return null; }
                
                foreach (var item in tabla)
                {
                    //if (item != null && item.)
                    //{
                    //    lista.Add(item);
                    //}
                }
            }
            else
            {
                var response = client.Get("TbUsuarios_TbServicios");
                TbServicios[] tabla = JsonConvert.DeserializeObject<TbServicios[]>(response.Body);
                if (tabla == null) { return null; }
                foreach (var item in tabla)
                {
                    if (item != null)
                    {
                        lista.Add(item);
                    }
                }
            }
            return lista;
        }

        public void Adquirir(int idUsuario, int idServicio)
        {
            TbUsuario_TbServicio usuarioServicio = new TbUsuario_TbServicio();
            try
            {
                var lista = obtenerServiciosCliente(null);
                if (lista != null)
                {
                    usuarioServicio.id = (lista.Count) + 1;
                    usuarioServicio.idUsuario = idUsuario;
                    usuarioServicio.idServicio = idServicio;
                }
                else
                {
                    usuarioServicio.id = 1;
                    usuarioServicio.idUsuario = idUsuario;
                    usuarioServicio.idServicio = idServicio;
                };
                client.SetAsync("TbUsuarios_TbServicios/" + usuarioServicio.id, usuarioServicio);

            }
            catch
            {

            }
        }
    }
}
