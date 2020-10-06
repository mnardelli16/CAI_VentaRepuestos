using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using ClassLibrary.Entidades;
using ClassLibrary.Exceptions;
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
            VentaRepuestos E = new VentaRepuestos();

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
                            AgregarRepuestos(E);
                            break;
                        }
                    case 2:
                        {
                            QuitarRepuesto(E);
                            break;
                        }
                    case 3:
                        {
                            ModificarPrecio(E);
                            break;
                        }
                    case 4:
                        {
                            AgregarStock(E);
                            break;
                        }
                    case 5:
                        {
                            QuitarStock(E);
                            break;
                        }
                    case 6:
                        {
                            TraerPorCatego(E);
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

        static void AgregarRepuestos(VentaRepuestos E)
        {
            Validaciones V = new Validaciones();
            ConsolaHelper H = new ConsolaHelper();
            Repuesto R = new Repuesto();

            try
            {

                // PIDO DATOS AL USUARIO
                string _srtCodigoR;
                int _codigoR = 0;
                bool _flag1;
                do
                {
                    _srtCodigoR = H.PedirCodigo("repuesto");
                    _flag1 = V.ValidarCodigoRepuesto(_srtCodigoR, ref _codigoR);
                } while (!_flag1);

                string _nombreR;
                bool _flag2;
                do
                {
                    _nombreR = H.PedirNombre("repuesto");
                    _flag2 = V.ValidarStringNULL(_nombreR);
                } while (!_flag2);

                string _strPrecio;
                double _precio = 0;
                bool _flag3;
                do
                {
                    _strPrecio = H.PedirPrecio();
                    _flag3 = V.ValidarPrecio(_strPrecio, ref _precio);
                } while (!_flag3);

                string _strStock;
                int _stock = 0;
                bool _flag4;
                do
                {
                    _strStock = H.PedirStock();
                    _flag4 = V.ValidarStock(_strStock, ref _stock);
                } while (!_flag4);

                string _srtCodigoC;
                int _codigoC = 0;
                bool _flag5;
                do
                {
                    _srtCodigoC = H.PedirCodigo("categoria");
                    _flag5 = V.ValidarCodigoRepuesto(_srtCodigoC, ref _codigoC);
                } while (!_flag5);

                string _nombreC;
                bool _flag6;
                do
                {
                    _nombreC = H.PedirNombre("categoria");
                    _flag6 = V.ValidarStringNULL(_nombreC);
                } while (!_flag6);

                Categoria C = new Categoria(_codigoC, _nombreC);
                R = new Repuesto(_codigoR, _nombreR, _precio, _stock, C);
                E.AgregarRepuesto(R);
                H.MostrarMensaje("Repuesto agregado con Exito!");
                

            } 
            catch(Exception e)
            {
                H.MostrarMensaje(e.Message);
            }

        }

        static void TraerPorCatego(VentaRepuestos E)
        {
            Validaciones V = new Validaciones();
            ConsolaHelper H = new ConsolaHelper();
            try
            {
                string _srtCodigoC;
                int _codigoC = 0;
                bool _flag1;
                do
                {
                    _srtCodigoC = H.PedirCodigo("categoria");
                    _flag1 = V.ValidarCodigoRepuesto(_srtCodigoC, ref _codigoC);
                } while (!_flag1);


                if (E.TraerPorCategoria(_codigoC).Count == 0)
                {
                    throw new ListaVaciaCategoriaException();
                }
                else
                {
                    foreach (Repuesto Rf in E.TraerPorCategoria(_codigoC))
                    {
                        H.MostrarMensaje(Rf.ToString());
                    }
                }
            }
            catch (ListaVaciaCategoriaException e)
            {
                H.MostrarMensaje(e.Message);
            }

        }

        static void QuitarRepuesto(VentaRepuestos E)
        {
            Validaciones V = new Validaciones();
            ConsolaHelper H = new ConsolaHelper();

            try
            {
                if(E.CantidadRepuestos() == 0)
                {
                    throw new ListaVaciaRepuestoException();
                }
                else
                {
                    H.MostrarMensaje("\nPor favor seleccione el codigo de repuesto a eliminar: \n" +
                                     "Lista de repuestos: ");

                    E.ListaRepuestos();
                }


                //PIDO CODIGO A ELIMINAR
                string _srtCodigoC;
                int _codigoC = 0;
                bool _flag1;
                do
                {
                    _srtCodigoC = H.PedirCodigoEliminar();
                    _flag1 = V.ValidarCodigoRepuesto(_srtCodigoC, ref _codigoC);
                } while (!_flag1);

                try
                {
                    if (E.BuscarCodigoRepuesto(_codigoC) == null)
                    {
                        throw new RepuestoInexistenteException();
                    }

                    try
                    {
                        if (E.BuscarCodigoRepuesto(_codigoC).Stock > 0)
                        {
                            throw new RepuestoConStockException();
                        }

                        E.QuitarRepuesto(_codigoC);

                        H.MostrarMensaje("Repuesto eliminado con Exito!");
                    }
                    catch( RepuestoConStockException x)
                    {
                        H.MostrarMensaje(x.Message);
                    }
                }
                catch (RepuestoInexistenteException e)
                {
                    H.MostrarMensaje(e.Message);
                }
            }
            catch(ListaVaciaRepuestoException e)
            {
                H.MostrarMensaje(e.Message);
            }
        }

        static void ModificarPrecio(VentaRepuestos E)
        {
            Validaciones V = new Validaciones();
            ConsolaHelper H = new ConsolaHelper();

            try
            {
                if (E.CantidadRepuestos() == 0)
                {
                    throw new ListaVaciaRepuestoException();
                }
                else
                {
                    H.MostrarMensaje("\nPor favor seleccione el codigo de repuesto a eliminar: \n" +
                                     "Lista de repuestos: ");

                    E.ListaRepuestos();
                }


                //PIDO CODIGO A ELIMINAR
                string _srtCodigoR;
                int _codigoR = 0;
                bool _flag1;
                do
                {
                    _srtCodigoR = H.PedirCodigoEliminar();
                    _flag1 = V.ValidarCodigoRepuesto(_srtCodigoR, ref _codigoR);
                } while (!_flag1);

                try
                {
                    if (E.BuscarCodigoRepuesto(_codigoR) == null)
                    {
                        throw new RepuestoInexistenteException();
                    }
                    else
                    {
                        //PIDO EL NUEVO PRECIO
                        string _strPrecio;
                        double _precio = 0;
                        bool _flag2;
                        do
                        {
                            _strPrecio = H.PedirPrecio();
                            _flag2 = V.ValidarPrecio(_strPrecio, ref _precio);
                        } while (!_flag2);

                        Repuesto R = new Repuesto();
                        E.ModificarPrecio(_codigoR,_precio,ref R);

                        H.MostrarMensaje("Precio modificado con Exito! \n");
                        H.MostrarMensaje("El repuesto de codigo {0} ahora tiene un precio de $ {1}",R.Codigo,R.Precio);

                    }

                }
                catch (RepuestoInexistenteException e)
                {
                    H.MostrarMensaje(e.Message);
                }
            }
            catch (ListaVaciaRepuestoException e)
            {
                H.MostrarMensaje(e.Message);
            }
        }

        static void AgregarStock(VentaRepuestos E)
        {
            Validaciones V = new Validaciones();
            ConsolaHelper H = new ConsolaHelper();

            try
            {
                if (E.CantidadRepuestos() == 0)
                {
                    throw new ListaVaciaRepuestoException();
                }
                else
                {
                    H.MostrarMensaje("\nPor favor seleccione el codigo de repuesto para agregar stock: \n" +
                                     "Lista de repuestos: ");

                    E.ListaRepuestos();
                }


                //PIDO CODIGO A MODIFICAR STOCK
                string _srtCodigoR;
                int _codigoR = 0;
                bool _flag1;
                do
                {
                    _srtCodigoR = H.PedirCodigoParaAgregarStock();
                    _flag1 = V.ValidarCodigoRepuesto(_srtCodigoR, ref _codigoR);
                } while (!_flag1);

                try
                {
                    if (E.BuscarCodigoRepuesto(_codigoR) == null)
                    {
                        throw new RepuestoInexistenteException();
                    }
                    else
                    {
                        //PIDO EL NUEVO STOCK
                        string _strStock;
                        int _stock = 0;
                        bool _flag2;
                        do
                        {
                            _strStock = H.PedirStock();
                            _flag2 = V.ValidarStock(_strStock, ref _stock);
                        } while (!_flag2);

                        Repuesto R = new Repuesto();
                        E.AgregarStock(_codigoR, _stock, ref R);

                        H.MostrarMensaje("Stock agregado con Exito! \n");
                        H.MostrarMensaje("El repuesto de codigo {0} ahora tiene un stock de {1} unidades", R.Codigo, R.Stock);

                    }

                }
                catch (RepuestoInexistenteException e)
                {
                    H.MostrarMensaje(e.Message);
                }
            }
            catch (ListaVaciaRepuestoException e)
            {
                H.MostrarMensaje(e.Message);
            }

        }

        static void QuitarStock(VentaRepuestos E)
        {
            Validaciones V = new Validaciones();
            ConsolaHelper H = new ConsolaHelper();

            try
            {
                if (E.CantidadRepuestos() == 0)
                {
                    throw new ListaVaciaRepuestoException();
                }
                else
                {
                    H.MostrarMensaje("\nPor favor seleccione el codigo de repuesto para quitar stock: \n" +
                                     "Lista de repuestos: ");

                    E.ListaRepuestos();
                }


                //PIDO CODIGO A MODIFICAR STOCK
                string _srtCodigoR;
                int _codigoR = 0;
                bool _flag1;
                do
                {
                    _srtCodigoR = H.PedirCodigoParaQuitarStock();
                    _flag1 = V.ValidarCodigoRepuesto(_srtCodigoR, ref _codigoR);
                } while (!_flag1);

                try
                {
                    if (E.BuscarCodigoRepuesto(_codigoR) == null)
                    {
                        throw new RepuestoInexistenteException();
                    }
                    else
                    {
                        //PIDO CUANTAS UNIDADES QUIERO RESTAR
                        string _strStock;
                        int _stock = 0;
                        bool _flag2;
                        do
                        {
                            _strStock = H.PedirStockAQuitar();
                            _flag2 = V.ValidarStock(_strStock, ref _stock);
                        } while (!_flag2);

                        try
                        {
                            Repuesto R = new Repuesto();
                            E.QuitarStock(_codigoR, _stock, ref R);

                            H.MostrarMensaje("Stock eliminado con Exito! \n");
                            H.MostrarMensaje("El repuesto de codigo {0} ahora tiene un stock de {1} unidades", R.Codigo, R.Stock);
                        }
                        catch (QuitarStockException e)
                        {
                            H.MostrarMensaje(e.Message);
                        }
                    }
                }
                catch (RepuestoInexistenteException e)
                {
                    H.MostrarMensaje(e.Message);
                }
            }
            catch (ListaVaciaRepuestoException e)
            {
                H.MostrarMensaje(e.Message);
            }
        }
    }
}
