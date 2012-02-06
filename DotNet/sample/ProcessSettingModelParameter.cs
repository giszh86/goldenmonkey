using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace sample
{
    using Monkey.Processing;
    using Monkey.Processing.UI;

    public class ProcessSettingModelParameter : ProcessBaseSample
    {
        public ProcessSettingModelParameter()
        {
            base.SetName("SettingModelParameter");
            base.SetTitle("输入模型参数");
            base.Abstract = "弹出参数设置对话框，由用户输入参数";

            ParaItem[] inputs = new ParaItem[1];
            ParaItem item = new ParaItem("Paras", "ParaItem[]", "参数", false, "");
            inputs[0] = item;
            base.SetInputParameters(inputs);

            ParaItem[] outputs = new ParaItem[1];
            item = new ParaItem("ParaSet", "ParameterSet");
            item.Title = "参数";
            outputs[0] = item;
            base.SetOutputParameters(outputs);
        }

        private void PopInputValue()
        {
            IConnector connector = this.GetInputConnector("Paras");
            if (null != connector)
            {
                this.SetInputValue("Paras", connector.Pop());
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

                _parameters = this.GetInputValue("Paras") as ParaItem[];
                ModelParameterWizardForm wizard = new ModelParameterWizardForm();
                ProcessDescription[] processQueue = new ProcessDescription[1];
                ProcessDescription item = new ProcessDescription("sample", 1, "sample", "sample");
                item.Inputs = _parameters;
                processQueue[0] = item;

                wizard.ProcessQueue = processQueue;
                if (wizard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    List<ParameterSet> paras = wizard.ParameterSetList; //这个地方速度慢
                    _para = paras[0];
                }
                else
                {
                    wizard.Close();
                    return false;
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
            IConnector connector = this.GetOutputConnector("ParaSet");
            if (null != connector)
            {
                connector.Push(_para);
            }
            else
            {
                this.SetOutputValue("ParaSet", _para);
            }            
        }

        private ParaItem[] _parameters = null;
        private ParameterSet _para = null;
    }
}
