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
    public class MUsuariosDAL : PrincipalBD, IUsuariosDAL
    {
        
        public void Actualizar(TbUsuarios usuario)
        {
            try
            {
                client.UpdateAsync("TbUsuarios/" + usuario.IDUsuario, usuario);
            }
            catch { };
        }

        public TbUsuarios Buscar(int idUsuario)
        {
            var response = client.Get("TbUsuarios/" + idUsuario);
            TbUsuarios valor = JsonConvert.DeserializeObject<TbUsuarios>(response.Body);
            return valor;
        }


        public  void Desactivar(int idUsuario)
        {
            try
            {
                var busqueda = Buscar(idUsuario);
                busqueda.estado = 0;
                Actualizar(busqueda);
            }
            catch { };
        }

        public  void Insertar(TbUsuarios usuario)
        {
            try
            {
                var lista = Mostrar();
                if (lista != null)
                {
                    usuario.IDUsuario = lista[lista.Count() - 1].IDUsuario + 1;
                }
                else
                {
                    usuario.IDUsuario = 1;
                };
                client.SetAsync("TbUsuarios/" + usuario.IDUsuario, usuario);

            }
            catch
            {

            }
        }

        public List<TbUsuarios> Mostrar()
        {
            var response = client.Get("TbUsuarios");
            TbUsuarios[] tabla = JsonConvert.DeserializeObject<TbUsuarios[]>(response.Body);
            if (tabla == null) { return null; }
            var lista = new List<TbUsuarios>();
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
