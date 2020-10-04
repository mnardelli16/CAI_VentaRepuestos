using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola.Entidades
{
    public class MenuConsola
    {
        public void PantallaInicio()
        {
            string _msj =
                "-----------------------------------------------------------------------------\n" +
                "--------------------BIENVENIDO A LA CASA DE REPUESTOS------------------------\n" +
                "-----------------------------------------------------------------------------\n\n" +
                "MENU:                                       \n" +
                "1 - Agregar Repuesto                        \n" +
                "2 - Quitar Repuesto                         \n" +
                "3 - Modificar Precio                        \n" +
                "4 - Agregar Stock                           \n" +
                "5 - Quitar Stock                            \n" +
                "6 - Mostrar Repuesto por Categoria          \n" +
                "7 - Salir del sistema                       \n";

            new ConsolaHelper().MostrarMensaje(_msj);
        }

        public int PedirMenu()
        {
            Validaciones V = new Validaciones();
            ConsolaHelper H = new ConsolaHelper();

            string _eleccion;
            bool _flag = false;

            do
            {
                _eleccion = H.PedirEleccionMenu();
                _flag = V.ValidarOpcionDelMenu(_eleccion);
            } while (!_flag);

            return Convert.ToInt32(_eleccion);

        }



    }
}
