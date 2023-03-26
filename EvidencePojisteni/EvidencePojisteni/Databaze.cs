using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteni
{
    internal class Databaze
    {
        private List<Pojisteny> zaznamy;

        public Databaze()
        {
            zaznamy = new List<Pojisteny>();
        }

        // Přidá nového pojištěného do databáze
        public void PridejZaznam(string jmeno, string prijmeni, DateTime datumNarozeni, string telCislo)
        {
            zaznamy.Add(new Pojisteny(jmeno, prijmeni, datumNarozeni, telCislo));
        }

        // Vrátí všechny uložené záznamy
        public List<Pojisteny> VratZaznamy()
        {
            return zaznamy;
        }

        // Vyhledá a vrátí záznamy podle jména a příjmení
        public List<Pojisteny> VyhledejZaznamy(string jmeno, string prijmeni)
        {
            List<Pojisteny> nalezeneZaznamy = new List<Pojisteny>();

            foreach (Pojisteny p in zaznamy)
            {
                if ((p.Jmeno.ToLower() == jmeno.ToLower()) && (p.Prijmeni.ToLower() == prijmeni.ToLower()))
                    nalezeneZaznamy.Add(p);
            }

            return nalezeneZaznamy;
        }

    }
}
