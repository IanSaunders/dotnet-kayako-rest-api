using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents a ticket and notes associated with that ticket.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+Ticket
    /// </remarks>
    /// </summary>
    [XmlType("ticket")]
    public class Ticket
    {
        /// <summary>
        /// Gets a value indicating the ID of the ticket
        /// </summary>
        [XmlAttribute("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets a value indicating the flag type
        /// </summary>
        [XmlAttribute("flagtype")]
        public int FlagType { get; set; }

        /// <summary>
        /// Gets a value indicating the display ID
        /// </summary>
        [XmlElement("displayid")]
        public string DisplayID { get; set; }

        /// <summary>
        /// Gets a value indicating the department ID
        /// </summary>
        [XmlElement("departmentid")]
        public int DepartmentID { get; set; }

        /// <summary>
        /// Gets a value indicating the status ID
        /// </summary>
        [XmlElement("statusid")]
        public int StatusID { get; set; }

        /// <summary>
        /// Gets a value indicating the priority ID
        /// </summary>
        [XmlElement("priorityid")]
        public int PriorityID { get; set; }

        /// <summary>
        /// Gets a value indicating the type ID
        /// </summary>
        [XmlElement("typeid")]
        public int TypeID { get; set; }

        /// <summary>
        /// Gets a value indicating the user ID who created the ticket
        /// </summary>
        [XmlElement("userid")]
        public int UserID { get; set; }

        /// <summary>
        /// Gets a value indicating the organization of the ticket creator
        /// </summary>
        [XmlElement("userorganization")]
        public string UserOrganization { get; set; }

        /// <summary>
        /// Gets a value indicating the organization ID of the ticket creator
        /// </summary>
        [XmlElement("userorganizationid")]
        public string UserOrganizationid { get; set; }

        /// <summary>
        /// Gets a value indicating the ID of the staff member who owns the ticket
        /// </summary>
        [XmlElement("ownerstaffid")]
        public int OwnerStaffID { get; set; }

        /// <summary>
        /// Gets a value indicating the name of the staff member who owns the ticket
        /// </summary>
        [XmlElement("ownerstaffnane")]
        public int OwnerStaffName { get; set; }

        /// <summary>
        /// Gets a value indicating the full name of the ticket creator
        /// </summary>
        [XmlElement("fullname")]
        public string Fullname { get; set; }

        /// <summary>
        /// Gets a value indicating the email address of the ticket creator
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets a value indicating the date of the last reply to the ticket
        /// </summary>
        [XmlElement("lastreplied")]
        public string LastReplied { get; set; }


        /// <summary>
        /// Gets a value indicating the subject of the ticket
        /// </summary>
        [XmlElement("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Gets a value indicating the creation time of the ticket
        /// </summary>
        [XmlElement("creationtime")]
        public string CreationTime { get; set; }

        /// <summary>
        /// Gets a value indicating the last activity on the ticket
        /// </summary>
        [XmlElement("lastactivity")]
        public string LastActivity { get; set; }

        /// <summary>
        /// Gets a value indicating the last reply to the ticket
        /// </summary>
        [XmlElement("laststaffreply")]
        public string LastStaffReply { get; set; }

        /// <summary>
        /// Gets a value indicating the last user reply to the ticket
        /// </summary>
        [XmlElement("lastuserreply")]
        public string LastUserReply { get; set; }

        /// <summary>
        /// Gets a value indicating the SLA PLan ID
        /// </summary>
        [XmlElement("slaplanid")]
        public string SLAPlanID { get; set; }

        /// <summary>
        /// Gets a value indicating when the next reply is due
        /// </summary>
        [XmlElement("nextreplydue")]
        public string NextReplyDue { get; set; }

        /// <summary>
        /// Gets a value indicating when the resolution is due
        /// /// </summary>
        [XmlElement("resolutiondue")]
        public string ResolutionDue { get; set; }

        /// <summary>
        /// Gets a value indicating the number of replies to this ticket
        /// /// </summary>
        [XmlElement("replies")]
        public int Replies { get; set; }

        /// <summary>
        /// Gets a value indicating the IP address the ticket was created with
        /// /// </summary>
        [XmlElement("ipaddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets a value indicating the creator ID (At least I think, havent checked yet...)
        /// /// </summary>
        [XmlElement("creator")]
        public int Creator { get; set; }

        /// <summary>
        /// Gets a value used to create the ticket
        /// /// </summary>
        [XmlElement("creationmode")]
        public int CreationMode { get; set; }

        /// <summary>
        /// Gets a value used to creation type
        /// /// </summary>
        [XmlElement("creationtype")]
        public string CreationType { get; set; }

        /// <summary>
        /// Gets a value indicating if the ticket has been escalated
        /// /// </summary>
        [XmlElement("isescalated")]
        public string IsEscalated { get; set; }

        /// <summary>
        /// Gets a value indicating the rule used to escalate the ticket
        /// /// </summary>
        [XmlElement("escalationruleid")]
        public string EscalationRuleID { get; set; }

        /// <summary>
        /// Gets a value a list of tags associated with ticket
        /// /// </summary>
        [XmlElement("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// List of notes associated with ticket
        /// </summary>
        [XmlElement("note")]
        public List<TicketNote> Notes { get; set; }

        /// <summary>
        /// List of Posts associated with ticket
        /// </summary>
        [XmlArray("posts")]
        [XmlArrayItem("post")]
        public List<TicketPost> Posts { get; set; }
    }
}
