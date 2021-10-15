using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesAPI.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
