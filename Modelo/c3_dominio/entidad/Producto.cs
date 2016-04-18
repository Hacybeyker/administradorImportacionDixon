using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c5_transversal.excepcion;

namespace Modelo.c3_dominio.entidad
{
    public class Producto
    {        
        public int codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public decimal precioProducto { get; set; }
        public string detalleProducto { get; set; }
        public int codigolineasubcategoria { get; set; }
        public List<ImagenProducto> listaImagenes { get; set; }
        public Producto()
        {
            this.codigoProducto = 0;
            this.listaImagenes = new List<ImagenProducto>();
        }
        public void validarPrecio()
        {
            if (this.precioProducto <= 0)
                throw ExcepcionReglaNegocio.crearErrorPrecioProducto();
        }
        public void agregarImagen(ImagenProducto imagenProducto)
        {
            verificarExistenciaImagen(imagenProducto);
            listaImagenes.Add(imagenProducto);
        }
        public void verificarExistenciaImagen(ImagenProducto imagenProducto)
        {
            foreach (ImagenProducto imagenProductoVerificar in listaImagenes)
            {
                if (imagenProductoVerificar.urlimagen.Equals(imagenProducto.urlimagen))
                    throw ExcepcionReglaNegocio.crearErrorExistenciaImagen();
            }
        }

        public void quitarImagen(string urlimagen)
        {
            foreach (ImagenProducto imagenProductoVerificar in listaImagenes)
            {
                if (imagenProductoVerificar.urlimagen.Equals(urlimagen))
                {
                    listaImagenes.Remove(imagenProductoVerificar);
                    break;
                }
            }
        }

    }
}
