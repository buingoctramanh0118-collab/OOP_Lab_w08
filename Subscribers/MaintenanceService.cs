/*
MSSV: 202418832
Họ tên: Bùi Ngọc Trâm Anh
*/

using System;
using System.Collections.Generic;

namespace Labw08
{
    public class MaintenanceService
    {
        private readonly List<string> requests = new();
        public IReadOnlyList<string> Requests => requests.AsReadOnly();

        public void HandleCriticalAlert(object? sender, DeviceAlertEventArgs e)
        {
            if (e.Severity != AlertSeverity.Critical) return;

            string req = $"Maintenance request for {e.DeviceId}: {e.Message}";
            requests.Add(req);
            Console.WriteLine($"[MAINTENANCE] {req}");
        }
    }
}
