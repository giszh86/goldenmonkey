using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
//using System.Collections;

namespace Monkey.Processing.UI
{
    public class StringConverter : System.ComponentModel.TypeConverter
    {
        public Int32[] StringtoInt(string str_in)
		{
            str_in.Split(';');
            return null;
         }

        public Single[] StringtoSingle(string str_in)
		{
            return null;
         }
     }
    


}
