using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFODronner.ViewModels
{
    public class ViewModelBase<T> : Notifier where T : class, ICloneable
    {
        public T Model { get; protected set; }
        protected T Source { get; set; }

        protected ViewModelBase(T model)
        {
            ChangeModel(model);
        }

        //protected ViewModelBase() : this (new T()) { }

        public virtual void Load(T model)
        {
            ChangeModel(model);
            OnPropertyChanged(string.Empty);
        }

        //public virtual T Save()
        //{

        //}

        void ChangeModel(T model)
        {
            Source = model;
            Model = (T)Source.Clone();
        }
    }
}
