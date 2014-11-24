using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Definition of a list of end users.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+User
    /// </remarks>
    /// </summary>
    [XmlRoot("users")]
    public class Users : List<User>
    {
        /// <summary>
        /// Create a list of users.
        /// </summary>
        public Users()
        {
        }
    }
}
