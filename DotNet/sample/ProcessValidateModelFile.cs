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

    public class ProcessValidateModelFile : ProcessBaseSample
    {
        public ProcessValidateModelFile()
        {
            base.SetName("ValidateModelFile");
            base.SetTitle("验证模型文件格式");
            base.Abstract = "验证模型文件格式,可以输入多个文件进行验证";

            ParaItem[] inputs = new ParaItem[2];
            ParaItem item = new ParaItem("FileArray", "String[]", "模型文件", false, "");            
            inputs[0] = item;
            item = new ParaItem("ValidateFile", "String","模型文件",false,"");           
            inputs[1] = item;
            base.SetInputParameters(inputs);

            ParaItem[] outputs = new ParaItem[2];
            item = new ParaItem("FileArray", "String[]");
            item.Title = "模型文件";            
            outputs[0] = item;

            item = new ParaItem("ValidationInfo", "String");
            item.Title = "验证结果";           
            outputs[1] = item;
            base.SetOutputParameters(outputs);
        }
                       
        private void PopInputValue()
        {            
            IConnector connector = this.GetInputConnector("FileArray");
            if (null != connector)
            {
                this.SetInputValue("FileArray", connector.Pop());
            }
            connector = this.GetInputConnector("ValidateFile");
            if (null != connector)
            {
                this.SetInputValue("ValidateFile", connector.Pop());
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        /// <!--
        /// <process name="" id="">
        ///     <state key="" value="" />
        ///     <state key="" value="" />
        /// </process>
        /// -->
        protected override Boolean Run(XmlElement state)
        {                
            XmlReader xmlRead = null;
            Int32 nIndexFile = 0;            

            try
            {
                if (!this.IsReady())
                {
                    return false;
                }
                PopInputValue();

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventCallBack);
                settings.ValidationType = ValidationType.Schema;
                String _strValidateFile = this.GetInputValue("ValidateFile") as String;
                settings.Schemas.Add(null, _strValidateFile);
                
                lock (_obj)
                {
                    if (1 != _state && 4 != _state)
                    {
                        RunException ex = new RunException();
                        throw ex;
                    }
                }

                Int32 nStartIndex = 0;
                String[] _fileArray = this.GetInputValue("FileArray") as String[];
                String strValue = this.GetState(state, "StartFile");
                if (!String.IsNullOrEmpty(strValue))
                {
                    nStartIndex = Int32.Parse(strValue);
                }

                nIndexFile = nStartIndex;
                String file = String.Empty;
                for (; nIndexFile < _fileArray.Length; ++nIndexFile)                
                {
                    lock (_obj)
                    {
                        if (1 != _state && 4 != _state)
                        {
                            RunException ex = new RunException();
                            throw ex;
                        }
                    }

                    file = _fileArray[nIndexFile];
                    xmlRead = XmlReader.Create(file, settings);
                    while (xmlRead.Read())
                    {
                    }
                    xmlRead.Close();
                    xmlRead = null;
                }

                PushOutputValue();
                return true;
            }
            catch (RunException rex)
            {
//                if (this.Pausing != null)
                {
                    lock (_obj)
                    {
                        if (2 == _state)
                        {
                            return false;
                        }
                        else if (3 == _state)
                        {
                            XmlDocument doc = new XmlDocument();
                            XmlElement stateNode = doc.CreateElement("process");
                            XmlAttribute xattri = doc.CreateAttribute("name");
                            xattri.Value = this.Name;
                            stateNode.Attributes.Append(xattri);
                            xattri = doc.CreateAttribute("id");
                            xattri.Value = this.ID.ToString();
                            stateNode.Attributes.Append(xattri);

                            SetState(stateNode, "StartFile", nIndexFile.ToString());
                        }
                    }
                }
                //if (this.Pausing != null)
                //{
                //    PausingEventArgs e = new PausingEventArgs();
                //    Pausing(this, e);
                //}
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
            IConnector connector = this.GetOutputConnector("FileArray");
            if (null != connector)
            {
                connector.Push(this.GetInputValue("FileArray"));
            }
            else
            {
                this.SetOutputValue("FileArray", this.GetInputValue("FileArray"));
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

        private void ValidationEventCallBack(Object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)//区分是警告还是错误 
            {
                _strValidationInfo += "Warning:" + e.Message;                
            }
            else
            {
                _strValidationInfo += "Error:" + e.Message;
            }
        }
                        
        private String _strValidationInfo = String.Empty;        
    }
}
