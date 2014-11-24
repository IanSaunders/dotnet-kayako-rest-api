using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using KayakoRestAPI.Core;
using System.Xml.Serialization;
using KayakoRestAPI;

namespace KayakoTestApplication
{
    /// <summary>
    /// A number of example uses of the .Net API for Kayako
    /// </summary>
    public class Program
    {
        const string API_KEY = "YOUR_API_KEY";
        const string SECRET_KEY = "YOUR_SECRET_KEY";
        const string API_URL = @"YOUR_SERVICE_URL"; //Note: No trailing ?


        static void Main(string[] args)
        {
            var service = new KayakoService(API_KEY, SECRET_KEY, API_URL);

            //Comment back in to test out features.
            //CreateTicket(service);
            //AddNote(service);
            //AddPost(service);
            //UpdateStaff(service);
            //UpdateUser(service);
            //AddRemoveAttachment(service);
        }

        static void AddRemoveAttachment(KayakoService service_)
        {
            Ticket t = service_.GetTicket(0);
            TicketPost p = t.Posts[0];

            Attachment a1 = service_.AddAttachment(t.ID, p.ID, MockAttachment.Filename, MockAttachment.Contents);

            Attachment a2 = service_.GetAttachment(t.ID, p.ID);

            if (a1.Contents != a2.Contents)
            {
                throw new Exception("Something went wrong!");
            }

            service_.DeleteAttachment(a1.TicketID, a1.ID);
        }

        static void UpdateUser(KayakoService service_)
        {
            User user = service_.GetUser(1);

            Console.WriteLine("Users old phone number => {0}", user.Phone);

            Random r = new Random();
            user.Phone = r.Next(511111, 600000).ToString();

            user = service_.UpdateUser(user);

            Console.WriteLine("Users new phone number => {0}", user.Phone);
        }

        static void UpdateStaff(KayakoService service_)
        {
            StaffUser staff = service_.GetStaff(1);

            StaffGroups groups = service_.GetStaffGroups();
            StaffGroup  newGroup = null;
            foreach (StaffGroup group in groups)
            {
                if (staff.GroupID != group.ID)
                {
                    newGroup = group;
                    break;
                }
            }

            Console.WriteLine("{0} is in group {1}", staff.Fullname, staff.GroupID);

            staff.GroupID = newGroup.ID;

            staff = service_.UpdateStaff(staff);

            Console.WriteLine("{0} is now in group {1}", staff.Fullname, staff.GroupID);

        }

        static void AddPost(KayakoService service_)
        {
            //Just get the first ticket so we can use it for creation.
            Ticket ticket = service_.GetTicket(1);

            //Get the first staff memeber.
            var user = service_.GetUser(1);

            TicketPost post = service_.AddTicketPost(ticket.ID, "API Generated Post", "Contents of API Generated Note", user.ID, null);

            Console.WriteLine("New Ticket Post Created:");
            Console.WriteLine("Contents: {0}", post.Contents);
            Console.WriteLine("Creator: {0}", post.Creator);
            Console.WriteLine("Email: {0}", post.Email);
        }

        static void AddNote(KayakoService service_)
        {
            //Just get the first ticket so we can use it for creation.
            Ticket ticket = service_.GetTicket(1);

            //Get the first staff memeber.
            var staff = service_.GetStaff(1);

            TicketNote note = service_.AddTicketNote(ticket.ID, "API Genereated Note", staff.ID, null, NoteColor.Green);

            Console.WriteLine("New Ticket Note Created:");
            Console.WriteLine("Subject: {0}", note.Content);
            Console.WriteLine("CreationDate: {0}", note.CreationDate);
            Console.WriteLine("NoteColor: {0}", note.NoteColor);
        }

        static void CreateTicket(KayakoService service_)
        {
            //Just get the first ticket so we can use it for creation.
            var ticket = service_.GetTicket(1);
            //Get the first staff memeber.
            var staff = service_.GetStaff(1);
            //Get the first user
            var user = service_.GetUser(1);

            var ticketToken = new TicketCreationToken
                (
                 "New Ticket",
                 staff.Fullname,
                 staff.Email,
                 "Ticket Contents",
                 ticket.DepartmentID,
                 ticket.StatusID,
                 ticket.PriorityID,
                 ticket.TypeID,
                 user.ID,
                 null
                );

            Ticket newTicket = service_.CreateTicket(ticketToken);

            Console.WriteLine("New Ticket Created:");
            Console.WriteLine("ID: {0}", newTicket.ID);
            Console.WriteLine("Subject: {0}", newTicket.Subject);
            Console.WriteLine("UserID: {0}", newTicket.UserID);
        }
    }
}
