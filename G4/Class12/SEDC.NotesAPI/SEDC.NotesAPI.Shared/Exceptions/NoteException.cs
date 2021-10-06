using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesAPI.Shared.Exceptions
{
    public class NoteException : Exception
    {
        public NoteException(string message) : base(message)
        {

        }
    }
}
