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
    public class MEmpleadosDAL : PrincipalBD, IEmpleadosDAL
    {
        public void Actualizar(TbEmpleados empleado)
        {
            try
            {
                client.UpdateAsync("TbEmpleados/" + empleado.IDEmpleado, empleado);
            }
            catch { };
        }

        public TbEmpleados Buscar(int idEmpleado)
        {
            var response = client.Get("TbEmpleados/" + idEmpleado);
            TbEmpleados valor = JsonConvert.DeserializeObject<TbEmpleados>(response.Body);
            return valor;
        }

        public void Eliminar(int idEmpleado)
        {
            try
            {
                client.DeleteAsync("TbEmpleados/" + idEmpleado);
            }
            catch { };
        }

        public void Insertar(TbEmpleados empleado)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    empleado.IDEmpleado = lista[lista.Count() - 1].IDEmpleado + 1;
                }
                else
                {
                    empleado.IDEmpleado = 1;
                };
                client.SetAsync("TbEmpleados/" + empleado.IDEmpleado, empleado);

            }
            catch
            {

            }
        }

        public List<TbEmpleados> Mostrar()
        {
            var response = client.Get("TbEmpleados");
            TbEmpleados[] tabla = JsonConvert.DeserializeObject<TbEmpleados[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbEmpleados>();
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
