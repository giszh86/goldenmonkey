using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sample
{
    using Monkey.Processing;
    using Monkey.DesignPattern;

    public class ConnectorStringArrayToString : IConnector
    {
        private String _guid = "";
        /// <summary>
        /// GUID，类的惟一标识
        /// </summary>
        public String Guid
        {
            get
            {               
                return _guid;
            }
            set
            {
                _guid = value;
            }
        }

        private PipeFilterMode _mode = PipeFilterMode.Customize;
        /// <summary>
        /// 模式
        /// </summary>
        public virtual PipeFilterMode Mode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
            }
        }

        private Int32 _id = 0;
        public Int32 ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        
        public String InputParaType
        {
            get
            {
                return "String[]";
            }
        }
        
        public String OutputParaType
        {
            get
            {
                return "String";
            }
        }

        /// <summary>
        /// 前置地理空间处理
        /// </summary>       
        public virtual Monkey.DesignPattern.IConnectableObject InputConnectableObject
        {
            get
            {               
                return null;
            }
            set
            {                
            }
        }

        /// <summary>
        /// 后置地理空间处理
        /// </summary>
        public virtual Monkey.DesignPattern.IConnectableObject OutputConnectableObject
        {
            get
            {
                return null;
            }
            set
            {                
            }
        }

        public Object Pop()
        {
            if (null == _pushObj)
            {
                return "";
            }
            else
            {
                return _pushObj[0];
            }
        }

        private String[] _pushObj = null;
        public void Push(Object value)
        {
            _pushObj = value as String[];
        }

        public IConnector Clone()
        {
            return null;
        }
        
        public void Serialize(System.IO.BinaryWriter writer)
        {
        }

        public void Deserialize(System.IO.BinaryReader reader)
        {
        }
    }
}
