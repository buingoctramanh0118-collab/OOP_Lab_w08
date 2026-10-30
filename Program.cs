/*
MSSV: 202418832
Họ tên: Bùi Ngọc Trâm Anh
*/

using System;
using System.Collections.Generic;

namespace Labw08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("HỆ THỐNG QUẢN LÝ THIẾT BỊ PHÒNG HỌC");

            var projector = new ProjectorRemote("PRJ-01", "Remote Máy chiếu D2-201");
            var ac = new AirConditionerRemote("AC-01", "Remote điều hòa", "D2-201");
            var mic = new WirelessMicrophone("MIC-01", "Micro không dây D2-201");

            var deviceList = new List<TeachingDevice> { projector, ac, mic };

            var consoleService = new ConsoleNotificationService();
            var auditLogger = new DeviceAuditLogger();
            var maintenanceService = new MaintenanceService();

            using (var coordinator = new DeviceMonitoringCoordinator(deviceList, consoleService, auditLogger, maintenanceService))
            {
                coordinator.Subscribe();

                Console.WriteLine("1. Đổi trạng thái thiết bị");
                projector.ChangeStatus(DeviceStatus.Borrowed);
                mic.ChangeStatus(DeviceStatus.UnderMaintenance);
                Console.WriteLine();

                Console.WriteLine("2. Mức pin Remote máy chiếu");
                projector.UpdateBatteryLevel(15);
                projector.UpdateBatteryLevel(0);
                Console.WriteLine();

                Console.WriteLine("3. Tín hiệu điều hòa");
                ac.UpdateResponseState(false);
                Console.WriteLine();

                Console.WriteLine("4. Chất lượng Micro");
                mic.UpdateSignalQuality(35);
                Console.WriteLine();

                Console.WriteLine("5. Lọc cảnh báo qua Custom Delegate");
                var criticalOnlyFilter = new FilteredAlertSubscriber(
                    alert => alert.Severity == AlertSeverity.Critical,
                    alert => Console.WriteLine($"[FILTERED - CRITICAL ONLY] Cảnh báo {alert.DeviceId}: {alert.Message}")
                );

                mic.AlertRaised += criticalOnlyFilter.HandleAlert;
                mic.UpdateSignalQuality(0);
                mic.AlertRaised -= criticalOnlyFilter.HandleAlert;
                Console.WriteLine();

                Console.WriteLine("6. Nhập sai chỉ số");
                try
                {
                    mic.UpdateBatteryLevel(150);
                }
                catch (InvalidDeviceReadingException ex)
                {
                    Console.WriteLine($"[NGOẠI LỆ] Thiết bị {ex.DeviceId} nhận giá trị không hợp lệ: {ex.InvalidValue}. Chi tiết: {ex.Message}");
                }
            }

            Console.WriteLine("\nCHƯƠNG TRÌNH KẾT THÚC");
        }
    }
}
