using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkey.Processing.UI
{
    public class SearchEventArgs : EventArgs
    {
        public String SearchKey
        {
            get
            {
                return searchKey;
            }
            set
            {
                searchKey = value;
            }
        }

        private String searchKey;
    }

}
