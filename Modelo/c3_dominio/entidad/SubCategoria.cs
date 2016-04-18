using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c5_transversal.excepcion;

namespace Modelo.c3_dominio.entidad
{
    public class SubCategoria
    {
        public SubCategoria()
        {
            this.codigosubcategoria = 0;
            this.listaLineaSubCategoria = new List<LineaSubCategoria>();
        }
        public int codigocategoria { get; set; }
        public int codigosubcategoria { get; set; }
        public string nombresubcategoria { get; set; }
        public List<LineaSubCategoria> listaLineaSubCategoria { get; set; }
        public void agregarLineaSubCategoria(LineaSubCategoria lineaSubCategoria)
        {
            verificarExistenciaLineaSubCategoria(lineaSubCategoria);
            listaLineaSubCategoria.Add(lineaSubCategoria);
        }
        public void verificarExistenciaLineaSubCategoria(LineaSubCategoria lineaSubCategoria)
        {
            foreach (LineaSubCategoria lineaSubCategoriaVerificar in listaLineaSubCategoria)
            {
                if (lineaSubCategoriaVerificar.codigolinea == lineaSubCategoria.codigolinea)
                    throw ExcepcionReglaNegocio.crearErrorExistenciaLineaSubCategoria();
            }
        }

        public void quitarLineaSubCategoria(int codigoLineaSubCategoria)
        {
            foreach (LineaSubCategoria lineaSubCategoriaVerificar in listaLineaSubCategoria)
            {
                if (lineaSubCategoriaVerificar.codigolinea == codigoLineaSubCategoria)
                {
                    listaLineaSubCategoria.Remove(lineaSubCategoriaVerificar);
                    break;
                }
            }
        }
    }
}
