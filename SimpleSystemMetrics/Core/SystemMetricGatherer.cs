using SimpleSystemMetrics.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSystemMetrics.Core
{
    internal class SystemMetricGatherer
    {
        public MemoryMetrics GetMemoryMetrics()
        {
            var output = "";
            var info = new ProcessStartInfo
            {
                FileName = "wmic",
                Arguments = "OS get FreePhysicalMemory,TotalVisibleMemorySize /Value",
                RedirectStandardOutput = true,
                CreateNoWindow = true,
            };

            using (var process = Process.Start(info))
            {
                if (process != null)
                {
                    output = process.StandardOutput.ReadToEnd();
                }
            }

            var lines = output.Trim().Split("\n");
            var freeMemoryParts = lines[0].Split("=", StringSplitOptions.RemoveEmptyEntries);
            var totalMemoryParts = lines[1].Split("=", StringSplitOptions.RemoveEmptyEntries);
            var metrics = new MemoryMetrics
            {
                Total = Math.Round(double.Parse(totalMemoryParts[1]) / 1024, 0),
                Free = Math.Round(double.Parse(freeMemoryParts[1]) / 1024, 0)
            };
            metrics.Used = metrics.Total - metrics.Free;

            return metrics;
        }


        //info.FileName = "wmic";        
        //info.Arguments = "OS get FreePhysicalMemory,TotalVisibleMemorySize /Value";        
        //info.RedirectStandardOutput = true;
    }
}
