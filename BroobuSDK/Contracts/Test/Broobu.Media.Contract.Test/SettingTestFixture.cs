// ***********************************************************************
// Assembly         : Broobu.Fx.Contract.Test
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-04-2013
// ***********************************************************************
// <copyright file="SettingTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Media.Contract.Agent;
using Broobu.Media.Contract.Interfaces;
using Iris.Fx.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Media.Contract.Test
{
    /// <summary>
    /// Class SettingTestFixture.
    /// </summary>
    [TestClass]
    public class SettingTestFixture : ISetting
    {
        /// <summary>
        /// Try_s the get settings.
        /// </summary>
        [TestMethod]
        public void Try_GetSettings()
        {
            //var res = GetSettings(AuthorizationDomainGenerator.CreateDefaultSetting());
            //Assert.IsNotNull(res);
        }


        /// <summary>
        /// Try_s the get setting by identifier.
        /// </summary>
        [TestMethod]
        public void Try_GetSettingById()
        {
            //var res = GetSetting(AuthorizationDomainGenerator.CreateDefaultSetting().Id);
            //Assert.IsNotNull(res);
        }


        /// <summary>
        /// Try_s the save settings.
        /// </summary>
        /// <param name="item">The item.</param>
        [TestMethod]
        public void Try_SaveSettings()
        {
            //var res = SaveSettings(AuthorizationDomainGenerator.CreateDefaultSetting());
            //Assert.IsNotNull(res);
        }





        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>SettingItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public SettingItem SaveSettings(SettingItem item)
        {
            return MediaAgentFactory
                .CreateSettingAgent()
                .SaveSettings(item);
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>SettingItem.</returns>
        public SettingItem GetSettings(SettingItem request)
        {
            return MediaAgentFactory
                .CreateSettingAgent()
                .GetSettings(request);
        }

        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SettingItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public SettingItem GetSetting(string id)
        {
            return MediaAgentFactory
                .CreateSettingAgent()
                .GetSetting(id);
          
        }
    }
}
