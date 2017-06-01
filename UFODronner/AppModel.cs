using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFODronner.Models;

namespace UFODronner
{
    public class AppModel
    {
        List<Dron> _drons;
        List<Dron> _dronPrototypes;

        public event Action<Dron> DronAdded;
        public event Action<Dron> DronRemoved;

        public AppModel()
        {
            _drons = new List<Dron>();
            _dronPrototypes = new List<Dron>
            {
                new Dron
                {
                    
                }
            };
        }

        public bool CanAdd
        {
            get
            {
                return _drons.Count < 3;
            }
        }

        public void AddDron(Dron dron)
        {
            if (CanAdd)
            {
                _drons.Add(dron);
                DronAdded?.Invoke(dron);
            }
                
        }

        public void RemoveDron(Dron dron)
        {
            if (_drons.Remove(dron))
                DronRemoved?.Invoke(dron);
        }

        public IEnumerable<Dron> GetDrons()
        {
            foreach (var dron in _drons)
                yield return dron;
        }
    }
}
