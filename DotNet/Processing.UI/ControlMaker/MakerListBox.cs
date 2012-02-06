using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Collections;

namespace Monkey.Processing.UI
{
    public class MakerListBox : ICustomPropertyMaker
    {
        public String Type
        {
            get
            {
                return "ListBox";
            }
        }

        //public IDynamicControl Make(PropertyItem define)
        //{
        //    return null;

        //}

        public CustomProperty Make(PropertyItem define)
        {           
            String defaultValue = "";
            try
            {
                defaultValue = define[_XMLTag.g_AttributionVariable];
            }
            catch (Exception ex)
            {
            }           

            CustomProperty property = new CustomProperty(define.Name, defaultValue, false, CustomPropertysManager.Instance.Category, define.Caption, true);
            property.Name = define.Name;
            String strValueDomain = "";
            if (define.ContainsKey(CustomPropertysManager.Instance.ValueDomain))
            {
                strValueDomain = define[CustomPropertysManager.Instance.ValueDomain];
            }            
            property.Choices = new CustomChoices(strValueDomain.Split(';'), false);
            return property;

          }

        //public IDynamicControl Make(PropertyItem define)
        //{
        //    if (String.Compare(define.Type, "Textbox", true) == 0)
        //    {
        //        //TextBox result = new TextBox();

        //       // return new TextBox();
        //    }

        //    return null;
        //}

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

        private PropertyItem _define = null;
    }
}
