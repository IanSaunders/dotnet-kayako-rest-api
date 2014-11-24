using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents an end user.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+User
    /// </remarks>
    /// </summary>
    [XmlType("user")]
    public class User
    {
        /// <summary>
        /// Gets a value indicating the ID of the user
        /// </summary>
        [XmlElement("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets a value indicating the group ID
        /// </summary>
        [XmlElement("usergroupid")]
        public int GroupID { get; set; }

        /// <summary>
        /// Gets a value indicating the User Role.
        /// </summary>
        [XmlElement("userrole")]
        public string Role { get; set; }

        /// <summary>
        /// Gets a value indicating the User Organisation ID.
        /// </summary>
        [XmlElement("userorganizationid")]
        public string OrganizationID { get; set; }

        /// <summary>
        /// Gets a value indicating the salutation
        /// </summary>
        [XmlElement("salutation")]
        public string Salutation { get; set; }

        /// <summary>
        /// Gets a value indicating the User Expiry.
        /// </summary>
        [XmlElement("userexpiry")]
        public string Expiry { get; set; }

        /// <summary>
        /// Gets a value indicating the users full name.
        /// </summary>
        [XmlElement("fullname")]
        public string Fullname { get; set; }

        /// <summary>
        /// Gets a value indicating the users email address.
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets a value indicating the users designation.
        /// </summary>
        [XmlElement("designation")]
        public string Designation { get; set; }

        /// <summary>
        /// Gets a value indicating the users phone number.
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets a value indicating the date of ther.
        /// </summary>
        [XmlElement("dateline")]
        public string Dateline { get; set; }

        /// <summary>
        /// Gets a value indicating the last visit of the user.
        /// </summary>
        [XmlElement("lastvisit")]
        public string LastVisit { get; set; }

        /// <summary>
        /// Gets a value indicating if the User is enabled.
        /// </summary>
        [XmlElement("isenabled")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets a value indicating the users timezone.
        /// </summary>
        [XmlElement("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Gets a value indicating if a user has DST enabled.
        /// </summary>
        [XmlElement("enabledst")]
        public bool EnableDST { get; set; }

        /// <summary>
        /// Gets a value indicating the SLA Plan of the user
        /// </summary>
        [XmlElement("slaplanid")]
        public int SLAPlanID { get; set; }

        /// <summary>
        /// Gets a value indicating the expiry date of the SLA plan
        /// </summary>
        [XmlElement("slaplanexpiry")]
        public string SLAPlanExpiry { get; set; }
    }
}
