using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents an Attachment.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketAttachment
    /// </remarks>
    /// </summary>
    [XmlType("attachment")]
    public class Attachment
    {
        /// <summary>
        /// Gets a value indicating the ID of the attachment
        /// </summary>
        [XmlElement("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets a value indicating the TicketID of the attachment.
        /// </summary>
        [XmlElement("ticketid")]
        public int TicketID { get; set; }

        /// <summary>
        /// Gets a value indicating the ticketpostid of the attachment.
        /// </summary>
        [XmlElement("ticketpostid")]
        public int TicketPostID { get; set; }

        /// <summary>
        /// Gets a value indicating the filename of the attachment.
        /// </summary>
        [XmlElement("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Gets a value indicating the filesize of the attachment.
        /// </summary>
        [XmlElement("filesize")]
        public decimal FileSize { get; set; }

        /// <summary>
        /// Gets a value indicating the filetype of the attachment.
        /// </summary>
        [XmlElement("filetype")]
        public string Filetype { get; set; }

        /// <summary>
        /// Gets a value indicating the dateline of the attachment.
        /// </summary>
        [XmlElement("dateline")]
        public int Dateline { get; set; }

        /// <summary>
        /// Gets a value indicating the contents of the attachment.
        /// </summary>
        [XmlElement("contents")]
        public string Contents { get; set; }
    }
}
