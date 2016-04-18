using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c5_transversal.excepcion;

namespace Modelo.c3_dominio.entidad
{
    public class LineaSubCategoria
    {
        public LineaSubCategoria()
        {
            this.codigolinea = 0;
            this.listaProductos = new List<Producto>();
        }
        public int codigosubcategoria { get; set; }
        public int codigolinea { get; set; }
        public string nombrelinea { get; set; }
        public List<Producto> listaProductos { get; set; }
        public void agregarProducto(Producto producto)
        {
            verificarExistenciaProducto(producto);
            listaProductos.Add(producto);
        }
        public void verificarExistenciaProducto(Producto producto)
        {
            foreach (Producto productoVerificar in listaProductos)
            {
                if (productoVerificar.codigoProducto == producto.codigoProducto)
                    throw ExcepcionReglaNegocio.crearErrorExistenciaProducto();
            }
        }

        public void quitarProducto(int codigoProducto)
        {
            foreach (Producto productoVerificar in listaProductos)
            {
                if (productoVerificar.codigoProducto == codigoProducto)
                {
                    listaProductos.Remove(productoVerificar);
                    break;
                }

            }
        }
    }
}
