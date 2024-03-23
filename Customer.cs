using System.Collections.Generic;

namespace OptionCo
{
    public class Customer
    {
        private int _id;
        private string _name;
        private string _email;
        private string _mobilePhone;
        private string _homePhone;
        private List<Device> _devices;


        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string MobilePhone
        {
            get => _mobilePhone;
            set => _mobilePhone = value;
        }

        public string HomePhone
        {
            get => _homePhone;
            set => _homePhone = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public List<Device> Devices
        {
            get => _devices;
            set => _devices = value;
        }

        public Customer(int id, string name, string email, string mobilePhone, string homePhone, List<Device> devices)
        {
            _id = id;
            _name = name;
            _email = email;
            _mobilePhone = mobilePhone;
            _homePhone = homePhone;
            _devices = devices;
        }
    }
}