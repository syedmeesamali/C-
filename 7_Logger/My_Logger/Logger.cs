using System;
using System.Diagnostics;
using System.IO;

class Logger
{
    private EventLog eventLog;

    public Logger()
    {
        if (!EventLog.SourceExists("MySource"))
        {
            EventLog.CreateEventSource("MySource", "MyLog");
        }

        eventLog = new EventLog();
        eventLog.Source = "MySource";
        eventLog.Log = "MyLog";
    }

    public void Log(string message)
    {
        eventLog.WriteEntry(message);
    }

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

