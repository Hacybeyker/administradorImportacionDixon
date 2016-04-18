using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.c5_transversal.excepcion
{
    public class ExcepcionReglaNegocio : Exception
    {
        private const string MENSAJE_ERROR_CONSULTAR = "Precio del producto invalido.";
        private const string MENSAJE_ERROR_EXISTENCIA_IMAGEN = "La imagen ya existe.";
        private const string MENSAJE_ERROR_EXISTENCIA_PRODUCTO = "El producto ya existe";
        private const string MENSAJE_ERROR_EXISTENCIA_LINEASUBCATEGORIA = "La Linea Sub Categoria ya existe.";
        private const string MENSAJE_ERROR_EXISTENCIA_SUBCATEGORIA = "La sub Categoria ya existe.";
        private const string MENSAJE_ERROR_IMAGEN_PRINCIPAL = "La imagen es principal, no se puede eliminar";
        public ExcepcionReglaNegocio(string message) : base(message) { }

        public static ExcepcionReglaNegocio crearErrorPrecioProducto()
        {
            return new ExcepcionReglaNegocio(MENSAJE_ERROR_CONSULTAR);
        }

        public static ExcepcionReglaNegocio crearErrorExistenciaImagen()
        {
            return new ExcepcionReglaNegocio(MENSAJE_ERROR_EXISTENCIA_IMAGEN);
        }
        public static ExcepcionReglaNegocio crearErrorExistenciaProducto()
        {
            return new ExcepcionReglaNegocio(MENSAJE_ERROR_EXISTENCIA_PRODUCTO);
        }
        public static ExcepcionReglaNegocio crearErrorExistenciaLineaSubCategoria()
        {
            return new ExcepcionReglaNegocio(MENSAJE_ERROR_EXISTENCIA_LINEASUBCATEGORIA);
        }
        public static ExcepcionReglaNegocio crearErrorExistenciaSubCategoria()
        {
            return new ExcepcionReglaNegocio(MENSAJE_ERROR_EXISTENCIA_SUBCATEGORIA);
        }
        public static ExcepcionReglaNegocio crearErrorImagenPrincipal()
        {
            return new ExcepcionReglaNegocio(MENSAJE_ERROR_IMAGEN_PRINCIPAL);
        }
    }
}
