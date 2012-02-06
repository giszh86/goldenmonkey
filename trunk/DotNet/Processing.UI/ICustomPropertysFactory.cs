using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkey.Processing.UI
{
    public interface ICustomPropertysFactory
    {
        CustomProperty Make(PropertyItem define);
    }
}
