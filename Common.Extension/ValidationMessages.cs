using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace Common.Extension
{
    public static class ValidationMessages
    {
        public static Dictionary<string, string> ValidationMsgs;
        static readonly object Locker = new object();

        /// <summary>
        /// Initializes the <see cref="ValidationMessages"/> class.
        /// </summary>
        public static void Init(string path)
        {
            if (ValidationMsgs == null || ValidationMsgs.Keys.Count == 0)
            {
                if (Monitor.TryEnter(Locker))
                {
                    try
                    {
                        //var xmlFile = AppDomain.CurrentDomain.BaseDirectory + AppConfiguration.MESSAGEXMLFILEPATH;

                        var doc = XDocument.Load(path);

                        ValidationMsgs = doc.Descendants("messages")
                                                 .First()
                                                 .Elements("message")
                                                 .ToDictionary(x => (string)x.Attribute("key"),
                                                           x => (string)x.Attribute("value"));

                    }
                    finally
                    {
                        Monitor.Exit(Locker);
                    }
                }
            }
        }
    }
}
