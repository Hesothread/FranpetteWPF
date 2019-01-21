using System;
using System.Collections.Generic;
using System.Text;

namespace FranpetteLib.Model
{
    class FNotification : AFranpetteObject
    {
        private object _data;
        public object Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }

        public override String GetFType()
        {
            return "FNotification";
        }
    }
}
