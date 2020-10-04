using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using ProyectoConsola.Entidades;

namespace ProyectoConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolaHelper H = new ConsolaHelper();
            MenuConsola M = new MenuConsola();
            Validaciones V = new Validaciones();

            M.PantallaInicio();
            int _opcion;
            int salida = 0;
            do
            {
                _opcion = M.PedirMenu();

                switch (_opcion)
                {
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                    case 7:
                        {
                            salida = 7;
                            break;
                        }
                }

            } while (salida != 7);

            H.MostrarMensaje("HASTA LUEGO");

            //System.Console.Clear();

            Console.ReadKey();


        }
    }
}
