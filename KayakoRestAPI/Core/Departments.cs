using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestAPI.Core
{
    /// <summary>
    /// Definition of a list deparments.
    /// 
    /// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+Department
    /// </remarks>
    /// </summary>
    [XmlRoot("departments")]
    public class Departments : List<Department>
    {
        /// <summary>
        /// Create a list of departments.
        /// </summary>
        public Departments()
        {
        }
    }
}
