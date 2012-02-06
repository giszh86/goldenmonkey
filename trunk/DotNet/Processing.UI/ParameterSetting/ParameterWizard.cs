using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Monkey.Processing.UI
{
    using Monkey.Processing;

    public partial class ParameterWizard : Monkey.Processing.UI.WizardPageBase
    {
        public ParameterWizard()
        {
            InitializeComponent();

            this.m_generalPropertyGridControl.PropertyValueChanged += new PropertyItemValueChangedEventHandler(generalPropertyGridControl_PropertyValueChanged);
        }

        private Int32 m_id = 0;
        private String m_name = String.Empty;
        public ParameterWizard(Int32 id, String name)
        {
            InitializeComponent();

            m_id = id;
            m_name = name;
            m_parameterSet.ID = id;
            m_parameterSet.Name = name;

            this.m_generalPropertyGridControl.PropertyValueChanged += new PropertyItemValueChangedEventHandler(generalPropertyGridControl_PropertyValueChanged);
        }

        public List<PropertyItem> Propertys
        {
            get
            {
                return this.m_generalPropertyGridControl.Propertys;
            }
            set
            {
                try
                {
                    this.m_generalPropertyGridControl.Propertys = value;                    
                    this.m_generalPropertyGridControl.FillGrids();

                    //初始化选择结果
                    String defaultValue = "";
                    foreach (PropertyItem item in this.m_generalPropertyGridControl.Propertys)
                    {
                        if (item.ContainsKey(_XMLTag.g_AttributionVariable))
                        {
                            defaultValue = item[_XMLTag.g_AttributionVariable];
                        }
                        m_parameterSet[item.Name] = defaultValue;
                    }
                }
                catch (Exception ex)
                {
                }   
            }
        }

        private void generalPropertyGridControl_PropertyValueChanged(Object s, PropertyItemValueChangedEventArgs e)
        {
            try
            {
                m_parameterSet[e.Name] = e.Value;                
            }
            catch (Exception ex)
            {
            }   
        }

        private ParameterSet m_parameterSet = new ParameterSet();
        public ParameterSet ParameterSet
        {
            get
            {
                return m_parameterSet;
            }
        }
    }
}
