using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner.Entity;

namespace RobotCleaner.UnitTests
{
    [TestClass]
    public class PositionTests
    {

        [TestMethod]
        public void Set_Coordinates_Of_Position_To_0_By_Constructor()
        {

            int xPosition = 0;
            int yPosition = 0;

            Position actualPosition = new Position(xPosition, yPosition);

            Assert.AreEqual(xPosition, actualPosition.X);
            Assert.AreEqual(yPosition, actualPosition.Y);
        }

        [TestMethod]
        public void Set_Values_For_Coordinates_Of_Position_By_Constructor()
        {
            int xPosition = 100;
            int yPosition = 200;

            Position actualPosition = new Position(100, 200);    
                   
            Assert.AreEqual(xPosition, actualPosition.X);
            Assert.AreEqual(yPosition, actualPosition.Y);
        }

        [TestMethod]
        public void Set_Cooridinates_Of_Position_OutOfRange()
        {

            int xPosition = -200000;
            int yPosition = 200000;

            Position position = new Position(xPosition, yPosition);
            
            Assert.IsFalse(position.ValidateInPlan(position));
           
        }
        //Cleaned Positions will be saved in SortedSet<Position> with an order, following are tests just for position comparison
        //These are just additional tests, I am using a built in generic collection to save positions.
        //First idea to save position in boolian 2D array couldn't work out due to memory limits for -100,000 to 100,000 positions
        //Second Idea, a List of strings also grows into a large , when it comes to store -100,000 to 100,000 locations

        [TestMethod]
        public void Compare_SamePositions()
        {
            
            int xPosition = 15;
            int yPosition = 25;

            Position actual = new Position(xPosition, yPosition);
            Position target = new Position(xPosition, yPosition);  
            
            Assert.AreEqual(0, actual.CompareTo(target));
        }
       
        [TestMethod]
        public void Compare_Small_X_With_Large_X_ReturnsNegativeValue()
        {

            int xPosition = 15;
            int yPosition = 50;

            Position actual = new Position(xPosition, yPosition);
            Position target = new Position(20, 50);

            Assert.AreEqual(-1, actual.CompareTo(target));
        }
        [TestMethod]
        public void Compare_Large_X_With_Small_X_ReturnsPositiveValue()
        {

            int xPosition = 100;
            int yPosition = 15;
            Position actual = new Position(xPosition, yPosition);

            Position target = new Position(50, 15);

            Assert.AreEqual(1, actual.CompareTo(target));
        }
       
        [TestMethod]
        public void Compare_Small_Y_With_Large_Y_ReturnsNegativeValue()
        {

            int xPosition = 50;
            int yPosition = 15;
            Position actual = new Position(xPosition, yPosition);

            Position target = new Position(50, 20);

            Assert.AreEqual(-1, actual.CompareTo(target));
        }
        [TestMethod]
        public void Compare_Large_Y_With_Small_Y_ReturnsPositiveValue()
        {

            int xPosition = 15;
            int yPosition = 100;
            Position actual = new Position(xPosition, yPosition);

            Position target = new Position(15, 50);

            Assert.AreEqual(1, actual.CompareTo(target));
        }
        

    }
}
