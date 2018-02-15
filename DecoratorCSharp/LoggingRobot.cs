using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorCSharp
{
    public class LoggingRobot : IRobot
    {
        private readonly IRobot robot;
        private readonly ILog log;

        public LoggingRobot(IRobot robot, ILog log)
        {
            this.robot = robot;
            this.log = log;
        }

        public void GoDown()
        {
            this.ReportCommand("MOVE DOWN");
            this.robot.GoDown();
        }

        public void GoLeft()
        {
            this.ReportCommand("MOVE LEFT");
            this.robot.GoLeft();
        }

        public void GoRight()
        {
            this.ReportCommand("MOVE RIGHT");
            this.robot.GoRight();
        }

        public void GoUp()
        {
            this.ReportCommand("MOVE UP");
            this.robot.GoUp();
        }

        private void ReportCommand(string command)
        {
            this.log.LogMessage($"The robot has been commanded to {command}");
        }
    }
}
