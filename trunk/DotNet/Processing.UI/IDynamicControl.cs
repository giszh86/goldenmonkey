using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkey.Processing.UI
{
    public interface IDynamicControl
    {
        Control Control
        {
            get;
        }

        Object Value
        {
            get;
        }

        Object DefaultValue
        {
            set;
        }
    }
}
