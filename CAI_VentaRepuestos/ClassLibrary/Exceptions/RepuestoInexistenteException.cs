using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Exceptions
{
    public class RepuestoInexistenteException: Exception
    {
        public RepuestoInexistenteException() : base("No existe dicho repuesto en la base")
        {

        }
    }
}
