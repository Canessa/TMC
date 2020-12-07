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
using Newtonsoft.Json.Linq;

namespace TMC.DAL.Metodos
{ 
    public class MComprasDAL : PrincipalBD, IComprasDAL
    {
        
        public void Actualizar(TbCompras compra)
        {
            try
            {
                client.UpdateAsync("TbCompras/" + compra.IDCompra, compra);
            }
            catch { };
        }

        public TbCompras Buscar(int idCompra)
        {
            var response = client.Get("TbCompras/" + idCompra);
            TbCompras valor = JsonConvert.DeserializeObject<TbCompras>(response.Body);
            return valor;
        }
        
        public void Eliminar(int idCompra)
        {
            try
            {
                var busqueda = Buscar(idCompra);
                busqueda.activo = false;
                busqueda.estado = "Cancelada" ;
                Actualizar(busqueda);
            }
            catch { };
        }

        public void cancelarServicio(int idUsuario, int idServicio)
        {
            var id = 0;
            var listaServicios = new MServiciosDAL().obtenerServiciosComprados(idUsuario);
            foreach (var servicio in listaServicios)
            {
                if (servicio.IDUsuario == idUsuario && servicio.IDServicio == idServicio)
                {
                    id = servicio.IDCompra;
                    break;
                }
            }
            if (id != 0)
            {
                client.DeleteAsync("TbCompras/" + id);
            } 
        }


        public void Insertar(TbCompras compra)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    compra.IDCompra = lista[lista.Count() - 1].IDCompra + 1;
                }
                else
                {
                    compra.IDCompra = 1;
                };
                client.SetAsync("TbCompras/" + compra.IDCompra, compra);

            }
            catch
            {

            }
        }

        public List<TbCompras> Mostrar()
        {
            var response = client.Get("TbCompras");
            TbCompras[] tabla = JsonConvert.DeserializeObject<TbCompras[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbCompras>();
            foreach (var item in tabla)
            {
                if (item != null)
                {
                    lista.Add(item);
                }
            }

            return lista;
        }

        public List<TbServicios> ObtenerComprasId(int Id)
        {
            List<TbServicios> serviciosContratados = new List<TbServicios>();
            var response = client.Get("TbCompras");
            TbCompras[] servicios = JsonConvert.DeserializeObject<TbCompras[]>(response.Body);
            if (servicios != null){
                foreach (var item in servicios)
                {
                    if (item != null && item.IDUsuario == Id && item.estado != "Cancelada")
                    {
                        serviciosContratados.Add(new MServiciosDAL().Buscar(item.IDServicio));
                    }
                }
            }
            else
            {
               serviciosContratados = null;
            }
            
            return serviciosContratados;
        }
}
}
