using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents a department.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+Department
    /// </remarks>
    /// </summary>
    [XmlType("department")]
    public class Department
    {
        /// <summary>
        /// Gets a value indicating the ID of the departments
        /// </summary>
        [XmlElement("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets a value indicating the title of the department.
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets a value indicating the type of the department.
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets a value indicating the module of the department.
        /// </summary>
        [XmlElement("module")]
        public string Module { get; set; }

        /// <summary>
        /// Gets a value indicating the DisplayOrder of the department.
        /// </summary>
        [XmlElement("displayorder")]
        public string DisplayOrder { get; set; }

        /// <summary>
        /// Gets a value indicating the ParentDepartmentId of the department.
        /// </summary>
        [XmlElement("parentdepartmentid")]
        public string ParentDepartmentId { get; set; }

        /// <summary>
        /// Gets a value indicating the UserVisibilityCustom of the department.
        /// </summary>
        [XmlElement("uservisibilitycustom")]
        public string UserVisibilityCustom { get; set; }
        
        /// <summary>
        /// List of UserGroup IDs associated with the ticket
        /// </summary>
        [XmlArray("usergroups")]
        [XmlArrayItem("id")]
        public List<int> UserGroups { get; set; }
    }
}
