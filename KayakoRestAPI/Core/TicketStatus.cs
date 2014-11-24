using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    [XmlType("ticketstatus")]
    public class TicketStatus
    {
        /// <summary>
        /// Gets the ID of the ticket
        /// </summary>
        [XmlElement("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        [XmlElement("displayorder")]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the department ID
        /// </summary>
        [XmlElement("departmentid")]
        public int DepartmentID { get; set; }

        /// <summary>
        /// Gets or sets the display icon
        /// </summary>
        [XmlElement("displayicon")]
        public string DisplayIcon { get; set; }

        /// <summary>
        /// Gets or sets the type of the ticket status
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the status is displayed in the main list
        /// </summary>
        [XmlElement("displayinmainlist")]
        public bool DisplayInMainList { get; set; }

        /// <summary>
        /// Gets or sets va value indicating if the ticket status is marked as resolved
        /// </summary>
        [XmlElement("markasresolved")]
        public bool MarkAsResolved { get; set; }

        /// <summary>
        /// Gets or sets the display count
        /// </summary>
        [XmlElement("displaycount")]
        public int DisplayCount { get; set; }

        /// <summary>
        /// Gets or sets the status color
        /// </summary>
        [XmlElement("statuscolor")]
        public string StatusColor { get; set; }

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        [XmlElement("statusbgcolor")]
        public string StatusBgColor { get; set; }

        /// <summary>
        /// Gets or sets the reset due time/
        /// </summary>
        [XmlElement("resetduetime")]
        public string ResetDueTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the ticket triggers a survery
        /// </summary>
        [XmlElement("triggersurvey")]
        public bool TriggerSurvey { get; set; }

        /// <summary>
        /// Gets or sets the staff visibility custom
        /// </summary>
        [XmlElement("staffvisibilitycustom")]
        public int StaffVisibilityCustom { get; set; }

        /// <summary>
        /// Gets or sets the staff group ID
        /// </summary>
        [XmlElement("staffgroupid")]
        public int StaffGroupID { get; set; }
    }
}
