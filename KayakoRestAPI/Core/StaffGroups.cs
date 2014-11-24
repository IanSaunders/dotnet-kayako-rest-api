using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Definition of a list of staff groups.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+StaffGroup
    /// </remarks>
    /// </summary>
    [XmlRoot("staffgroups")]
    public class StaffGroups : List<StaffGroup>
    {
        /// <summary>
        /// Create a list of staff groups.
        /// </summary>
        public StaffGroups()
        {
        }
    }
}
