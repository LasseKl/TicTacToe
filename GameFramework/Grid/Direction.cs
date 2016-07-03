using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public enum Direction
    {
        Upper = 1,
        Lower = 2,
        Left = 4,
        Right = 8,

        UpperLeft = Upper | Left,
        UpperRight = Upper | Right,
        LowerLeft = Lower | Left,
        LowerRight = Lower | Right
    }
}
