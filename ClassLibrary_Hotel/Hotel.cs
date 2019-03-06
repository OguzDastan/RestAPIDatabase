using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Hotel
{
    public class Hotel
    {
        private int _hotelNo;
        private string _name;
        private string _address;


        public int HotelNo
        {
            get { return _hotelNo; }
            set { _hotelNo = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
