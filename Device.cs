using System.Collections.Generic;

namespace OptionCo
{
    public class Device
    {
        private int _id;
        private string _serialKey;
        private string _deviceType;
        private int _customerId;
        private List<Repair> _repairs;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string SerialKey
        {
            get => _serialKey;
            set => _serialKey = value;
        }

        public string DeviceType
        {
            get => _deviceType;
            set => _deviceType = value;
        }

        public List<Repair> Repair
        {
            get => _repairs;
            set => _repairs = value;
        }

        public int CustomerId
        {
            get => _customerId;
            set => _customerId = value;
        }

        public Device(int id, string serialKey, int customerId, string deviceType, List<Repair> repairs)
        {
            _id = id;
            _serialKey = serialKey;
            _customerId = customerId;
            _deviceType = deviceType;
            _repairs = repairs;
        }
    }
}