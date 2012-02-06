using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading; 

namespace sample
{
    using Monkey.Processing;

    public class ProcessValidateModelFileWithProcessList : ProcessBaseSample
    {
        public ProcessValidateModelFileWithProcessList()
        {
            base.SetName("ValidateModelFileWithProcessList");
            base.SetTitle("使用地理空间列表验证模型文件格式");
            base.Abstract = "验证模型文件格式,察看模型中的地理空间处理是否在地理空间列表中，是否有效";

            ParaItem[] inputs = new ParaItem[2];
            ParaItem item = new ParaItem("ModelFile", "String", "模型文件", false, "");
            inputs[0] = item;
            item = new ParaItem("ProcessListFile", "String", "地理空间处理列表文件", false, "");
            inputs[1] = item;
            base.SetInputParameters(inputs);

            ParaItem[] outputs = new ParaItem[3];
            item = new ParaItem("ModelFile", "String");
            item.Title = "模型文件";
            outputs[0] = item;

            item = new ParaItem("ProcessListFile", "String");
            item.Title = "地理空间处理列表文件";
            outputs[1] = item;

            item = new ParaItem("ValidationInfo", "String");
            item.Title = "验证结果";
            outputs[2] = item;
            base.SetOutputParameters(outputs);
        }        

        private void PopInputValue()
        {
            IConnector connector = this.GetInputConnector("ModelFile");
            if (null != connector)
            {
                this.SetInputValue("ModelFile", connector.Pop());
            }
            connector = this.GetInputConnector("ProcessListFile");
            if (null != connector)
            {
                this.SetInputValue("ProcessListFile", connector.Pop());
            }
        }

        protected override Boolean Run(XmlElement state)
        {
            XmlReader xmlRead = null;            

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
                String strProcessListFile = this.GetInputValue("ProcessListFile") as String;
                if (!System.IO.File.Exists(strProcessListFile))
                {
                    return false;
                }

                IProcessListParser processListParser = InstanceManager.Instance.ProcessListParser;
                if (null == processListParser)
                {
                    return false;
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(strModelFile);
                XmlElement rootModelFile = doc.DocumentElement;
                doc.Load(strProcessListFile);
                XmlElement rootProcessListFile = doc.DocumentElement;

                ProcessDefineDescription pdd = null;
                String strProcessName = String.Empty;
                String strParaName = String.Empty;
                ParaItem para = null;
                String strParaType = String.Empty;
                foreach (XmlNode node in rootModelFile.GetElementsByTagName("operation"))
                {
                    strProcessName = node.Attributes["name"].Value;
                    pdd = processListParser.GetProcess(strProcessName);
                    if (null == pdd)
                    {
                        _strValidationInfo += strProcessName + "不存在；";
                        continue;
                    }

                    ParaItem[] inputs = pdd.Inputs;
                    foreach (XmlNode nodeInput in node.SelectSingleNode("inputs").SelectNodes("input"))
                    {
                        strParaName = nodeInput.Attributes["name"].Value;
                        para = FindPara(inputs, strParaName);
                        if (null == para)
                        {
                            _strValidationInfo += strProcessName + "的参数\"" + strParaName + "\"不正确；";
                        }
                        strParaType = nodeInput.Attributes["type"].Value;
                        if (String.Compare(strParaType, para.DataType, true) != 0)
                        {
                            _strValidationInfo += strProcessName + "的参数\"" + strParaName + "\"的类型不正确；";
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
                if (null != xmlRead)
                {
                    xmlRead.Close();
                }
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

            connector = this.GetOutputConnector("ProcessListFile");
            if (null != connector)
            {
                connector.Push(this.GetInputValue("ProcessListFile"));
            }
            else
            {
                this.SetOutputValue("ProcessListFile", this.GetInputValue("ProcessListFile"));
            }

            connector = this.GetOutputConnector("ValidationInfo");
            if (null != connector)
            {
                connector.Push(_strValidationInfo);
            }
            else
            {
                this.SetOutputValue("ValidationInfo", _strValidationInfo);
            }
        }

        private ParaItem FindPara(ParaItem[] items, String name)
        {
            if (null == items || String.IsNullOrEmpty(name))
            {
                return null;
            }
            else
            {
                foreach (ParaItem item in items)
                {
                    if (String.Compare(item.Name, name, true) == 0)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        private String _strValidationInfo = String.Empty;        
    }
}
