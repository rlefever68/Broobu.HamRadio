// ***********************************************************************
// Assembly         : Broobu.Hamdroid.Contract
// Author           : Rafael Lefever
// Created          : 01-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-19-2014
// ***********************************************************************
// <copyright file="HamdroidPortal.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Hamdroid.Contract.Agents;
using Broobu.Hamdroid.Contract.Interfaces;

namespace Broobu.Hamdroid.Contract
{
    /// <summary>
    ///     Class HamdroidPortal.
    /// </summary>
    public static class HamdroidPortal
    {
        /// <summary>
        ///     Gets the agent.
        /// </summary>
        /// <value>The agent.</value>
        public static IHamdroidAgent Agent
        {
            get { return new HamdroidAgent(); }
        }
    }
}