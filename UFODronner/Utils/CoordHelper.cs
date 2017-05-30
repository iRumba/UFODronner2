using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFODronner.Utils
{
    public static class CoordHelper
    {
        public static double GetViewCoord(double coord, double scale)
        {
            return coord * scale;
        }

        public static double GetRealCoord(double coord, double scale)
        {
            return coord / scale;
        }
    }
}
