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

        public List<TbServicios> obtenerServiciosCliente()
        {
            var lista = new List<TbServicios>();
            var listaComprados = new List<TbCompras>();
                var response = client.Get("TbCompras/");
                TbServicios[] tabla = JsonConvert.DeserializeObject<TbServicios[]>(response.Body);
                if (tabla == null) { return null; }
                
                foreach (var item in tabla)
                {
                    if (item != null)
                    {
                        lista.Add(item);
                    }
                }
            return lista;
        }

        public List<TbCompras> obtenerServiciosComprados(int id)
        {
            var listaComprados = new List<TbCompras>();
            var response = client.Get("TbCompras");
            TbCompras[] tabla = { };
            tabla = JsonConvert.DeserializeObject<TbCompras[]>(response.Body);
            if (tabla == null) { return null; }

            foreach (var item in tabla)
            {
                if (item != null && item.IDUsuario == id)
                {
                    listaComprados.Add(item);
                }
            }
            return listaComprados;
        }

        public void Adquirir(int idUsuario, int idServicio)
        {
            TbCompras usuarioServicio = new TbCompras();
            try
            {
                var lista = obtenerServiciosCliente();
                if (lista != null)
                {
                    usuarioServicio.IDCompra = (lista.Count) + 1;
                    usuarioServicio.IDUsuario = idUsuario;
                    usuarioServicio.IDServicio = idServicio;
                    usuarioServicio.NombreServicio = new MServiciosDAL().Buscar(idServicio).nombre;
                    usuarioServicio.precio = new MServiciosDAL().Buscar(idServicio).precio;
                    usuarioServicio.activo = new MServiciosDAL().Buscar(idServicio).estado;
                    usuarioServicio.estado = "pendiente";
                }
                else
                {
                    usuarioServicio.IDCompra= 1;
                    usuarioServicio.IDUsuario = idUsuario;
                    usuarioServicio.IDServicio = idServicio;
                    usuarioServicio.NombreServicio = new MServiciosDAL().Buscar(idServicio).nombre;
                    usuarioServicio.precio = new MServiciosDAL().Buscar(idServicio).precio;
                    usuarioServicio.activo = new MServiciosDAL().Buscar(idServicio).estado;
                    usuarioServicio.estado = "pendiente";
                };
                client.SetAsync("TbCompras/" + usuarioServicio.IDCompra, usuarioServicio);

            }
            catch
            {

            }
        }
    }
}
