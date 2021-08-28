﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UserRegistrationUsingReflection
{
    public class CustomException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            FIELD_NOT_EXIST, EMPTY_MESSAGE,
            CLASS_NOT_FOUND, CONSTRUCTOR_NOT_FOUND,
            METHOD_NOT_FOUND, INVALID_INPUT
        }
        public CustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

    }
}
