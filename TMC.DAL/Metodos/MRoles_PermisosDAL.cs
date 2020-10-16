using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;
using System.Data.SqlClient;
using TMC.DAL.Interfaces;
using FireSharp;
using FireSharp.Response;
using Newtonsoft.Json;

namespace TMC.DAL.Metodos
{
    public class MRoles_PermisosDAL : PrincipalBD, IRoles_PermisosDAL
    {
        
        public void Actualizar(TbRoles_TbPermisos rolPermiso)
        {
            try
            {
                client.UpdateAsync("TbRoles_TbPermisos/" + rolPermiso.IDRolPermiso, rolPermiso);
            }
            catch { };
        }

        public TbRoles_TbPermisos Buscar(int idRolPermiso)
        {
            var response = client.Get("TbRoles_TbPermisos/" + idRolPermiso);
            TbRoles_TbPermisos valor = JsonConvert.DeserializeObject<TbRoles_TbPermisos>(response.Body);
            return valor;
        }
        

        public void Desactivar(int idRolPermiso)
        {
            try
            {
                var busqueda= Buscar(idRolPermiso);
                busqueda.estado = 0;
                Actualizar(busqueda);
            }
            catch { };
        }

        public void Insertar(TbRoles_TbPermisos rolPermiso)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    rolPermiso.IDRolPermiso = lista[lista.Count() - 1].IDRolPermiso + 1;
                }
                else
                {
                    rolPermiso.IDRolPermiso = 1;
                };
                client.SetAsync("TbRoles_TbPermisos/" + rolPermiso.IDRolPermiso, rolPermiso);

            }
            catch
            {

            }
        }

        public List<TbRoles_TbPermisos> Mostrar()
        {
            var response = client.Get("TbRoles_TbPermisos");
            TbRoles_TbPermisos[] tabla = JsonConvert.DeserializeObject<TbRoles_TbPermisos[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbRoles_TbPermisos>();
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
