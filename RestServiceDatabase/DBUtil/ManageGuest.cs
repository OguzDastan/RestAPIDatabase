using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClassLibrary_Hotel;

namespace RestServiceDatabase.DBUtil
{
    public class ManageGuest : IManageGuest
    {
        private string queryString;
        private string connectionString = "Data Source=oguzserverdb.database.windows.net;Initial Catalog=MyServerDB;User ID=oguz0040;Password=Dastan12;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Guest> GetAllGuest()
        {
            List<Guest> lg = new List<Guest>();
            string queryString1 = "SELECT * FROM Guest";

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
            queryString = $"SELECT * FROM Guest " +
                          $"WHERE Id = {guestNr}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    g.GuestNo = reader.GetInt32(0);
                    g.Name = reader.GetString(1);
                    g.Adress = reader.GetString(2);
                }
            }
            return g;
        }

        public bool CreateGuest(Guest guest)
        {
            queryString = $"INSERT INTO Guest " +
                          $"(Id, Name, Address) " +
                          $"VALUES ({guest.GuestNo}, '{guest.Name}', '{guest.Adress}') ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                int i = command.ExecuteNonQuery();

                if (i > 0)
                {
                    Console.WriteLine("Success!");
                    return true;
                }
            }
            return false;
        }

        public bool UpdateGuest(Guest guest, int guestNr)
        {
            queryString = $"UPDATE Guest SET " +
                          $"Name = '{guest.Name}', " +
                          $"Address = '{guest.Adress}' " +
                          $"WHERE Id = {guestNr}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                int i = command.ExecuteNonQuery();

                if (i > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public Guest DeleteGuest(int guestNr)
        {
            Guest g = new Guest();

            // Read soon-to-be-deleted data
            string queryString2 = "SELECT * FROM Guest " +
                                  $"WHERE Id = {guestNr}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString2, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    g.GuestNo = reader.GetInt32(0);
                    g.Name = reader.GetString(1);
                    g.Adress = reader.GetString(2);
                }
            }

            // Delete data
            string queryString1 = $"DELETE FROM Guest " +
                          $"WHERE Id = {guestNr}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString1, connection);
                command.Connection.Open();

                command.ExecuteNonQuery();
            }

            return g;
        }
    }
}