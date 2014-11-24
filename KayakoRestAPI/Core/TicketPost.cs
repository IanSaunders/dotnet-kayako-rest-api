using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents a ticket post
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketPost
    /// </remarks>
    /// </summary>
    [XmlType("post")]
    [Serializable]
    public class TicketPost
    {
        /// <summary>
        /// Gets a value indicating the ID of the ticket post
        /// </summary>
        [XmlElement("ticketpostid")]
        public int ID { get; set; }

        /// <summary>
        /// Gets a value indicating the time of the post
        /// </summary>
        [XmlElement("dateline")]
        public int DateLine { get; set; }

        /// <summary>
        /// Gets a value indicating the User ID of the poster
        /// </summary>
        [XmlElement("userid")]
        public int UserID { get; set; }

        /// <summary>
        /// Gets a value indicating the Full name of the poster
        /// </summary>
        [XmlElement("fullname")]
        public string Fullname { get; set; }

        /// <summary>
        /// Gets a value indicating the email of the poster
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets a value indicating the email to address of the poster
        /// </summary>
        [XmlElement("emailto")]
        public string EmailTo { get; set; }

        /// <summary>
        /// Gets a value indicating the IP Address of the poster
        /// </summary>
        [XmlElement("ipaddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets a value indicating the ID of the ticket creator
        /// </summary>
        [XmlElement("creator")]
        public int Creator { get; set; }

        /// <summary>
        /// Gets a value indicating the Staff ID assigned to this ticket
        /// </summary>
        [XmlElement("staffid")]
        public int StaffID { get; set; }

        /// <summary>
        /// Gets a value indicating if this post is from a third party.
        /// </summary>
        [XmlElement("isthirdparty")]
        public bool IsThirdParty { get; set; }

        /// <summary>
        /// Gets a value indicating if this post was created from HTML
        /// </summary>
        [XmlElement("ishtml")]
        public bool IsHTML { get; set; }
        
        /// <summary>
        /// Gets a value indicating if this post was created from an email
        /// </summary>
        [XmlElement("isemailed")]
        public bool isemailed { get; set; }

        /// <summary>
        /// Gets a value indicating if this post is a survery comment
        /// </summary>
        [XmlElement("issurverycomment")]
        public bool IsSurveryComment { get; set; }

        /// <summary>
        /// Gets the contents of the post.
        /// </summary>
        [XmlElement("contents")]
        public string Contents { get; set; }
    }
}
