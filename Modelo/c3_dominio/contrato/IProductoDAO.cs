using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c3_dominio.entidad;

namespace Modelo.c3_dominio.contrato
{
    interface IProductoDAO
    {
        void crearProducto(Producto producto, int codigoLinea);
        void eliminarProducto(Producto producto);
        void modificarProducto(Producto producto);
        Producto buscarProducto(int codigoProducto);
        List<Producto> buscarProductos();
        List<Producto> buscarProductos(LineaSubCategoria lineaSubCategoria);

    }
}
