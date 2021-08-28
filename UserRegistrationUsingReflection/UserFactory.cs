using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace UserRegistrationUsingReflection
{
    class UserFactory
    {
        public Object CreateUserObject(string className, string constructorName)
        {
            //check class name and constructor name are same
            string pattern = constructorName + "$";
            Match res = Regex.Match(className, pattern);

            if (res.Success)
            {
                try
                {
                    //create assembly object
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type classType = assembly.GetType(className);
                    //create object
                    var obj = Activator.CreateInstance(classType);
                    return obj;
                }
                catch (CustomException ex)
                {
                    //exception if class not found
                    throw new CustomException(CustomException.ExceptionType.CLASS_NOT_FOUND, "Class Not found");
                }
            }
            else
            {
                //exception if constructor not found
                throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor Not found");
            }

        }

        /// <summary>
        /// Test method for setting field
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public string SetField(string message, string fieldName)
        {
            try
            {
                ValidateUserDetails user = new ValidateUserDetails();
                Type type = typeof(ValidateUserDetails);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new CustomException(CustomException.ExceptionType.EMPTY_MESSAGE, "Message should not be null");
                }
                fieldInfo.SetValue(user, message);
                return user.message;
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.FIELD_NOT_EXIST, "Feild is not found");
            }
        }
    }
}
