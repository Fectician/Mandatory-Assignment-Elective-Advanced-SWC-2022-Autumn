using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameFrameWork
{
    public static class Tracing
    {
        static XmlDocument configDoc = new XmlDocument();
        private static TraceSource ts;
        static string FrameworkConfigDebugLevel()
        {
            configDoc.Load(@"../../../FrameworkConfig.xml");
            XmlNode nameNode = configDoc.DocumentElement.SelectSingleNode("DebugLevel");
            if (nameNode != null)
            {
                String str = nameNode.InnerText.Trim();
                return str;
            }
            return "All";
        }
        public static void TraceRunner()
        {
            if (ts != null) return;
            ts = new TraceSource("Tracer");
            string DebugLevel = FrameworkConfigDebugLevel();
            ts.Switch = new SourceSwitch("Objo", DebugLevel);
            TraceListener listen1 = new ConsoleTraceListener();
            TraceListener listen2 = new TextWriterTraceListener(new StreamWriter("FrameworkLog.txt"));

            //listen2.Filter = new EventTypeFilter(SourceLevels.Warning);

            ts.Listeners.Add(listen1);
            ts.Listeners.Add(listen2);
        }

        public static void TraceOutput(string output, TraceEventType debuglevel)
        {
            ts.TraceEvent(debuglevel, 333, output);
            ts.Flush();
        }
    }
}
