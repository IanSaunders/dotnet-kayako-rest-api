using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{ 
    /// <summary>
    /// Definition of a list Ticket Statuses.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketStatus
    /// </remarks>
    /// </summary>
    [XmlRoot("ticketstatuses")]
    public class TicketStatuses : List<TicketStatus>
    {
        public TicketStatuses()
        {

        }
    }
}
