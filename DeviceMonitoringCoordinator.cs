/*
MSSV: 202418832
Họ tên: Bùi Ngọc Trâm Anh
*/

using System;
using System.Collections.Generic;

namespace Labw08
{
    public class DeviceMonitoringCoordinator : IDisposable
    {
        private readonly List<TeachingDevice> devices;
        private readonly ConsoleNotificationService notificationService;
        private readonly DeviceAuditLogger auditLogger;
        private readonly MaintenanceService maintenanceService;
        private bool isSubscribed = false;

        public DeviceMonitoringCoordinator(
            IEnumerable<TeachingDevice> devices,
            ConsoleNotificationService notificationService,
            DeviceAuditLogger auditLogger,
            MaintenanceService maintenanceService)
        {
            this.devices = new List<TeachingDevice>(devices);
            this.notificationService = notificationService;
            this.auditLogger = auditLogger;
            this.maintenanceService = maintenanceService;
        }

        public void Subscribe()
        {
            if (isSubscribed) return;

            foreach (var device in devices)
            {
                device.StatusChanged += auditLogger.HandleStatusChanged;
                device.AlertRaised += notificationService.HandleAlert;
                device.AlertRaised += maintenanceService.HandleCriticalAlert;
            }
            isSubscribed = true;
            Console.WriteLine("Đã hoàn tất đăng ký sự kiện cho tất cả thiết bị.\n");
        }

        public void Unsubscribe()
        {
            if (!isSubscribed) return;

            foreach (var device in devices)
            {
                device.StatusChanged -= auditLogger.HandleStatusChanged;
                device.AlertRaised -= notificationService.HandleAlert;
                device.AlertRaised -= maintenanceService.HandleCriticalAlert;
            }
            isSubscribed = false;
            Console.WriteLine("\nĐã hủy đăng ký sự kiện cho tất cả thiết bị.");
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}
