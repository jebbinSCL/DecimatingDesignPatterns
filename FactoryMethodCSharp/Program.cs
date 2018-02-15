using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FactoryMethodCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var asteroids = new[] {
                Asteroid.Large(new Point(23, 10)),
                Asteroid.Medium(new Point(16, 21)),
                Asteroid.Small(new Point(4, 5)),
            };

            Draw(asteroids);
            
            var random = new Random(DateTime.Now.Millisecond);
            var randomAsteroids = Enumerable.Range(0, 100).Select(i => Asteroid.Random(random, 50, 50));

            Draw(randomAsteroids);

            Console.ReadKey();
        }

        private static void Draw(IEnumerable<Asteroid> asteroids)
        {
            foreach (var asteroid in asteroids)
            {
                asteroid.Draw();
            }

            Console.ReadKey();
        }
    }

    public interface IAsteroid
    {
        void Draw();
    }

    public class Asteroid : IAsteroid
    {
        public Point CenterLocation { get; private set; }

        /// <summary>
        /// Contains a collection of points which represent the translations from the <see cref="this.Location"/> too the boundary of this asteroid.
        /// </summary>
        private IEnumerable<Point> boundaryTranslations;

        private Asteroid(Point centerLocation, IEnumerable<Point> boundaryTranslations) {
            this.CenterLocation = centerLocation;
            this.boundaryTranslations = boundaryTranslations;
        }

        public void Draw()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append($"Center: {this.CenterLocation}, Boundaries: ");

            foreach (var point in this.boundaryTranslations)
            {
                str.Append(point);
            }

            return str.ToString();
        }

        public static Asteroid Large(Point location)
        {
            return new Asteroid(
                location,
                new[] { new Point(3, 3), new Point(3, -3), new Point(-3, -3), new Point(-3, 3) }
            );
        }

        public static Asteroid Medium(Point location)
        {
            return new Asteroid(
                location,
                new[] { new Point(2, 2), new Point(2, -2), new Point(-2, -2), new Point(-2, 2) }
            );
        }

        public static Asteroid Small(Point location)
        {
            return new Asteroid(
                location,
                new[] { new Point(1, 1), new Point(1, -1), new Point(-1, -1), new Point(-1, 1) }
            );
        }

        internal static Asteroid Random(Random random, int gameWidth, int gameHeight)
        {
            var location = new Point(random.Next(0, gameWidth), random.Next(0, gameHeight));

            var size = random.Next(0, 3);

            switch (size)
            {
                case 0: return Small(location);
                case 1: return Medium(location);
                case 2: return Large(location);
                default: throw new InvalidOperationException($"Whoops: {size}");
            }
        }
    }
}
