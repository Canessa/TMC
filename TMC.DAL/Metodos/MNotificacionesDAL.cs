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
    public class MNotificacionesDAL : PrincipalBD, INotificacionesDAL
    {
        public void Actualizar(TbNotificaciones notificacion)
        {
            try
            {
                client.UpdateAsync("TbNotificaciones/" + notificacion.IDNotificacion, notificacion);
            }
            catch { };
        }

        public TbNotificaciones Buscar(int idNotificacion)
        {
            var response = client.Get("TbNotificaciones/" + idNotificacion);
            TbNotificaciones valor = JsonConvert.DeserializeObject<TbNotificaciones>(response.Body);
            return valor;
        }

        public void Eliminar(int idNotificacion)
        {
            try
            {
                client.DeleteAsync("TbNotificaciones/" + idNotificacion);
            }
            catch { };
        }

        public void Insertar(TbNotificaciones notificacion)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    notificacion.IDNotificacion = lista[lista.Count() - 1].IDNotificacion + 1;
                }
                else
                {
                    notificacion.IDNotificacion = 1;
                };
                client.SetAsync("TbNotificaciones/" + notificacion.IDNotificacion, notificacion);

            }
            catch
            {

            }
        }

        public List<TbNotificaciones> Mostrar()
        {
            var response = client.Get("TbNotificaciones");
            TbNotificaciones[] tabla = JsonConvert.DeserializeObject<TbNotificaciones[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbNotificaciones>();
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
