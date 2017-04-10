using System;
namespace RobotCleaner.Entity
{
    public class Position: IComparable<Position>
    
    {
     
        private int _xCoordinate;        
        private int _yCoordinate;

        
        public int X
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }

        public int Y
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        
        public Position(int xPosition, int yPosition)
        {
            _xCoordinate = xPosition;
            _yCoordinate = yPosition;
        }

        public bool ValidateInPlan(Position position)
        {

            if (position.X >= -100000 && position.X <= 100000 && position.Y >= -100000 && position.Y <= 100000)
            {

                return true;
            }
            else
            {
                if (position.X < -100000)
                    position.X = -100000;
                if (position.X > 100000)
                    position.X = 100000;

                if (position.Y < -100000)
                    position.Y = -100000;
                if (position.Y > 100000)
                    position.Y = 100000;
                return false;
            }

        }

        //To save cleaned positions in SortedSet, it's necessary to implement IComparable

        public int CompareTo(Position other)
        {
            if (X == other.X)
                return Y.CompareTo(other.Y);
            return X.CompareTo(other.X);
        }
    }
}
