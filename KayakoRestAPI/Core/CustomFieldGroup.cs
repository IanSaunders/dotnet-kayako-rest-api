using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Represents a group of custom fields.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketCustomField
    /// </remarks>
    /// </summary>
    [XmlType("group")]
    public class CustomFieldGroup : List<CustomField>
    {
        /// <summary>
        /// Gets a value indicating the ID of the custom field group
        /// </summary>
        [XmlAttribute("id")]
        public int ID { get; set; }
        
        /// <summary>
        /// Gets a value indicating the ID of the custom field group
        /// </summary>
        [XmlAttribute("title")]
        public int Title { get; set; }
    }
}
