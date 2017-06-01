using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFODronner.Utils;

namespace UFODronner.ViewModels
{
    public class DonateItem
    {
        public RelayCommand OpenUrl { get; set; }

        public int Value { get; set; }

        public DonateItem()
        {
            OpenUrl = new RelayCommand();
            OpenUrl.Executed += OpenUrl_Executed;
        }

        private void OpenUrl_Executed(object obj)
        {
            var url = Url;
            if (!string.IsNullOrWhiteSpace(url))
                System.Diagnostics.Process.Start(url);
        }

        public string DisplayedValue
        {
            get
            {
                return Value <= 0 ? "?" : Value.ToString();
            }
        }

        public string Url
        {
            get
            {
                var sb = new StringBuilder("https://www.paypal.me/iRumba");
                if (Value > 0)
                    sb.Append($"/{Value}");
                return sb.ToString();
            }
        }
    }
}
