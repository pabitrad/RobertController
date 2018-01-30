using System;

namespace RobotLibrary
{
    /// <summary>
    /// Interface for Robot
    /// </summary>
    public interface IRobot
    {
        void Move(double distance);
        void Turn(double angle);
        void Beep();
    }

    /// <summary>
    /// Class to implement IRobot interface
    /// </summary>
    public class Robot : IRobot
    {
        public void Move(double distance)
        {
            Console.WriteLine("Robot is moved by distance {0}.", + distance);
        }

        public void Turn(double angle)
        {
            Console.WriteLine("Robot is Rotated by angle {0}.", angle);
        }

        public void Beep()
        {
            Console.WriteLine("Beep is generated.");
        }
    }
}
