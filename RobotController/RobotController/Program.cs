using System;
using RobotLibrary;

namespace FactortyRobotController
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            var controller = new RobotController();

            var move = new MoveCommand(robot);
            move.Distance = 1000;
            controller.ExecuteCommand(move);

            var turn = new TurnCommand(robot);
            turn.Angle = 45;
            controller.ExecuteCommand(turn);

            var beep = new BeepCommand(robot);
            controller.ExecuteCommand(beep);
        }
    }
}
