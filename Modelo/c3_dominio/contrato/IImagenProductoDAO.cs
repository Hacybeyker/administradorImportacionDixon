using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c3_dominio.entidad;

namespace Modelo.c3_dominio.contrato
{
    public interface IImagenProductoDAO
    {
        void crearImagenProducto(ImagenProducto imagenProducto, int codigoproducto);
        void modificarImagenProducto(ImagenProducto imagenProducto);
        void eliminarImagenProducto(ImagenProducto imagenProducto);
        List<ImagenProducto> listarImagenesPorProducto(Producto producto);
        ImagenProducto buscarImagenPrincipalProducto(Producto producto);
        ImagenProducto buscarImagenProducto(int codigoimagenproducto);
    }
}
