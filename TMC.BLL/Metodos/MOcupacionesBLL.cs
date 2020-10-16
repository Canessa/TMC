using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMC.BLL.Interfaces;
using TMC.DATA;

namespace TMC.BLL.Metodos
{
    public class MOcupacionesBLL : MBase, IOcupacionesBLL
    {
        public void Actualizar(TbOcupaciones ocupacion)
        {
            vOcupaciones.Actualizar(ocupacion);
        }

        public TbOcupaciones Buscar(int idOcupacion)
        {
            return vOcupaciones.Buscar(idOcupacion);
        }

        public int Eliminar(int idOcupacion)
        {
            //Validacion de relaciones con TbEmpleados
            IEmpleadosBLL cEmpleados = new MEmpleadosBLL();
            List<TbEmpleados> listaEmpleados = cEmpleados.Mostrar();
            if (listaEmpleados != null)
            {
                foreach (TbEmpleados i in listaEmpleados)
                {
                    if (i.IDOcupacion == idOcupacion)
                    {
                        return 1;
                    }
                }
            }
            vOcupaciones.Eliminar(idOcupacion);
            return 0;
        }

        public void Insertar(TbOcupaciones ocupacion)
        {
            vOcupaciones.Insertar(ocupacion);
        }

        public List<TbOcupaciones> Mostrar()
        {
            return vOcupaciones.Mostrar();
        }
    }
}
