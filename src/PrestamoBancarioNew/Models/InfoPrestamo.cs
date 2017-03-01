using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoBancarioNew.Models
{
    public class InfoPrestamo
    {
        public InfoPrestamo(int mes, double cuota, double intereses, double amortizacionPrincipal, double amortizacionAcumulada, double capital)
        {
            Mes = mes;
            Cuota = cuota;
            Intereses = intereses;
            AmortizacionPrincipal = amortizacionPrincipal;
            AmortizacionAcumulada = amortizacionAcumulada;
            Capital = capital;

        }
        [Key]
        public int Id { get; set; }
        public int Mes { get; set; }
        public double Cuota { get; set; }
        public double Intereses { get; set; }
        public double AmortizacionPrincipal { get; set; }
        public double AmortizacionAcumulada { get; set; }
        public double Capital { get; set; }
        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; }



    }
}
