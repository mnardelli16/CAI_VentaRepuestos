using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ClassLibrary.Entidades
{
    public class Repuesto
    {
        private int _codigo;
        private string _nombre;
        private double _precio;
        private int _stock;
        protected Categoria _categoria;

        public int Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public double Precio
        {
            get { return this._precio; }
            set { this._precio = value; }
        }
        public int Stock
        {
            get { return this._stock; }
            set { this._stock = value; }
        }
        public Categoria Categorias
        {
            get { return this._categoria; }
        }

        public Repuesto()
        {

        }

        public override string ToString()
        {
            return string.Format("Codigo: {0} - Nombre: {1} - Precio: {2} - Stock: {3} - Categoria: {4}",
                                this._codigo, this._nombre, this._precio, this._stock, this._categoria);
        }
    }
}
