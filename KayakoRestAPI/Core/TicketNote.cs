using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents a ticket note
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketNote#REST-TicketNote-Response
    /// </remarks>
    /// </summary>
    [XmlType("note")]
    public class TicketNote
    {
        /// <summary>
        /// Gets or sets value indicating the type of note.
        /// </summary>
        [XmlAttribute("type")]
        public string type { get; set; }

        /// <summary>
        /// Gets or sets value indicating the note color.
        /// </summary>
        [XmlAttribute("notecolor")]
        public int NoteColor { get; set; }

        /// <summary>
        /// Gets or sets value indicating the staff id of the note creator.
        /// </summary>
        [XmlAttribute("creatorstaffid")]
        public int CreatorStaffID { get; set; }

        /// <summary>
        /// Gets or sets value indicating who the note is viewable by
        /// </summary>
        [XmlAttribute("forstaffid")]
        public int ForStaffID { get; set; }

        /// <summary>
        /// Gets or sets value indicating the name of the staff member who created the note.
        /// </summary>
        [XmlAttribute("creatorstaffname")]
        public string CreatorStaffName { get; set; }

        /// <summary>
        /// Gets or sets value indicating the creation date of the note
        /// </summary>
        [XmlAttribute("creationdate")]
        public int CreationDate { get; set; }

        /// <summary>
        /// Gets or sets content of the note
        /// </summary>
        [XmlText]
        public string Content { get; set; }
    }
}
