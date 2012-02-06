using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace sample
{
    using Monkey.DesignPattern;
    using Monkey.Processing;

    public class ProcessDisplayModelResult : IProcess
    {
        private String _guid = "";
        public virtual String Guid
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


        private Int32 _id;
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

        public String Name
        {
            get
            {
                return "DisplayModelResult";
            }
        }

        public String Title
        {
            get
            {
                return "显示模型结果";
            }
        }

        public String Abstract
        {
            get
            {
                return "显示模型结果";
            }
        }

        public ParaItem[] InputSet
        {
            get
            {
                ParaItem[] paras = new ParaItem[1];
                paras[0] = new ParaItem("Any","Any");
                return paras;
            }
        }

        public ParaItem[] OutputSet
        {
            get
            {
                ParaItem[] paras = new ParaItem[0];
                return paras;
            }
        }

        public EventItem[] Events
        {
            get
            {
                return null;
            }
        }

        public virtual Monkey.DesignPattern.IConnectableObject InputConnectableObject
        {
            get
            {
                return new Connectors(_inConnectors.Values.ToArray());
            }
            set
            {
            }
        }

        /// <summary>
        /// 输出连接器
        /// </summary>
        public virtual Monkey.DesignPattern.IConnectableObject OutputConnectableObject
        {
            get
            {
                return new Connectors(_outConnectors.Values.ToArray());
            }
            set
            {
            }
        }


        public Boolean IsReady()
        {            
            return true;         
        }

        public Boolean SetInputConnector(String parameter, IConnector connector)
        {
            _inConnectors[parameter] = connector;
            return true;
        }

        public Boolean SetOutputConnector(String parameter, IConnector connector)
        {
            _outConnectors[parameter] = connector;
            return true;
        }

        public Boolean SetInputValue(String parameter, Object value)
        {
            _inObjs[parameter] = value;
            return true;
        }

        public Object GetOutputValue(String parameter)
        {
            return null;
        }

        public Boolean BindingEvent(String eventKey, MulticastDelegate eventDelegate)
        {
            return false;
        }

        public Boolean Execute()
        {
            String strInfo = "";
            foreach (IConnector connector in _inConnectors.Values)
            {
                strInfo += connector.Pop() as String + "\n";
            }

            foreach (Object obj in _inObjs)
            {
                strInfo += obj as String + "\n";
            }

            System.Windows.Forms.MessageBox.Show(strInfo);

            return true;
        }

        public Boolean Cancel()
        {
            return false;
        }

        public Boolean Pause()
        {
            return false;
        }

        public Boolean Resume(XmlElement state)
        {
            return false;
        }

        public IProcess Clone()
        {
            return null;
        }

        public void Serialize(System.IO.BinaryWriter writer)
        {
        }

        public void Deserialize(System.IO.BinaryReader reader)
        {
        }

        public event ExecutingStateEventHandler Stepped;

        public event PausingEventHandler Pausing;

        public event ExecutingEventHandler Executing;
        
        public event ExecutedEventHandler Executed;

        private Dictionary<String, IConnector> _inConnectors = new Dictionary<String, IConnector>();
        private Dictionary<String, IConnector> _outConnectors = new Dictionary<String, IConnector>();
        private Dictionary<String, Object> _inObjs = new Dictionary<String, Object>();        
    }
}
