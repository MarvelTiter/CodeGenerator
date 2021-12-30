using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core
{
    public class ObservableObject : INotifyPropertyChanged, ICloneable
    {
        public bool SetValue<T>(ref T oldValue, T newValue, [CallerMemberName] string name = null)
        {
            if (Equals(oldValue, newValue))
                return false;
            oldValue = newValue;
            RaisePropertyChanged(name);
            return true;
        }

        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
