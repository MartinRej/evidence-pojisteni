using System.Threading.Channels;

namespace EvidencePojisteni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Evidence evidence = new Evidence();

            bool pokracovat = true;
            while (pokracovat)
            {
                Console.Clear();
                evidence.VypisMenu();
                char volba = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (volba)
                {
                    case '1':
                        evidence.PridejPojisteneho();
                        break;
                    case '2':
                        evidence.VypisVsechnyPojistene();
                        break;
                    case '3':
                        evidence.VyhledejPojistene();
                        break;
                    case '4':
                        bool spravnaVolba = false;
                        while (!spravnaVolba)
                        {
                            Console.WriteLine("\nPřejete si opravdu ukončit program? a - ano, n - ne");
                            char ukoncit = Console.ReadKey().KeyChar;
                            if ((ukoncit == 'a') || (ukoncit == 'A'))
                            {
                                spravnaVolba = true;
                                pokracovat = false;
                            }
                            else if ((ukoncit == 'n') || (ukoncit == 'N'))
                                spravnaVolba = true;
                            else
                            {
                                Console.WriteLine("\nNeplatná volba - zadejte a nebo n.");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Neplatná volba - zadejte číslo od 1 do 4. Pokračujte stiskem libovolné klávesy.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}