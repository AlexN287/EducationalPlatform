using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.Models.BusinessLogicLayer
{
    public class UserBLL
    {
        private static UserDAL userDAL = new UserDAL();

        public static User GetUserByNameAndPassword(string name, string password)
        {
            try
            {
                return userDAL.GetUserFromLogin(name, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a user: " + ex.Message);
                throw;
            }
        }

        public static void AddUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User cannot be null.");
                }

                userDAL.AddUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a user: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<User> GetUsersByRole(string role)
        {
            return userDAL.GetUsersByRole(role);
        }

        public static ObservableCollection<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }

        public static void UpdateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User cannot be null.");
                }

                userDAL.UpdateUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a user: " + ex.Message);
                throw;
            }
        }

        public static void DeleteUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User cannot be null.");
                }

                userDAL.DeleteUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a user: " + ex.Message);
                throw;
            }
        }
    }
}
