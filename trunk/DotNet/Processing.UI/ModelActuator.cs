using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Monkey.Processing.UI
{
    using Monkey.Processing;
    using Monkey.Processing.Graph;
    

    public class ModelActuator
    {
        public ModelActuator()
        {
        }

        #region Private Fields

        private static String _LOG = "Monkey.Processing.UI.ModelActuator";      

        #endregion

        #region 模型执行

        public static Boolean ExecuteXmlModel(String filePath, Boolean isWithParameter)
        {            
            try
            {
                String _filePath = filePath;
                if (!File.Exists(_filePath))
                {
                    return false;
                }
                //解析文件
                IModelParser parser = InstanceManager.Instance.NewParser;
                if (null == parser)
                {
                    return false;
                }
                parser.File = filePath;
                Boolean _isStepByStep = parser.IsStepByStepMode;
                //建立地理空间处理模型
                Graph gpm = new Graph();
                ProcessDescription[] processes = parser.ProcessList;

//                List<ProcessDescription> processQueue = null;
//                if (_isStepByStep)
//                {
//                    processQueue = new List<ProcessDescription>();
//                    //从空间处理列表查找SpatialProcess
//                    IProcessListParser processListParser = InstanceManager.Instance.ProcessListParser;
//                    if (null == processListParser)
//                    {
//                        return false;
//                    }

//                    ProcessDefineDescription processDefine = null;
//                    //ProcessDescription item = null;
//                    List<ParaItem> parameters = null;
//                    //ParaItem parameter = null;
//                    foreach (ProcessDescription process in processes)
//                    {
//                        //如果是开始结点，就不添加到列表中
//                        if (process.Name.Equals(_XMLTag.g_ValueStart))
//                        {
//                            continue;
//                        }

//                        processDefine = processListParser.GetProcess(process.Name);
//                        //item = new ProcessDescription(processDefine.Name, process.Id, processDefine.Caption, processDefine.Description);
//                        parameters = new List<ParaItem>();
//                        foreach (ParaItem paraitem in processDefine.Inputs)
//                        {
//                            if (IsParameterInProcess(process, paraitem.Name))
//                            {
////                                paraitem.Value = GetVariable(process, paraitem.Name);
//                                parameters.Add(paraitem);
//                            }
//                        }
//                        item.Inputs = parameters;
//                        processQueue.Add(item);
//                    }
//                }
//                else
//                {
                    foreach (ProcessDescription process in processes)
                    {
                        gpm.CreateNode(process.Id, process);
                    }
                //}
                LinkDescription[] links = parser.LinkList;
                foreach (LinkDescription link in links)
                {
                    gpm.Link(gpm.NodeById(link.FromId), gpm.NodeById(link.ToId), link);
                }

                IModelJob job = InstanceManager.Instance.ProcessManager.CreateJob("xmlModel") as IModelJob;
                if (null == job)
                {
                    return false;
                }
                job.JobValue = gpm;

                if (!isWithParameter)
                {
                    
                    if (_isStepByStep)
                    {
                        ModelParameterWizardForm wizard = new ModelParameterWizardForm();
                        //List<ProcessDescription> processQueue = new List<ProcessDescription>();
                        ////从空间处理列表查找SpatialProcess
                        //IProcessListParser processListParser = InstanceManager.Instance.ProcessListParser;
                        //if (null == processListParser)
                        //{
                        //    return false;
                        //}

                        //ProcessDefineDescription processDefine = null;
                        //ProcessDescription item = null;
                        //List<ParaItem> parameters = null;
                        ////ParaItem parameter = null;
                        //foreach (ProcessDescription process in parser.ProcessList)
                        //{
                        //    //如果是开始结点，就不添加到列表中
                        //    if (process.Name.Equals(_XMLTag.g_ValueStart))
                        //    {
                        //        continue;
                        //    }

                        //    processDefine = processListParser.GetProcess(process.Name);
                        //    item = new ProcessDescription(processDefine.Name, process.Id, processDefine.Caption, processDefine.Description);
                        //    parameters = new List<ParaItem>();
                        //    foreach (ParaItem paraitem in processDefine.Inputs)
                        //    {
                        //        if (IsParameterInProcess(process, paraitem.Name))
                        //        {
                        //            paraitem.Value = GetVariable(process, paraitem.Name);
                        //            parameters.Add(paraitem);
                        //        }
                        //    }
                        //    item.Inputs = parameters;
                        //    processQueue.Add(item);
                        //}

//                        wizard.ProcessQueue = processQueue;
                        wizard.ProcessQueue = processes;
                        if (wizard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            List<ParameterSet> paras = wizard.ParameterSetList; //这个地方速度慢
                            if (!job.SetParameters(paras.ToArray()))
                            {
                                throw new Exception("设置参数失败");
                            }
                        }
                        else
                        {
                            wizard.Close();
                            return false;
                        }
                    }
                }
                else
                {
                    throw new NotImplementedException("该场景未实现");
                }

                return job.Execute();
            }
            catch (Exception ex)
            {
                IRunningLogger logger = InstanceManager.Instance.Context.GetVariable("RunningStatusLogger") as IRunningLogger;
                if (null != logger)
                {
                    logger.Error(_LOG, ex.Message);
                }
            }

            return false;
        }    

       

        #endregion


        #region Private Function

        private static Boolean IsParameterInProcess(ProcessDescription parser, String parameter)
        {
/* 
            try
            {
                parameter = parameter.Trim().ToLower();
                List<ParaItem> paras = parser.Parameters;
                foreach (ParaItem item in paras)
                {
                    if (parameter.Equals(item.Name.Trim().ToLower()))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                IRunningStatusLogger logger = Context.Instance.GetVariable("RunningStatusLogger") as IRunningStatusLogger;
                if (null != logger)
                {
                    logger.Error(_LOG, ex.Message);
                }
            }
*/
            return false;
        }

        private static Object GetVariable(ProcessDescription parser, String parameter)
        {
/*
            try
            {
                parameter = parameter.Trim().ToLower();
                foreach (ParaItem item in parser.Parameters)
                {
                    if (parameter.Equals(item.Name.Trim().ToLower()))
                    {
                        //先屏蔽掉，等控件开发好再换回来
                        //return GPManager.CreateObject(item.Type, item.Properties[_XMLTag.g_AttributionVariable]);
                        return item.Properties[_XMLTag.g_AttributionVariable];
                    }
                }
            }
            catch (Exception ex)
            {
                IRunningStatusLogger logger = Context.Instance.GetVariable("RunningStatusLogger") as IRunningStatusLogger;
                if (null != logger)
                {
                    logger.Error(_LOG, ex.Message);
                }
            }
*/
            return null;
        }

        #endregion
    }
}