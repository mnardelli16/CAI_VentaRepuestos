using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entidades
{
    public class VentaRepuestos
    {
        private List<Repuesto> _listaProductos;
        private string _nombreComercio;
        private string _direccion;

        public string NombreComercio
        {
            get { return this._nombreComercio; }
            set { this._nombreComercio = value; }
        }
        public string Direccion
        {
            get { return this._direccion; }
            set { this._direccion = value; }
        }

        public VentaRepuestos()
        {
            _listaProductos = new List<Repuesto>();
        }

    }
}
