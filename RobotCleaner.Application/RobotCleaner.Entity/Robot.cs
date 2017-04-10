using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.Entity
{
    public class Robot
    {
        public Position _position;
        private RobotInstructions _instructions;                
        private SortedSet<Position> _cleanedPlaces;

        public Robot(RobotInstructions instructions)
        {
            
            _instructions = instructions;
            _position = new Position(_instructions._position.X,_instructions._position.Y);            
            _cleanedPlaces = new SortedSet<Position>();            
            _cleanedPlaces.Add(_instructions._position);
        }
        
        public void FollowInstructions()
        {
            foreach (MovementInstruction move in _instructions._movementInstruction)
            {
                for (int i = 0; i < move.StepstoMove; i++)
                {
                    if(_position.ValidateInPlan(_position))
                    {                       
                        MoveRobot(move);
                    }
                }
            }
        }
        private void MoveRobot(MovementInstruction move)
        {
            switch (move.RobotDirection)
            {
                case Direction.North:
                    _position.Y++;
                    break;
                case Direction.East:
                    _position.X++;
                    break;
                case Direction.South:
                    _position.Y--;
                    break;
                case Direction.West:
                    _position.X--;
                    break;
            }

            _position.ValidateInPlan(_position);

            Position cleanedPosition = new Position(_position.X, _position.Y);
            
             _cleanedPlaces.Add(cleanedPosition);           
        }

        public string PrintCleanedPlaces()
        {
            return string.Format("=> Cleaned: {0}", _cleanedPlaces.Count);
        }
    }
}
