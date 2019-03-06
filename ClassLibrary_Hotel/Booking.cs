using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Hotel
{
    public class Booking
    {
        private int _bookingId;
        private int _room;
        private int _guest;
        private DateTime _dateFrom;
        private DateTime _dateTo;


        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }

        public int Room1
        {
            get { return _room; }
            set { _room = value; }
        }

        public int Guest1
        {
            get { return _guest; }
            set { _guest = value; }
        }

        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; }
        }

        public DateTime DateTo
        {
            get { return _dateTo; }
            set { _dateTo = value; }
        }
    }
}
