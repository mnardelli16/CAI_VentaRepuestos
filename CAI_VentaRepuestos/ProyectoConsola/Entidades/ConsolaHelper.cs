using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola.Entidades
{
    public class ConsolaHelper
    {

        public void MostrarMensaje(string s)
        {
            Console.WriteLine(s);
        }

        public string PedirEleccionMenu()
        {
            Console.Write("Por favor seleccione una opcion del menu: ");
            return Console.ReadLine();
        }

        public string SeguirMenu()
        {
            Console.Write("Desea continuar en el sistema S/N: ");
            return Console.ReadLine();
        }

    }
}
