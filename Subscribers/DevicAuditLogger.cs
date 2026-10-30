/*
MSSV: 202418832
Họ tên: Bùi Ngọc Trâm Anh
*/

using System;
using System.Collections.Generic;

namespace Labw08
{
public class DeviceAuditLogger
{
    private readonly List<string> entries = new();
    public IReadOnlyList<string> Entries => entries.AsReadOnly();

    public void HandleStatusChanged(
        object? sender,
        DeviceStatusChangedEventArgs e)
    {
        entries.Add(
            $"{e.ChangedAt}: {e.DeviceId}, " +
            $"{e.OldStatus} -> {e.NewStatus}");
    }
}
}
