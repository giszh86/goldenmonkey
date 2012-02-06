using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.Collections;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Windows.Forms.Design;

namespace Monkey.Processing.UI
{
   

    public class TypeEditorEnhanceTextBox : System.Drawing.Design.UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                if (!context.PropertyDescriptor.IsReadOnly)
                {
                    return UITypeEditorEditStyle.Modal;
                }
            }
            return UITypeEditorEditStyle.None;
        }

        [RefreshProperties(RefreshProperties.All)]
        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            if (context == null || provider == null || context.Instance == null)
            {
                return base.EditValue(provider, value);
            }

/*            FileDialog fileDlg;
            if (context.PropertyDescriptor.Attributes[typeof(SaveFileAttribute)] == null)
            {
                fileDlg = new OpenFileDialog();
            }
            else
            {
                fileDlg = new SaveFileDialog();
            }
            fileDlg.Title = "Select " + context.PropertyDescriptor.DisplayName;
            fileDlg.FileName = (string)value;

            FileDialogFilterAttribute filterAtt = (FileDialogFilterAttribute)context.PropertyDescriptor.Attributes[typeof(FileDialogFilterAttribute)];
            if (filterAtt != null)
            {
                fileDlg.Filter = filterAtt.Filter;
            }
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                value = fileDlg.FileName;
            }
            fileDlg.Dispose();*/
            return value;
        }
    }
}
