using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{ 
    /// <summary>
    /// Definition of a list end tickets.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+Ticket
    /// </remarks>
    /// </summary>
    [XmlRoot("tickets")]
    public class Tickets : List<Ticket>
    {
        /// <summary>
        /// Create a list of tickets.
        /// </summary>
        public Tickets()
        {
        }
    }
}
