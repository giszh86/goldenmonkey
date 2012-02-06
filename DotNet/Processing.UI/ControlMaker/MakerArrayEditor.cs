using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;

namespace Monkey.Processing.UI
{
    public class MakerArrayEditor : ICustomPropertyMaker
    {
        public String Type
        {
            get
            {
                return "ArrayEditor";
            }
        }

        public CustomProperty Make(PropertyItem define)
        {
            //String defaultValue = define["default"];
            //if (String.IsNullOrEmpty(defaultValue))
            //{
            //    defaultValue = "";
            //}

            Int32 size = 1;
            if (define.ContainsKey(_XMLTag.g_AttributionMaxlen))
            {
                String maxLen = define[_XMLTag.g_AttributionMaxlen];
                if (!String.IsNullOrEmpty(maxLen))
                {
                    size = Int32.Parse(maxLen);
                }
            }          

            String itemType = "";
            if (define.ContainsKey(_XMLTag.g_AttributionItemType))
            {
                itemType = define[_XMLTag.g_AttributionItemType];
            }
            else if (define.ContainsKey(_XMLTag.g_AttributionType))
            {
                itemType = define[_XMLTag.g_AttributionType];
                String[] strs = itemType.Split('.');
                if (2 == strs.Length)
                {
                    itemType = strs[1];
                }
            }

            String defaultValue = "";
            if (define.ContainsKey(_XMLTag.g_AttributionVariable))
            {
                defaultValue = define[_XMLTag.g_AttributionVariable];
            }           

            TypeConverter typeConverter = null;
            CustomProperty property = null;
            if (String.IsNullOrEmpty(itemType))
            {
                //String[] defaultValue = new String[4];
                //defaultValue[0] = define["default"];
                property = new CustomProperty(define.Name, Toolkit.ToStringArray(defaultValue), false, CustomPropertysManager.Instance.Category, define.Caption, true);
                property.CustomTypeConverter = new ArrayConverter();
            }
            else
            {
                switch (itemType)
                {
                    case "Int32":
                        {
                            
                            Int32[] intArray = new Int32[size];
                            Toolkit.CopyArray(intArray, Toolkit.ToInt32Array(defaultValue));
                            property = new CustomProperty(define.Name, intArray, false, CustomPropertysManager.Instance.Category, define.Caption, true);
                            property.CustomTypeConverter = new ArrayConverter();
                        }
                        break;
                    case "String":
                        {
                            String[] stringArray = new String[size];
                            Toolkit.CopyArray(stringArray, Toolkit.ToStringArray(defaultValue));
                            property = new CustomProperty(define.Name, stringArray, false, CustomPropertysManager.Instance.Category, define.Caption, true);
                            property.CustomTypeConverter = new ArrayConverter();
                            //StringArrayConverter();
                        }
                        break;
                    case "Single":
                        {
                            Single[] singleArray = new Single[size];
                            Toolkit.CopyArray(singleArray, Toolkit.ToSingleArray(defaultValue));
                            property = new CustomProperty(define.Name, singleArray, false, CustomPropertysManager.Instance.Category, define.Caption, true);
                            property.CustomTypeConverter = new ArrayConverter();
                        }
                        break;
                    default:
                        {
                            String[] stringArray = new String[size];
                            Toolkit.CopyArray(stringArray, Toolkit.ToStringArray(defaultValue));
                            property = new CustomProperty(define.Name, stringArray, false, CustomPropertysManager.Instance.Category, define.Caption, true);
                            property.CustomTypeConverter = new ArrayConverter();
                        }
                        break;
                }
            }


            //String[] defaultValue = new String[4];
            //defaultValue[0] = define["default"]; ;

            //CustomProperty property = new CustomProperty(define.Name, defaultValue, false, CustomPropertysManager.Instance.Category, define.Caption, true);
            property.Name = define.Name;         
//            property.CustomTypeConverter = typeConverter;
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
