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
    [XmlType("field")]
    public class CustomField
    {
        /// <summary>
        /// Create a CustomField.
        /// </summary>
        public CustomField()
        {
        }
        
        /// <summary>
        /// Gets a value indicating the ID of the custom field
        /// </summary>
        [XmlAttribute("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets a value indicating the type of the custom field
        /// </summary>
        [XmlAttribute("type")]
        public int Type { get; set; }

        /// <summary>
        /// Gets a value indicating the title of the custom field
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets a value indicating the value of the custom field
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
