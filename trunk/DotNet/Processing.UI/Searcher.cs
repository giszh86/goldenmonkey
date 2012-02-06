using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkey.Processing.UI
{
    public partial class Searcher : UserControl
    {
        public Searcher()
        {
            InitializeComponent();

            cmbSearch.Sorted = true;
        }

        public StringCollection SearchList
        {
            get
            {
                return searchList;
            }
            set
            {
                searchList = value;

                //刷新搜索列表
                cmbSearch.Items.Clear();
                foreach (String item in searchList)
                {
                    cmbSearch.Items.Add(item);
                }                
            }
        }        
	//{属性可以是一个字符串数组，或者是一个字典
		//将搜索集合设置到cmbSearch中
		//设定按照升序进行排序
	//}

	    //选中事件
        public event SearchEventHandler SearchChanged;
	//public event search over
	//{
		// 在事件参数中，传递被选中的对象，外部响应这个时间，并进行处理
	//}

        protected virtual void SearchEventTrigger(String key)
        {
            SearchEventArgs sea = new SearchEventArgs();
            sea.SearchKey = key;
            SearchChanged.Invoke(this, sea);
        }

        private void cmbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //输入一个字符，从列表中查找，将查到的第一个最匹配元素设定为选中
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.Z) ||
                 (e.KeyCode >= Keys.NumPad0 && e.KeyCode >= Keys.NumPad9))
            {
                cmbSearch.SelectedIndex = cmbSearch.FindString(cmbSearch.Text);
            }
            
            //输入回车键，将选定内容选中到窗口中，完成搜索
            if (e.KeyCode == Keys.Enter)
            {
                //触发选中事件
                SearchEventTrigger(cmbSearch.Text);
            }
        }

        //下拉选择事件响应函数
        //用户从下拉框中选择一个要素，将其填充到ComBox中，并触发选中事件
        private void cmbSearch_DropDownClosed(object sender, EventArgs e)
        {
            //触发选中事件
            //SearchEventTrigger(cmbSearch.Text);
        }

        //搜索完毕事件，将搜索到的字符串发送给事件，这样智能窗口可以接受之后可以动态刷新控件
        protected StringCollection searchList = new StringCollection();

        //下拉选择事件响应函数
        //用户从下拉框中选择一个要素，将其填充到ComBox中，并触发选中事件
        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //触发选中事件
            SearchEventTrigger(cmbSearch.Text);
        }
    }
}
