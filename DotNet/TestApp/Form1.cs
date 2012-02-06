using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    using Monkey.Processing;
    using Monkey.Processing.UI;


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Init();

            TestExecuteXmlModel();
        }

        public void Init()
        {
            //InstanceManager.Instance.NewParser = new GeospatialProcessModelParser();
            //InstanceManager.Instance.FactoryLoader = new f
        }

        public void TestExecuteXmlModel()
        {
            ModelActuator.ExecuteXmlModel(@"F:\05_Amateur\04_空间信息流程\04_Sourcecode\类型\GPW.xml", false);
        }

    }
}
