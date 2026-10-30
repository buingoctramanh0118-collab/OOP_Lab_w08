
/*
MSSV: 202418832
Họ tên: Bùi Ngọc Trâm Anh
*/

using System;

namespace Labw08
{
    public class ConsoleNotificationService
    {
        public void HandleAlert(object? sender, DeviceAlertEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] {e.DeviceId}: {e.Message}");
        }
    }
}
