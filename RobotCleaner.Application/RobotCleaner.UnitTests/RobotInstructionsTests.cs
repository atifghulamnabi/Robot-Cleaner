using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner.Entity;

namespace RobotCleaner.UnitTests
{
    [TestClass]
    public class RobotInstructionsTests
    {
         [TestMethod]
        public void Robot_With_Complete_Input()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("3");
            robotInstructions.GetInputInstructions("10 2");
            robotInstructions.GetInputInstructions("E 1");
            robotInstructions.GetInputInstructions("E 1");
            robotInstructions.GetInputInstructions("E 1");
            Assert.IsTrue(robotInstructions.InputsAreComplete);
        }
        [TestMethod]
        public void Robot_With_Incomplete_Input()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("10");
            robotInstructions.GetInputInstructions("10 2");
            robotInstructions.GetInputInstructions("E 0");
            Assert.IsFalse(robotInstructions.InputsAreComplete);
        }
       
        [TestMethod]
        public void Robot_With_Five_Complete_Commands()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("5");
            robotInstructions.GetInputInstructions("10 2");
            robotInstructions.GetInputInstructions("E 3");
            robotInstructions.GetInputInstructions("E 3");
            robotInstructions.GetInputInstructions("E 3");
            robotInstructions.GetInputInstructions("E 3");
            robotInstructions.GetInputInstructions("E 3");
            Assert.AreEqual(5, robotInstructions._numbersOfInstructions);
        }

        [TestMethod]
        public void Get_Ten_Thousand_InputCommands()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("10000");
            robotInstructions.GetInputInstructions("10 2");
            for (int i =0; i<10000; i++)
            {
                robotInstructions.GetInputInstructions("N 2");
            }           
            
            Assert.IsTrue(robotInstructions.InputsAreComplete);
        }
        [TestMethod]
        public void Robot_NumberOfInstructions_Less_Than_Zero()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("-1");
            robotInstructions.GetInputInstructions("10 2");
           
            Assert.AreEqual(0, robotInstructions._numbersOfInstructions);            
        }
        [TestMethod]
        public void Robot_NumberOfInstructions_Greater_Than_10000()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("15000");
            robotInstructions.GetInputInstructions("10 2");

            Assert.AreEqual(10000, robotInstructions._numbersOfInstructions);
        }
        
        [TestMethod]
        public void Robot_InputPosition()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("1");
            robotInstructions.GetInputInstructions("10 2");
         
            Assert.AreEqual(10, robotInstructions._position.X);
            Assert.AreEqual(2, robotInstructions._position.Y);
        }
        [TestMethod]
        public void Robot_One_Movement_Instruction()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("1");
            robotInstructions.GetInputInstructions("10 2");
            robotInstructions.GetInputInstructions("E 2");          

            Assert.AreEqual(1, robotInstructions._movementInstruction.Count);
        }

        [TestMethod]
        public void Robot_Movement_With_99999_Steps()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("1");
            robotInstructions.GetInputInstructions("10 2");
            robotInstructions.GetInputInstructions("E 99999");
            MovementInstruction moveCommand = robotInstructions._movementInstruction[0];

            Assert.AreEqual(99999, moveCommand.StepstoMove);
        }
        [TestMethod]
        public void Robot_Movement_With_Morethan99999_Steps()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("1");
            robotInstructions.GetInputInstructions("10 2");
            robotInstructions.GetInputInstructions("E 1500000");
            MovementInstruction moveCommand = robotInstructions._movementInstruction[0];

            Assert.AreEqual(99999, moveCommand.StepstoMove);
        }
        [TestMethod]
        public void Robot_Movement_With_Zero_Step()
        {
            RobotInstructions robotInstructions = new RobotInstructions();
            robotInstructions.GetInputInstructions("1");
            robotInstructions.GetInputInstructions("10 2");
            robotInstructions.GetInputInstructions("E 1");
            MovementInstruction moveCommand = robotInstructions._movementInstruction[0];

            Assert.AreEqual(1, moveCommand.StepstoMove);
        }
       

    }
}
