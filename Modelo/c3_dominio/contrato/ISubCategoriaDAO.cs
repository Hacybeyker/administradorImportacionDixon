using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c3_dominio.entidad;

namespace Modelo.c3_dominio.contrato
{
    public interface ISubCategoriaDAO
    {
        void crearSubCategoria(SubCategoria subCategoria, int codigoCategoria);
        void editarSubCategoria(SubCategoria subCategoria);
        void eliminarSubCategoria(SubCategoria subCategoria);
        List<Categoria> listarCategorias();
        List<SubCategoria> buscarSubCategorias(Categoria categoria);
        SubCategoria buscarSubCategoria(int codigoSubCategoria);
        SubCategoria buscarProductosPorSubCategoria(int codigoSubCategoria);
        List<SubCategoria> listarSubCategoriaMenu(Categoria categoria);
 
    }
}
