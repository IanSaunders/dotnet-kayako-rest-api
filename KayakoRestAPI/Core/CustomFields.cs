using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Definition of a list CustomField.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+TicketCustomField
    /// </remarks>
    /// </summary>
    [XmlRoot("customfields")]
    public class CustomFields : List<CustomFieldGroup>
    {
        /// <summary>
        /// Create a list of CustomFields.
        /// </summary>
        public CustomFields()
        {
        }
    }
}
