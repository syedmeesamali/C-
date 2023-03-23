using System;
using System.Diagnostics;
using System.IO;

class Logger
{
    private EventLog eventLog;
    string filePath = @"D:\SYED\Logs\report.html"; // specify your desired file path here

    public Logger()
    {
        using (EventLog session = new EventLog("MyNewLog")) {
            session.Source = "MySource";
            session.WriteEntry("Log entry message", EventLogEntryType.Information);
        }
    } //End of logger constructor

    public void Log(string message)
    {
        string eventLogName = "MyNewLog";
        string eventLogSource = "MySource";

        if (!EventLog.SourceExists(eventLogSource)) {
            EventLog.CreateEventSource(eventLogSource, eventLogName);
        }
        using (EventLog eventLog = new EventLog(eventLogName)) {
            eventLog.Source = eventLogSource;
            eventLog.WriteEntry(message);
            MessageBox.Show(eventLog.Source);
        }
    } //End of log

    public void ExportToHtml(string filePath)
    {
        var entries = eventLog.Entries;
        
        using (var writer = new StreamWriter(filePath))
        {
            writer.WriteLine("<html><body>");
            writer.WriteLine("<table>");
            writer.WriteLine("<tr><th>Event ID</th><th>Message</th></tr>");

            foreach (EventLogEntry entry in entries)
            {
                writer.WriteLine("<tr>");
                writer.WriteLine($"<td>{entry.EventID}</td>");
                writer.WriteLine($"<td>{entry.Message}</td>");
                writer.WriteLine("</tr>");
            }

            writer.WriteLine("</table>");
            writer.WriteLine("</body></html>");
        }
    }
}

