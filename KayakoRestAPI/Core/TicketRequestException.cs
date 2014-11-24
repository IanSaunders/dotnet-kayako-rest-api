namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents errors that occur when requesting a ticket
    /// </summary>
    public class TicketRequestException : System.Exception
    {
        /// <summary>
        //     Initializes a new instance of the KayakoRestAPI.core.TicketRequestException class.
        /// </summary>
        /// <param name="message_">The message that describes the error.</param>
        public TicketRequestException(string message_) : base(message_)
        {
        }

        /// <summary>
        //     Initializes a new instance of the KayakoRestAPI.core.TicketRequestException class.
        /// </summary>
        /// <param name="message_">The message that describes the error.</param>
        /// <param name="innerExp_">The exception that is the cause of the current exception, or a null reference.</param>
        public TicketRequestException(string message_, System.Exception innerExp_) : base(message_, innerExp_)
        {
        }
    }
}
