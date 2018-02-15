using System;

namespace SingletonCSharp
{
    static class RandomUser
    {
        public static void WriteRandomNumbers()
        {
            var random = GlobalRandom.GetInstance();
            DoSomethingRandom(random);

            var sameRandom = GlobalRandom.GetInstance();
            DoSomethingRandom(sameRandom);

            var randomsAreTheSame = ReferenceEquals(random, sameRandom);
            Console.WriteLine($"Randoms are the same: {randomsAreTheSame}");
        }

        private static void DoSomethingRandom(GlobalRandom random)
        {
            Console.WriteLine(random.Next());
        }
    }

    class GlobalRandom : Random
    {
        private static readonly GlobalRandom instance = new GlobalRandom(11123123);

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
