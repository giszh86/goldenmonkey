using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkey.Processing.UI
{
    using Monkey.Processing;

    public partial class ModelParameterWizardForm : Form
    {
        public ModelParameterWizardForm()
        {
            InitializeComponent();
        }

        #region Private Fields

        private static String _LOG = "Monkey.Processing.UI.ModelParameterWizardForm";
        
        private List<ParameterWizard> m_wizPages = new List<ParameterWizard>();
        private List<ProcessDescription> m_processQueue = new List<ProcessDescription>();
        private List<ParameterSet> m_parameterSetList = null;

        #endregion


        //public List<ProcessParser> ProcessQueue
        public ProcessDescription[] ProcessQueue
        {           
            set
            {
                m_processQueue.Clear();
                foreach (ProcessDescription item in value)
                {
                    m_processQueue.Add(item);
                }                
                //m_processQueue = value;

                this.m_wizPages.Clear();
                ParameterWizard wizPage = null;
                List<PropertyItem> propertys = null;
                PropertyItem property = null;
                //Dictionary<String, String> map = null;
                this.SuspendLayout();
                ProcessDescription process = null;
                //foreach (ProcessDescription process in m_processQueue)
                String variable = null;
                for (Int32 i = 0; i < m_processQueue.Count; ++i)
                {
                    process = m_processQueue[i];

                    //如果是开始结点，就不添加到列表中
                    if (process.Name.Equals(_XMLTag.g_ValueStart))
                    {
                        continue;
                    }

                    propertys = new List<PropertyItem>();
                    foreach (ParaItem item in process.Inputs)
                    {
                        property = new PropertyItem(item.Name, item.UIType, item.Title);                    
                        property.Propertys = item.Properties;
                        if (null != item.Value)
                        {
                            variable = item.Value as String;
                            if (!String.IsNullOrEmpty(variable))
                            {
                                property[_XMLTag.g_AttributionVariable] = variable;
                            }
                        }
                        propertys.Add(property);
                    }

                    wizPage = new ParameterWizard(process.Id, process.Name);
                    if (0 == i)
                    {
                        wizPage.WelcomePage = true;
                    }
                    if (m_processQueue.Count - 1 == i)
                    { 
                        wizPage.FinishPage = true;
                    }
                    wizPage.WelcomePage = false;
                    wizPage.Description = null;
                    wizPage.Index = i;
                    wizPage.Name = "process.Name";
                    wizPage.Size = new Size(496, 372);
                    wizPage.TabIndex = 0;
                    wizPage.Title = null;
                    wizPage.HeaderImage = null;
                    wizPage.QuietMode = true;
                    wizPage.WizardPageParent = this.m_wizard;
                    wizPage.Propertys = propertys;                    
                    m_wizPages.Add(wizPage);                    
                    this.m_wizard.Pages.Add(wizPage);
                }
                this.ResumeLayout(false);
            }
        }
        
        public List<ParameterSet> ParameterSetList
        {
            get
            {
                return m_parameterSetList;
            }
        }

        private void m_wizard_Finish(object sender, WizardForm.EventNextArgs e)
        {
            try
            {
                m_parameterSetList = new List<ParameterSet>();
                //由于控件不全，这里做一次转换，将String转成对应类型，后面做全了再删除
                ParameterSet paras = null;
                String strValue;
                m_index = 0;
                ParameterSet parasResult = null;
                foreach (ParameterWizard wizPage in m_wizPages)
                {
                    paras = wizPage.ParameterSet;
                    parasResult = new ParameterSet();
                    parasResult.ID = paras.ID;
                    parasResult.Name = paras.Name;
                    foreach (KeyValuePair<String, Object> pair in paras)
                    {
                        if (pair.Value is String)
                        {
                            parasResult[pair.Key] = Reductor(pair.Key, pair.Value as String);
                        }
                        else
                        {
                            parasResult[pair.Key] =pair.Value;
                        }
                    }

                    //m_parameterSetList.Add(wizPage.ParameterSet);
                    m_parameterSetList.Add(parasResult);
                    ++m_index;
                }
            }
            catch (Exception ex)
            {
                IRunningLogger logger = InstanceManager.Instance.Context.GetVariable("RunningStatusLogger") as IRunningLogger;
                if (null != logger)
                {
                    logger.Error(_LOG, ex.Message);
                }
            }   
        }

        private Int32 m_index = 0;
        private Object Reductor(String key, String value)
        {
            try
            {
                ProcessDescription process = m_processQueue[m_index];
                key = key.Trim().ToLower();

                foreach (ParaItem para in process.Inputs)
                {
                    if (String.Compare(key, para.Name,true) == 0)
                    {
                        return InstanceManager.Instance.ProcessManager.CreateObject(para.DataType, value);
                    }
                }
            }
            catch (Exception ex)
            {
                IRunningLogger logger = InstanceManager.Instance.Context.GetVariable("RunningStatusLogger") as IRunningLogger;
                if (null != logger)
                {
                    logger.Error(_LOG, ex.Message);
                }
            }   

            return value;
        }
        
    }
}
