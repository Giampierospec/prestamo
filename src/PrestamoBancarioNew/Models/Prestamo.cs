using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoBancarioNew.Models
{
    public class Prestamo
    {
        public Prestamo()
        {

        }
        public Prestamo(double capital, int plazo, double tasa)
        {
            Capital = capital;
            Plazo = plazo;
            Tasa = tasa * 1200;
        }
        [Key]
        public int Id { get; set; }
        public double Capital { get; set; }
        public int Plazo { get; set; }
        public double Tasa { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public ICollection<InfoPrestamo> InfoPrestamos { get; set; }
        public List<InfoPrestamo> TablaAmortizacion(double capital, int plazo, double tasa)
        {
            List<InfoPrestamo> detallePrestamo = new List<InfoPrestamo>();
            double cuota;
            double intereses;
            double amort;
            double amortAcumulado = 0;

            tasa /= 1200;
            cuota = capital * (tasa / (double)(1 - Math.Pow(1 + (double)tasa, -plazo)));

            for (int i = 0; i <= plazo; i++)
            {
                if (i == 0)
                {
                    detallePrestamo.Add(new InfoPrestamo(0, cuota, 0, 0, 0, capital));
                }
                else
                {
                    intereses = capital * tasa;
                    amort = cuota - intereses;
                    amortAcumulado += amort;
                    capital -= amort;
                    detallePrestamo.Add(new InfoPrestamo(i, cuota, intereses, amort, amortAcumulado, capital));
                }
            }
            return detallePrestamo;
        }
        public  Prestamo PagoPrestamo(double capital, int plazo, double tasa)
        {
            double cuota;
            double intereses;
            double amort;
            double amortAcumulado = 0;

            tasa /= 1200;
            cuota = capital * (tasa / (double)(1 - Math.Pow(1 + (double)tasa, -plazo)));
            intereses = capital * tasa;
            amort = cuota - intereses;
            amortAcumulado += amort;
            capital -= amort;
            plazo-= 1;
            return new Prestamo(capital, plazo, tasa);
        }
    }
}
