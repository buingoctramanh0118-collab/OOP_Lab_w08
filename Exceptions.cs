/*
MSSV: 202418832
Họ tên: Bùi Ngọc Trâm Anh
*/

using System;

namespace Labw08
{
    public class InvalidDeviceReadingException : Exception
    {
        public string DeviceId { get; }
        public int InvalidValue { get; }

        public InvalidDeviceReadingException(string deviceId, int invalidValue, string message) 
            : base(message)
        {
            DeviceId = deviceId;
            InvalidValue = invalidValue;
        }
    }
}
