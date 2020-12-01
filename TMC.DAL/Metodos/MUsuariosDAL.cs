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
                //client.PushAsync("TbUsuarios/" + usuario.IDUsuario, usuario);
               // client.Update("TbUsuarios/" + usuario.IDUsuario, usuario);
                //client.Push("TbUsuarios/" + usuario.IDUsuario, usuario);
            }
            catch { };
        }

        public TbUsuarios Buscar(int idUsuario)
        {
            var response = client.Get("TbUsuarios/" + idUsuario);
            TbUsuarios valor = JsonConvert.DeserializeObject<TbUsuarios>(response.Body);
            return valor;
        }



        public int ObtenerId(string email)
        {
            var response = client.Get("TbUsuarios/");
            int id = 0;
            TbUsuarios[] tabla = { };
            tabla = JsonConvert.DeserializeObject<TbUsuarios[]>(response.Body);
            foreach (var usuario in tabla)
            {
                if (usuario != null && usuario.correo == email)
                {
                    id = usuario.IDRol;
                    break;
                }
            }
            return id;
        }


        public void Desactivar(int idUsuario)
        {
            try
            {
                var busqueda = Buscar(idUsuario);
                busqueda.estado = false;
                Actualizar(busqueda);
            }
            catch { };
        }

        public void Insertar(TbUsuarios usuario)
        {
            try
            {
                var lista = Mostrar().Count;
                if (lista > 0)
                {
                    usuario.IDUsuario = lista;
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

        public void InsertarHistorial(TbHistorial registro)
        {
            try
            {
                int lista = cantidadRegistros();
                if (lista > 0)
                {
                    registro.Id= lista + 1;
                }
                else
                {
                    registro.Id= 1;
                };
                client.SetAsync("TbHistorial/" + registro.Id, registro);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //public List<TbHistorial> Mostrar()
        //{

        //}

        public int cantidadRegistros()
        {
            int cantidad = 0;
            var response = client.Get("TbHistorial");
            TbHistorial[] tabla = JsonConvert.DeserializeObject<TbHistorial[]>(response.Body);
            if (tabla == null) { return 0; }
            var lista = new List<TbHistorial>();
            foreach (var item in tabla)
            {
                if (item != null)
                {
                    cantidad++;
                }
            }

            return cantidad;
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

        public TbUsuarios FindEmail(string email)
        {
            var response = client.Get("TbUsuarios/" + email);
            TbUsuarios valor = JsonConvert.DeserializeObject<TbUsuarios>(response.Body);
            return valor;
        }
    }
}
