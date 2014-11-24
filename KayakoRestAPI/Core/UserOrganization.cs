using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents a User Organization
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+UserOrganization
    /// </remarks>
    /// </summary>
    [XmlType("userorganization")]
    public class UserOrganization
    {
        public UserOrganization()
        {
        }

        /// <summary>
        /// Gets a value indicating the ID of the organisation
        /// </summary>
        [XmlElement("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets a value indicating the Name of the organisation
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets a value indicating the OrganizationType of the organisation
        /// </summary>
        [XmlElement("organizationtype")]
        public string OrganizationType { get; set; }

        /// <summary>
        /// Gets a value indicating the Address of the organisation
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets a value indicating the City of the organisation
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets a value indicating the State of the organisation
        /// </summary>
        [XmlElement("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets a value indicating the PostalCode of the organisation
        /// </summary>
        [XmlElement("postalcode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets a value indicating the Country of the organisation
        /// </summary>
        [XmlElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets a value indicating the Phone of the organisation
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets a value indicating the Fax of the organisation
        /// </summary>
        [XmlElement("fax")]
        public string Fax { get; set; }

        /// <summary>
        /// Gets a value indicating the Website of the organisation
        /// </summary>
        [XmlElement("website")]
        public string Website { get; set; }

        /// <summary>
        /// Gets a value indicating the Dateline of the organisation
        /// </summary>
        [XmlElement("dateline")]
        public string Dateline { get; set; }

        /// <summary>
        /// Gets a value indicating when the organisation was LastUpdated
        /// </summary>
        [XmlElement("lastupdated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// Gets a value indicating the SLAPlanID of the organisation
        /// </summary>
        [XmlElement("slaplanid")]
        public int? SLAPlanID { get; set; }

        /// <summary>
        /// Gets a value indicating the SLAPlanExpiry of the organisation
        /// </summary>
        [XmlElement("slaplanexpiry")]
        public string SLAPlanExpiry { get; set; }
    }
}
