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

    public class ProcessValidateProcessListFile : ProcessBaseSample
    {
        public ProcessValidateProcessListFile()
        {
            base.SetName("ValidateProcessListFile");
            base.SetTitle("验证地理空间列表文件格式");
            base.Abstract = "验证地理空间列表文件格式";

            ParaItem[] inputs = new ParaItem[4];
            ParaItem item = new ParaItem("ProcessListFile", "String", "地理空间处理列表文件", false, "");
            inputs[0] = item;
            item = new ParaItem("ProcessDescriptionsValidateFile", "String", "地理空间处理列表验证文件", false, "");
            inputs[1] = item;
            item = new ParaItem("GroupValidateFile", "String", "地理空间处理分组验证文件", false, "");
            inputs[2] = item;
            item = new ParaItem("ProcessDescriptionValidateFile", "String", "地理空间处理验证文件", false, "");
            inputs[3] = item;
            base.SetInputParameters(inputs);

            ParaItem[] outputs = new ParaItem[2];
            item = new ParaItem("ProcessListFile", "String");
            item.Title = "地理空间处理列表文件";
            outputs[0] = item;            

            item = new ParaItem("ValidationInfo", "String");
            item.Title = "验证结果";
            outputs[1] = item;
            base.SetOutputParameters(outputs);
        }

        private void PopInputValue()
        {
            IConnector connector = this.GetInputConnector("ProcessListFile");
            if (null != connector)
            {
                this.SetInputValue("ProcessListFile", connector.Pop());
            }

            connector = this.GetInputConnector("ProcessDescriptionsValidateFile");
            if (null != connector)
            {
                this.SetInputValue("ProcessDescriptionsValidateFile", connector.Pop());
            }

            connector = this.GetInputConnector("GroupValidateFile");
            if (null != connector)
            {
                this.SetInputValue("GroupValidateFile", connector.Pop());
            }

            connector = this.GetInputConnector("ProcessDescriptionValidateFile");
            if (null != connector)
            {
                this.SetInputValue("ProcessDescriptionValidateFile", connector.Pop());
            }
        }

        protected override Boolean Run(XmlElement state)
        {
            XmlReader xmlRead = null;
            Boolean bProcessDescriptionsValidated = false;
            Int32 nGroupItem = 0;
            Int32 nProcessItem = 0;

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
                String strValidateFile = this.GetInputValue("ProcessDescriptionsValidateFile") as String;
                settings.Schemas.Add(null, strValidateFile);

                lock (_obj)
                {
                    if (1 != _state && 4 != _state)
                    {
                        RunException ex = new RunException();
                        throw ex;
                    }
                }
                
                String strValue = this.GetState(state, "IsValidateProcessDescriptionsFile");
                if (!String.IsNullOrEmpty(strValue))
                {
                    bProcessDescriptionsValidated = Boolean.Parse(strValue);
                }
                String strProcessListFile = "";
                if (!bProcessDescriptionsValidated)
                {
                    strProcessListFile = this.GetInputValue("ProcessListFile") as String;
                    xmlRead = XmlReader.Create(strProcessListFile, settings);
                    while (xmlRead.Read())
                    {
                    }
                    xmlRead.Close();
                    xmlRead = null;

                    bProcessDescriptionsValidated = true;
                }

                lock (_obj)
                {
                    if (1 != _state && 4 != _state)
                    {
                        RunException ex = new RunException();
                        throw ex;
                    }
                }

                //验证分组文件
                settings = new XmlReaderSettings();
                settings.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventCallBack);
                settings.ValidationType = ValidationType.Schema;
                strValidateFile = this.GetInputValue("GroupValidateFile") as String;
                settings.Schemas.Add(null, strValidateFile);

                strValue = this.GetState(state, "GroupValidateItem");                
                if (!String.IsNullOrEmpty(strValue))
                {
                    nGroupItem = Int32.Parse(strValue);
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(strProcessListFile);
                XmlElement xmlListFile = doc.DocumentElement;
                XmlNodeList nodeLists = xmlListFile.GetElementsByTagName("Group");
                String strFile = "";
                String strBaseDirectory = InstanceManager.Instance.Context.GetVariable("BaseDirectory") as String;
                XmlNode node = null;
                for (; nGroupItem < nodeLists.Count; ++nGroupItem)
                {
                    lock (_obj)
                    {
                        if (1 != _state && 4 != _state)
                        {
                            RunException ex = new RunException();
                            throw ex;
                        }
                    }

                    node = nodeLists[nGroupItem];
                    strFile = strBaseDirectory + "../Config/ProcessGroups/" + node.InnerText + ".xml";
                    strFile = System.IO.Path.GetFullPath(strFile);
                    xmlRead = XmlReader.Create(strFile, settings);
                    while (xmlRead.Read())
                    {
                    }
                    xmlRead.Close();
                    xmlRead = null;

                    //验证地理空间处理文件
                    XmlReaderSettings settings2 = new XmlReaderSettings();
                    settings2.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventCallBack);
                    settings2.ValidationType = ValidationType.Schema;
                    strValidateFile = this.GetInputValue("ProcessDescriptionValidateFile") as String;
                    settings2.Schemas.Add(null, strValidateFile);

                    strValue = this.GetState(state, "ProcessValidateItem");
                    nProcessItem = 0;
                    if (!String.IsNullOrEmpty(strValue))
                    {
                        nProcessItem = Int32.Parse(strValue);
                    }

                    doc = new XmlDocument();
                    doc.Load(strFile);
                    XmlElement xmlGroupFile = doc.DocumentElement;
                    XmlNodeList processLists = xmlGroupFile.GetElementsByTagName("ProcessDescription");
                    for (; nProcessItem < processLists.Count; ++nProcessItem)
                    {
                        lock (_obj)
                        {
                            if (1 != _state && 4 != _state)
                            {
                                RunException ex = new RunException();
                                throw ex;
                            }
                        }

                        node = processLists[nProcessItem];
                        strFile = strBaseDirectory + "../Config/ProcessDescriptions/" + node.InnerText + ".xml";
                        strFile = System.IO.Path.GetFullPath(strFile);
                        xmlRead = XmlReader.Create(strFile, settings);
                        while (xmlRead.Read())
                        {
                        }
                        xmlRead.Close();
                        xmlRead = null;
                    }
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

                            SetState(stateNode, "IsValidateProcessDescriptionsFile", bProcessDescriptionsValidated.ToString());
                            SetState(stateNode, "GroupValidateItem", nGroupItem.ToString());
                            SetState(stateNode, "ProcessValidateItem", nProcessItem.ToString());
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
            IConnector connector =  this.GetOutputConnector("ProcessListFile");
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
