using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Hotel
{
    public class Room
    {
        private int _roomId;
        private char _roomType;
        private double _price;

        public int RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        public char RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
