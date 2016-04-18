using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.c5_transversal.excepcion
{
    public class ExcepcionSQL : Exception
    {
        private const string MENSAJE_ERROR_CONSULTAR = "No se pudo realizar la consulta.<br>"
                + "Intente de nuevo o consulte con el Administrador.";
        private const string MENSAJE_ERROR_INSERTAR = "No se pudo guardar los datos.<br>"
                + "Verifique los datos obligatorios y \u00FAnicos.<br>"
                + "Intente de nuevo o consulte con el Administrador.";
        private const string MENSAJE_ERROR_MODIFICAR = "No se pudo actualizar los datos.<br>"
                + "Verifique los datos obligatorios y \u00FAnicos.<br>"
                + "Intente de nuevo o consulte con el Administrador.";
        private const string MENSAJE_ERROR_ELIMINAR = "No se pudo eliminar el registro.<br>"
                + "Intente de nuevo o consulte con el Administrador.";
        private const string MENSAJE_ERROR_ABRIRCONEXION = "No se pudo abrir la conexi\u00F3n con la base de datos.<br>"
                + "Intente de nuevo o consulte con el Administrador.";
        private const string MENSAJE_ERROR_CERRARCONEXION = "No se pudo cerrar la conexi\u00F3n con la base de datos.<br>"
                + "Intente de nuevo o consulte con el Administrador.";
        private const string MENSAJE_ERROR_INICIARTRANSACCION = "No se pudo iniciar la transacci\u00F3n.<br>"
                + "Intente de nuevo o consulte con el Administrador.";
        private const string MENSAJE_ERROR_TERMINARTRANSACCION = "No se pudo terminar la transacci\u00F3n.<br>"
                + "Intente de nuevo o consulte con el Administrador.";
        private const string MENSAJE_ERROR_CANCELARTRANSACCION = "No se pudo cancelar la transacci\u00F3n.<br>"
                + "Intente de nuevo o consulte con el Administrador.";
        public ExcepcionSQL(string message) : base(message) { }
        public static ExcepcionSQL crearErrorConsultar()
        {
            return new ExcepcionSQL(MENSAJE_ERROR_CONSULTAR);
        }
        public static ExcepcionSQL crearErrorInsertar()
        {
            return new ExcepcionSQL(MENSAJE_ERROR_INSERTAR);
        }

        public static ExcepcionSQL crearErrorModificar()
        {
            return new ExcepcionSQL(MENSAJE_ERROR_MODIFICAR);
        }

        public static ExcepcionSQL crearErrorEliminar()
        {
            return new ExcepcionSQL(MENSAJE_ERROR_ELIMINAR);
        }

        public static ExcepcionSQL crearErrorAbrirConexion()
        {
            return new ExcepcionSQL(MENSAJE_ERROR_ABRIRCONEXION);
        }

        public static ExcepcionSQL crearErrorCerrarConexion()
        {
            return new ExcepcionSQL(MENSAJE_ERROR_CERRARCONEXION);
        }

        public static ExcepcionSQL crearErrorIniciarTransaccion()
        {
            return new ExcepcionSQL(MENSAJE_ERROR_INICIARTRANSACCION);
        }

        public static ExcepcionSQL crearErrorTerminarTransaccion()
        {
            return new ExcepcionSQL(MENSAJE_ERROR_TERMINARTRANSACCION);
        }

        public static ExcepcionSQL crearErrorCancelarTransaccion()
        {
            return new ExcepcionSQL(MENSAJE_ERROR_CANCELARTRANSACCION);
        }
    }
}
