using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel;

namespace Monkey.Processing.UI
{
    public interface ICustomPropertyMaker
    {
        String Type
        {
            get;
        }

        //PropertyItem Define
        //{
        //    set;
        //}

        //IDynamicControl Make(PropertyItem define);

        CustomProperty Make(PropertyItem define);

        //UITypeEditor TypeEdit
        //{
        //    get;
        //}

        //TypeConverter TypeConverter
        //{
        //    get;
        //}
    }
}
