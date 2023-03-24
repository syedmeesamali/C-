using System;
using System.Diagnostics;
using System.IO;

namespace My_Logger
{
    public class Loggy
    {
        EventLog eventLog;
        List<string> LogVals = new List<string>();
        

        public void Log(string message)
        {
            string eventLogName = "MyNewLog";
            string eventLogSource = "MySource";

            if (!EventLog.SourceExists(eventLogSource))
            {
                EventLog.CreateEventSource(eventLogSource, eventLogName);
            }
            using (EventLog eventLog = new EventLog(eventLogName))
            {
                eventLog.Source = eventLogSource;
                eventLog.WriteEntry(message);

                var entries = eventLog.Entries;
                DateTime now = DateTime.Now;
                foreach (EventLogEntry entry in entries)
                {
                    LogVals.Add("Event ID: {0}" + entry.InstanceId);
                    LogVals.Add("Time of occurence: " + now.ToString("F"));
                    LogVals.Add("Message: {0}" + entry.Message);
                }
            }
        } //End of log

        public void ExportToHtml(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("<html><body>");
                writer.WriteLine("<table border='1' style='border-collapse:collapse'>");
                writer.WriteLine("<tr><th>Event Details</th></tr>");

                foreach (var entry in LogVals)
                {
                    writer.WriteLine("<tr>");
                    writer.Write($"<td>{entry}</td>");
                    writer.Write("</tr>");
                }

                writer.WriteLine("</table>");
                writer.WriteLine("</body></html>");
            }
        }//End of export function

    } //End of class Loggy
}
