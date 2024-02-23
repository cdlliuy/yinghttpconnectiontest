namespace yinghttpconnectiontest
{
    using System.Diagnostics;
    using System.Diagnostics.Tracing;
    using System.Text;

    internal sealed class HttpEventListener : EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            // Allow internal HTTP logging
            if (eventSource.Name == "Private.InternalDiagnostics.System.Net.Http")
            {
                EnableEvents(eventSource, EventLevel.LogAlways);
            }
            if (eventSource.Name == "Private.InternalDiagnostics.System.Net.Security")
            {
                EnableEvents(eventSource, EventLevel.LogAlways);
            }

        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            // Log whatever other properties you want, this is just an example
            var sb = new StringBuilder().Append($"{eventData.TimeStamp:HH:mm:ss.fffffff}[{eventData.EventName}] ");
            for (int i = 0; i < eventData.Payload?.Count; i++)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append(eventData.PayloadNames?[i]).Append(": ").Append(eventData.Payload[i]);
            }
            try
            {
                Console.WriteLine(sb.ToString());
            }
            catch { }
        }
    }

}
