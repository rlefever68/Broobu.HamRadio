// ***********************************************************************
// Assembly         : Broobu.SweNet.Contract
// Author           : Rafael Lefever
// Created          : 01-28-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-28-2014
// ***********************************************************************
// <copyright file="SwenetPortal.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.SweNet.Contract.Agent;
using Broobu.SweNet.Contract.Interfaces;


namespace Broobu.SweNet.Contract
{
    /// <summary>
    /// Class SwenetPortal.
    /// </summary>
    public static class SweNetPortal
    {
        /// <summary>
        /// Gets the agent.
        /// </summary>
        /// <value>The agent.</value>
        public static ISweNetAgent Agent 
        {
            get { 
                return new SweNetAgent();
            }
        }
    }
}
