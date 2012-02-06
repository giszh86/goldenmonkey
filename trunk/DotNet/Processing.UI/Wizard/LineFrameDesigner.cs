using System;
using System.Drawing.Design;
using System.Windows.Forms.Design;

#region 修订历史
/* 时间:2010.6.8
 * 修订者:gis
 * 修订内容:整理代码，修改命名空间，屏蔽不必要的内容
 * 代码来源:www.codeproject.com
 * 许可类型:CPOL
 */
#endregion

namespace Monkey.Processing.UI
{
  public class LineFrameDesigner : ParentControlDesigner
  {
    public override System.Windows.Forms.Design.SelectionRules SelectionRules
    {
      get
      {
        SelectionRules sel = SelectionRules.LeftSizeable | 
          SelectionRules.RightSizeable | 
          SelectionRules.Moveable | 
          SelectionRules.Visible;
        
        return sel;
      }
    }
  }
}
