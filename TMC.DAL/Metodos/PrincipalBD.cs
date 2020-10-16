using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp;

namespace TMC.DAL
{
    //clase principal de metodos con la base de datos
    public class PrincipalBD
    {
        //Inicializadores
        public FirebaseClient client;
        public FirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "kCrN8JOIPELTrNa7SXu21pGLEJThvxd3onopEEvr",
            BasePath = "https://bd-tmc.firebaseio.com/"
        };

        //Generador de la conexion con la base de datos Firebase
        public PrincipalBD()
        {
            client = new FirebaseClient(config);

        }

    }
}
