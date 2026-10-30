/*
MSSV: 202418832
Họ tên: Bùi Ngọc Trâm Anh
*/

using System;

namespace Labw08
{
    public delegate bool AlertFilter(DeviceAlertEventArgs alert);

    public class FilteredAlertSubscriber
    {
        private readonly AlertFilter filter;
        private readonly Action<DeviceAlertEventArgs> action;

        public FilteredAlertSubscriber(AlertFilter filter, Action<DeviceAlertEventArgs> action)
        {
            this.filter = filter;
            this.action = action;
        }

        public void HandleAlert(object? sender, DeviceAlertEventArgs e)
        {
            if (filter(e))
            {
                action(e);
            }
        }
    }
}
