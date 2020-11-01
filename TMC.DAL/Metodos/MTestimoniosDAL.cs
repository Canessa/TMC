using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DAL.Interfaces;
using TMC.DATA;

namespace TMC.DAL.Metodos
{
    public class MTestimoniosDAL : PrincipalBD, ITestimoniosDAL
    {
        public void Actualizar(TbTestimonios testimonio)
        {
            try
            {
                client.UpdateAsync("TbTestimonios/" + testimonio.IDTestimonio, testimonio);
            }
            catch { };
        }

        public TbTestimonios Buscar(int idTestimonio)
        {
            var response = client.Get("TbTestimonios/" + idTestimonio);
            TbTestimonios valor = JsonConvert.DeserializeObject<TbTestimonios>(response.Body);
            return valor;
        }

        public void Eliminar(int idTestimonio)
        {
            try
            {
                client.DeleteAsync("TbTestimonios/" + idTestimonio);
            }
            catch { };
        }

        public void Insertar(TbTestimonios testimonio)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    testimonio.IDTestimonio = lista[lista.Count() - 1].IDTestimonio + 1;
                }
                else
                {
                    testimonio.IDTestimonio = 1;
                };
                client.SetAsync("TbTestimonios/" + testimonio.IDTestimonio, testimonio);

            }
            catch
            {

            }
        }

        public List<TbTestimonios> Mostrar()
        {
            var response = client.Get("TbTestimonios");
            TbTestimonios[] tabla = JsonConvert.DeserializeObject<TbTestimonios[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbTestimonios>();
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
