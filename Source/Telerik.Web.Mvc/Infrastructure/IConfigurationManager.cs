// (c) Copyright Telerik Corp. 
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.

namespace Telerik.Web.Mvc.Infrastructure
{
    using System.Configuration;

    /// <summary>
    /// Defines the read operaations of configuration.
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Gets the section with the specified name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sectionName">Name of the section.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Generic seems the only solution otherwise, it will be overloaded with different asp.net sections.")]
        T GetSection<T>(string sectionName) where T : ConfigurationSection;
    }
}