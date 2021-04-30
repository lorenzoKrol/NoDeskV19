using System;
using TGG_DAL;
using TGG_Model;
using System.Collections.Generic;

namespace TGG_Service
{
    public class User_Service
    {
        User_DAO User_DAO = new User_DAO();
        public void AddUser(string email, string name, string password, string status)
        {
            try
            {
                User_DAO.AddUser(email, name, password, status);
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
            
        }
        public void UpdateUser(string originalEmail,string email, string name, string password, string status)
        {
            try
            {
                User_DAO.UpdateUser(originalEmail, email, name, password, status);
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
        }

        public User GetUser(string username)
        {
            try
            {
                return User_DAO.GetUser(username);
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
            
        }

        public User verifyUserCredentials(string username, string password)
        {
            try
            {
                return User_DAO.verifyUserCredentials(username, password);
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
        }
        public List<User> GetAllUsers()
        {
            try
            {
                return User_DAO.GetAllUsers();
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }
        }
        public void DeleteUser(string email)
        {
            try
            {
                User_DAO.DeleteUser(email);
            }
            catch (Exception e)
            {
                throw new Exception(" " + e.Message);
            }

        }
    }
}
