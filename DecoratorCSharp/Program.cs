using System;

namespace DecoratorCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new ConsoleLog();
            var robot = new PointRobot(log);

            MoveRobot("Point", robot, log);

            var loggingRobot = new LoggingRobot(robot, log);

            MoveRobot("Logging", loggingRobot, log);

            var recordingRobot = new RecordingRobot(loggingRobot);

            MoveRobot("Recording", recordingRobot, log);

            log.LogMessage(Environment.NewLine);

            recordingRobot.Replay();

            Console.ReadKey();
        }

        private static void MoveRobot(string name, IRobot robot, ILog log)
        {
            log.LogMessage(Environment.NewLine);
            log.LogMessage($"Moving the {name} Robot");

            robot.GoRight();
            robot.GoUp();
            robot.GoDown();
            robot.GoLeft();

            Console.ReadKey();
        }
    } 
}
