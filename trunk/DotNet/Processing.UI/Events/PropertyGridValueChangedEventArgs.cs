using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkey.Processing.UI
{
    public class PropertyItemValueChangedEventArgs : EventArgs
    {
        public PropertyItemValueChangedEventArgs(String name, Object value)
        {
            _name = name;
            _value = value;
        }

        private String _name = String.Empty;
        public String Name
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

        private Object _value = null;
        public Object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }

    public delegate void PropertyItemValueChangedEventHandler(Object s, PropertyItemValueChangedEventArgs e);
}
