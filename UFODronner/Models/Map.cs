using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFODronner.Models
{
    public class Map : ICloneable
    {
        double _width;
        double _height;

        public double Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public double Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
