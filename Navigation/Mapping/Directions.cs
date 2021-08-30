using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Mapping
{
    public class Directions
    {
        public static int[,] fourWays = new int[4, 2] {
            {0, 1},  //вверх
            {1, 0},  //вправо
            {-1, 0}, //влево
            {0, -1}  //вниз

        };

        public static string[] fourWaysNames = new string[4] {
            "N",
            "E",
            "W",
            "S"

        };
    }
}
