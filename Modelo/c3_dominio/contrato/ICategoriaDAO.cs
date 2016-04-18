using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c3_dominio.entidad;

namespace Modelo.c3_dominio.contrato
{
    public interface ICategoriaDAO
    {
        void crearCategoria(Categoria categoria);
        void editarCategoria(Categoria categoria);
        void eliminarCategoria(Categoria categoria);
        List<Categoria> listarCategorias();
        Categoria buscarCategoria(int codigocategoria);
        Categoria buscarProductosPorCategoria(int codigoCategoria);
        List<Categoria> listaCategoriaMenu();

    }
}
