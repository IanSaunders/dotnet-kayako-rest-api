using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Definition of a list TicketAttachments.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketAttachment
    /// </remarks>
    /// </summary>
    [XmlRoot("attachments")]
    public class Attachments : List<Attachment>
    {
        /// <summary>
        /// Create a list of attachments.
        /// </summary>
        public Attachments()
        {
        }
    }
}
