using System;
using System.Collections.Generic;
namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<object> kartyak = new List<object> { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, "Ász", "Ász", "Ász", "Ász", "Bubi", "Bubi", "Bubi", "Bubi", "Dáma", "Dáma", "Dáma", "Dáma", "Király", "Király", "Király", "Király" };
            List<object> jatekos = new List<object> { };
            List<object> dealer = new List<object> { };

            for (int i = 0; i < 2; i++)
            {
                int kartya = rnd.Next(kartyak.Count);
                jatekos.Add(kartyak[kartya]);
                kartyak.Remove(kartyak[kartya]);
                kartya = rnd.Next(kartyak.Count);
                dealer.Add(kartyak[kartya]);
                kartyak.Remove(kartyak[kartya]);
            }

            Console.WriteLine($"A kártyáid: {string.Join(", ", jatekos)}");
            Console.WriteLine($"A dealer egyik kártyája: {dealer[0]}");

            Console.Write($"Válassz: Hit (1) vagy Stand (2)");
            int valasztas = Convert.ToInt32(Console.ReadLine());


        }
    }
}
