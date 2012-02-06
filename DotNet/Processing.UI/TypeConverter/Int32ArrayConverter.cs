using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkey.Processing.UI
{
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Globalization;

    public class Int32ArrayConverter : ArrayConverter
    {
        public Int32ArrayConverter()
            : base()
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
/*            BrowsableLabelStyleAttribute attribute1 = (BrowsableLabelStyleAttribute)context.PropertyDescriptor.Attributes[typeof(BrowsableLabelStyleAttribute)];
            if (attribute1 != null)
            {
                switch (attribute1.LabelStyle)
                {
                    case LabelStyle.lsNormal:
                        {
                            return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType);
                        }
                    case LabelStyle.lsTypeName:
                        {
                            return ("(" + value.GetType().Name + ")");
                        }
                    case LabelStyle.lsEllipsis:
                        {
                            return "(...)";
                        }
                }
            }
            return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType);*/
            //return value;
            Object result = null;
            String[] array = value as String[];
            if (context != null &&
                array == null)
            {
                result = base.ConvertFrom(context, culture, value);
            }
            else
            {
            }

            return Toolkit.ToInt32Array(array);
        }
    }
}
