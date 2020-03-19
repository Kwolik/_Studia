using System;
using System.Collections.Generic;

namespace Zbiory_miękkie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Spodnie:");
            var A = new Trousers(Trousers.P.jeans, Trousers.P.modern, Trousers.P.na_zamek);
            var B = new Trousers(Trousers.P.jeans, Trousers.P.klasyczne, Trousers.P.granatowe, Trousers.P.na_guziki);
            Console.Write($"\nOsoba A:\n");;
            A.Show();
            Console.Write($"\nOsoba B:\n");
            B.Show();
            Console.WriteLine("\n = = = = = = = = = \n");
            Console.WriteLine("Warzywa:");
            var Aa = new Vegetables(Vegetables.P.świeże, Vegetables.P.ostre, Vegetables.P.czerwone);
            var Bb = new Vegetables(Vegetables.P.mrożone, Vegetables.P.zielone, Vegetables.P.słodkie, Vegetables.P.liściaste);
            var Cc = new Vegetables(Vegetables.P.świeże, Vegetables.P.zielone, Vegetables.P.czerwone, Vegetables.P.słodkie);
            Console.Write($"\nOsoba A:\n"); ;
            Aa.Show();
            Console.Write($"\nOsoba B:\n");
            Bb.Show();
            Console.Write($"\nOsoba C:\n");
            Cc.Show();
        }
    }

    class Trousers
    {
        private Dictionary<int, int> scores;

        public enum P // Parametry
        {
            drogie, tanie, jeans, dresowe, klasyczne, modern, fit, granatowe, czarne, na_zamek, na_guziki
        }

        public Trousers(params P[] p)
        {
            scores = SetScores();

            foreach (var parameters in p)
                foreach (var item in types)
                    if (item.Value.Contains(parameters))
                        scores[item.Key]++;
        }

        private Dictionary<int, List<P>> types = new Dictionary<int, List<P>>()
        {
            { 0, new List<P>() { P.tanie, P.dresowe, P.czarne, P.modern } },
            { 1, new List<P>() { P.jeans, P.klasyczne, P.fit, P.na_zamek } },
            { 2, new List<P>() { P.tanie, P.modern, P.granatowe, P.na_guziki } },
            { 3, new List<P>() { P.jeans, P.klasyczne, P.granatowe, P.na_zamek } },
            { 4, new List<P>() { P.na_zamek, P.dresowe, P.drogie, P.fit } },
        };

        private Dictionary<int, int> SetScores()
        {
            var scores = new Dictionary<int, int>();
            foreach (var item in types)
                scores.Add(item.Key, 0);

            return scores;
        }

        private Dictionary<int, int> PickBest()
        {
            int bestScore = 0;
            var best = new Dictionary<int, int>();
            foreach (var item in scores)
            {
                if (item.Value > bestScore)
                {
                    bestScore = item.Value;
                    best.Clear();
                    best.Add(item.Key, item.Value);
                }
                else if (item.Value == bestScore)
                    best.Add(item.Key, item.Value);
            }

            return best;
        }

        public void Show()
        {
            var best = PickBest();
            foreach (var item in best)
                Console.WriteLine($"Index: {item.Key} Ile wartości się zgadza: {item.Value}");
        }
    }

    class Vegetables
    {
        private Dictionary<int, int> scores;

        public enum P // Parametry
        {
            świeże, mrożone, ostre, słodkie, zielone, czerwone, lokalne, tropikalne, liściaste, bulwowe
        }

        public Vegetables(params P[] p)
        {
            scores = SetScores();

            foreach (var parameters in p)
                foreach (var item in types)
                    if (item.Value.Contains(parameters))
                        scores[item.Key]++;
        }

        private Dictionary<int, List<P>> types = new Dictionary<int, List<P>>()
        {
            { 0, new List<P>() { P.świeże, P.słodkie, P.czerwone, P.tropikalne } },
            { 1, new List<P>() { P.zielone, P.lokalne, P.bulwowe, P.mrożone } },
            { 2, new List<P>() { P.świeże, P.ostre, P.zielone, P.liściaste } },
            { 3, new List<P>() { P.świeże, P.słodkie, P.czerwone, P.tropikalne } },
            { 4, new List<P>() { P.mrożone, P.ostre, P.zielone, P.lokalne } },
        };

        private Dictionary<int, int> SetScores()
        {
            var scores = new Dictionary<int, int>();
            foreach (var item in types)
                scores.Add(item.Key, 0);

            return scores;
        }

        private Dictionary<int, int> PickBest()
        {
            int bestScore = 0;
            var best = new Dictionary<int, int>();
            foreach (var item in scores)
            {
                if (item.Value > bestScore)
                {
                    bestScore = item.Value;
                    best.Clear();
                    best.Add(item.Key, item.Value);
                }
                else if (item.Value == bestScore)
                    best.Add(item.Key, item.Value);
            }

            return best;
        }

        public void Show()
        {
            var best = PickBest();
            foreach (var item in best)
                Console.WriteLine($"Index: {item.Key} Ile wartości się zgadza: {item.Value}");
        }
    }
}
