using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Definition of a list of staff.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+Staff
    /// </remarks>
    /// </summary>
    [XmlRoot("staffusers")]
    public class StaffUsers : List<StaffUser>
    {
        /// <summary>
        /// Create a list of staff.
        /// </summary>
        public StaffUsers()
        {
        }
    }
}
