using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserRegistrationUsingReflection
{
  public  class ValidateUserDetails
    {
        public string message;
        UserFields fields = new UserFields();

        public ValidateUserDetails(string message)
        {
            this.message = message;
        }
        public ValidateUserDetails()
        {

        }
        public void ValidateUser()
        {
            //Read input from user and store it in object

            Console.Write("Enter first name :");
            fields.firstName = Console.ReadLine();
            Console.Write("Enter Last name : ");
            fields.lastName = Console.ReadLine();
            Console.Write("Enter Email Id : ");
            fields.emailId = Console.ReadLine();
            Console.Write("Enter Phone Number :");
            fields.phoneNum = Console.ReadLine();
            Console.Write("Enter Password : ");
            fields.password = Console.ReadLine();
            ValidateUserAnnotationFields();
        }

        public void ValidateUserAnnotationFields()
        {
            //validate object
            ValidationContext validationContext = new ValidationContext(fields, null, null);
            //List for error messages
            List<ValidationResult> validationResults = new List<ValidationResult>();
            //return whether validation is correct or not
            bool isValid = Validator.TryValidateObject(fields, validationContext, validationResults, true);

            if (!isValid)
            {
                //if invalid print error messages
                foreach (ValidationResult validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }

        }
    }
}
