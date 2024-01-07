namespace OptionCo
{
    public class Repair
    {
        private int _id;
        private string _description;
        private string _dateIn;
        private string _dateOut;
        private string _status;
        private int _customerId;
        private int _deviceId;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string DateIn
        {
            get { return _dateIn; }
            set { _dateIn = value; }
        }

        public string DateOut
        {
            get { return _dateOut; }
            set { _dateOut = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public int DeviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }
        

        public Repair(int id, string description, string dateIn, string dateOut, string status, int customerId, int deviceId)
        {
            _id = id;
            _description = description;
            _dateIn = dateIn;
            _dateOut = dateOut;
            _status = status;
            _customerId = customerId;
            _deviceId = deviceId;
        }



    }
}