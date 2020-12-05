using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.DATA;

namespace TMC.BLL.Interfaces
{
    public interface IUsuariosBLL
    {
        //Insert del registro en la DB
        void Insertar(TbUsuarios usuario);
        //Crear registro en el historial
        void InsertarHistorial(TbHistorial registro);
        //Obtiene el id del usuario 
        int ObtenerId(string email);
        //Obtiene el rol del usuario
        int ObtenerIdRol(string email);
        //Update registro en la DB
        void Actualizar(TbUsuarios usuario);
        //Desactivar usuario cambiando estado
        int Desactivar(int idUsuario);
        //Lista con todos los registros
        List<TbUsuarios> Mostrar();
        //Busca un registro especifico
        TbUsuarios Buscar(int idUsuario);
        //Usuario correo
        TbUsuarios FindEmail(String emails);
        //Obtener servicios contratados
        List<TbServicios> getServiciosContratados(int usuarioID);
    }
}
