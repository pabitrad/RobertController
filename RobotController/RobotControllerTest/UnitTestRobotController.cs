using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotLibrary;
using FactortyRobotController;

namespace RobotControllerTest
{
    /// <summary>
    /// Test class for RobotController
    /// </summary>
    [TestClass]
    public class UnitTestRobotController
    {
        /// <summary>
        /// Test case for RobertController.ExecuteAllCommands() to check command count at the end
        /// This would ensure that all commands executed successfully and command stored in memory and can be replayed later
        /// </summary>
        [TestMethod]
        public void TestExecuteAllCommands()
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

            Assert.AreEqual(controller.CommandCount, 3);
        }

        /// <summary>
        /// Test case to test null argument exception, when robot passed as null to method RobertController.ExecuteCommand()
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestExecuteCommandForNullArgument()
        {
            var controller = new RobotController();
            controller.ExecuteCommand(null);
        }

        /// <summary>
        /// Test case to test null argument exception when robot is passed as null to any command object constructor (Move, Turn or Beep)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRobotAsNull()
        {
            var controller = new RobotController();

            var move = new MoveCommand(null);
            move.Distance = 1000;
            controller.ExecuteCommand(move);
        }
    }
}
