using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFODronner.ViewModels
{
    public class ScaledObject : Notifier
    {
        protected double Scale { get; set; }

        public virtual void SetScale(double scale)
        {
            Scale = scale;
        }
    }
}
