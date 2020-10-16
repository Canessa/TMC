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
    public class MProgresosDAL : PrincipalBD, IProgresosDAL
    {
        
        public void Actualizar(TbProgresos progreso)
        {
            try
            {
                client.UpdateAsync("TbProgresos/" + progreso.IDProgreso, progreso);
            }
            catch { };
        }

        public TbProgresos Buscar(int idProgreso)
        {
            var response = client.Get("TbProgresos/" + idProgreso);
            TbProgresos valor = JsonConvert.DeserializeObject<TbProgresos>(response.Body);
            return valor;
        }
        

        public void Eliminar(int idProgreso)
        {
            try
            {
                client.DeleteAsync("TbProgresos/" + idProgreso);
            }
            catch { };
        }

        public void Insertar(TbProgresos progreso)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    progreso.IDProgreso = lista[lista.Count() - 1].IDProgreso + 1;
                }
                else
                {
                    progreso.IDProgreso = 1;
                };
                client.SetAsync("TbProgresos/" + progreso.IDProgreso, progreso);

            }
            catch
            {

            }
        }

        public List<TbProgresos> Mostrar()
        {
            var response = client.Get("TbProgresos");
            TbProgresos[] tabla = JsonConvert.DeserializeObject<TbProgresos[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbProgresos>();
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
