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
    public class MPermisosDAL : PrincipalBD, IPermisosDAL
    {
        
        public void Actualizar(TbPermisos permiso)
        {
            try
            {
                 client.UpdateAsync("TbPermisos/" + permiso.IDPermiso, permiso);
            }
            catch { };
        }

        public TbPermisos Buscar(int idPermiso)
        {
            var response = client.Get("TbPermisos/" + idPermiso);
            TbPermisos valor = JsonConvert.DeserializeObject<TbPermisos>(response.Body);
            return valor;
        }

       
        public void Eliminar(int idPermiso)
        {
            try
            {
                client.DeleteAsync("TbPermisos/" + idPermiso);
            }
            catch { };
        }

        public void Insertar(TbPermisos permiso)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    permiso.IDPermiso=lista[lista.Count() - 1].IDPermiso+1;
                }
                else
                {
                    permiso.IDPermiso = 1;
                };
                client.SetAsync("TbPermisos/" + permiso.IDPermiso, permiso);

            }
            catch { }
        }



        public List<TbPermisos> Mostrar()
        {
            var response = client.Get("TbPermisos");
            TbPermisos[] tabla = JsonConvert.DeserializeObject<TbPermisos[]>(response.Body);
            if(tabla == null) { return null; }
            var lista = new List<TbPermisos>();
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
