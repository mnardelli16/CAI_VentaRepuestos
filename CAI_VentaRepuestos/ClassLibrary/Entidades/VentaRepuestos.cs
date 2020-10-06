using ClassLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entidades
{
    public class VentaRepuestos
    {
        public List<Repuesto> _listaProductos;
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
            this._listaProductos = new List<Repuesto>();
        }

        public void AgregarRepuesto(Repuesto R)
        {
            this._listaProductos.Add(R);

        }

        public List<Repuesto> TraerPorCategoria(int a)
        {
            List<Repuesto> R = new List<Repuesto>();
            foreach(Repuesto rep in this._listaProductos)
            {
                if(rep.Categorias.Codigo == a)
                {
                    R.Add(rep);
                }
            }
            return R;
        }

        public void ListaRepuestos()
        {
            foreach(Repuesto R in this._listaProductos)
            {
                Console.WriteLine(R.ToString());
            }
        }

        public int CantidadRepuestos()
        {
            return _listaProductos.Count;
        }

        public Repuesto BuscarCodigoRepuesto(int a)
        {
            return _listaProductos.Find(x => x.Codigo == a);
        }

        public void QuitarRepuesto(int a)
        {
            Repuesto R = BuscarCodigoRepuesto(a);

            _listaProductos.Remove(R);
        }

        public void ModificarPrecio(int codigo, double precio, ref Repuesto R)
        {
            R = BuscarCodigoRepuesto(codigo);

            R.Precio = precio;

        }

        public void AgregarStock(int codigo, int stock, ref Repuesto R)
        {
            R = BuscarCodigoRepuesto(codigo);

            R.Stock += stock;
        }

        public void QuitarStock(int codigo, int stockaquitar, ref Repuesto R)
        {
            R = BuscarCodigoRepuesto(codigo);

            if (R.Stock < stockaquitar) 
            {
                throw new QuitarStockException(); // la excepcion se captura desde el program, para mostrar el mensaje al usuario
            }
            else
            {
                R.Stock -= stockaquitar;
            }

        }
    }
}
