using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorCSharp
{
    public class RecordingRobot : IRobot, IRobotRecorder
    {
        private IList<Action> commands;

        private readonly IRobot robot;

        public RecordingRobot(IRobot robot)
        {
            this.commands = new List<Action>();
            this.robot = robot;
        }

        public void GoDown()
        {
            this.commands.Add(this.robot.GoDown);
            this.robot.GoDown();
        }

        public void GoLeft()
        {
            this.commands.Add(this.robot.GoLeft);
            this.robot.GoLeft();
        }

        public void GoRight()
        {
            this.commands.Add(this.robot.GoRight);
            this.robot.GoRight();
        }

        public void GoUp()
        {
            this.commands.Add(this.robot.GoUp);
            this.robot.GoUp();
        }

        public void Replay()
        {
            foreach (var command in this.commands)
            {
                command();
            }
        }

        public void Reset()
        {
            this.commands.Clear();
        }
    }
}
