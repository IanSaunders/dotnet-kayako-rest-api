using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Definition of a list User Organizations.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+UserOrganization
    /// </remarks>
    /// </summary>
    [XmlRoot("userorganizations")]
    public class UserOrganizations : List<UserOrganization>
    {
        /// <summary>
        /// Create a list of user organisations.
        /// </summary>
        public UserOrganizations()
        {
        }
    }
}
