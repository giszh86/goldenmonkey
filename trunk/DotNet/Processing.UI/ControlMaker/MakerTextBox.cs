using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
//using System.Web.UI.WebControls;
using System.Web;


namespace Monkey.Processing.UI
{      
    public class MakerText : ICustomPropertyMaker
    {
        public String Type
        {
            get
            {
                return "TextBox";
            }
        }

        //public PropertyItem Define
        //{
        //    set
        //    {
        //        _define = value;
        //    }
        //}

        public CustomProperty Make(PropertyItem define)
        {
            try
            {
                //String defaultValue = define["default"];
                //if (String.IsNullOrEmpty(defaultValue))
                //{
                //    defaultValue = "";
                //}

                //String [] defaultValue = new String[4];
                
                String defaultValue = String.Empty;
                //if (define.ContainsKey(_XMLTag.g_AttributionDefault))
                //{
                //    defaultValue = define[_XMLTag.g_AttributionDefault];
                //}
                if (define.ContainsKey(_XMLTag.g_AttributionVariable))
                {
                    defaultValue = define[_XMLTag.g_AttributionVariable];
                }

                String caption = define.Caption;
                if (String.IsNullOrEmpty(caption))
                {
                    caption = define.Name;
                }


                CustomProperty property = new CustomProperty(define.Name, defaultValue, false, CustomPropertysManager.Instance.Category, caption, true);

                property.Name = define.Name;
                //property.CustomTypeConverter = new StringConverter();  

                //property.CustomTypeConverter = new System.Web.UI.WebControls.StringArrayConverter();
                //property.CustomTypeConverter = new ArrayConverter();
                return property;

                String itemType = define["ItemType"];
                //if (String.IsNullOrEmpty(defaultValue))
                //{
                //    property.CustomTypeConverter = new StringConverter(); 
                //}
                //else
                //{
                //    switch (itemType)
                //    {
                //        case "Int32":
                //            {
                //                //property.CustomTypeConverter = new Int32Converter();
                //                property.CustomTypeConverter = new TypeConverterArray();
                //            }
                //            break;
                //        case "String":
                //            {
                //                property.CustomTypeConverter = new StringConverter();
                //                //StringArrayConverter();
                //            }
                //            break;
                //        case "Single":
                //            {
                //                property.CustomTypeConverter = new SingleConverter();
                //            }
                //            break;
                //        default:
                //            {
                //                property.CustomTypeConverter = new StringConverter();
                //            }
                //            break;
                //    }
                //}



                //property.CustomTypeConverter = new Int32Converter();    
                //property.CustomEditor = new 

                return property;
            }
            catch (Exception ex)
            {
                Toolkit.DEBUG_TRACE("Monkey.Processing.UI.GeneralPropertyGridControl.FillGridsPropertyGroups Exception:" + ex.Message + "\n");
                return null;
            }
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
