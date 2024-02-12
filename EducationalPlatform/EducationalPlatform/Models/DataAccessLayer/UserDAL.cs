using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Models.Models;

namespace Tema3_MVP.Models.DataAccessLayer
{
    public class UserDAL
    {
        public int GetUserID(User user)
        {
            SqlConnection connection = DALHelper.Connection;
            string storedProcedure = "GetUserByID";

                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", user.username);
                    command.Parameters.AddWithValue("@password", user.password);
                    command.Parameters.Add("@user_id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    int userId = (int)command.Parameters["@user_id"].Value;

                    if (userId != 0)
                    {
                    // User exists, do something with the user ID
                    return userId;
                    }
                    else
                    {
                    // User does not exist or the provided credentials are incorrect
                    MessageBox.Show("Invalid username or password");
                    return 0;
                    
                    }
                }
        }

        public User GetUserFromLogin(string username, string password)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GetUserByUsernameAndPassword", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int userId = (int)reader["user_id"];
                        string userType = ((string)reader["role"]).Trim();

                        return new User(userId, username, password, userType);
                    }
                }

                reader.Close();
            }

            return null;
        }

        public void AddUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@role", user.role);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public ObservableCollection<User> GetUsersByRole(string role)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetUsersByRole", con);
                ObservableCollection<User> result = new ObservableCollection<User>();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", role);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new User()
                        {
                            UserID = (int)reader["user_id"],
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString(),
                            Role = reader["role"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<User> GetAllUsers()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", con);
                ObservableCollection<User> result = new ObservableCollection<User>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new User()
                        {
                            UserID = (int)reader["user_id"],
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString(),
                            Role = reader["role"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@user_id", user.UserID);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@role", user.role);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@user_id", user.UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
    
