using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UFODronner.Models;
using UFODronner.ViewModels;

namespace UFODronner.TemplateSelectors
{
    public class MapObjectTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var dron = item as DronVm;
            if (dron == null)
                return null;

            FrameworkElement element = container as FrameworkElement;

            try
            {
                var res = element.FindResource(dron.Name) as DataTemplate;
                return res;
            }
            catch
            {
                return null;
            }
        }
    }
}
