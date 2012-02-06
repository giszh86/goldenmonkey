using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkey.Processing.UI
{
    using Monkey.Processing;

    public class CustomPropertysManager
    {
        #region 单件模式实现

        /// <summary>
        /// 单件模式，构造函数为私有类型
        /// </summary>
        /// <remarks></remarks>
        CustomPropertysManager()
        {
            _factorys.Add(new ProcessingCustomPropertysFactory());
        }

        /// <summary>
        /// 实例获取接口
        /// 单件模式管理
        /// </summary>
        /// <returns>处理器管理器全局唯一变量</returns>
        /// <remarks></remarks>
        public static CustomPropertysManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_padLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CustomPropertysManager();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 单件唯一实例
        /// </summary>
        /// <remarks></remarks>
        static CustomPropertysManager _instance = null;

        /// <summary>
        /// 辅助静态成员，用于单件模式加锁处理
        /// </summary>
        /// <remarks></remarks>
        static readonly Object _padLock = new Object();

        #endregion


        #region 工厂管理
        /// <summary>
        /// 注册工厂
        /// </summary>
        /// <param name="factory">处工厂</param>
        /// <returns>注册成功返回true，否则返回false</returns>
        /// <remarks></remarks>
        //public Boolean RegisterFactory(ICustomPropertyMaker factory)
        public Boolean RegisterFactory(ICustomPropertysFactory factory)
        {
            if (null == factory)
            {
                return false;
            }

            if (_factorys.Contains(factory))
            {
                return false;
            }
            else
            {
                _factorys.Add(factory);
                return true;
            }        
        }

        /// <summary>
        /// 反注册工厂
        /// </summary>
        /// <param name="factory">工厂</param>
        /// <returns>反注册成功返回true，否则返回false</returns>
        /// <remarks></remarks>
        //public Boolean UnregisterFactory(ICustomPropertyMaker factory)
        public Boolean UnregisterFactory(ICustomPropertysFactory factory)
        {
            return _factorys.Remove(factory);
        }

        #endregion


        /// <summary>
        /// 根据工厂类型查找工厂
        /// </summary>
        /// <param name="type">工厂要创建的控件类型</param>
        /// <returns>找到返回，否则返回null</returns>
        /// <remarks></remarks>
//        public ICustomPropertyMaker Find(String type)
//        //public ICustomPropertyMaker Find(PropertyItem define)
//        {
//            ICustomPropertyMaker factory = null;
//            for (Int32 i = 0; i < _factorys.Count; ++i)
//            {
                
////                factory = _factorys.elementAt(i);
//                factory = _factorys[i];

//                if (null != factory)
//                {
//                    if (String.Compare(factory.Type, type, true) == 0)
//                    {
//                        return factory;
//                    }
//                }
//            }

//            return null;
//        }

        //public IDynamicControl Make(PropertyItem define)
        //{
        //    ICustomPropertyMaker maker = Find(define.Type);
        //    if (null == maker)
        //    {
        //        return null;
        //    }

        //    return maker.Make(define);
        //}

        public CustomProperty Make(PropertyItem define)
        {
            lock (this)
            {
                CustomProperty cp = null;
                foreach (ICustomPropertysFactory factory in _factorys)
                {
                    cp = factory.Make(define);
                    if (null != cp)
                    {
                        return cp;
                    }
                }
                return null;
                //ICustomPropertyMaker maker = Find(define.Type);
                //if (null == maker)
                //{
                //    return null;
                //}

                //return maker.Make(define);
            }
        }

        //public IDynamicControl Make(String type)
        //{
        //    return null;
        //}

        public String Category
        {
            get
            {
                return "参数设置";
            }
        }

        public String ValueDomain
        {
            get
            {
                return "ValueDomain";
            }
        }
        /// <summary>
        /// 处理器工厂列表
        /// </summary>
        /// <remarks></remarks>
        //private List<ICustomPropertyMaker> _factorys = new List<ICustomPropertyMaker>();
        private List<ICustomPropertysFactory> _factorys = new List<ICustomPropertysFactory>();
        
    }

    
}
