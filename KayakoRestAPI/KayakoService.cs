/**
 * Kayako Rest API Implementation by Ian Saunders - Ian.Michael.Saunders@gmail.com 
 * 
 * This code is given as an example API to be extended. Not all features currently provided by
 * the Kayako REST API are implemented though most are. Feel free to make modficiations and
 * submit them back to the main repo.
 * 
 * NOTE: This API implementation comes UNSUPPORTED and with no liability to the author 
 *       for any issues resulting from use.
 *       
 * Please see: http://wiki.kayako.com/display/DEV for more details and if you need to extend the API
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using KayakoRestAPI.Core;

namespace KayakoRestAPI
{
    /// <summary>
    /// This service allows the interaction with the Kayako REST API.
    /// </summary>
    /// <remarks>
    /// See - http://wiki.kayako.com/display/DEV/REST+API
    /// </remarks>
    public class KayakoService
    {
        protected string m_apiKey;
        protected string m_secretKey;
        protected string m_apiUrl;
        protected string m_signature;
        protected string m_encodedSignature;
        protected string m_salt;

        /// <summary>
        /// Initializes a new instance of the KayakoRestAPI.KayakoService class.
        /// </summary>
        /// <param name="apiKey_">API Key.</param>
        /// <param name="secretKey_">Secret API Key.</param>
        /// <param name="apiUrl_">URL of Kayako REST API</param>
        public KayakoService(string apiKey_, string secretKey_, string apiUrl_)
        {
            m_apiKey = apiKey_;
            m_secretKey = secretKey_;
            m_apiUrl = apiUrl_;

            ComputeSaltAndSignature();
        }
        
        protected void ComputeSaltAndSignature()
        {
            // Generate a new globally unique identifier for the salt
            var salt = System.Guid.NewGuid().ToString();
            m_salt = salt;

            // Initialize the keyed hash object using the secret key as the key
            HMACSHA256 hashObject = new HMACSHA256(Encoding.UTF8.GetBytes(m_secretKey));

            // Computes the signature by hashing the salt with the secret key as the key
            var signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(salt));

            // Base 64 Encode
            m_signature = Convert.ToBase64String(signature);

            // URLEncode
            m_encodedSignature = System.Web.HttpUtility.UrlEncode(m_signature);
        }

        /// <summary>
        /// Create a ticket
        /// </summary>
        /// <remarks>
        /// see - http://wiki.kayako.com/display/DEV/REST+-+Ticket#REST-Ticket-POST%2FTickets%2FTicket
        /// </remarks>
        /// <param name="newTicket_">Details used to create a new ticket </param>
        /// <returns>The newly created ticket.</returns>
        public Ticket CreateTicket(TicketCreationToken newTicket_)
        {
            string url = m_apiUrl + "?/Tickets/Ticket";

            string parameters = string.Empty;

            parameters += string.Format("subject={0}", newTicket_.Subject);
            parameters += string.Format("&fullname={0}", newTicket_.Fullname);
            parameters += string.Format("&email={0}", newTicket_.Email);
            parameters += string.Format("&contents={0}", newTicket_.Contents);
            parameters += string.Format("&departmentid={0}", newTicket_.DepartmentID);
            parameters += string.Format("&ticketstatusid={0}", newTicket_.TicketStatusID);
            parameters += string.Format("&ticketpriorityid={0}", 1);
            parameters += string.Format("&tickettypeid={0}", newTicket_.TicketTypeID);

            if (newTicket_.UserID != null)
            {
                parameters += string.Format("&userid={0}", newTicket_.UserID);
            }
            else if (newTicket_.StaffID != null)
            {
                parameters += string.Format("&staffid={0}", newTicket_.StaffID);
            }

            if (newTicket_.OwnerStaffID != null)
            {
                parameters += string.Format("&ownerstaffid={0}", newTicket_.OwnerStaffID);
            }

            if (newTicket_.OwnerStaffID != null)
            {
                parameters += string.Format("&ownerstaffid={0}", newTicket_.OwnerStaffID);
            }

            Tickets tickets = ExecutePost<Tickets>(url, parameters);
            if (tickets.Count > 0)
            {
                return tickets[0];
            }
            return null;
        }

        /// <summary>
        /// Update the ticket identified by <paramref name="Ticket"/>
        /// </summary>
        /// <remarks>
        /// see - http://wiki.kayako.com/display/DEV/REST+-+Ticket#REST-Ticket-POST%2FTickets%2FTicket
        /// </remarks>
        /// <param name="ticket_">Details used to update the ticket </param>
        /// <returns>The updated ticket.</returns>
        public Ticket UpdateTicket(Ticket ticket_)
        {
            string url = m_apiUrl + "?/Tickets/Ticket/" + ticket_.ID;

            string parameters = string.Empty;

            parameters += string.Format("subject={0}", ticket_.Subject);
            parameters += string.Format("&fullname={0}", ticket_.Fullname);
            parameters += string.Format("&email={0}", ticket_.Email);
            parameters += string.Format("&departmentid={0}", ticket_.DepartmentID);
            parameters += string.Format("&ticketstatusid={0}", ticket_.StatusID);
            parameters += string.Format("&ticketpriorityid={0}", ticket_.PriorityID);
            parameters += string.Format("&tickettypeid={0}", ticket_.TypeID);
            parameters += string.Format("&ownerstaffid={0}", ticket_.OwnerStaffID);
            parameters += string.Format("&userid={0}", ticket_.UserID);

            Tickets tickets = ExecutePut<Tickets>(url, parameters);
            if (tickets.Count > 0)
            {
                return tickets[0];
            }
            return null;
        }

        /// <summary>
        /// Add a new post to an existing ticket.. Only <paramref name="userid_"/> or <paramref name="staffid_"/> should be set.
        /// <remarks>
        /// See - http://wiki.kayako.com/display/DEV/REST+-+TicketPost#REST-TicketPost-POST%2FTickets%2FTicketPost
        /// </remarks>
        /// </summary>
        /// <param name="ticketid_">The unique numeric identifier of the ticket</param>
        /// <param name="subject_">The ticket post subject.</param>
        /// <param name="contents_">The ticket post contents</param>
        /// <param name="userid_">The User ID, if the ticket post is to be created as a user</param>
        /// <param name="staffid_">The Staff ID, if the ticket post is to be created as a staff.</param>
        /// <returns></returns>
        public TicketPost AddTicketPost(int ticketid_, string subject_, string contents_, int? userid_, int? staffid_)
        {
            string url = m_apiUrl + "?/Tickets/TicketPost";
            
            string parameters = string.Empty;

            parameters += string.Format("ticketid={0}", ticketid_);
            parameters += string.Format("&subject={0}", subject_);
            parameters += string.Format("&contents={0}", contents_);

            if (userid_ == null && staffid_ == null)
            {
                throw new ArgumentException("Neither UserID nor StaffID are set, one of these fields are required field and cannot be null.");
            }


            if (userid_ != null && staffid_ != null)
            {
                throw new ArgumentException("UserID are StaffID are both set, only one of these fields must be set.");
            }

            if (userid_ != null)
            {
                parameters += string.Format("&userid={0}", userid_.Value);
            }

            if (staffid_ != null)
            {
                parameters += string.Format("&staffid={0}", staffid_.Value);
            }

            TicketPosts posts = ExecutePost<TicketPosts>(url, parameters);
            if (posts.Count > 0)
            {
                return posts[0];
            }
            return null;
        }

        /// <summary>
        /// Retrieve a list of all departments and sub-departments in the help desk.
        /// </summary>
        /// <returns>Departments</returns>
        public Departments GetAllDepartments()
        {
            string url = m_apiUrl + "?/Base/Department/" + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            Departments departments = Extract<Departments>(url);

            return departments;
        }

        /// <summary>
        /// Retrieve a list of all the ticket posts that belong to a ticket given ticket's id.
        /// </summary>
        /// <param name="ticketid_">The unique numeric identifier of the ticket.</param>
        /// <returns>TicketPosts</returns>
        public TicketPosts GetAllPosts(int ticketid_)
        {
            string url = m_apiUrl + "?/Tickets/TicketPost/ListAll/" + ticketid_ + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            TicketPosts posts = Extract <TicketPosts>(url);

            return posts;
        }

        /// <summary>
        /// Retrieve the post identified by <paramref name="postid_"/> that belong to the ticket identified by <paramref name="ticketid_"/>.
        /// </summary>
        /// <param name="ticketid_">The unique numeric identifier of the ticket.</param>
        /// <param name="postid_">The unique numeric identifier of the ticket post.</param>
        /// <returns>The ticket post</returns>
        public TicketPost GetPosts(int ticketid_, int postid_)
        {
            string url = m_apiUrl + "?/Tickets/TicketPost/" + ticketid_ + "/" + postid_ + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            TicketPosts posts = Extract<TicketPosts>(url);

            if (posts.Count > 0)
            {
                return posts[0];
            }

            return null;
        }

        /// <summary>
        /// Retrieve a list of all users in the help desk starting from a marker (user id) till the item fetch limit is reached (by default this is 1000).
        /// </summary>
        /// <remarks>
        /// See - http://wiki.kayako.com/display/DEV/REST+-+User#REST-User-GET%2FBase%2FUser%2FFilterORGET%2FBase%2FUser%2FFilter%2F%24marker%24%2F%24maxitems%24
        /// </remarks>
        /// <returns>List of users</returns>
        public Users GetUsers()
        {
            return GetUsers(string.Empty, 1000);
        }

        /// <summary>
        /// Retrieve a list of all users in the help desk starting from a marker (user id) till the item fetch limit is reached (by default this is 1000).
        /// </summary>

        /// <param name="filter_">Filter to apply</param>
        /// <returns>List of users</returns>
        public Users GetUsers(string filter_)
        {
            return GetUsers(filter_, 1000);
        }

        /// <summary>
        /// Retrieve a list of all users in the help desk starting from a marker (user id) till the item fetch limit is reached (by default this is 1000).
        /// </summary>
        /// <param name="filter_">Filter to apply</param>
        /// <returns>List of users</returns>
        public Users GetUsers(string filter_, int max_)
        {
            string url = m_apiUrl + "?/Base/User/Filter/" + filter_ + "/"+ max_ + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            return Extract<Users>(url);
        }

        /// <summary>
        /// Retrieve the user identified by <paramref name="userId_"/>.
        /// </summary>
        /// <param name="userId_">The unique numeric identifier of the user.</param>
        /// <returns>User</returns>
        public User GetUser(int userId_)
        {
            string url = m_apiUrl + "?/Base/User/" + userId_ + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            Users users = Extract<Users>(url);

            if (users != null && users.Count > 0)
            {
                return users[0];
            }
            return null;
        }

        /// <summary>
        /// Run a search for a user by email 
        /// http://wiki.kayako.com/display/DEV/REST+-+UserSearch
        /// </summary>
        /// <param name="query_">The Search Query.</param>
        /// <returns>Users</returns>
        /// <remarks>
        /// May require an update of UserSearch Page
        /// https://gist.github.com/2038199 
        /// copy to __swift/modules/base/api/class.Controller_UserSearch.php
        /// </remarks>
        public Users FindUsersByEmail(string email_)
        {
            return FindUsers(string.Format("query={0}", email_));
        }

        /// <summary>
        /// Run a search for a user by organization id [Doesn't work as of "4.40.954"]
        /// http://wiki.kayako.com/display/DEV/REST+-+UserSearch
        /// </summary>
        /// <param name="query_">The user organization id.</param>
        /// <returns>USers</returns>
        /// <remarks>
        /// May require an update of UserSearch Page
        /// https://gist.github.com/2038199 
        /// copy to __swift/modules/base/api/class.Controller_UserSearch.php
        /// </remarks>
        public Users FindUsersByOrganisation(string userorganizationid_)
        {
            return FindUsers(string.Format("query={0}", userorganizationid_));
        }

        /// <summary>
        /// Run a search on Users. You can search users from email, full name, phone, organization name and user group. [Doesn't work as of "4.40.954"]
        /// http://wiki.kayako.com/display/DEV/REST+-+UserSearch
        /// </summary>
        /// <param name="query_">The Search Query.</param>
        /// <returns>query_</returns>
        public Users FindUsers(string query_)
        {
            string url = m_apiUrl + "?/Base/UserSearch";


            string parameters = string.Empty;

            Users users = ExecutePost<Users>(url, query_);

            return users;
        }
        
        /// <summary>
        /// Create a new User record
        /// </summary>
        /// <remarks>
        /// http://wiki.kayako.com/display/DEV/REST+-+User#REST-User-POST%2FBase%2FUser
        /// </remarks>
        /// <param name="fullname_">The full name of User.</param>
        /// <param name="password_">The User Password</param>
        /// <param name="email_">The Email Address of User</param>
        /// <param name="userGroupId_">The User Group ID to assign to this User.</param>
        /// <param name="userOrg">The User Organization ID</param>
        /// <returns>New user if create, else null.</returns>
        public User CreateUser(string fullname_, string password_, string email_, int userGroupId_, int userOrg)
        {
            string url = m_apiUrl + "?/Base/User";

            string parameters = string.Empty;

            parameters += string.Format("fullname={0}", fullname_);
            parameters += string.Format("&usergroupid={0}", userGroupId_);
            parameters += string.Format("&password={0}", password_);
            parameters += string.Format("&email={0}", email_);
            parameters += string.Format("&userorganizationid={0}", userOrg);

            Users users = ExecutePost<Users>(url, parameters);
            if (users.Count > 0)
            {
                return users[0];
            }
            return null;
        }

        /// <summary>
        /// Update the user identified by <param name="user_".
        /// </summary>
        /// <remarks>
        /// See - http://wiki.kayako.com/display/DEV/REST+-+User#REST-User-GET%2FBase%2FUser%2FFilterORGET%2FBase%2FUser%2FFilter%2F%24marker%24%2F%24maxitems%24
        /// </remarks>
        /// <param name="staffUser_">User to updated</param>
        /// <returns>Updated user.</returns>
        public User UpdateUser(User user_)
        {
            string url = m_apiUrl + "?/Base/User/" + user_.ID;

            string parameters = string.Empty;

            parameters += string.Format("fullname={0}", user_.Fullname);
            parameters += string.Format("&usergroupid={0}", user_.GroupID);
            parameters += string.Format("&email={0}", user_.Email);
            parameters += string.Format("&userorganizationid={0}", user_.OrganizationID);
            parameters += string.Format("&salutation={0}", user_.Salutation);
            parameters += string.Format("&designation={0}", user_.Designation);
            parameters += string.Format("&phone={0}", user_.Phone);
            parameters += string.Format("&isenabled={0}", user_.IsEnabled);
            parameters += string.Format("&userrole={0}", user_.Role);
            parameters += string.Format("&timezone={0}", user_.Timezone);
            parameters += string.Format("&enabledst={0}", user_.EnableDST);
            parameters += string.Format("&slaplanid={0}", user_.SLAPlanID);
            parameters += string.Format("&slaplanexpiry={0}", user_.SLAPlanExpiry);
            parameters += string.Format("&userexpiry={0}", user_.Expiry);

            Users users = ExecutePut<Users>(url, parameters);

            if (users.Count > 0)
            {
                return users[0];
            }
            return null;
        }

        /// <summary>
        /// Retrieve a list of all staff user groups in the help desk.
        /// </summary>
        /// <returns>List of staff groups</returns>
        public StaffGroups GetStaffGroups()
        {
            string url = m_apiUrl + "?/Base/StaffGroup/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            return Extract<StaffGroups>(url);
        }

        /// <summary>
        /// Retrieve a staff group identified by <paramref name="groupId_"/>.
        /// </summary>
        /// <param name="groupId_">The numeric identifier of the staff group.</param>
        /// <returns>The staff group</returns>
        public StaffGroup GetStaffGroups(int groupId_)
        {
            string url = m_apiUrl + "?/Base/StaffGroup/" + groupId_  + "/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            StaffGroups grps = Extract<StaffGroups>(url);

            if (grps != null && grps.Count > 0)
            {
                return grps[0];
            }

            return null;
        }

        /// <summary>
        /// Retrieve a list of all staff users in the help desk.
        /// </summary>
        /// <returns>The staff</returns>
        public StaffUsers GetStaff()
        {
            string url = m_apiUrl + "?/Base/Staff/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            return Extract<StaffUsers>(url);
        }

        /// <summary>
        /// Retrieve a staff identified by <paramref name="staffId_"/>
        /// </summary>
        /// <param name="staffId_">The numeric identifier of the staff.</param>
        /// <returns>The staff user.</returns>
        public StaffUser GetStaff(int staffId_)
        {
            string url = m_apiUrl + "?/Base/Staff/" + staffId_ + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            StaffUsers users = Extract<StaffUsers>(url);

            if (users != null && users.Count > 0)
            {
                return users[0];
            }
            return null;
        }

        /// <summary>
        /// Update the staff identified by <paramref name="staffUser_"/>
        /// </summary>
        /// <remarks>
        /// http://wiki.kayako.com/display/DEV/REST+-+Staff#REST-Staff-PUT%2FBase%2FStaff%2F%24id%24
        /// </remarks>
        /// <param name="staffUser_">User to updated</param>
        /// <returns>Updated user.</returns>
        public StaffUser UpdateStaff(StaffUser staffUser_) 
        {
            return UpdateStaff(staffUser_, null, null);
        }

        /// <summary>
        /// Update the staff identified by <paramref name="staffUser_"/>
        /// </summary>
        /// <remarks>
        /// http://wiki.kayako.com/display/DEV/REST+-+Staff#REST-Staff-PUT%2FBase%2FStaff%2F%24id%24
        /// </remarks>
        /// <param name="staffUser_">User to updated</param>
        /// <param name="signature_">User signature</param>
        /// <param name="timezone_">Timezone of user</param>
        /// <returns>Updated user.</returns>
        public StaffUser UpdateStaff(StaffUser staffUser_, string signature_, string timezone_)
        {            
            string url = m_apiUrl + "?/Base/Staff/" + staffUser_.ID;
            
            string parameters = string.Empty;

            parameters += string.Format("firstname={0}", staffUser_.Firstname);
            parameters += string.Format("&lastname={0}", staffUser_.Lastname);
            parameters += string.Format("&username={0}", staffUser_.Username);
            parameters += string.Format("&staffgroupid={0}", staffUser_.GroupID);
            parameters += string.Format("&email={0}", staffUser_.Email);
            parameters += string.Format("&designation={0}", staffUser_.Designation);
            parameters += string.Format("&mobilenumber={0}", staffUser_.MobileNumber);
            parameters += string.Format("&isenabled={0}", staffUser_.IsEnabled);
            parameters += string.Format("&greeting={0}", staffUser_.Greeting);

            if (signature_ != null)
            {
                parameters += string.Format("&signature={0}", "NA");
            }

            if (timezone_ != null)
            {
                parameters += string.Format("&timezone={0}", string.Empty);
            }

            parameters += string.Format("&enabledst={0}", staffUser_.EnableDST);
            
            StaffUsers users = ExecutePut<StaffUsers>(url, parameters);

            if (users.Count > 0)
            {
                return users[0];
            }
            return null;
        }
        
        /// <summary>
        /// Delete the staff identified by <paramref name="staffID_"/>.
        /// </summary>
        /// <param name="staffID_">The numeric identifier of the staff.</param>
        /// <returns>True if staff removed, false otherwise.</returns>
        /// <exception cref="InvalidOperationException" />
        public bool DeleteStaff(int staffID_)
        {
            string requestUrl_ = m_apiUrl + "?/Base/Staff/" + staffID_ + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;
            return ExecuteDelete(requestUrl_);
        }

        protected string BuildList(int[] items_)
        {
            string parameters = string.Empty;
            if (items_ != null && items_.Length > 0)
            {
                foreach (int ix in items_)
                {
                    parameters += string.Format("{0},", ix);
                }
                parameters = parameters.Substring(0, parameters.Length - 1);
            }
            else
            {
                parameters += "-1";
            }
            return "/" + parameters;
        }

        /// <summary>
        /// Retrieve a filtered list of tickets from the help desk.
        /// </summary>
        /// <param name="departmentId_">Filter the tickets by the specified department id (Required)</param>
        /// <param name="ticketstatusid_">Filter the tickets by the specified ticket status id</param>
        /// <param name="ownerstaffid_">Filter the tickets by the specified owner staff id</param>
        /// <param name="userid_">Filter the tickets by the specified user id</param>
        /// <returns>Matching Tickets</returns>
        public Tickets GetTickets(int[] departmentId_, int[] ticketstatusid_, int[] ownerstaffid_, int[] userid_)
        {
            if (departmentId_ == null || departmentId_.Length <= 0)
            {
                throw new ArgumentException("At least one department ID is required.");
            }
            string parameters = string.Empty;

            parameters += BuildList(departmentId_);
            parameters += BuildList(ticketstatusid_);
            parameters += BuildList(ownerstaffid_);
            parameters += BuildList(userid_);
            
            string url = m_apiUrl + "?/Tickets/Ticket/ListAll" + parameters + "/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            return Extract<Tickets>(url);
        }

        /// <summary>
        /// Retrieve the ticket identified by <paramref name="ticketId_"/>.
        /// </summary>
        /// <param name="ticketId_">The unique numeric identifier of the ticket or the ticket mask ID (e.g. ABC-123-4567).</param>
        /// <returns>The ticket!</returns>
        public Ticket GetTicket(int ticketId_)
        {
            string url = m_apiUrl + "?/Tickets/Ticket/" + ticketId_ + "/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            Tickets tickets = Extract<Tickets>(url);

            if (tickets.Count > 0)
            {
                return tickets[0];
            }

            return null;
        }

        /// <summary>
        /// Delete the ticket identified by <paramref name="ticketId_"/>.
        /// </summary>
        /// <param name="ticketId_">The unique numeric identifier of the ticket.</param>
        /// <returns>If true is returned, the deletion was successful.</returns>
        public bool DeleteTicket(int ticketId_)
        {
            string url = m_apiUrl + "?/Tickets/Ticket/" + ticketId_ + "/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            return ExecuteDelete(url);
        }

        /// <summary>
        /// Retrieve a list of all ticket statues in the help desk.
        /// </summary>
        /// <remarks>
        /// See - http://wiki.kayako.com/display/DEV/REST+-+TicketStatus
        /// </remarks>
        /// <returns>The ticket statuses</returns>
        public TicketStatuses GetTicketStatuses()
        {
            string url = m_apiUrl + "?/Tickets/TicketStatus/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            return Extract<TicketStatuses>(url);
        }

        /// <summary>
        /// Retrieve the ticket status identified by <paramref name="statusId_"/>.
        /// </summary>
        /// <remarks>
        /// See - http://wiki.kayako.com/display/DEV/REST+-+TicketStatus#REST-TicketStatus-GET%2FTickets%2FTicketStatus%2F%24id%24
        /// </remarks>
        /// <param name="statusId_">The unique numeric identifier of the ticket status.</param>
        /// <returns>The ticket status</returns>
        public TicketStatus GetTicketStatuses(int statusId_)
        {
            string url = m_apiUrl + "?/Tickets/TicketStatus/" + statusId_ + "/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            TicketStatuses statuses = Extract<TicketStatuses>(url);

            if (statuses != null && statuses.Count > 0)
            {
                return statuses[0];
            }
            return null;
        }

        /// <summary>
        /// Retrieve a list of a ticket's notes.
        /// </summary>
        /// <remarks>
        /// http://wiki.kayako.com/display/DEV/REST+-+TicketNote#REST-TicketNote-GET%2FTickets%2FTicketNote%2FListAll%2F%24ticketid%24
        /// </remarks>
        /// <param name="ticketId_">The unique numeric identifier of the ticket.</param>
        /// <returns>Ticket notes.</returns>
        public TicketNotes GetTicketNotes(int ticketId_)
        {
            string url = m_apiUrl + "?/Tickets/TicketNote/ListAll/" + ticketId_ + "/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            return Extract<TicketNotes>(url);
        }

        /// <summary>
        /// Retrieve the note identified by <paramref name="noteId_"/> that belongs to a ticket identified by <paramref name="ticketId_"/>.
        /// </summary>
        /// <param name="ticketId_">The unique numeric identifier of the ticket.</param>
        /// <param name="noteId_">The unique numeric identifier of the ticket note.</param>
        /// <returns>List of ticket notes</returns>
        public TicketNote GetTicketNotes(int ticketId_, int noteId_)
        {
            string url = m_apiUrl + "?/Tickets/TicketNote/" + ticketId_ + "/" + noteId_ + "/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            TicketNotes notes = Extract<TicketNotes>(url);

            if (notes != null && notes.Count > 0)
            {
                return notes[0];
            }
            return null;
        }
        
        /// <summary>
        /// Add a new note to a ticket.
        /// </summary>
        /// <remarks>
        /// http://wiki.kayako.com/display/DEV/REST+-+TicketNote#REST-TicketNote-POST%2FTickets%2FTicketNote</remarks>
        /// <param name="ticketid_">The unique numeric identifier of the ticket.</param>
        /// <param name="contents_">The ticket note contents.</param>
        /// <param name="staffid_">The Staff ID, if the ticket is to be created as a staff.</param>
        /// <param name="forstaffid">The Staff ID, this value can be provided if you wish to restrict the note visibility to a specific staff.</param>
        /// <param name="color_">The Note Color</param>
        /// <returns>The added ticket note.</returns>
        public TicketNote AddTicketNote(int ticketid_, string contents_, int? staffid_, int? forstaffid_, NoteColor color_)
        {
            return AddTicketNote(ticketid_, contents_, staffid_, null, forstaffid_, color_);
        }

        /// <summary>
        /// Add a new note to a ticket.
        /// </summary>
        /// <remarks>
        /// http://wiki.kayako.com/display/DEV/REST+-+TicketNote#REST-TicketNote-POST%2FTickets%2FTicketNote</remarks>
        /// <param name="ticketid_">The unique numeric identifier of the ticket.</param>
        /// <param name="contents_">The ticket note contents.</param>
        /// <param name="fullname_">The Fullname, if the ticket is to be created without providing a staff user. Example: System messages, Alerts etc.</param>
        /// <param name="forstaffid">The Staff ID, this value can be provided if you wish to restrict the note visibility to a specific staff.</param>
        /// <param name="color_">The Note Color</param>
        /// <returns>The added ticket note.</returns>
        public TicketNote AddTicketNote(int ticketid_, string contents_, string fullname_, int? forstaffid_, NoteColor color_)
        {
            return AddTicketNote(ticketid_, contents_, null, fullname_, forstaffid_, color_);
        }

        /// <summary>
        /// Add a new note to a ticket.
        /// </summary>
        /// <remarks>
        /// http://wiki.kayako.com/display/DEV/REST+-+TicketNote#REST-TicketNote-POST%2FTickets%2FTicketNote</remarks>
        /// <param name="ticketid_">The unique numeric identifier of the ticket.</param>
        /// <param name="contents_">The ticket note contents.</param>
        /// <param name="staffid_">The Staff ID, if the ticket is to be created as a staff.</param>
        /// <param name="fullname_">The Fullname, if the ticket is to be created without providing a staff user. Example: System messages, Alerts etc.</param>
        /// <param name="forstaffid">The Staff ID, this value can be provided if you wish to restrict the note visibility to a specific staff.</param>
        /// <param name="color_">The Note Color</param>
        /// <returns>The added ticket note.</returns>
        public TicketNote AddTicketNote(int ticketid_, string contents_, int? staffid_, string fullname_, int? forstaffid_, NoteColor color_)
        {
            string url = m_apiUrl + "?/Tickets/TicketNote";

            string parameters = string.Empty;

            parameters += string.Format("ticketid={0}", ticketid_);
            parameters += string.Format("&contents={0}", contents_);
            parameters += string.Format("&notecolor={0}", (int)color_);

            if (fullname_ == null && staffid_ == null)
            {
                throw new ArgumentException("Neither Fullname nor StaffID are set, one of these fields are required field and cannot be null.");
            }
            
            if (fullname_ != null && staffid_ != null)
            {
                throw new ArgumentException("Fullname are StaffID are both set, only one of these fields must be set.");
            }

            if (fullname_ != null)
            {
                parameters += string.Format("&fullname={0}", fullname_);
            }

            if (staffid_ != null)
            {
                parameters += string.Format("&staffid={0}", staffid_.Value);
            }

            if (forstaffid_ != null)
            {
                parameters += string.Format("&forstaffid={0}", forstaffid_.Value);
            }

            TicketNotes notes = ExecutePost<TicketNotes>(url, parameters);

            if (notes.Count > 0)
            {
                return notes[0];
            }
            return null;
        }

        /// <summary>
        /// Retrieve a list of all organizations in the help desk
        /// </summary>
        /// <returns>TicketPosts</returns>
        public UserOrganizations GetUserOrganizations()
        {
            string url = m_apiUrl + "?/Base/UserOrganization/&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            UserOrganizations orgs = Extract<UserOrganizations>(url);

            return orgs;
        }

        /// <summary>
        /// Retrieve a list of all organizations in the help desk
        /// </summary>
        /// <returns>TicketPosts</returns>
        public UserOrganization GetUserOrganization(int id_)
        {
            string url = m_apiUrl + "?/Base/UserOrganization/" + id_  + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            UserOrganizations orgs = Extract<UserOrganizations>(url);

            if (orgs != null && orgs.Count > 0)
            {
                return orgs[0];
            }

            return null;
        }

        /// <summary>
        /// Create a new user organization record
        /// </summary>
        /// <remarks>
        /// See - http://wiki.kayako.com/display/DEV/REST+-+UserOrganization#REST-UserOrganization-POST%2FBase%2FUserOrganization
        /// </remarks>
        /// <param name="org_">Organisation to create</param>
        /// <returns>Added organisation.</returns>
        public UserOrganization CreateUserOrganization(UserOrganization org_)
        {
            string url = m_apiUrl + "?/Base/UserOrganization";

            string parameters = string.Empty;

            parameters += string.Format("name={0}", org_.Name);
            parameters += string.Format("&organizationtype={0}", org_.OrganizationType);
            parameters += string.Format("&address={0}", org_.Address);
            parameters += string.Format("&city={0}", org_.City);
            parameters += string.Format("&state={0}", org_.State);
            parameters += string.Format("&postalcode={0}", org_.PostalCode);
            parameters += string.Format("&country={0}", org_.Country);
            parameters += string.Format("&phone={0}", org_.Phone);
            parameters += string.Format("&fax={0}", org_.Fax);
            parameters += string.Format("&website={0}", org_.Website);
            parameters += string.Format("&slaplanid={0}", org_.SLAPlanID);
            parameters += string.Format("&slaplanexpiry={0}", org_.SLAPlanExpiry);

            UserOrganizations orgs = ExecutePost<UserOrganizations>(url, parameters);

            if (orgs.Count > 0)
            {
                return orgs[0];
            }
            return null;
        }

        /// <summary>
        /// Update the user organization identified by <paramref name="org_"/>.
        /// </summary>
        /// <remarks>
        /// See - http://wiki.kayako.com/display/DEV/REST+-+UserOrganization#REST-UserOrganization-PUT%2FBase%2FUserOrganization%2F%24id%24
        /// </remarks>
        /// <param name="org_">Organisation to update</param>
        /// <returns>Updated organisation.</returns>
        public UserOrganization UpdateUserOrganization(UserOrganization org_)
        {
            string url = m_apiUrl + "?/Base/UserOrganization/" + org_.ID;

            string parameters = string.Empty;

            parameters += string.Format("name={0}", org_.Name);
            parameters += string.Format("&organizationtype={0}", org_.OrganizationType);
            parameters += string.Format("&address={0}", org_.Address);
            parameters += string.Format("&city={0}", org_.City);
            parameters += string.Format("&state={0}", org_.State);
            parameters += string.Format("&postalcode={0}", org_.PostalCode);
            parameters += string.Format("&country={0}", org_.Country);
            parameters += string.Format("&phone={0}", org_.Phone);
            parameters += string.Format("&fax={0}", org_.Fax);
            parameters += string.Format("&website={0}", org_.Website);
            parameters += string.Format("&slaplanid={0}", org_.SLAPlanID);
            parameters += string.Format("&slaplanexpiry={0}", org_.SLAPlanExpiry);

            UserOrganizations orgs = ExecutePut<UserOrganizations>(url, parameters);

            if (orgs.Count > 0)
            {
                return orgs[0];
            }
            return null;
        }

        /// <summary>
        /// Retrieve a list of a ticket's attachments.
        /// </summary>
        /// <remarks>
        /// <see cref="http://wiki.kayako.com/display/DEV/REST+-+TicketAttachment#REST-TicketAttachment-GET%2FTickets%2FTicketAttachment%2FListAll%2F%24ticketid%24"/>
        /// </remarks>
        /// <param name="ticketid_">The unique numeric identifier of the ticket.</param>
        /// <returns>Attachments associated with ticket.</returns>
        public Attachments GetAttachments(int ticketid_)
        {
            string url = m_apiUrl + "?/Tickets/TicketAttachment/ListAll/" + ticketid_ + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            Attachments attachments = Extract<Attachments>(url);

            return attachments;
        }

        /// <summary>
        /// Retrieve the attachment identified by <paramref name="attachmentId_"/> that belongs to a ticket identified by <paramref name="attachmentId_"/>.
        /// </summary>
        /// <remarks>
        /// The attachment contents are base64 encoded.
        /// <see cref="http://en.wikipedia.org/wiki/Base64"/>
        /// <see cref="http://wiki.kayako.com/display/DEV/REST+-+TicketAttachment#REST-TicketAttachment-GET%2FTickets%2FTicketAttachment%2F%24ticketid%24%2F%24id%24"/>
        /// </remarks>
        /// <param name="ticketid_">The unique numeric identifier of the ticket.</param>
        /// <param name="attachmentId_">The unique numeric identifier of the attachment.</param>
        /// <returns>The attachment if it exists or null.</returns>
        public Attachment GetAttachment(int ticketid_, int attachmentId_)
        {
            //Give attachment ID twice to get around Kayako bug
            string url = m_apiUrl + "?/Tickets/TicketAttachment/" + ticketid_ + "/" + attachmentId_ + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            Attachments attachments = Extract<Attachments>(url);

            if (attachments.Count > 0)
            {
                return attachments[0];
            }

            return null;
        }

        /// <summary>
        /// Add an attachment to a ticket post.
        /// </summary>
        /// <remarks>
        /// <see cref="http://wiki.kayako.com/display/DEV/REST+-+TicketAttachment#REST-TicketAttachment-POST%2FTickets%2FTicketAttachment"/>
        /// </remarks>
        /// <param name="ticketid_">The unique numeric identifier of the ticket.</param>
        /// <param name="ticketpostid_">The unique numeric identifier of the ticket post.</param>
        /// <param name="filename_">The file name for the attachment.</param>
        /// <param name="contents_">The BASE64 encoded attachment contents.</param>
        /// <returns>The added attachment or null.</returns>
        public Attachment AddAttachment(int ticketid_, int ticketpostid_, string filename_, string contents_)
        {
            string url = m_apiUrl + "?/Tickets/TicketAttachment";

            string parameters = string.Empty;

            parameters += string.Format("ticketid={0}", ticketid_);
            parameters += string.Format("&ticketpostid={0}", ticketpostid_);
            parameters += string.Format("&filename={0}", filename_);
            parameters += string.Format("&contents={0}", contents_);


            Attachments attachments = ExecutePost<Attachments>(url, parameters);

            if (attachments.Count > 0)
            {
                return attachments[0];
            }
            return null;
        }

        /// <summary>
        /// Delete an attachment identified by <paramref name="attachemntid_"/> which belongs to a ticket identified by <paramref name="tickeid_"/>.
        /// </summary>
        /// <remarks>
        /// <see cref="http://wiki.kayako.com/display/DEV/REST+-+TicketAttachment#REST-TicketAttachment-DELETE%2FTickets%2FTicketAttachment%2F%24ticketid%24%2F%24id%24"/>
        /// </remarks>
        /// <param name="tickeid_">The unique numeric identifier of the ticket.</param>
        /// <param name="attachemntid_">The unique numeric identifier of the attachment.</param>
        /// <returns>If true is returned, the deletion was successful.</returns>
        public bool DeleteAttachment(int tickeid_, int attachemntid_)
        {
            //Give attachment ID twice to get around Kayako bug
            string requestUrl_ = m_apiUrl + "?/Tickets/TicketAttachment/" + tickeid_ + "/" + attachemntid_ + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;
            return ExecuteDelete(requestUrl_);
        }

        /// <summary>
        /// Retrieve a list of a ticket's custom fields.
        /// </summary>
        /// <remarks>
        /// <see cref="http://wiki.kayako.com/display/DEV/REST+-+TicketCustomField"/>
        /// This API method is either only available or was modified in Kayako version 4.01.220 (and above). You should update your helpdesk before relying on this method.
        /// </remarks>
        /// <param name="ticketid_">The unique numeric identifier of the ticket.</param>
        /// <returns>The list of custom fields</returns>
        public CustomFields GetCustomFields(int ticketid_)
        {
            string url = m_apiUrl + "?/Tickets/TicketCustomField/" + ticketid_ + "&apikey=" + m_apiKey + "&salt=" + m_salt + "&signature=" + m_encodedSignature;

            CustomFields customfields = Extract<CustomFields>(url);

            return customfields;
        }

#if KAYAKO_ADDS_SUPPORT_FOR_THESE
        /// <summary>
        /// Updates the XYZ custom field value
        /// </summary>
        /// <param name="ticketid_">Ticket ID</param>
        /// <param name="value_">XYZ ID</param>
        /// <returns>Custom IDS of ticket</returns>
        public CustomFields UpdateCustomField(int ticketid_, string value_)
        {
            string url = m_apiUrl + "?/Tickets/TicketCustomField/" + ticketid_;

            string parameters = string.Empty;

            parameters += string.Format("custom_field_value={0}", value_);

            CustomFields customFields = ExecutePut<CustomFields>(url, parameters);

            return customFields;
        }

        /// <summary>
        /// Adds the XYZ custom field value
        /// </summary>
        /// <param name="ticketid_">Ticket ID</param>
        /// <param name="value_">XYZ ID</param>
        /// <returns>Custom IDs of ticket</returns>
        public CustomFields AddCustomField(int ticketid_, string value_)
        {
            string url = m_apiUrl + "?/Tickets/TicketCustomField";

            string parameters = string.Empty;

            parameters += string.Format("ticketid={0}", ticketid_);
            parameters += string.Format("&custom_field_value={0}", value_);

            CustomFields customFields = ExecutePost<CustomFields>(url, parameters);

            return customFields;
        }
#endif
        /// <summary>
        /// Generic method for extracting data via PUSH.
        /// </summary>
        /// <typeparam name="TTarget">Target type to extract</typeparam>
        /// <param name="requestUrl_">URL to request data.</param>
        /// <param name="parameters_">Parameters to post.</param>
        /// <returns>TTarget result of the extraction</returns>
        protected TTarget ExecutePut<TTarget>(string requestUrl_, string parameters_) where TTarget : class, new()
        {
            return ExecuteCall<TTarget>(requestUrl_, parameters_, "PUT");
        }

        /// <summary>
        /// Generic method for extracting data via POST.
        /// </summary>
        /// <typeparam name="TTarget">Target type to extract</typeparam>
        /// <param name="requestUrl_">URL to request data.</param>
        /// <param name="parameters_">Parameters to post.</param>
        /// <returns>TTarget result of the extraction</returns>
        protected TTarget ExecutePost<TTarget>(string requestUrl_, string parameters_) where TTarget : class, new()
        {
            return ExecuteCall<TTarget>(requestUrl_, parameters_, "POST");
        }
        
        /// <summary>
        /// Generic method for extracting data.
        /// </summary>
        /// <typeparam name="TTarget">Target type to extract</typeparam>
        /// <param name="requestUrl_">URL to request data.</param>
        /// <param name="parameters_">Parameters to post.</param>
        /// <returns>TTarget result of the extraction</returns>
        protected TTarget ExecuteCall<TTarget>(string requestUrl_, string parameters_, string method_) where TTarget : class, new()
        {
            WebRequest webRequest = WebRequest.Create(requestUrl_);

            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = method_;

            parameters_ += string.Format("&salt={0}", m_salt);
            parameters_ += string.Format("&signature={0}", m_signature);
            parameters_ += string.Format("&apikey={0}", m_apiKey);

            byte[] bytes = Encoding.ASCII.GetBytes(parameters_);

            webRequest.ContentLength = bytes.Length;
            Stream os = webRequest.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(TTarget));
            try
            {
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse != null)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                    string s = sr.ReadToEnd();

                    using (var reader2 = new StringReader(s))
                    {
                        TTarget notes = (TTarget)serializer.Deserialize(reader2);
                        return notes;
                    }
                }
            }
            catch (WebException ex_)
            {
                HttpWebResponse response = (HttpWebResponse)ex_.Response;

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string s = reader.ReadToEnd();

                    if (s == "No fullname or staff id specified")
                    {
                        throw new TicketNoteException("Could not create Ticket Note, no valid fullname or staff id specified.", ex_.InnerException);
                    }
                }
            }
            return null;
        }
        

        /// <summary>
        /// Generic method for extracting data.
        /// </summary>
        /// <typeparam name="TTarget">Target type to extract</typeparam>
        /// <param name="requestUrl_">URL to request data.</param>
        /// <returns>TTarget result of the extraction</returns>
        protected TTarget Extract<TTarget>(string requestUrl_) where TTarget : class, new()
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUrl_);
            TTarget targetData = new TTarget();

            request.Method = "GET";

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TTarget));
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseText = reader.ReadToEnd();

                    using (var stringReader = new StringReader(responseText))
                    {
                        targetData = (TTarget)serializer.Deserialize(stringReader);
                    }
                }
            }
            catch (WebException ex_)
            {
                HttpWebResponse response = (HttpWebResponse)ex_.Response;

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    StreamReader errorReader = new StreamReader(response.GetResponseStream());
                    string s = errorReader.ReadToEnd();

                    if (s == "Ticket Posts not Found")
                    {
                        throw new TicketRequestException("Ticket Posts not Found", ex_.InnerException);
                    }
                }
            }

            return targetData;
        }


        /// <summary>
        /// Executes a DELETE HTTP Request against the given URL
        /// </summary>
        /// <param name="requestUrl_">URL to execute request.</param>
        /// <returns>True if delete request was OK</returns>
        private static bool ExecuteDelete(string requestUrl_)
        {

            var request = (HttpWebRequest)WebRequest.Create(requestUrl_);
            StaffUsers staffusers = new StaffUsers();

            request.Method = "DELETE";

            XmlSerializer serializer = new XmlSerializer(typeof(StaffUsers));
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            catch (WebException ex_)
            {

                StreamReader sr = new StreamReader(ex_.Response.GetResponseStream());
                string s = sr.ReadToEnd();

                throw new InvalidOperationException("Could not remove item. " + s, ex_);
            }
            return false;
        }
    }
}
