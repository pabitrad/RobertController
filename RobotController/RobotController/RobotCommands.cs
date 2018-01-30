using System;
using System.Collections.Generic;
using RobotLibrary;

namespace FactortyRobotController
{
    /// <summary>
    /// Base class for Move, Turn and Beep commands
    /// </summary>
    public abstract class RobotCommandBase
    {
        protected Robot _robot;

        public RobotCommandBase(Robot robot)
        {
            if (robot == null)
            {
                throw new ArgumentNullException("robot can not be null.");
            }

            _robot = robot;
        }

        public abstract void Execute();
    }

    /// <summary>
    /// Class to store Move Robot Command
    /// </summary>
    public class MoveCommand : RobotCommandBase
    {
        public int Distance { get; set; }

        public MoveCommand(Robot robot) : base(robot) { }

        public override void Execute()
        {
            _robot.Move(Distance);
        }
    }

    /// <summary>
    /// Class to store Turn Robot Command
    /// </summary>
    public class TurnCommand : RobotCommandBase
    {
        public int Angle { get; set; }

        public TurnCommand(Robot robot) : base(robot) { }

        public override void Execute()
        {
            _robot.Turn(Angle);
        }
    }

    /// <summary>
    /// Class to store Beep Robot Command
    /// </summary>
    public class BeepCommand : RobotCommandBase
    {
        public BeepCommand(Robot robot) : base(robot) { }

        public override void Execute()
        {
            _robot.Beep();
        }
    }

    /// <summary>
    /// This class contains methods to execute commands and store the commands to reply
    /// </summary>
    public class RobotController
    {
        private List<RobotCommandBase> _listCommand = new List<RobotCommandBase>();

        public int CommandCount
        {
            get { return _listCommand.Count;  }
        }

        /// <summary>
        /// Execute a single command
        /// </summary>
        /// <param name="command"> This can be Move, Turn or Beep command</param>
        public void ExecuteCommand(RobotCommandBase command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command can not be null.");
            }

            _listCommand.Add(command);

            command.Execute();
        }

        /// <summary>
        /// Execute all the commands stored in list
        /// </summary>
        public void ExecuteAllCommands()
        {
            foreach (var robotCommand in _listCommand)
            {
                robotCommand.Execute();
            }
        }
    }
}
