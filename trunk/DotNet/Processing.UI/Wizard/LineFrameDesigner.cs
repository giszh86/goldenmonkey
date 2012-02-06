using System;
using System.Drawing.Design;
using System.Windows.Forms.Design;

#region �޶���ʷ
/* ʱ��:2010.6.8
 * �޶���:gis
 * �޶�����:������룬�޸������ռ䣬���β���Ҫ������
 * ������Դ:www.codeproject.com
 * �������:CPOL
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
