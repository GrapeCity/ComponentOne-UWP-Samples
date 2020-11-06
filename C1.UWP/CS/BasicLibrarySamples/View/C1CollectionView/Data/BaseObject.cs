using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;

namespace BasicLibrarySamples
{
    /// <summary>
    /// Object that implements INotifyPropertyChanged.
    /// </summary>
    public class BaseObject : INotifyPropertyChanged
    {
        // ** INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        protected bool SetValue<T>(ref T field, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Object that implements INotifyPropertyChanged and IEditableObject.
    /// </summary>
    public class BaseEditableObject : BaseObject, IEditableObject
    {
        object _clone;
        public void BeginEdit()
        {
            _clone = this.MemberwiseClone();
        }
        public void CancelEdit()
        {
            if (_clone != null)
            {
                foreach (var pi in this.GetType().GetRuntimeProperties())
                {
                    if (pi.CanRead && pi.CanWrite)
                    {
                        var value = pi.GetValue(_clone);
                        pi.SetValue(this, value);
                    }
                }
            }
            _clone = null;
        }
        public void EndEdit()
        {
            _clone = null;
        }
    }

}
