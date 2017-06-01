using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFODronner.Models
{
    public class Dron1 : MapObject<Dron>
    {
        public Dron1() : base(new Dron()
        {
            MinAngle = 30,
            MaxAngle = 60,
            MinSensitivity = 20,
            MaxSensitivity = 40,
            InterferenceRadius = 100,
        })
        {
            Name = "Dron1 (803)";
        }
    }
}
