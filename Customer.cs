using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string MobilePhone
        {
            get { return _mobilePhone; }
            set { _mobilePhone = value; }
        }

        public string HomePhone
        {
            get { return _homePhone; }
            set { _homePhone = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public List<Device> Devices
        {
            get { return _devices; }
            set { _devices = value; }
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