using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Definition of a list of ticket notes 
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketNote
    /// </remarks>
    /// </summary>
    [XmlRoot("notes")]
    public class TicketNotes : List<TicketNote>
    {
        /// <summary>
        /// Create a list of ticket notes.
        /// </summary>
        public TicketNotes()
        {
        }
    }
}
