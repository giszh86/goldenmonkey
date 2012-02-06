using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sampleApp
{
    using Monkey.Processing;
    using sample;

    class Program
    {
        static void Main(string[] args)
        {            
            String strModelFile = InstanceManager.Instance.Context.GetVariable("BaseDirectory") as String;
            String[] separator = new String[]{"\\"};                
            String[] strs = strModelFile.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            strs[strs.Length - 1] = "sample.xml";
            strModelFile = String.Join("/", strs);
            ProcessExtractModelParameter p1 = new ProcessExtractModelParameter();
            p1.SetInputValue("ModelFile", strModelFile);
            IConnector c1 = new ConveyConnector();
            p1.SetOutputConnector("ModelParameter", c1);
            IConnector c2 = new ConveyConnector();
            p1.SetOutputConnector("ModelFile", c2);
            p1.Execute();

            ProcessSettingModelParameter p2 = new ProcessSettingModelParameter();
            p2.SetInputConnector("Paras", c1);
            IConnector c3 = new ConveyConnector();
            p2.SetOutputConnector("ParaSet", c3);
            p2.Execute();

            ProcessRunModel p3 = new ProcessRunModel();
            p3.SetInputConnector("ModelFile", c2);
            p3.SetInputConnector("ParaSet", c3);
            p3.Execute();
        }
    }
}
