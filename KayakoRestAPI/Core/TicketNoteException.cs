using System;
using System.Collections.Generic;
using System.Text;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents errors that occur when requesting ticket notes
    /// </summary>
    public class TicketNoteException : Exception
    {
        /// <summary>
        //     Initializes a new instance of the KayakoRestAPI.core.TicketNoteException class.
        /// </summary>
        /// <param name="message_">The message that describes the error.</param>
        public TicketNoteException(string message_) : base(message_)
        {

        }

        /// <summary>
        //     Initializes a new instance of the KayakoRestAPI.core.TicketNoteException class.
        /// </summary>
        /// <param name="message_">The message that describes the error.</param>
        /// <param name="innerExp_">The exception that is the cause of the current exception, or a null reference.</param>
        public TicketNoteException(string message_, Exception innerExcp_) : base(message_, innerExcp_)
        {
            
        }
    }
}
