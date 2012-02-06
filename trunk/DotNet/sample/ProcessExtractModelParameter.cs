using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace sample
{
    using Monkey.Processing;

    public class ProcessExtractModelParameter : ProcessBaseSample
    {
        public ProcessExtractModelParameter()
        {
            base.SetName("ExtractModelParameter");
            base.SetTitle("提取模型参数");
            base.Abstract = "遍历模型文件，从中提取没有进行设置值的参数，做为模型参数";

            ParaItem[] inputs = new ParaItem[1];
            ParaItem item = new ParaItem("ModelFile", "String", "模型文件", false, "");            
            inputs[0] = item;            
            base.SetInputParameters(inputs);

            ParaItem[] outputs = new ParaItem[2];
            item = new ParaItem("ModelFile", "String");
            item.Title = "模型文件";
            outputs[0] = item;

            item = new ParaItem("ModelParameter", "ParaItem[]");
            item.Title = "模型参数";
            outputs[1] = item;
            base.SetOutputParameters(outputs);
        }

        private void PopInputValue()
        {
            IConnector connector = this.GetInputConnector("ModelFile");
            if (null != connector)
            {
                this.SetInputValue("ModelFile", connector.Pop());
            }            
        }

        protected override Boolean Run(XmlElement state)
        {
             try
            {
                if (!this.IsReady())
                {
                    return false;
                }
                PopInputValue();

                String strModelFile = this.GetInputValue("ModelFile") as String;
                if (!System.IO.File.Exists(strModelFile))
                {
                    return false;
                }
                IProcessListParser processList = InstanceManager.Instance.ProcessListParser;
                if (null == processList)
                {
                    return false;
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(strModelFile);
                XmlElement root = doc.DocumentElement;
                ParaItem para = null;
                XmlAttribute attri = null;
                ProcessDefineDescription pdd = null;
                ParaItem[] inputs = null;
                ParaItem pid = null;
                foreach (XmlNode node in root.GetElementsByTagName("operation"))
                {
                    pdd = processList.GetProcess(node.Attributes["name"].Value);
                    if (null == pdd)
                    {
                        continue;
                    }
                    inputs =  pdd.Inputs;
                    foreach (XmlNode item in node.SelectSingleNode("inputs").ChildNodes)
                    {
                        if (String.IsNullOrEmpty(item.Attributes["variable"].Value))
                        {
                            para = new ParaItem(node.Attributes["name"].Value + "." + node.Attributes["id"].Value + "." + item.Attributes["name"].Value, item.Attributes["type"].Value);
                            pid = FindPara(inputs, item.Attributes["name"].Value);
                            if (null != pid)
                            {
                                para.Abstract = pid.Abstract;
                                para.UIType = pid.UIType;
                                para.Option = pid.Option;
                                para.Title = pid.Title;                                
                            }
                            attri = item.Attributes["title"];
                            if (null != attri)
                            {                                
                                para.Title = attri.Value;
                            }                           
                            _parameters.Add(para);
                        }
                    }
                }

                PushOutputValue();
                return true;
            }
             catch (Exception ex)
             {
                 IRunningLogger logger = InstanceManager.Instance.Context.GetVariable("RunningLogger") as IRunningLogger;
                 if (null != logger)
                 {
                     logger.Error("sample.ProcessValidateModelFile", ex.Message);
                 }
             }
             finally
             {
                
             }

             return false;
        }

        private void PushOutputValue()
        {
            IConnector connector = this.GetOutputConnector("ModelFile");
            if (null != connector)
            {
                connector.Push(this.GetInputValue("ModelFile"));
            }
            else
            {
                this.SetOutputValue("ModelFile", this.GetInputValue("ModelFile"));
            }

            connector = this.GetOutputConnector("ModelParameter");
            if (null != connector)
            {
                connector.Push(_parameters.ToArray());
            }
            else
            {
                this.SetOutputValue("ModelParameter", _parameters.ToArray());
            }
        }

        private ParaItem FindPara(ParaItem[] paras, String name)
        {
            if (null == paras || String.IsNullOrEmpty(name))
            {
                return null;
            }
            foreach (ParaItem item in paras)
            {
                if (String.Compare(item.Name, name, true) == 0)
                {
                    return item;
                }
            }
            return null;
        }

        private List<ParaItem> _parameters = new List<ParaItem>();
    }
}
