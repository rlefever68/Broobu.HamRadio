// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.Contract.Test
// Author           : Rafael Lefever
// Created          : 05-02-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-02-2014
// ***********************************************************************
// <copyright file="ManageTaxoTestFixture.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.ManageTaxo.Business;
using Broobu.ManageTaxo.Contract.Domain;
using Broobu.ManageTaxo.Contract.Interfaces;
using Broobu.Taxonomy.Contract.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Broobu.ManageTaxo.Contract.Test
{
    /// <summary>
    /// Class ManageTaxoTestFixture.
    /// </summary>
    [TestClass]
    public class ManageTaxoTestFixture : IManageTaxo
    {
        /// <summary>
        /// Try_s this instance.
        /// </summary>
        [TestMethod]
        public void Try_GetRootHookItems()
        {
            var res = GetHookItems(new HookItem() {Id = HookConst.Root});
            foreach (var hookItem in res)
            {
                Console.WriteLine(hookItem.Id);
            }
        }


        [TestMethod]
        public void Try_GetDescriptionsForHookRoot()
        {
            var res = GetTranslationsForObject(HookConst.Root);
            foreach (var descriptionItem in res)
            {
                Console.WriteLine(descriptionItem.ToString());
            }
        }



    [TestMethod]
        public void Try_GetRootHook()
        {
            var res = GetHook(HookConst.Root);
            Console.WriteLine("Hook=> Id:{0}\tDisplayName:{1}\tParentId:{2}\tTypeId:{3}", res.Id,res.DisplayName,res.ParentId,res.TypeId);
        }



        

        public DescriptionItem[] GetTranslationsForObject(string objectId)
        {
            return ManageTaxoPortal
                .Agent
                .GetTranslationsForObject(objectId);
        }

        /// <summary>
        /// Gets the description types.
        /// </summary>
        /// <returns>DescriptionItem[].</returns>
        /// <exception cref="NotImplementedException"></exception>
        public DescriptionItem[] GetDescriptionTypes()
        {
            //return ManageTaxoPortal
            //    .Agent
            //    .GetDescriptionTypes();
            return ManageTaxoProvider
                .Worker
                .GetDescriptionTypes();

        }

        /// <summary>
        /// Gets the hook items.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns>HookItem[].</returns>
        /// <exception cref="NotImplementedException"></exception>
        public HookItem[] GetHookItems(HookItem root)
        {
            return ManageTaxoPortal
                .Agent
                .GetHookItems(root);
            //return ManageTaxoProvider
            //    .Worker
            //    .GetHookItems(root);

        }

        /// <summary>
        /// Deletes the hook.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Hook DeleteHook(Hook document)
        {
            return ManageTaxoPortal
                .Agent
                .DeleteHook(document);
        }

        /// <summary>
        /// Gets the hook.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Hook.</returns>
        public Hook GetHook(string id)
        {
            return ManageTaxoPortal
                .Agent
                .GetHook(id);
        }

        /// <summary>
        /// Saves the hook.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Hook SaveHook(Hook document)
        {
            return ManageTaxoPortal
                .Agent
                .SaveHook(document);
        }

        /// <summary>
        /// Deletes the description.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Description.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Description DeleteDescription(Description document)
        {
            return ManageTaxoPortal
                .Agent
                .DeleteDescription(document);
        }

        /// <summary>
        /// Saves the description.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Description.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Description SaveDescription(Description document)
        {
            return ManageTaxoPortal
                .Agent
                .SaveDescription(document);
        }
    }
}
