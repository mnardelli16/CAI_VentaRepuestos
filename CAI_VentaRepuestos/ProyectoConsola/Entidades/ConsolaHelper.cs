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
        public void MostrarMensaje(string s,int a, double d)
        {
            Console.WriteLine(s,a,d);
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

        public string PedirCodigo(string s)
        {
            Console.Write("Por favor ingrese un codigo de {0}: ",s);
            return Console.ReadLine();
        }
        public string PedirNombre(string s)
        {
            Console.Write("Por favor ingrese el nombre de {0}: ",s);
            return Console.ReadLine();
        }
        public string PedirPrecio()
        {
            Console.Write("Por favor ingrese el precio del repuesto: ");
            return Console.ReadLine();
        }
        public string PedirStock()
        {
            Console.Write("Por favor ingrese el stock del repuesto: ");
            return Console.ReadLine();
        }

        public string PedirCodigoEliminar()
        {
            Console.Write("Por favor ingrese un codigo de repuesto a eliminar: ");
            return Console.ReadLine();
        }

        public string PedirCodigoParaAgregarStock()
        {
            Console.Write("Por favor ingrese un codigo de repuesto para agregar stock: ");
            return Console.ReadLine();
        }

        public string PedirCodigoParaQuitarStock()
        {
            Console.Write("Por favor ingrese un codigo de repuesto para quitar stock: ");
            return Console.ReadLine();
        }

        public string PedirStockAQuitar()
        {
            Console.Write("Por favor ingrese el stock que quiere quitar: ");
            return Console.ReadLine();
        }
    }
}
