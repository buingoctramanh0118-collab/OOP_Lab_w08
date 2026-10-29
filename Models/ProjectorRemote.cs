/*
MSSV: 202418832
Họ tên: Bùi Ngọc Trâm Anh
*/

namespace Labw08
{
    public class ProjectorRemote : TeachingDevice
    {
        public int BatteryLevel { get; private set; } = 100;

        public ProjectorRemote(string id, string name) : base(id, name) { }

        public void UpdateBatteryLevel(int newLevel)
        {
            if (newLevel < 0 || newLevel > 100)
                throw new InvalidDeviceReadingException(Id, newLevel, "Mức pin phải từ 0 đến 100");

            int oldLevel = BatteryLevel;
            BatteryLevel = newLevel;

            if (newLevel == 0 && oldLevel != 0)
            {
                RaiseAlert($"Pin điều khiển máy chiếu 0%", AlertSeverity.Critical);
            }
            else if (newLevel < 20 && oldLevel >= 20)
            {
                RaiseAlert($"Pin điều khiển máy chiếu yếu ({newLevel}%).", AlertSeverity.Warning);
            }
        }
    }
}
