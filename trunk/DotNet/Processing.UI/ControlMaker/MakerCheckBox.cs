using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;

namespace Monkey.Processing.UI
{
    public class MakerCheckBox : ICustomPropertyMaker
    {
        public String Type
        {
            get
            {
                return "CheckBox";
            }
        }

        //public IDynamicControl Make(PropertyItem define)
        //{
        //    return null;
            
        //}

        public CustomProperty Make(PropertyItem define)
        {
            return null;
        }

        public UITypeEditor TypeEdit
        {
            get
            {
                return null;
            }
        }

        public TypeConverter TypeConverter
        {
            get
            {
                return null;
            }
        }
    }
}
