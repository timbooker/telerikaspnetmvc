// (c) Copyright Telerik Corp. 
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.

namespace Telerik.Web.Mvc.Infrastructure
{
    using System;
    using System.Web;

    /// <summary>
    /// Defines members that must be implemented for cache the http response
    /// </summary>
    public interface IHttpResponseCacher
    {
        /// <summary>
        /// Caches the response for the specified duration.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="duration">The duration.</param>
        void Cache(HttpContextBase context, TimeSpan duration);
    }
}