// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract.Test
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="AccountTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Security.Principal;
using Broobu.Authorization.Contract.Agent;
using Broobu.Authorization.Contract.Domain;
using Broobu.Authorization.Contract.Interfaces;
using Iris.Fx.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Authorization.Contract.Test
{
    /// <summary>
    /// Class AccountTestFixture.
    /// </summary>
    [TestClass]
    public class AccountTestFixture : IAccount
    {
        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        public void Try_GetAccountForUser()
        {
            string userName = "Test AccountItem Username";
            var res = GetAccountForUser(userName);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Username,userName);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        public void Try_GetAccountForWindowsUser()
        {
            var wi = WindowsIdentity.GetCurrent();
            string userName = wi.Name;
            var res = GetAccountForUser(userName);
            Console.WriteLine(res);
            Console.WriteLine(String.Format("Username : {0} \t First Name: {1}", res.Username, res.FirstName ));
        }



        /// <summary>
        /// Try_s the save account item.
        /// </summary>
        [TestMethod]
        public void Try_SaveAccountItem()
        {
            var acc = new Account() 
            {
                Id = "Test_AccountItem",
                Username = "Test AccountItem Username"
            };
            var res = SaveAccountItem(acc);
            Assert.AreEqual(res.Username,acc.Username);
        }





        /// <summary>
        /// Gets the account for session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>AccountItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Account GetAccountForSession(IrisSession session)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates the credentials.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>ValidationResult.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ValidationResult ValidateCredentials(string userName, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the account for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>AccountItem.</returns>
        public Account GetAccountForUser(string userName)
        {
            return AuthorizationPortal
                .Accounts
                .GetAccountForUser(userName);
        }

        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>AccountItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Account[] GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the account item.
        /// </summary>
        /// <param name="accountItem">The account item.</param>
        /// <returns>AccountItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Account SaveAccountItem(Account accountItem)
        {
            return AuthorizationPortal
                .Accounts
                .SaveAccountItem(accountItem);
        }

        /// <summary>
        /// Gets the accounts for role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>AccountItem[][].</returns>
        public Account[] GetAccountsForRole(string roleId)
        {
            return AuthorizationPortal
                .Accounts
                .GetAccountsForRole(roleId);

        }

        /// <summary>
        /// Saves the accounts for role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="accounts">The accounts.</param>
        /// <returns>AccountItem[][].</returns>
        public AccountXRole[] LinkAccountsToRole(string roleId, Account[] accounts)
        {
            return AuthorizationPortal
                .Accounts
                .LinkAccountsToRole(roleId, accounts);

        }

        /// <summary>
        /// Deletes the accounts for role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="accounts">The accounts.</param>
        /// <returns>AccountItem[][].</returns>
        public AccountXRole[] UnlinkAccountsFromRole(string roleId, Account[] accounts)
        {
            return AuthorizationPortal
                .Accounts
                .UnlinkAccountsFromRole(roleId, accounts);

        }
    }
}
