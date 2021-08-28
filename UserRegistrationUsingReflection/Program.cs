using System;

namespace UserRegistrationUsingReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************This is User Registeration Problem Using Reflection****************");

            ValidateUserDetails validate = new ValidateUserDetails();
            validate.ValidateUser();
        }
    }
}
