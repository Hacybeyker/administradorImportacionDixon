using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c5_transversal.excepcion;

namespace Modelo.c3_dominio.entidad
{
    public class ImagenProducto
    {
        public int codigoimagen { get; set; }
        public int codigoproducto { get; set; }
        public string nombreimagen { get; set; }
        public string urlimagen { get; set; }
        public bool principal { get; set; }
        public ImagenProducto()
        {
            this.codigoimagen = 0;
            this.principal = false;
        }
        public void validarPrincipal(ImagenProducto imagenProducto)
        {
            if (imagenProducto.principal == true)
                throw ExcepcionReglaNegocio.crearErrorImagenPrincipal();
        }
        
    }
}
