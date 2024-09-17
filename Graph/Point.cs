using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

    
        public string DetermineQuarter()
        {
            if (X > 0 && Y > 0)
                return "першій";
            if (X < 0 && Y > 0)
                return "другій";
            if (X < 0 && Y < 0)
                return "третій";
            if (X > 0 && Y < 0)
                return "четвертій";
            return "на осі";
        }
    }

}
