using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.Entity
{
    public class MovementInstruction
    {
       public Direction RobotDirection { get; set; }
       public int StepstoMove { get; set; }
    }
}
