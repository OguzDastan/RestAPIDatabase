using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Hotel
{
    public class Guest
    {
        private int _guestNo;
        private string _name;
        private string _adress;

        public int GuestNo
        {
            get { return _guestNo; }
            set { _guestNo = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }
    }
}
