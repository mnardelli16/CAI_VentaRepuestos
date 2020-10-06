using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Exceptions
{
    public class RepuestoConStockException: Exception
    {
        public RepuestoConStockException(): base("Existe stock de dicho repuesto. No puede eliminarse")
        {

        }
    }
}
