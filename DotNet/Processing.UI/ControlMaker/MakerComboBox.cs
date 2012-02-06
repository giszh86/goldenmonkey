using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Monkey.Processing.UI
{
    public class MakerComboBox : ICustomPropertyMaker
    {
        public String Type
        {
            get
            {
                return "ComboBox";
            }
        }

        //public IDynamicControl Make(PropertyItem define)
        //{
        //    return null;
        //    //ComboBox result = new ComboBox();
        //    //result.DataSource
        //    //下拉框类型，String、Int32、Double...
        //    //result.FormatInfo
        //    //return result;
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
