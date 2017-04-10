using System
    ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner.Entity;

namespace RobotCleaner.UnitTests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void CreateRobot()
        {
            RobotInstructions commands = new RobotInstructions();
            commands.GetInputInstructions("0");
            commands.GetInputInstructions("0 0");
            Robot robot = new Robot(commands);
            Assert.IsNotNull(robot);
        }
        [TestMethod]
        public void Robot_WithZeroCommand()
        {
            RobotInstructions commands = new RobotInstructions();
            commands.GetInputInstructions("0");
            commands.GetInputInstructions("6 8");
            Robot robot = new Robot(commands);
            robot.FollowInstructions();
            Assert.AreEqual(commands._position.X, robot._position.X);
            Assert.AreEqual(commands._position.Y, robot._position.Y);
        }
        [TestMethod]
        public void Robot_WithOnePlaceCleaned()
        {
            RobotInstructions commands = new RobotInstructions();
            commands.GetInputInstructions("0");
            commands.GetInputInstructions("6 8");
            Robot robot = new Robot(commands);
            robot.FollowInstructions();
            string output = robot.PrintCleanedPlaces();
            Assert.AreEqual("=> Cleaned: 1", output);

        }
        [TestMethod]
        public void MoveRobot_WithOneCommand()
        {
            RobotInstructions commands = new RobotInstructions();
            commands.GetInputInstructions("1");
            commands.GetInputInstructions("6 8");
            commands.GetInputInstructions("E 1");
            Robot robot = new Robot(commands);
            robot.FollowInstructions();
            Assert.AreEqual(commands._position.X+1, robot._position.X);
            Assert.AreEqual(commands._position.Y, robot._position.Y);

        }
        [TestMethod]
        public void Robot_WithTwoPlaceCleaned()
        {
            RobotInstructions commands = new RobotInstructions();
            commands.GetInputInstructions("1");
            commands.GetInputInstructions("6 8");
            commands.GetInputInstructions("E 1");
            Robot robot = new Robot(commands);
            robot.FollowInstructions();
            string output = robot.PrintCleanedPlaces();
            Assert.AreEqual("=> Cleaned: 2", output);

        }
        [TestMethod]
        public void MoveRobot_With_OutOfRangeCoordinates()
        {
            RobotInstructions commands = new RobotInstructions();
            commands.GetInputInstructions("1");
            commands.GetInputInstructions("-100000 200000");
            commands.GetInputInstructions("E 1");           
            Robot robot = new Robot(commands);
            robot.FollowInstructions();
            Assert.IsTrue(robot._position.ValidateInPlan(robot._position));

        }
        [TestMethod]
        public void Robot_Will_Never_Go_OutSide_Of_GridRange()
        {
            RobotInstructions commands = new RobotInstructions();
            commands.GetInputInstructions("1");
            commands.GetInputInstructions("-100000 100000");
            commands.GetInputInstructions("W 1");
            Robot robot = new Robot(commands);
            robot.FollowInstructions();            
            Assert.AreEqual(commands._position.X, robot._position.X);
            Assert.AreEqual(commands._position.Y, robot._position.Y);

        }
        [TestMethod]
        public void Robot_Will_Not_Move_More_Than_999999_Steps()
        {
            RobotInstructions commands = new RobotInstructions();
            commands.GetInputInstructions("1");
            commands.GetInputInstructions("0 0");
            commands.GetInputInstructions("N 100000");
            Robot robot = new Robot(commands);
            robot.FollowInstructions();
            //Robot will move towards North, i.e Y++            
            Assert.AreEqual(99999, robot._position.Y);

        }
      
        [TestMethod]
        public void MoveRobot_InSideTheBounds()
        {
            RobotInstructions commands = new RobotInstructions();
            commands.GetInputInstructions("1");
            commands.GetInputInstructions("-6 8");
            commands.GetInputInstructions("W 1");
            Robot robot = new Robot(commands);
            robot.FollowInstructions();
            //Robot will move one position towards West
            Assert.AreEqual(commands._position.X-1, robot._position.X);
            Assert.AreEqual(commands._position.Y, robot._position.Y);

        }
       
        [TestMethod]
        public void MoveRobot_In_All_Directions()
        {
            
            RobotInstructions commands = new RobotInstructions();
            commands.GetInputInstructions("4");
            commands.GetInputInstructions("0 0");
            commands.GetInputInstructions("N 5");
            commands.GetInputInstructions("E 5");
            commands.GetInputInstructions("S 5");
            commands.GetInputInstructions("W 5");            
            
            Robot robot = new Robot(commands);
            
            robot.FollowInstructions();
            string output = robot.PrintCleanedPlaces();            
            Assert.AreEqual("=> Cleaned: 20", output);
        }
    }
}
