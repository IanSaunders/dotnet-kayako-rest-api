using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents a staff user.
    /// </summary>
    /// <remarks>
    /// http://wiki.kayako.com/display/DEV/REST+-+Staff#REST-Staff-Response
    /// </remarks>
    [XmlType("staff")]
    public class StaffUser
    {
        /// <summary>
        /// Gets a value indicating the ID
        /// </summary>
        [XmlElement("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the group ID of the staff member
        /// </summary>
        [XmlElement("staffgroupid")]
        public int GroupID { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        [XmlElement("firstname")]
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        [XmlElement("lastname")]
        public string Lastname { get; set; }

        /// <summary>
        /// Gets or sets the full name
        /// </summary>
        [XmlElement("fullname")]
        public string Fullname { get; set; }

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        [XmlElement("username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the designation
        /// </summary>
        [XmlElement("designation")]
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the greeting
        /// </summary>
        [XmlElement("greeting")]
        public string Greeting { get; set; }

        /// <summary>
        /// Gets or sets the mobile number
        /// </summary>
        [XmlElement("mobilenumber")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the enabled state
        /// </summary>
        [XmlElement("isenabled")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the users timezone
        /// </summary>
        [XmlElement("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if DST is enabled
        /// </summary>
        [XmlElement("enabledst")]
        public int EnableDST { get; set; }
    }
}
