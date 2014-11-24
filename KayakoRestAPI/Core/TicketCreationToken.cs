using System; 
using System.Collections.Generic;
using System.Text;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents a token used to create a ticket
    /// </summary>
    public class TicketCreationToken
    {  
        /// <summary>
        /// Create a new ticket. 
        /// ownerstaffid and type are optional.
        /// Either UserID or StaffID should be correctly set the other should be set to null.
        /// All other arguments required.
        /// </summary>
        /// <param name="subject_">The Ticket Subject</param>
        /// <param name="fullname_">Full Name of creator</param>
        /// <param name="email_">Email Address of creator</param>
        /// <param name="contents_">The contents of the first ticket post</param>
        /// <param name="departmentid_">The Department ID</param>
        /// <param name="ticketstatusid_">The Ticket Status ID</param>
        /// <param name="ticketpriorityid_">The Ticket Priority ID</param>
        /// <param name="tickettypeid_">The Ticket Type ID</param>
        /// <param name="userid_">The User ID, if the ticket is to be created as a user.</param>
        /// <param name="staffid_">The Staff ID, if the ticket is to be created as a staff</param>
        public TicketCreationToken
            (
              string subject_,
              string fullname_,
              string email_,
              string contents_,
              int departmentid_,
              int ticketstatusid_,
              int ticketpriorityid_,
              int tickettypeid_,
              int? userid_,
              int? staffid_
            ) :
            this(
              subject_,
              fullname_,
              email_,
              contents_,
              departmentid_,
              ticketstatusid_,
              ticketpriorityid_,
              tickettypeid_,
              userid_,
              staffid_,
              null,
              "default"
        )
        {
        }
        /// <summary>
        /// Create a new ticket. 
        /// ownerstaffid and type are optional.
        /// Either UserID or StaffID should be correctly set the other should be set to null.
        /// All other arguments required.
        /// </summary>
        /// <param name="subject_">The Ticket Subject</param>
        /// <param name="fullname_">Full Name of creator</param>
        /// <param name="email_">Email Address of creator</param>
        /// <param name="contents_">The contents of the first ticket post</param>
        /// <param name="departmentid_">The Department ID</param>
        /// <param name="ticketstatusid_">The Ticket Status ID</param>
        /// <param name="ticketpriorityid_">The Ticket Priority ID</param>
        /// <param name="tickettypeid_">The Ticket Type ID</param>
        /// <param name="userid_">The User ID, if the ticket is to be created as a user.</param>
        /// <param name="staffid_">The Staff ID, if the ticket is to be created as a staff</param>
        /// <param name="ownerstaffid_">The Owner Staff ID, if you want to set an Owner for this ticke</param>
        public TicketCreationToken
            (
              string subject_,
              string fullname_,
              string email_,
              string contents_,
              int departmentid_,
              int ticketstatusid_,
              int ticketpriorityid_,
              int tickettypeid_,
              int? userid_,
              int? staffid_,
              int? ownerstaffid_
            ) :
            this(
              subject_,
              fullname_,
              email_,
              contents_,
              departmentid_,
              ticketstatusid_,
              ticketpriorityid_,
              tickettypeid_,
              userid_,
              staffid_,
              ownerstaffid_,
              "default"
        )
        {
        }

        /// <summary>
        /// Create a new ticket. 
        /// ownerstaffid and type are optional.
        /// Either UserID or StaffID should be correctly set the other should be set to null.
        /// All other arguments required.
        /// </summary>
        /// <param name="subject_">The Ticket Subject</param>
        /// <param name="fullname_">Full Name of creator</param>
        /// <param name="email_">Email Address of creator</param>
        /// <param name="contents_">The contents of the first ticket post</param>
        /// <param name="departmentid_">The Department ID</param>
        /// <param name="ticketstatusid_">The Ticket Status ID</param>
        /// <param name="ticketpriorityid_">The Ticket Priority ID</param>
        /// <param name="tickettypeid_">The Ticket Type ID</param>
        /// <param name="userid_">The User ID, if the ticket is to be created as a user.</param>
        /// <param name="staffid_">The Staff ID, if the ticket is to be created as a staff</param>
        /// <param name="ownerstaffid_">The Owner Staff ID, if you want to set an Owner for this ticke</param>
        public TicketCreationToken
            (
              string subject_,
              string fullname_,
              string email_,
              string contents_,
              int departmentid_,
              int ticketstatusid_,
              int ticketpriorityid_,
              int tickettypeid_,
              int? userid_,
              int? staffid_,
              string type_
            ) :
            this(
              subject_,
              fullname_,
              email_,
              contents_,
              departmentid_,
              ticketstatusid_,
              ticketpriorityid_,
              tickettypeid_,
              userid_,
              staffid_,
              null,
              type_
        )
        {
        }

        /// <summary>
        /// Create a new ticket. 
        /// ownerstaffid and type are optional.
        /// Either UserID or StaffID should be correctly set the other should be set to null.
        /// All other arguments required.
        /// </summary>
        /// <param name="subject_">The Ticket Subject</param>
        /// <param name="fullname_">Full Name of creator</param>
        /// <param name="email_">Email Address of creator</param>
        /// <param name="contents_">The contents of the first ticket post</param>
        /// <param name="departmentid_">The Department ID</param>
        /// <param name="ticketstatusid_">The Ticket Status ID</param>
        /// <param name="ticketpriorityid_">The Ticket Priority ID</param>
        /// <param name="tickettypeid_">The Ticket Type ID</param>
        /// <param name="userid_">The User ID, if the ticket is to be created as a user.</param>
        /// <param name="staffid_">The Staff ID, if the ticket is to be created as a staff</param>
        /// <param name="ownerstaffid_">The Owner Staff ID, if you want to set an Owner for this ticke</param>
        /// <param name="type_">The ticket type: 'default' or 'phone'</param>
        public TicketCreationToken
            (
              string subject_,
              string fullname_,
              string email_,
              string contents_,
              int departmentid_,
              int ticketstatusid_,
              int ticketpriorityid_,
              int tickettypeid_,
              int? userid_,
              int? staffid_,
              int? ownerstaffid_,
              string type_
            )
        {
            Subject = subject_;
            Fullname = fullname_;
            Email = email_;
            Contents = contents_;
            DepartmentID = departmentid_;
            TicketStatusID = ticketstatusid_;
            TicketPriorityID = ticketpriorityid_;
            TicketTypeID = tickettypeid_;
            UserID = userid_;
            StaffID = staffid_;
            OwnerStaffID = ownerstaffid_;
            type = type_;

            Validate();
        }
        
        public string Subject { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Contents { get; set; }
        public int DepartmentID { get; set; }
        public int TicketStatusID { get; set; }
        public int TicketPriorityID { get; set; }
        public int TicketTypeID { get; set; }
        public int? UserID { get; set; }
        public int? StaffID { get; set; }
        public int? OwnerStaffID { get; set; }
        public string type { get; set; }
        
        /// <summary>
        /// Has the class been correctly setup.
        /// </summary>
        protected void Validate()
        {            
            TestRequiredField(Subject, "Subject");
            TestRequiredField(Fullname, "Fullname");
            TestRequiredField(Email, "Email");
            TestRequiredField(Contents, "Contents");
            //TestRequiredField(DepartmentID, "Subject");
            //TestRequiredField(TicketStatusID, "Subject");
            //TestRequiredField(TicketPriorityID, "Subject");
            //TestRequiredField(TicketTypeID, "Subject");
            
            if (UserID == null && StaffID == null)
            {
                throw new ArgumentException("Neither UserID nor StaffID are set, one of these fields are required field and cannot be null.");
            }

            if (UserID != null && StaffID != null)
            {
                throw new ArgumentException("UserID are StaffID are set, only one of these fields must be set.");
            }
        }

        /// <summary>
        /// Test field for validity.
        /// </summary>
        /// <param name="value_"></param>
        /// <param name="name_"></param>
        protected void TestRequiredField(object value_, string name_)
        {
            if (value_ == null)
            {
                throw new ArgumentException(name_ + " is a required field and cannot be null.");
            }
        }
    }
}
