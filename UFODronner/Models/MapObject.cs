using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFODronner.Models
{
    public class MapObject : ICloneable
    {
        double _x;
        double _y;
        string _name;
        //Map _parent;

        public MapObject() : this(0, 0) { }

        public MapObject(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public double X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
            //var res = new MapObject
            //{
            //    X = X,
            //    Y = Y,
            //    Name = Name
            //}
        }

        //public Map Parent
        //{
        //    get
        //    {
        //        return _parent;
        //    }

        //    set
        //    {
        //        if (_parent != null)
        //            _parent.Remove(this);
        //        if (value != null)
        //            value.Add(this);
        //        SetParent(value);
        //    }
        //}

        //internal void SetParent(Map parent)
        //{
        //    _parent = parent;
        //}
    }

    public class MapObject<T> : MapObject where T : class, ICloneable
    {
        T _packagedObject;

        public MapObject(T packagedObject) : this(packagedObject, 0, 0) { }

        public MapObject(T packagedObject, double x, double y) : base(x, y)
        {
            PackagedObject = packagedObject;
        }

        public T PackagedObject
        {
            get
            {
                return _packagedObject;
            }

            set
            {
                _packagedObject = value;
            }
        }

        public override object Clone()
        {
            var res = (MapObject<T>)base.Clone();
            res.PackagedObject = (T)PackagedObject.Clone();
            return res;
        }
    }
}
