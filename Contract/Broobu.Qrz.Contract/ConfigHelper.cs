// ***********************************************************************
// Assembly         : Broobu.Qrz.Contract
// Author           : ON8RL
// Created          : 12-05-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-05-2013
// ***********************************************************************
// <copyright file="ConfigHelper.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Broobu.Qrz.Contract
{
/// <summary>
/// Class ConfigHelper.
/// </summary>
    public class ConfigHelper
    {

/// <summary>
/// Class AppSettingsKey.
/// </summary>
        private class AppSettingsKey
        {
/// <summary>
/// The username
/// </summary>
            public const string Username = "Qrz.Username";
/// <summary>
/// The password
/// </summary>
            public const string Password = "Qrz.Password";
/// <summary>
/// The URL
/// </summary>
            public const string Url = "Qrz.Url";
/// <summary>
/// The login command
/// </summary>
            public const string LoginCommand = "Qrz.LoginCommand";
/// <summary>
/// The get call sign command
/// </summary>
            public const string GetCallSignCommand = "Qrz.GetCallSignCommand";
        }


/// <summary>
/// Gets the name of the QRZ user.
/// </summary>
/// <value>The name of the QRZ user.</value>
        public static string QrzUserName 
        {
            get 
            {
                return ConfigurationManager.AppSettings[AppSettingsKey.Username] ?? "QrzUsername";
            }
        }


/// <summary>
/// Gets the QRZ password.
/// </summary>
/// <value>The QRZ password.</value>
        public static string QrzPassword 
        {
            get
            {
                return ConfigurationManager.AppSettings[AppSettingsKey.Password] ?? "QrzPassword";
            }

            }

/// <summary>
/// Gets the QRZ URL.
/// </summary>
/// <value>The QRZ URL.</value>
        public static string QrzUrl 
        {
            get
            {
                return ConfigurationManager.AppSettings[AppSettingsKey.Url] ?? "http://www.qrz.com/xml";
            }
        }

/// <summary>
/// Gets the QRZ login command.
/// </summary>
/// <value>The QRZ login command.</value>
        public static  string QrzLoginCommand 
        { 
            get
            {
                return ConfigurationManager.AppSettings[AppSettingsKey.LoginCommand] ?? "{0}?username={1};password={2}";
            }
        }

/// <summary>
/// Gets the QRZ get call sign command.
/// </summary>
/// <value>The QRZ get call sign command.</value>
        public static string QrzGetCallSignCommand
        {
            get
            {
                return ConfigurationManager.AppSettings[AppSettingsKey.GetCallSignCommand] ?? "{0}?s={1);callsign={2}";
            }
        }
    }
    
}

