using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola.Entidades
{
    public class Validaciones
    {
        ConsolaHelper H = new ConsolaHelper();
        public bool ValidarOpcionDelMenu(string a)
        {
            bool flag = false;

            if (!Int32.TryParse(a, out int salida))
            {
                H.MostrarMensaje("No es una opcion valida");
            }
            else if (salida <= 0 || salida > 7)
            {
                H.MostrarMensaje("No es una opcion valida");
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool ValidarSalida(string a)
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(a))
            {
                H.MostrarMensaje("No debe dejar espacios en blanco");
            }
            else if (a == "S")
            {
                flag = true;
            }
            else if (a == "N")
            {
                flag = true;
            }
            else
            {
                H.MostrarMensaje("No son opciones validas");
            }
            return flag;
        }

        public bool ValidarCodigoRepuesto(string a, ref int salida)
        {
            bool flag = false;

            if (!Int32.TryParse(a, out salida))
            {
                H.MostrarMensaje("Debe ingresar un numero");
            }
            else if (salida <= 0)
            {
                H.MostrarMensaje("El codigo debe ser mayor a 0");
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool ValidarStringNULL(string a)
        {
            bool flag = false;
            if (string.IsNullOrWhiteSpace(a))
            {
                H.MostrarMensaje("No debe dejar espacios en blanco");
            }
            else
            {
                flag = true;
            }
            return flag;
        }
        public bool ValidarPrecio(string a, ref double salida)
        {
            bool flag = false;

            if (!double.TryParse(a, out salida))
            {
                H.MostrarMensaje("Debe ingresar un numero");
            }
            else if (salida <= 0)
            {
                H.MostrarMensaje("El precio debe ser mayor a 0");
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool ValidarStock(string a, ref int salida)
        {
            bool flag = false;

            if (!Int32.TryParse(a, out salida))
            {
                H.MostrarMensaje("Debe ingresar un numero");
            }
            else if (salida < 0)
            {
                H.MostrarMensaje("El stock debe ser mayor a 0");
            }
            else
            {
                flag = true;
            }
            return flag;
        }
    }
}
