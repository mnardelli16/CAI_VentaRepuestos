using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Exceptions
{
    public class ListaVaciaCategoriaException:Exception
    {
        public ListaVaciaCategoriaException() : base("No existen repuestos para esa categoria")
        {

        }
    }
}
