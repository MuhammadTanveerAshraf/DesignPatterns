using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Solid_Principles
{
    internal class SingleResponsibility
    {
        public SingleResponsibility()
        {
            Console.WriteLine("Single Responsibility");
            var user = new object();
            var userService = new UserService();
            var result = userService.Register(user);
            if (result)
            {
                var userEmail = string.Empty;
                new EmailService().SendEmail(userEmail);
            }
        }
    }

    public class UserService
    {
        public bool Register(object user)
        {
            //Register User and save data in database
            return true;
        }
    }

    public class EmailService
    {
        public void SendEmail(string email)
        {
            //Send email functionality here
        }
    }
}
