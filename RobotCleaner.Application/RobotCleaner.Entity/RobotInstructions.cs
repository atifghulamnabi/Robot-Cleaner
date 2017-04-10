using RobotCleaner.Entity;
using System;
using System.Collections.Generic;

namespace RobotCleaner
{
    public class RobotInstructions
    {

        public int _numbersOfInstructions;
        public List<string> _inputInstructions;
        const int _firstTwoInputs = 2;
        public Position _position;
        public List<MovementInstruction> _movementInstruction;
        private const int MaxSteps = 99999;
        private const int MinSteps = 1;
       
        public RobotInstructions()
         {
            _numbersOfInstructions = 0;
            _inputInstructions = new List<string>();
            _movementInstruction = new List<MovementInstruction>();
            
         }
       
        public void GetInputInstructions(string inputString)
        {
            if (!InputsAreComplete)
            {
                if (_inputInstructions.Count == 0)
                {
                    SetNumbersOfCommands(inputString);
                }
                else if (_inputInstructions.Count == 1)
                {
                    SetPosition(inputString);
                }
                else
                {
                    _movementInstruction.Add(SplitMovementInstruction(inputString));
                }
                _inputInstructions.Add(inputString);

            }       

        }

        private MovementInstruction SplitMovementInstruction(string movementInstruction)
        {
            MovementInstruction _movementInstruction = new MovementInstruction();   
            string[] movementTokens = movementInstruction.Split(' ');
            switch (movementTokens[0].ToUpper())
            {
                case "N":
                    _movementInstruction.RobotDirection = Direction.North;
                    break;
                case "S":
                    _movementInstruction.RobotDirection = Direction.South;
                    break;
                case "E":
                    _movementInstruction.RobotDirection = Direction.East;
                    break;
                case "W":
                    _movementInstruction.RobotDirection = Direction.West;
                    break;               
            }
            _movementInstruction.StepstoMove = int.Parse(movementTokens[1]);

            if (_movementInstruction.StepstoMove > MaxSteps)
                _movementInstruction.StepstoMove = MaxSteps;
            if (_movementInstruction.StepstoMove < MinSteps)
                _movementInstruction.StepstoMove = MinSteps;

            return _movementInstruction;
            
        }

        private void SetPosition(string inputString)
        {
            
            string[] coordinates = inputString.Split(' ');
            if (coordinates.Length > 1)
            {
                int x = int.Parse(coordinates[0]);
                int y = int.Parse(coordinates[1]);
                _position = new Position(x, y);                
            }
        }

        private void SetNumbersOfCommands(string inputString)
        {   
            _numbersOfInstructions = int.Parse(inputString);
            if (_numbersOfInstructions < 0)
                _numbersOfInstructions = 0;
            if (_numbersOfInstructions > 10000)
                _numbersOfInstructions = 10000;                   
        }

        public bool InputsAreComplete
        {
            get
            {
                return _inputInstructions.Count == _numbersOfInstructions+ _firstTwoInputs;
            }

        }


    }
}