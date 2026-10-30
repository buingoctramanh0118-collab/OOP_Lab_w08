/*
MSSV: 202418832
Họ tên: Bùi Ngọc Trâm Anh
*/

namespace Labw08
{
    public class AirConditionerRemote : TeachingDevice
    {
        public string AssignedRoom { get; }
        public bool IsResponsive { get; private set; } = true;

        public AirConditionerRemote(string id, string name, string assignedRoom) : base(id, name)
        {
            AssignedRoom = assignedRoom;
        }

        public void UpdateResponseState(bool isResponsive)
        {
            if (IsResponsive && !isResponsive)
            {
                IsResponsive = false;
                RaiseAlert($"Điều hòa phòng {AssignedRoom} không phản hồi", AlertSeverity.Critical);
            }
            else
            {
                IsResponsive = isResponsive;
            }
        }
    }
}
