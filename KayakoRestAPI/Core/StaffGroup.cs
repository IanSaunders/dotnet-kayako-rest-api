using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents a staff group.
    /// </summary>
    /// <remarks>
    /// see: http://wiki.kayako.com/display/DEV/REST+-+StaffGroup#REST-StaffGroup-Response
    /// </remarks>
    [XmlType("staffgroup")]
    public class StaffGroup
    {
        /// <summary>
        /// Gets a value indicating the ID of the staff group
        /// </summary>
        [XmlElement("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets value indicating the Title of the staff group
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets a value indicating if this group is has admin privileges
        /// </summary>
        [XmlElement("isadmin")]
        public bool IsAdmin { get; set; }
    }
}
