using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Exceptions
{
    public class ListaVaciaRepuestoException:Exception
    {
        public ListaVaciaRepuestoException() : base("La lista de repuestos se encuentra vacia")
        {

        }
    }
}
