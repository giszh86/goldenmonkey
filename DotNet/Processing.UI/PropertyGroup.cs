using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkey.Processing.UI
{
    public class PropertyGroup : List<PropertyItem>
    {
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

        public String Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
            }
        }

        private String _name;
        private String _caption;
    }
}
