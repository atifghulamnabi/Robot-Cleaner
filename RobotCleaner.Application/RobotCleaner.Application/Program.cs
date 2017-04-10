using RobotCleaner.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RobotInstructions instructions = new RobotInstructions();

            while (!instructions.InputsAreComplete)
            {                
                instructions.GetInputInstructions(Console.ReadLine());
            }
            
            Robot robot = new Robot(instructions);
            
            robot.FollowInstructions();

            Console.WriteLine(robot.PrintCleanedPlaces());

            
            Console.ReadLine();
        }
    }
}
