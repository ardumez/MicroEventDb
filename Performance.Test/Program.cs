using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Parsers;
using Microsoft.Diagnostics.Tracing.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = new TraceEventSession("GC Listen"))
            {
                session.EnableProvider(
                    ClrTraceEventParser.ProviderGuid,
                    TraceEventLevel.Informational,
                    (ulong)ClrTraceEventParser.Keywords.GC);

                session.Source.Clr.GCStart += Clr_GCStart;

            }
        }

        private static void Clr_GCStart(Microsoft.Diagnostics.Tracing.Parsers.Clr.GCStartTraceData obj)
        {
            Console.WriteLine($"GCStart: Process: {obj.ProcessID}");
        }
    }
}
