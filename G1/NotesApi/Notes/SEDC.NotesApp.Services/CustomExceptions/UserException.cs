using System;

namespace SEDC.NotesApp.Services.CustomExceptions
{
    public class UserException : Exception
    {
        public UserException() { }

        public UserException(string message) : base(message) { }
    }
}
