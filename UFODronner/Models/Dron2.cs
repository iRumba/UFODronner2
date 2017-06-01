using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFODronner.Models
{
    public class Dron2 : MapObject<Dron>
    {
        public Dron2() : base(new Dron()
        {
            MinAngle = 10,
            MaxAngle = 40,
            MinSensitivity = 40,
            MaxSensitivity = 50,
            InterferenceRadius = 150,
        })
        {
            Name = "Dron2 (805)";
        }
    }
}
