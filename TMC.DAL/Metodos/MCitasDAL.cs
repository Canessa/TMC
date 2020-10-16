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
    public class MCitasDAL : PrincipalBD, ICitasDAL
    {
        
        public  void Actualizar(TbCitas cita)
        {
            try
            {
                client.UpdateAsync("TbCitas/" + cita.IDCita, cita);
            }
            catch { };
        }

        public TbCitas Buscar(int idCita)
        {
            var response = client.Get("TbCitas/" + idCita);
            TbCitas valor = JsonConvert.DeserializeObject<TbCitas>(response.Body);
            return valor;
        }
        
        public  void Cancelar(int idCita)
        {
            try
            {
                client.DeleteAsync("TbCitas/" + idCita);
            }
            catch { };
        }

        public void Insertar(TbCitas cita)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    cita.IDCita = lista[lista.Count() - 1].IDCita + 1;
                }
                else
                {
                    cita.IDCita = 1;
                };
                client.SetAsync("TbCitas/" + cita.IDCita, cita);

            }
            catch
            {

            }
        }

        public List<TbCitas> Mostrar()
        {
            var response = client.Get("TbCitas");
            TbCitas[] tabla = JsonConvert.DeserializeObject<TbCitas[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbCitas>();
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
