using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c3_dominio.entidad;

namespace Modelo.c3_dominio.contrato
{
    public interface ILineaSubCategoriaDAO
    {
        void crearLineaSubCategoria(LineaSubCategoria lineaSubCategoria, int codigoSubCategoria);
        void editarLineaSubCategoria(LineaSubCategoria lineaSubCategoria);
        void eliminarLineaSubCategoria(LineaSubCategoria lineaSubCategoria);
        List<LineaSubCategoria> buscarLineaSubCategorias(SubCategoria subCategoria);
        LineaSubCategoria buscarLineaSubCategoria(int codigoLineaSubCategoria);
        LineaSubCategoria buscarProductosPorLinea(int codigoLineaSubCategoria);
    
    }
}
