using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkey.Processing.UI
{
    public class ProcessingCustomPropertysFactory : ICustomPropertysFactory
    {
        public CustomProperty Make(PropertyItem define)
        {
            String strType = define.Type;
            strType = strType.ToLower();

            switch (strType)
            {
                case "arrayeditor":
                    {
                        ICustomPropertyMaker maker = new MakerArrayEditor();
                        return maker.Make(define);
                    }
                    break;
                case "checkbox":
                    {
                        ICustomPropertyMaker maker = new MakerCheckBox();
                        return maker.Make(define);
                    }
                    break;
                case "combobox":
                    {
                        ICustomPropertyMaker maker = new MakerComboBox();
                        return maker.Make(define);
                    }
                    break;
                case "listbox":
                    {
                        ICustomPropertyMaker maker = new MakerListBox();
                        return maker.Make(define);
                    }
                    break;
                case "textbox":
                    {
                        ICustomPropertyMaker maker = new MakerText();
                        return maker.Make(define);
                    }
                    break;
            }

            return null;
        }
    }
}
