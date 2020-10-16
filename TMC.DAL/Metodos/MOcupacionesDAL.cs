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
    public class MOcupacionesDAL : PrincipalBD, IOcupacionesDAL
    {
        public void Actualizar(TbOcupaciones ocupacion)
        {
            try
            {
                client.UpdateAsync("TbOcupaciones/" + ocupacion.IDOcupacion, ocupacion);
            }
            catch { };
        }

        public TbOcupaciones Buscar(int idOcupacion)
        {
            var response = client.Get("TbOcupaciones/" + idOcupacion);
            TbOcupaciones valor = JsonConvert.DeserializeObject<TbOcupaciones>(response.Body);
            return valor;
        }

        public void Eliminar(int idOcupacion)
        {
            try
            {
                client.DeleteAsync("TbOcupaciones/" + idOcupacion);
            }
            catch { };
        }

        public void Insertar(TbOcupaciones ocupacion)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    ocupacion.IDOcupacion = lista[lista.Count() - 1].IDOcupacion + 1;
                }
                else
                {
                    ocupacion.IDOcupacion = 1;
                };
                client.SetAsync("TbOcupaciones/" + ocupacion.IDOcupacion, ocupacion);

            }
            catch
            {

            }
        }

        public List<TbOcupaciones> Mostrar()
        {
            var response = client.Get("TbOcupaciones");
            TbOcupaciones[] tabla = JsonConvert.DeserializeObject<TbOcupaciones[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbOcupaciones>();
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
