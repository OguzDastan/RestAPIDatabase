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
            List<Guest> lg = new List<Guest>();
            string queryString1 = "SELECT * FROM DemoGuest";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString1, connection);
                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lg.Add(new Guest()
                        {
                            GuestNo = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Adress = reader.GetString(2)
                        });
                    }
                }

                return lg;
            }
        }

        public Guest GetGuestFromId(int guestNr)
        {
            Guest g = new Guest();
            queryString = $"SELECT * FROM DemoGuest " +
                          $"WHERE Guest_No = {guestNr}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    g.GuestNo = reader.GetInt32(0);
                }
                reader.Close();
                connection.Close();
            }
            return g;
        }

        public bool CreateGuest(Guest guest)
        {
            queryString = $"INSERT INTO DemoGuest " +
                          $"(Guest_No, Name, Address) " +
                          $"VALUES ({guest.GuestNo}, '{guest.Name}', '{guest.Adress}') ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                int i = command.ExecuteNonQuery();

                if (i > 0)
                {
                    return true;
                }

                command.Clone();
                connection.Close();
            }
            return false;
        }

        public bool UpdateGuest(Guest guest, int guestNr)
        {
            queryString = $"UPDATE DemoGuest SET " +
                          $"Name = '{guest.Name}', " +
                          $"Address = '{guest.Adress}' " +
                          $"WHERE Guest_No = {guestNr}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                int i = command.ExecuteNonQuery();

                if (i > 0)
                {
                    return true;
                }
                command.Clone();
                connection.Close();
            }
            return false;
        }

        public Guest DeleteGuest(int guestNr)
        {
            Guest g = new Guest();
            
            queryString = $"DELETE FROM DemoGuest " +
                          $"WHERE Guest_No = {guestNr}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                command.ExecuteNonQuery();
            }
            return g;
        }
    }
}