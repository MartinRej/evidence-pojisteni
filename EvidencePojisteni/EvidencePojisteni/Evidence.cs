using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EvidencePojisteni
{
    internal class Evidence
    {
        private Databaze databaze;

        public Evidence()
        {
            databaze = new Databaze();
        }

        // Vypíše textové menu
        public void VypisMenu()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Evidence pojištěných");
            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("Vyberte si akci:");
            Console.WriteLine("1 - Přidat nového pojištěného");
            Console.WriteLine("2 - Vypsat všechny pojištěné");
            Console.WriteLine("3 - Vyhledat pojištěného");
            Console.WriteLine("4 - Konec\n");
            Console.Write("Vaše volba: ");
        }

        // Přidá nového pojištěného se zadanými údaji do databáze
        public void PridejPojisteneho()
        {
            string jmeno = ZadejText("Zadejte křestní jméno pojištěného: ");
            string prijmeni = ZadejText("Zadejte příjmení: ");
           
            Console.Write("\nZadejte datum narození v číselném formátu: ");
            DateTime datumNarozeni;
            while (!DateTime.TryParse(Console.ReadLine().Trim(), out datumNarozeni))
            {
                Console.WriteLine("\nJe nutné zadat datum v číselném formátu (př.: 20.1.1993");
                Console.Write("\nZadejte datum narození v číselném formátu: ");
            }

            string telCislo = "";
            Regex vzorTelCisla = new Regex(@"^\+\d{1,4} ?\d{3} ?\d{3} ?\d{3}$"); // Regulární výraz jako vzor formátu tel. čísla
            bool spravneZadani = false;
            while (!spravneZadani)
            {
                Console.Write("\nZadejte telefonní číslo včetně předvolby.\nTrojice číslic mohou být odděleny mezerou (př.: +420 123 456 789): ");
                telCislo = Console.ReadLine().Trim();

                if (vzorTelCisla.IsMatch(telCislo))
                    spravneZadani = true;
                else
                    Console.WriteLine("\nZadané telefonní číslo není v platném formátu!");
            }

            databaze.PridejZaznam(jmeno, prijmeni, datumNarozeni, telCislo);
            
            Console.WriteLine("\nData byla uložena. Pokračujte libovolnou klávesou...");
            Console.ReadKey();
        }

        // Vypíše všechny evidované pojištěné
        public void VypisVsechnyPojistene()
        {
            List<Pojisteny> zaznamy = databaze.VratZaznamy();

            if (zaznamy.Count == 0)
                Console.WriteLine("Evidence neobsahuje žádná data!");
            else
            {
                VypisZaznamy(zaznamy);
            }

            Console.WriteLine("\nPokračujte libovolnou klávesou...");
            Console.ReadKey();
        }

        // Vyhledá a vypíše pojištěné podle jména a příjmení
        public void VyhledejPojistene()
        {
            List<Pojisteny> zaznamy = databaze.VratZaznamy();

            if (zaznamy.Count > 0)
            {
                string jmeno = ZadejText("Zadejte křestní jméno pojištěného: ");
                string prijmeni = ZadejText("Zadejte příjmení: ");
                Console.WriteLine();

                zaznamy = databaze.VyhledejZaznamy(jmeno, prijmeni);

                if (zaznamy.Count == 0)
                    Console.WriteLine("Evidence neobsahuje pojištěnce daného jména.");
                else
                {
                    Console.WriteLine("Nalezené osoby:");
                    VypisZaznamy(zaznamy);
                }
            }
            else
                Console.WriteLine("Evidence neobsahuje žádná data!");

            Console.WriteLine("\nPokračujte libovolnou klávesou...");
            Console.ReadKey();
        }

        // Slouží k výpisu záznamů
        public void VypisZaznamy(List<Pojisteny> zaznamy)
        {
            int odsazeni = 15;
            Console.WriteLine();
            Console.WriteLine("Jméno".PadRight(odsazeni) + "\t" + "Příjmení".PadRight(odsazeni) + "\tVěk\tDatum narození\tTelefonní číslo");
            Console.WriteLine("-----".PadRight(odsazeni) + "\t" + "--------".PadRight(odsazeni) + "\t---\t--------------\t---------------");

            // Seřazení záznamů pro výpis podle příjmení, jména a věku
            var serazeneZaznamy = zaznamy.OrderBy(p => p.Prijmeni).ThenBy(p => p.Jmeno).ThenBy(p => p.Vek);
            foreach (Pojisteny p in serazeneZaznamy)
                Console.WriteLine(p);
        }

        // Vyzve k zadání textu a ošetří vstup
        public string ZadejText(string vyzva)
        {
            bool spravneZadani = false;
            string text = "";
            while (!spravneZadani)
            {
                Console.WriteLine();
                Console.Write(vyzva);
                text = Console.ReadLine().Trim();
                if (text == "")
                    Console.WriteLine("Neplatné zadání - pole nesmí být prázdné!");
                else if (text.Any(c => char.IsDigit(c)))
                    Console.WriteLine("Neplatné zadání - text nesmí obsahovat číslice!");
                else
                    spravneZadani = true;
            }

            return text;
        }

    }
}
