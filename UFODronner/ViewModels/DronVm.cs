using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UFODronner.Models;

namespace UFODronner.ViewModels
{
    public class DronVm : MapObjectVm
    {
        //MapObject<Dron> _source;
        //double _sensitivity;
        double _value;
        double _rotateAngle;
        bool _isActivated;
        bool _canActivate = true;

        public event Action<DronVm> ActivatedChanged;

        public DronVm(MapObject<Dron> source) : base(source)
        {
            //_source = source;
        }

        public double Sensitivity
        {
            get
            {
                return TypedModel.PackagedObject.Sensitivity;
            }

            set
            {
                TypedModel.PackagedObject.Sensitivity = value;
                OnPropertyChanged(nameof(Sensitivity));
                OnPropertyChanged(nameof(Angle));
                OnPropertyChanged(nameof(Value));
            }
        }

        public MapObject<Dron> TypedModel
        {
            get
            {
                return (MapObject<Dron>)Model;
            }
        }

        public double MinSensitivity
        {
            get
            {
                return TypedModel.PackagedObject.MinSensitivity;
            }
        }

        public double MaxSensitivity
        {
            get
            {
                return TypedModel.PackagedObject.MaxSensitivity;
            }
        }

        public double MinAngle
        {
            get
            {
                return TypedModel.PackagedObject.MinAngle;
            }
        }

        public double MaxAngle
        {
            get
            {
                return TypedModel.PackagedObject.MaxAngle;
            }
        }

        public double RotateAngle
        {
            get
            {
                return TypedModel.PackagedObject.RotateAngle;
            }

            set
            {
                TypedModel.PackagedObject.RotateAngle = value;
                OnPropertyChanged(nameof(RotateAngle));
            }
        }

        public double Angle
        {
            get
            {
                return (1 - TypedModel.PackagedObject.SensitivityPercent) * (MaxAngle - MinAngle) + MinAngle;
            }
        }

        //public double AngleCoefficient
        //{
        //    get
        //    {
        //        var obj = TypedModel.PackagedObject;
        //        return (obj.MaxAngle - obj.MinAngle) / (obj.MaxSensitivity - obj.MinSensitivity);
        //    }
        //}

        public double InterferenceRadius
        {
            get
            {
                var res = new ScaledValue();
                res.Value = TypedModel.PackagedObject.InterferenceRadius;
                res.SetScale(Scale);
                return res.ViewValue;
            }
        }

        public bool IsActivated
        {
            get
            {
                return _isActivated;
            }

            set
            {
                if (_isActivated != value)
                {
                    _isActivated = value;
                    OnPropertyChanged(nameof(IsActivated));
                    ActivatedChanged?.Invoke(this);
                }
            }
        }

        public double Value
        {
            get
            {
                return CoerceValue(_value);
            }

            set
            {
                value = CoerceValue(value);
                if (value != _value)
                {
                    _value = value;
                    OnPropertyChanged(nameof(Value));
                    OnPropertyChanged(nameof(ValueAngle));
                }
            }
        }

        double CoerceValue(double value)
        {
            return Math.Round(Math.Min(Sensitivity, Math.Max(0, value)), 2);
        }

        public double ValueAngle
        {
            get
            {
                return Value / MaxSensitivity * Angle;
            }
        }

        public bool CanActivate
        {
            get
            {
                return _canActivate;
            }

            set
            {
                _canActivate = value;
                OnPropertyChanged(nameof(CanActivate));
            }
        }
    }
}
