using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sample
{
    using Monkey.Processing;

    public class SampleFactory : IProcessFactory
    {        
        public String Author
        {
            get
            {
                return "sample";
            }
        }
        
        public DateTime Date
        {
            get
            {
                return new DateTime(2010,6,1);
            }
        }
        
        public String Version
        {
            get
            {
                return "1.0.0";
            }
        }
        
        public String Description
        {
            get
            {
                return "sample factory";
            }
        }
        
        public String[] Processes
        {
            get
            {
                String[] items = new String[] { "ValidateModelFile", "ValidateProcessListFile", "ValidateModelFileWithProcessList", "ExtractModelParameter", "SettingModelParameter", "RunModel", "DisplayModelResult" };
                return items;
            }
        }
        
        public String[] ObjectTypes
        {
            get
            {
                String[] items = new String[] { };
                return items;
            }
        }
        
        public EventItem[] Events
        {
            get
            {
                return null;
            }
        }
        
        public String[] JobTypes
        {
            get
            {
                return null;
            }
        }
        
        public IProcess CreateProcess(String name)
        {
            switch (name)
            {
                case "ValidateModelFile":
                    {
                        return new ProcessValidateModelFile();
                    }
                    break;
                case "ValidateProcessListFile":
                    {
                        return new ProcessValidateProcessListFile();
                    }
                    break;
                case "ValidateModelFileWithProcessList":
                    {
                        return new ProcessValidateModelFileWithProcessList();
                    }
                    break;
                case "ExtractModelParameter":
                    {
                        return new ProcessExtractModelParameter();
                    }
                    break;
                case "SettingModelParameter":
                    {
                        return new ProcessSettingModelParameter();
                    }
                    break;
                case "RunModel":
                    {
                        return new ProcessRunModel();
                    }
                    break;
                case "DisplayModelResult":
                    {
                        return new ProcessDisplayModelResult();
                    }
                    break;                  
            }

            return null;
        }
        
        public IConnector CreateConnector(String inParaType, String outParaType)
        {
            if (String.Compare(inParaType, "String[]", true) == 0 &&
                    String.Compare(outParaType, "String", true) == 0)
            {
                return new ConnectorStringArrayToString();
            }
            return null;
        }
        
        public Object CreateObject(String type, String value)
        {
            switch (type)
            {
                case "String":
                    {
                        return value;
                    }
                    break;
            }

            return value;
        }
        
        public MulticastDelegate CreateEvent(String key)
        {
            return null;
        }
        
        public IJob CreateJob(String type)
        {
            return null;
        }

        public void Release()
        {
        }
    }
}
