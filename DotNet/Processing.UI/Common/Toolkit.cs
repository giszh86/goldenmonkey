using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace Monkey.Processing.UI
{
    using Monkey.Processing;
    using Monkey.LicenseLibrary;

    internal class Toolkit
    {
        /// <summary>
        /// 
        /// </summary>
        public Toolkit()
        {
            _licProvider.Connect();
        }

        private static LicenseProvider _licProvider = new LicenseProvider();
        internal static Boolean Validate()
        {
            try
            {
                return _licProvider.Validate(LicenseProvider.ProductName.ProcessingUI, LicenseProvider.ProductVersion.V100);
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public static String[] ToStringArray(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                String[] result = new String[0];
                return result;
            }

            return value.Split(',');
        }

        public static Int32[] ToInt32Array(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                Int32[] result = new Int32[0];
                return result;
            }

            String[] array = value.Split(',');
            Int32[] intArray = new Int32[array.Length];
            for (Int32 i = 0; i < array.Length; ++i)
            {
                intArray[i] = Int32.Parse(array[i]);
            }

            return intArray;
        }

        public static Int32[] ToInt32Array(String[] value)
        {
            Int32[] intArray = new Int32[value.Length];
            for (Int32 i = 0; i < value.Length; ++i)
            {
                intArray[i] = Int32.Parse(value[i]);
            }

            return intArray;
        }

        public static Single[] ToSingleArray(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                Single[] result = new Single[0];
                return result;
            }

            String[] array = value.Split(',');
            Single[] singleArray = new Single[array.Length];
            for (Int32 i = 0; i < array.Length; ++i)
            {
                singleArray[i] = Single.Parse(array[i]);
            }

            return singleArray;
        }

        public static void CopyArray(String[] target, String[] source)
        {
            for (Int32 i = 0; i < source.Length && i < target.Length; ++i)
            {
                target[i] = source[i];
            }
        }

        public static void CopyArray(Int32[] target, Int32[] source)
        {
            for (Int32 i = 0; i < source.Length && i < target.Length; ++i)
            {
                target[i] = source[i];
            }
        }

        public static void CopyArray(Single[] target, Single[] source)
        {
            for (Int32 i = 0; i < source.Length && i < target.Length; ++i)
            {
                target[i] = source[i];
            }
        }

        public static void SaveToFile(String path, XmlDocument doc)
        {
            try
            {
                using (FileStream stream = File.Create(path))
                {

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;

                    XmlWriter writer = XmlWriter.Create(stream, settings);

                    doc.WriteTo(writer);
                    writer.Close();
                    stream.Close();
                    stream.Dispose();
                }
            }
            catch (Exception ex)
            {                
            }

        }
               
        //测试用
        [Conditional("TRACE"), Conditional("DEBUG")]
        internal static void DEBUG_TRACE(String strMsg)
        {
            Trace.WriteLine(strMsg + "\n");
        }  
    }
}
