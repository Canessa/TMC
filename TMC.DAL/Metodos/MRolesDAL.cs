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
    public class MRolesDAL : PrincipalBD, IRolesDAL
    {
        
        public void Actualizar(TbRoles rol)
        {
            try
            {
                client.UpdateAsync("TbRoles/" + rol.IDRol, rol);
            }
            catch { };
        }

        public TbRoles Buscar(int idRol)
        {
            var response = client.Get("TbRoles/" + idRol);
            TbRoles valor = JsonConvert.DeserializeObject<TbRoles>(response.Body);
            return valor;
        }
        

        public  void Eliminar(int idRol)
        {
            try
            {
               client.DeleteAsync("TbRoles/" + idRol);
            }
            catch { };
        }

        public  void Insertar(TbRoles rol)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    rol.IDRol = lista[lista.Count() - 1].IDRol + 1;
                }
                else
                {
                    rol.IDRol = 1;
                };
                client.SetAsync("TbRoles/" + rol.IDRol, rol);

            }
            catch
            {

            }
        }

        public List<TbRoles> Mostrar()
        {
            var response = client.Get("TbRoles");
            TbRoles[] tabla = JsonConvert.DeserializeObject<TbRoles[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbRoles>();
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
