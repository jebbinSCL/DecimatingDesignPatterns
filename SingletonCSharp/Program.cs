using System;

namespace SingletonCSharp
{
    static class RandomUser
    {
        public static void WriteRandomNumbers()
        {
            var random = GlobalRandom.GetInstance();
            Console.WriteLine(random.Next());

            var sameRandom = GlobalRandom.GetInstance();
            Console.WriteLine(random.Next());

            var randomsAreTheSame = ReferenceEquals(random, sameRandom);
            Console.WriteLine($"Randoms are the same: {randomsAreTheSame}");
        }
    }

    class GlobalRandom : Random
    {
        private static GlobalRandom instance = new GlobalRandom(11123123);
        private GlobalRandom(int seed) : base(seed) { }
        public static GlobalRandom GetInstance()
        {
            return instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RandomUser.WriteRandomNumbers();
            Console.ReadLine();
        }
    }
}
