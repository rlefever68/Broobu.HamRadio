// ***********************************************************************
// Assembly         : Iris.ManageAuthorization.Contract.Test
// Author           : ON8RL
// Created          : 12-05-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-05-2013
// ***********************************************************************
// <copyright file="ManageAuthorizationTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Iris.ManageAuthorization.Business;
using Iris.ManageAuthorization.Contract.Agent;
using Iris.ManageAuthorization.Contract.Domain;
using Iris.ManageAuthorization.Contract.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// The Test namespace.
/// </summary>
namespace Iris.ManageAuthorization.Contract.Test
{
    /// <summary>
    /// Class ManageAuthorizationTestFixture.
    /// </summary>
    [TestClass]
    public class ManageAuthorizationTestFixture : IManageAuthorization
    {
        /// <summary>
        /// Try_s the get all application functions.
        /// </summary>
        [TestMethod]
        public void Try_GetAllApplicationFunctions()
        {
            var res = GetAllApplicationFunctions();
            foreach (var item in res)
            {
                Console.WriteLine(String.Format("Id:{0} \t Title:{1}", item.Id, item.Title));
            }
            Assert.IsNotNull(res);
        }

        /// <summary>
        /// Try_s the get all accounts.
        /// </summary>
        [TestMethod]
        public void Try_GetAllAccounts()
        {
            var res = GetAllAccounts();
            foreach (var accountViewItem in res)
            {
                Console.WriteLine(String.Format("Id: {0} \t {1} {2}", accountViewItem.Id,accountViewItem.FirstName,accountViewItem.LastName));
            }
            Assert.IsNotNull(res);
        }



        /// <summary>
        /// Gets all application functions.
        /// </summary>
        /// <returns>ApplicationFunctionViewItem[][].</returns>
        public ApplicationFunctionViewItem[] GetAllApplicationFunctions()
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .GetAllApplicationFunctions();
        }

        /// <summary>
        /// Saves the application functions.
        /// </summary>
        /// <param name="applicationFunctionViewItems">The application function view items.</param>
        /// <returns>ApplicationFunctionViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ApplicationFunctionViewItem[] SaveApplicationFunctions(ApplicationFunctionViewItem[] applicationFunctionViewItems)
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .SaveApplicationFunctions(applicationFunctionViewItems);
        }

        /// <summary>
        /// Deletes the application functions.
        /// </summary>
        /// <param name="applicationFunctionViewItems">The application function view items.</param>
        /// <returns>ApplicationFunctionViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ApplicationFunctionViewItem[] DeleteApplicationFunctions(ApplicationFunctionViewItem[] applicationFunctionViewItems)
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .DeleteApplicationFunctions(applicationFunctionViewItems);
        }

        /// <summary>
        /// Gets the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function identifier.</param>
        /// <returns>RoleViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RoleViewItem[] GetRolesForApplicationFunction(string applicationFunctionId)
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .GetRolesForApplicationFunction(applicationFunctionId);

        }

        /// <summary>
        /// Saves the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function identifier.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>RoleViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RoleViewItem[] SaveRolesForApplicationFunction(string applicationFunctionId, RoleViewItem[] roles)
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .SaveRolesForApplicationFunction(applicationFunctionId, roles);
        }

        /// <summary>
        /// Deletes the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function identifier.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>RoleViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RoleViewItem[] DeleteRolesForApplicationFunction(string applicationFunctionId, RoleViewItem[] roles)
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .DeleteRolesForApplicationFunction(applicationFunctionId, roles);
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>RoleViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RoleViewItem[] GetAllRoles()
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .GetAllRoles();
        }

        /// <summary>
        /// Saves the roles.
        /// </summary>
        /// <param name="roleViewItems">The role view items.</param>
        /// <returns>RoleViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RoleViewItem[] SaveRoles(RoleViewItem[] roleViewItems)
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .SaveRoles(roleViewItems);
        }

        /// <summary>
        /// Deletes the roles.
        /// </summary>
        /// <param name="roleViewItem">The role view item.</param>
        /// <returns>RoleViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RoleViewItem[] DeleteRoles(RoleViewItem[] roleViewItem)
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .DeleteRoles(roleViewItem);
        }

        /// <summary>
        /// Gets the accounts for role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>AccountViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public AccountViewItem[] GetAccountsForRole(string roleId)
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .GetAccountsForRole(roleId);
        }

        /// <summary>
        /// Saves the accounts for role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="accounts">The accounts.</param>
        /// <returns>AccountViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public AccountViewItem[] SaveAccountsForRole(string roleId, AccountViewItem[] accounts)
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .SaveAccountsForRole(roleId, accounts);
        }

        /// <summary>
        /// Deletes the accounts for role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="accounts">The accounts.</param>
        /// <returns>AccountViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public AccountViewItem[] DeleteAccountsForRole(string roleId, AccountViewItem[] accounts)
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .DeleteAccountsForRole(roleId, accounts);
        }

        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>AccountViewItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public AccountViewItem[] GetAllAccounts()
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .GetAllAccounts();

            //return ManageAuthorizationProviderFactory
            //    .CreateManageAuthorizationProvider()
            //    .GetAllAccounts();
        }

        /// <summary>
        /// Gets the ribbon types.
        /// </summary>
        /// <returns>System.String[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string[] GetRibbonTypes()
        {
            return ManageAuthorizationAgentFactory
                .CreateManageAuthorizationAgent()
                .GetRibbonTypes();
        }
    }
}
