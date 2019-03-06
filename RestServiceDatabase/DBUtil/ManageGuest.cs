using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ClassLibrary_Hotel;

namespace RestServiceDatabase.DBUtil
{
    public class ManageGuest : IManageGuest
    {
        private string queryString;
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Guest> GetAllGuest()
        {
            queryString = "SELECT * FROM DemoGuest";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GetAllGuest().Add(new Guest()
                    {
                        GuestNo = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Adress = reader.GetString(2)

                    });
                }

                return GetAllGuest();
            }
        }

        public Guest GetGuestFromId(int guestNr)
        {
            queryString = "SELECT * FROM DemoGuest WHERE Guest_No = guestNr";
            int guestID = guestNr;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    guestNr = reader.GetInt32(0);
                }
            }
            return GetGuestFromId(guestID);
        }

        public bool CreateGuest(Guest guest)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGuest(Guest guest, int guestNr)
        {
            throw new NotImplementedException();
        }

        public Guest DeleteGuest(int guestNr)
        {
            throw new NotImplementedException();
        }
    }
}