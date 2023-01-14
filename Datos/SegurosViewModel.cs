using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class SegurosViewModel
    {
        public string Fecha { get; set; }
        public string Sucursal { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string SerieOrigen { get; set; }
        public string NumeroOrigen { get; set; }
        public string SerieFel { get; set; }
        public string NumeroFel { get; set; }
        public string RequestId { get; set; }
        public string Convenio { get; set; }
        public string Autorizacion { get; set; }
        public string TipoDocumentoAs { get; set; }
        public string NombreA { get; set; }
        public string NitA { get; set; }
        public string CanalVenta { get; set; }
        public decimal TotalA { get; set; }
        public string SerieB { get; set; }
        public string NumeroB { get; set; }
        public string SerieOrigenB { get; set; }
        public string NumeroOrigenB { get; set; }
        public string SerieFelB { get; set; }
        public string NumeroFelB { get; set; }
        public string RequestIdB { get; set; }
        public string NombreB { get; set; }
        public string NitB { get; set; }
        public decimal TotalB { get; set; }
        public int Estado { get; set; }
    }
}
