// ***********************************************************************
// Assembly         : Broobu.Media.Contract.Test
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="MediaTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Media.Contract.Agent;
using Broobu.Media.Contract.Interfaces;
using Iris.Fx.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// The Test namespace.
/// </summary>
namespace Broobu.Media.Contract.Test
{
    /// <summary>
    /// Class MediaTestFixture.
    /// </summary>
    [TestClass]
    public class MediaTestFixture : IDescription
    {
        /// <summary>
        /// Try_s the save description.
        /// </summary>
        [TestMethod]
        public void Try_SaveDescription()
        {
            var res = SaveDescription(new DescriptionItem()
            {
                Id = "test_descripton_id",
                Title = "Hello I am a Test Description"
            });
            Assert.IsNotNull(res);
        }


        /// <summary>
        /// Try_s the get description item.
        /// </summary>
        [TestMethod]
        public void Try_GetDescriptionItem()
        {
            var res = GetDescriptionItem("test_descripton_id");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Title, "Hello I am a Test Description");
        }

        /// <summary>
        /// Gets the description item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DescriptionItem.</returns>
        public DescriptionItem GetDescriptionItem(string id)
        {
            return MediaAgentFactory
                .CreateDescriptionAgent()
                .GetDescriptionItem(id);
        }

        /// <summary>
        /// Gets the description items for object.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObject(string objectId)
        {
            return MediaAgentFactory
                .CreateDescriptionAgent()
                .GetDescriptionItemsForObject(objectId);
        }

        /// <summary>
        /// Gets the type of the description items for.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForType(string typeId)
        {
            return MediaAgentFactory
                .CreateDescriptionAgent()
                .GetDescriptionItemsForType(typeId);
        }

        /// <summary>
        /// Gets the description items for culture.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForCulture(string objectId)
        {
            return MediaAgentFactory
                .CreateDescriptionAgent()
                .GetDescriptionItemsForCulture(objectId);

        }

        /// <summary>
        /// Gets the description items for object and culture.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObjectAndCulture(string objectId, string cultureId)
        {
            return MediaAgentFactory
                .CreateDescriptionAgent()
                .GetDescriptionItemsForObjectAndCulture(objectId,cultureId);

        }

        /// <summary>
        /// Gets the type of the description items for object and.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObjectAndType(string objectId, string typeId)
        {
            return MediaAgentFactory
                .CreateDescriptionAgent()
                .GetDescriptionItemsForObjectAndType(objectId, typeId);
        }

        /// <summary>
        /// Gets the type of the description items for object culture and.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DescriptionItem[] GetDescriptionItemsForObjectCultureAndType(string objectId, string cultureId, string typeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the type of the description items for culture and.
        /// </summary>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DescriptionItem[] GetDescriptionItemsForCultureAndType(string cultureId, string typeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the description items like title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>DescriptionItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DescriptionItem[] GetDescriptionItemsLikeTitle(string title)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>DescriptionItem.</returns>
        public DescriptionItem SaveDescription(DescriptionItem description)
        {
            return MediaAgentFactory
                .CreateDescriptionAgent()
                .SaveDescription(description);
        }

        /// <summary>
        /// Deletes the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>DescriptionItem.</returns>
        public DescriptionItem DeleteDescription(DescriptionItem description)
        {
            return MediaAgentFactory
                .CreateDescriptionAgent()
                .DeleteDescription(description);
           
        }

        /// <summary>
        /// Saves the descriptions.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] SaveDescriptions(DescriptionItem[] descriptions)
        {
            return MediaAgentFactory
                .CreateDescriptionAgent()
                .SaveDescriptions(descriptions);
        }
    }
}
