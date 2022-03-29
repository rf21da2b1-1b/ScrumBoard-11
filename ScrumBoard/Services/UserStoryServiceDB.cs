using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public class UserStoryServiceDB:IUserStoryService
    {
        private const String ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";





        public List<UserStory> GetAll()
        {
            List<UserStory> liste = new List<UserStory>();
            String sql = "select * from UserStory";

            // opret forbindelse
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // åbner forbindelsen
                connection.Open();

                // opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // altid ved select
                SqlDataReader reader = cmd.ExecuteReader();

                // læser alle rækker
                while (reader.Read())
                {
                    UserStory us = ReadUserStory(reader);
                    liste.Add(us);
                }
            }

            return liste;
        }

        

        public UserStory GetById(int id)
        {
            String sql = "select * from UserSTory where Id=@Id";

            // opret forbindelse
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // åbner forbindelsen
                connection.Open();

                // opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);
                // indsæt værdierne
                cmd.Parameters.AddWithValue("@Id", id);

                // altid ved select
                SqlDataReader reader = cmd.ExecuteReader();

                // læser alle rækker
                while (reader.Read())
                {
                    UserStory us = ReadUserStory(reader);
                    return us;
                }
            }

            return null; // eller throw new KeyNotFoundException();
        }

        public UserStory Create(UserStory newUserStory)
        {
            String sql = "insert into UserStory(Title,Description, StoryPoints, BusinessValue, State) values(@Title, @Desc, @SP, @BV, @State)";

            // opret forbindelse
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // åbner forbindelsen
                connection.Open();

                // opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // indsæt værdierne
                cmd.Parameters.AddWithValue("@Title", newUserStory.Title);
                cmd.Parameters.AddWithValue("@Desc", newUserStory.Description);
                cmd.Parameters.AddWithValue("@SP", newUserStory.StoryPoints);
                cmd.Parameters.AddWithValue("@BV", newUserStory.BusinessValue);
                cmd.Parameters.AddWithValue("@State", (int)newUserStory.State);


                // altid ved Insert, update, delete
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // fejl
                    throw new ArgumentException("Not created");
                }

                return FindLatestInserted();
            }
        }

        

        public UserStory Delete(int id)
        {
            UserStory deletedUS= GetById(id);

            String sql = "delete from UserStory where Id=@ID";

            // opret forbindelse
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // åbner forbindelsen
                connection.Open();

                // opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // indsæt værdierne
                cmd.Parameters.AddWithValue("@ID", id);


                // altid ved Insert, update, delete
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // fejl
                }

                return deletedUS;
            }
        }

        public UserStory Modify(UserStory modifiedUserStory)
        {
            String sql = "update UserStory set Title=@Title, Description=@Desc, StoryPoints=@SP, BusinessValue=@BV, State=@State where Id=@UpdateId";

            // opret forbindelse
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // åbner forbindelsen
                connection.Open();

                // opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // indsæt værdierne
                cmd.Parameters.AddWithValue("@Title", modifiedUserStory.Title);
                cmd.Parameters.AddWithValue("@Desc", modifiedUserStory.Description);
                cmd.Parameters.AddWithValue("@SP", modifiedUserStory.StoryPoints);
                cmd.Parameters.AddWithValue("@BV", modifiedUserStory.BusinessValue);
                cmd.Parameters.AddWithValue("@State", (int)modifiedUserStory.State);
                cmd.Parameters.AddWithValue("@UpdateId", modifiedUserStory.Id);


                // altid ved Insert, update, delete
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // fejl
                    throw new ArgumentException("Could not update UserStory with id = " + modifiedUserStory.Id);
                }

                return modifiedUserStory;
            }
        }


        private UserStory ReadUserStory(SqlDataReader reader)
        {
            UserStory us = new UserStory();

            us.Id = reader.GetInt32(0);
            us.Title = reader.GetString(1);
            us.Description = reader.GetString(2);
            us.StoryPoints = reader.GetInt32(3);
            us.BusinessValue = reader.GetInt32(4);
            us.State = (UserStoryStateType)reader.GetInt32(5);

            return us;
        }

        private UserStory FindLatestInserted()
        {
            String sql = "SELECT TOP 1 * FROM UserStory ORDER BY Id DESC";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(sql, connection);
                
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    UserStory us = ReadUserStory(reader);
                    return us;
                }
            }

            return null; 

        }
    }
}
