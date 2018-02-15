using System.Drawing;

namespace DecoratorCSharp
{
    public class PointRobot : IRobot
    {
        private Point location = new Point(0, 0);
        private readonly ILog log;

        public PointRobot(ILog log)
        {
            this.log = log;
            ReportLocation();
        }

        public void GoDown()
        {
            this.UpdateLocation(this.location.X, this.location.Y - 1);
            this.ReportLocation();
        }

        public void GoLeft()
        {
            this.UpdateLocation(this.location.X - 1, this.location.Y);
            this.ReportLocation();
        }

        public void GoRight()
        {
            this.UpdateLocation(this.location.X + 1, this.location.Y);
            this.ReportLocation();
        }

        public void GoUp()
        {
            this.UpdateLocation(this.location.X, this.location.Y + 1);
            this.ReportLocation();
        }

        private void UpdateLocation(int newX, int newY)
        {
            this.location = new Point(newX, newY);
        }

        private void ReportLocation()
        {
            this.log.LogMessage($"I AM NOW AT ( {location.X:00}, {location.Y:00} )");
        }
    }
}
