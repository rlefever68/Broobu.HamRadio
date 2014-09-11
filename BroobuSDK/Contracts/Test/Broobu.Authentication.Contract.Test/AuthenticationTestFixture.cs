// ***********************************************************************
// Assembly         : Broobu.Authentication.Contract.Test
// Author           : ON8RL
// Created          : 12-16-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-17-2013
// ***********************************************************************
// <copyright file="AuthenticationTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Authentication.Contract.Agent;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Contract.Interfaces;
using Iris.Fx.Authentication;
using Iris.Fx.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Authentication.Contract.Test
{
    /// <summary>
    /// Class AuthenticationTestFixture.
    /// </summary>
    [TestClass]
    public class AuthenticationTestFixture : IAuthentication
    {


        /// <summary>
        /// Try_s the register new user.
        /// </summary>
        [TestMethod]
        public void Try_RegisterNewUser()
        {
            var nu = new NewUserRegistrationInfo()
            {
                Id = "John",
                AuthMode = AuthenticationMode.Native,
                UserName = "jdoe",
                Email = "no@no.no"
            };
            var re = RegisterNewUser(nu);
            Assert.AreEqual((object)nu.UserName, re.UserName);
        }



        /// <summary>
        /// Try_s the get iris session.
        /// </summary>
        [TestMethod]
        public void Try_GetIrisSessionByCredentials()
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    (se, cert, chain, sslerror) =>
                    {
                        Console.WriteLine("Certificate: {0}\nChain:{1}  \nError:{2}", cert.Subject, chain.ChainStatus[0].StatusInformation, sslerror);
                        return true;
                    };  
                var sess = AuthenticateUserCredentials();
                Assert.AreNotEqual(null, sess);
                Assert.AreEqual(AuthenticationDefaults.UserName, sess.Username);
            }
            catch (Exception e)
            {

                Assert.Fail(e.Message);

            }
        }


        /// <summary>
        /// Try_s the get iris session by user name password.
        /// </summary>
        [TestMethod]
        public void Try_GetIrisSessionByUserNamePassword()
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    (se, cert, chain, sslerror) =>
                    {
                        Console.WriteLine("Certificate: {0}\nChain:{1}  \nError:{2}", cert.Subject, chain.ChainStatus[0].StatusInformation, sslerror);
                        return true;
                    };
                var sess = AuthenticateByUserNameAndPassword(AuthenticationDefaults.Id, AuthenticationDefaults.EncPwd);
                Assert.AreNotEqual(null, sess);
                Assert.AreEqual(AuthenticationDefaults.UserName, sess.Username);
            }
            catch (Exception e)
            {

                Assert.Fail(e.Message);

            }
        }



        /// <summary>
        /// Authenticates the user credentials.
        /// </summary>
        /// <returns>IrisSession.</returns>
        public IrisSession AuthenticateUserCredentials()
        {
            return AuthenticationPortal
                .CreateAgent(AuthenticationDefaults.Id, AuthenticationDefaults.EncPwd)
                .AuthenticateUserCredentials();
        }

        /// <summary>
        /// Authenticates the by user name and password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns>IrisSession.</returns>
        public IrisSession AuthenticateByUserNameAndPassword(string userName, string passWord)
        {
            return AuthenticationPortal
                .Authentication
                .AuthenticateByUserNameAndPassword(userName, passWord);
        }

        /// <summary>
        /// Registers the new user.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>NewUserRegistrationViewItem.</returns>
        public NewUserRegistrationInfo RegisterNewUser(NewUserRegistrationInfo item)
        {
            return AuthenticationPortal
                .Authentication
                .RegisterNewUser(item);

        }


        /// <summary>
        /// Users the name exists.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>IdResult{System.Boolean}.</returns>
        public IdResult<bool> UserNameExists(string userName)
        {
            return AuthenticationPortal
                .Authentication
                .UserNameExists(userName);
        }

        /// <summary>
        /// Terminates the session.
        /// </summary>
        /// <returns>IrisSession.</returns>
        public IrisSession TerminateSession()
        {
            return AuthenticationPortal
                .Authentication
                .TerminateSession();
        }
    }
}
