// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Contract.Test
// Author           : Rafael Lefever
// Created          : 01-12-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-02-2014
// ***********************************************************************
// <copyright file="TaxonomyHookTestFixture.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.Hosting;
using Broobu.Taxonomy.Business.Workers;
using Broobu.Taxonomy.Contract.Constants;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Broobu.Taxonomy.Contract.Test.Domain;
using Iris.Fx.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Taxonomy.Contract.Test
{
    /// <summary>
    /// Class TaxonomyHookTestFixture.
    /// </summary>
    [TestClass]
    public class TaxonomyHookTestFixture : IHook
    {



        [TestMethod]
        public void Try_InflateDomain()
        {

        }



        [TestMethod]
        public void Try_GetRootChildren()
        {
            var res = TaxonomyPortal
                .Hooks
                .GetChildren(HookConst.RootHook);
            Console.WriteLine("Root: {0}", HookConst.RootHook.Id);
            foreach (var hook in res)
            {
                Console.WriteLine("\tChild Id: {0}",hook.Id);
            }
        }




        /// <summary>
        /// Try_s the save taxonomy hook.
        /// </summary>
        [TestMethod]
        public void Try_SaveTaxonomyHook()
        {
            try
            {
                var res = TaxonomyPortal
                    .Hooks
                    .Save(new Hook() { Id = "TestHook1", ParentId = SysConst.NullGuid, TypeId = SysConst.NullGuid });
                Assert.IsNotNull(res);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }

        /// <summary>
        /// Try_s the generate domain.
        /// </summary>
        [TestMethod]
        public void Try_GenerateDomain()
        {
            try
            {
                var path = HostingEnvironment.MapPath(TaxonomyServiceConst.DefaultHooksXmlPath) ??
                           TaxonomyServiceConst.DefaultHooksXmlPath;
                var res = TaxonomyDomainGenerator.GetDefaultHooks(path);
                foreach (var hook in res)
                {
                    Console.WriteLine(hook.ToString());
                }
                Assert.IsNotNull(res);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }


        /// <summary>
        /// Try_s the save taxonomy object.
        /// </summary>
        [TestMethod]
        public void Try_SaveTaxonomyObject()
        {
            var it = new Creature() {Id="Kat1"};
            try
            {

                var res = TaxonomyPortal
                    .Hooks
                    .GetTaxonomyHookId("Kat1", "Katje nummer 1", HookConst.EcoSpaceRoot);
                Assert.IsNotNull(res);
                Console.WriteLine("Creature {0} saved", res);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Hook GetById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the specified it.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Hook Save(Hook it)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers the type of the enumeration.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Hook RegisterEnumerationType(Hook item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the type of the enumerations for.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>Hook[].</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Hook[] GetEnumerationsForType(string typeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>Hook[].</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Hook[] SaveEnumerations(Hook[] enums)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>Hook[].</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Hook[] DeleteEnumerations(Hook[] enums)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the enumeration.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Hook DeleteEnumeration(Hook item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the taxonomy hook identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="displayName"></param>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetTaxonomyHookId(string id, string displayName, string ecoSpace)
        {
            return TaxonomyPortal
                .Hooks
                .GetTaxonomyHookId(id, displayName, ecoSpace);
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="hydrate"></param>
        /// <returns>Hook[].</returns>
        public Hook[] GetChildren(Hook root, bool hydrate = false)
        {
            return TaxonomyPortal
                .Hooks
                .GetChildren(root,hydrate);
        }
    }
}
