using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteni
{
    internal class Pojisteny
    {
        public string Jmeno { get; private set; }
        public string Prijmeni { get; private set; }
        public DateTime DatumNarozeni { get; private set; }
        public int Vek { get; private set; }
        public string TelCislo { get; private set; }

        public Pojisteny(string jmeno, string prijmeni, DateTime datumNarozeni, string telCislo)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            DatumNarozeni = datumNarozeni;
            TelCislo = telCislo;

            // Výpočet věku z data narození
            Vek = DateTime.Now.Year - datumNarozeni.Year;

            if (DateTime.Now.Month < datumNarozeni.Month)
                Vek--;
            else if ((DateTime.Now.Month == datumNarozeni.Month) && (DateTime.Now.Day < datumNarozeni.Day))
                Vek--;
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}", Jmeno.PadRight(15), Prijmeni.PadRight(15), Vek.ToString().PadRight(3), DatumNarozeni.ToShortDateString(), TelCislo);
        }
    }
}
