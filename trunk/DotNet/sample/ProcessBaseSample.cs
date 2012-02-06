using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Threading; 

namespace sample
{
    using Monkey.Processing;

    public class ProcessBaseSample : ProcessBase
    {
        public override Boolean Execute()
        {

            XmlDocument doc = new XmlDocument();
            lock (_obj)
            {
                _state = 1;
            }            

            return Run(doc.CreateElement("process"));
        }

        public override Boolean Cancel()
        {
            lock (_obj)
            {
                _state = 2;
            }
            return true;
        }

        public override Boolean Pause()
        {
            lock (_obj)
            {
                _state = 3;
            }
            return true;
        }

        public override Boolean Resume(XmlElement state)
        {
            lock (_obj)
            {
                _state = 4;
            }
            return Run(state);
        }

        public override IProcess Clone()
        {
            return null;
        }

        protected virtual Boolean Run(XmlElement state)
        {
            return false;
        }

        protected String GetState(XmlElement state, String key)
        {
            String strKey = String.Empty;
            foreach (XmlNode node in state.SelectNodes("state"))
            {
                strKey = node.Attributes["key"].Value;
                if (String.Compare(strKey, key, true) == 0)
                {
                    return node.Attributes["value"].Value;
                }
            }
            return "";
        }

        protected void SetState(XmlElement state, String key, String value)
        {
            String strKey = String.Empty;
            foreach (XmlNode node in state.SelectNodes("state"))
            {
                strKey = node.Attributes["key"].Value;
                if (String.Compare(strKey, key, true) == 0)
                {
                    node.Attributes["value"].Value = value;
                    return;
                }
            }
            XmlDocument doc = new XmlDocument();
            XmlNode xnode = doc.CreateElement("state");
            XmlAttribute xattri = doc.CreateAttribute("key");
            xattri.Value = key;
            xnode.Attributes.Append(xattri);
            xattri = doc.CreateAttribute("value");
            xattri.Value = value;
            xnode.Attributes.Append(xattri);
            state.AppendChild(xnode);
        }

        protected UInt32 _state = 0;
        protected Object _obj = new Object();
    }
}
