using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkey.Processing.UI
{
    public class PropertyItem : Dictionary<String, String>
    {
        public PropertyItem()
        {
            this._type = String.Empty;
            this._name = String.Empty;
            this._caption = String.Empty;
        }

        public PropertyItem(String name, String type, String caption)
        {
            if (String.IsNullOrEmpty(type))
            {
                this._type = "Textbox";
            }
            else
            {
                this._type = type;
            }
            this._name = name;
            this._caption = caption;
        }

        public String Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

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

        public Dictionary<String, String> Propertys
        {
            set
            {
                foreach (String key in value.Keys)
                {
                    this.Add(key, value[key]);
                }
            }
        }

        private String _type;
        private String _name;
        private String _caption;
    }
}
