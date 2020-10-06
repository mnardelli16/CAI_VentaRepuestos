using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Exceptions
{
    public class QuitarStockException:Exception
    {
        public QuitarStockException(): base("No puede quitar mas stock del disponible.")
        {

        }
    }
}
