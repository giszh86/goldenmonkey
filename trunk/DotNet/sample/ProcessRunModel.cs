using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace sample
{
    using Monkey.Processing;

    public class ProcessRunModel : ProcessBaseSample
    {
        public ProcessRunModel()
        {
            base.SetName("RunModel");
            base.SetTitle("运行模型");
            base.Abstract = "解析模型文件，设置参数，运行模型";

            ParaItem[] inputs = new ParaItem[2];
            ParaItem item = new ParaItem("ModelFile", "String", "模型文件", false, "");
            inputs[0] = item;
            item = new ParaItem("ParaSet", "ParameterSet", "参数", false, "");
            inputs[1] = item;
            base.SetInputParameters(inputs);            
        }

        private void PopInputValue()
        {
            IConnector connector = this.GetInputConnector("ModelFile");
            if (null != connector)
            {
                this.SetInputValue("ModelFile", connector.Pop());
            }

            connector = this.GetInputConnector("ParaSet");
            if (null != connector)
            {
                this.SetInputValue("ParaSet", connector.Pop());
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

                String fileModel = this.GetInputValue("ModelFile") as String;
                if (String.IsNullOrEmpty(fileModel))
                {
                    return false;
                }
                ParameterSet paraSet = this.GetInputValue("ParaSet") as ParameterSet;
                if (null == paraSet)
                {
                    return false;
                }

                ProcessChain chain = new ProcessChain();
                XmlDocument doc = new XmlDocument();
                doc.Load(fileModel);
                XmlElement root = doc.DocumentElement;                                              
                foreach (XmlNode node in root.GetElementsByTagName("operation"))
                {
                    chain.AddProcess(node.Attributes["name"].Value, Int32.Parse(node.Attributes["id"].Value));                    
                }
                 
                Int32 prevID = 0;
                Int32 backID = 0;
                foreach (XmlNode linknode in root.GetElementsByTagName("link"))
                {
                    prevID = Int32.Parse(linknode.Attributes["from"].Value);
                    backID = Int32.Parse(linknode.Attributes["to"].Value);
                    foreach (XmlNode assignnode in linknode.SelectNodes("assign"))
                    {                        
                        chain.ConnectProcesses(prevID, backID,
                            assignnode.SelectNodes("from")[0].InnerText,
                            assignnode.SelectNodes("to")[0].InnerText);                        
                    }
                }

                String[] strs = null;
                IProcess process = null;
                foreach (String key in paraSet.Keys)
                {
                    strs = key.Split('.');
                    if (3 != strs.Length)
                    {
                        return false;
                    }

                    process = chain.GetProcessById(Int32.Parse(strs[1]));
                    if (null == process)
                    {
                        return false;
                    }
                    process.SetInputValue(strs[2], paraSet[key]);
                }

                return chain.Execute();
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
        
    }
}
