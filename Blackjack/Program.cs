using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Blackjack
{
    class Program
    {
        static int KartyaErtek(object kartya)
        {
            string ertek = kartya.ToString();
            if (ertek == "Ász" || ertek == "Bubi" || ertek == "Dáma" || ertek == "Király")
            {
                return 10;
            }
            return int.Parse(ertek);
        }


        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<object> kartyak = new List<object> { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, "Ász", "Ász", "Ász", "Ász", "Bubi", "Bubi", "Bubi", "Bubi", "Dáma", "Dáma", "Dáma", "Dáma", "Király", "Király", "Király", "Király" };
            List<object> jatekos = new List<object> { };
            List<object> dealer = new List<object> { };
            int jatekos_osszeg = jatekos.Sum(k => KartyaErtek(k));
            int dealer_osszeg = dealer.Sum(k => KartyaErtek(k));

            for (int i = 0; i < 2; i++)
            {
                int kartya = rnd.Next(kartyak.Count);
                jatekos.Add(kartyak[kartya]);
                kartyak.Remove(kartyak[kartya]);

                kartya = rnd.Next(kartyak.Count);
                dealer.Add(kartyak[kartya]);
                kartyak.Remove(kartyak[kartya]);

                jatekos_osszeg = jatekos.Sum(k => KartyaErtek(k));
                dealer_osszeg = dealer.Sum(k => KartyaErtek(k));
            }

            for (int i = 0; i < kartyak.Count(); i++)
            {
                Console.Clear();
                Console.WriteLine($"A kártyáid: {string.Join(", ", jatekos)}");
                Console.WriteLine($"A kártyáid összege: {jatekos_osszeg}");
                Console.WriteLine($"A dealer egyik kártyája: {dealer[0]}");

                Thread.Sleep(1000);

                Console.Write($"Válassz: Hit (1) vagy Stand (2): ");
                int valasztas = Convert.ToInt32(Console.ReadLine());

                if (valasztas == 1)
                {
                    int kartya = rnd.Next(kartyak.Count);
                    jatekos.Add(kartyak[kartya]);
                    kartyak.Remove(kartyak[kartya]);
                    jatekos_osszeg = jatekos.Sum(k => KartyaErtek(k));

                    if (jatekos.Sum(k => KartyaErtek(k)) > 21)
                    {
                        break;
                    }
                }

                else if (valasztas == 2)
                {
                    Console.Clear();
                    Console.WriteLine($"A dealer kártyái: {string.Join(", ", dealer)}");
                    Console.WriteLine($"A dealer kártyáinak összege: {dealer_osszeg}");
                    Thread.Sleep(1000);
                    break;
                }
            }

            jatekos_osszeg = jatekos.Sum(k => KartyaErtek(k));
            dealer_osszeg = dealer.Sum(k => KartyaErtek(k));

            while (dealer.Sum(k => KartyaErtek(k)) < 17)
            {
                Console.WriteLine("A dealer húz!");
                int kartya = rnd.Next(kartyak.Count);
                dealer.Add(kartyak[kartya]);
                kartyak.Remove(kartyak[kartya]);

                dealer_osszeg = dealer.Sum(k => KartyaErtek(k));
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine($"A dealer kártyái: {string.Join(", ", dealer)}");
                Console.WriteLine($"A dealer kártyáinak összege: {dealer_osszeg}");
                Thread.Sleep(1000);
            }

            if (dealer.Sum(k => KartyaErtek(k)) > jatekos.Sum(k => KartyaErtek(k)) && dealer.Sum(k => KartyaErtek(k)) < 21)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine($"A kártyáid: {string.Join(", ", jatekos)}");
                Console.WriteLine($"A kártyáid összege: {jatekos_osszeg}");
                Console.WriteLine($"A dealer kártyái: {string.Join(", ", dealer)}");
                Console.WriteLine($"A dealer kártyáinak összege: {dealer_osszeg}");
                Thread.Sleep(500);
                Console.WriteLine("A dealer nyert!");
            }

            if (jatekos.Sum(k => KartyaErtek(k)) > 21)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine($"A kártyáid: {string.Join(", ", jatekos)}");
                Console.WriteLine($"A kártyáid összege: {jatekos_osszeg}");
                Thread.Sleep(500);
                Console.WriteLine("Bust! Vesztettél!");
            }

            else if (dealer.Sum(k => KartyaErtek(k)) < jatekos.Sum(k => KartyaErtek(k)) || dealer.Sum(k => KartyaErtek(k)) > 21)
            {

                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine($"A kártyáid: {string.Join(", ", jatekos)}");
                Console.WriteLine($"A kártyáid összege: {jatekos_osszeg}");
                Console.WriteLine($"A dealer kártyái: {string.Join(", ", dealer)}");
                Console.WriteLine($"A dealer kártyáinak összege: {dealer_osszeg}");

                if (dealer_osszeg > 21)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Dealer bust!");
                }
                Thread.Sleep(500);
                Console.WriteLine("Te nyertél!");
            }

            else
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Döntetlen!");
            }
        }
    }
}
