using SimpleSystemMetrics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSystemMetrics.Core
{
    public class SimpleSystemMetric : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayContextMenuStrip;
        private OverviewForm overviewForm = new OverviewForm();
        private SystemMetricGatherer gatherer = new SystemMetricGatherer();
        private int interval = 5000;
        private System.Timers.Timer MemoryMetricsTimer = new System.Timers.Timer();
        public SimpleSystemMetric()
        {
            trayContextMenuStrip = new ContextMenuStrip();
            trayContextMenuStrip.Items.Add("Overview Panel");
            trayContextMenuStrip.Items.Add("Exit");
            trayContextMenuStrip.ItemClicked += (sender, e) =>
            {
                if (e.ClickedItem.Text == "Exit")
                {
                    Exit();
                }
                else if (e.ClickedItem.Text == "Overview Panel")
                {
                    overviewForm.Show();
                }
            };

            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.AppIcon,
                ContextMenuStrip = trayContextMenuStrip,
                Visible = true
            };

            MemoryMetricsTimer.Interval = interval;
            MemoryMetricsTimer.Elapsed += GetAndSetMemoryMetrics;
            MemoryMetricsTimer.AutoReset = true;
            MemoryMetricsTimer.Enabled = true;

            //var bTimer = new System.Timers.Timer();
            //bTimer.Interval = 2000;
            //bTimer.Elapsed += OnTimedEventB;
            //bTimer.AutoReset = true;
            //bTimer.Enabled = true;
        }

        // should we separate GetAndSetMemoryMetrics() into another more suitable class?
        private void GetAndSetMemoryMetrics(object source, System.Timers.ElapsedEventArgs e)
        {
            Task.Run(() =>
            {
                MemoryMetrics memoryMetrics = gatherer.GetMemoryMetrics();
                overviewForm.SetMemoryUsageTexts(memoryMetrics);

            });
        }

        void Exit()
        {
            MemoryMetricsTimer.Dispose();
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}