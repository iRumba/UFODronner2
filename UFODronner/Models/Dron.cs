using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFODronner.Models
{
    public class Dron : ICloneable
    {
        double _sensitivity;

        public double InterferenceRadius { get; set; }

        public double MinAngle { get; set; }

        public double MaxAngle { get; set; }

        public double MinSensitivity { get; set; }

        public double MaxSensitivity { get; set; }

        public double RotateAngle { get; set; }

        public double Sensitivity
        {
            get
            {
                return _sensitivity = Math.Max(MinSensitivity, Math.Min(_sensitivity, MaxSensitivity));
            }
            set
            {
                _sensitivity = Math.Max(MinSensitivity, Math.Min(value, MaxSensitivity));
            }
        }

        public double SensitivityPercent
        {
            get
            {
                return (Sensitivity - MinSensitivity) / (MaxSensitivity - MinSensitivity);
            }
        }

        public void RefreshSensitivity()
        {
            Sensitivity = MinSensitivity;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
