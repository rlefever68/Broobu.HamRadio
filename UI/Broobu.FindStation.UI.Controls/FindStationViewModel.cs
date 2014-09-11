// ***********************************************************************
// Assembly         : Broobu.FindStation.UI.Controls
// Author           : ON8RL
// Created          : 12-08-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-08-2013
// ***********************************************************************
// <copyright file="FindStationViewModel.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Input;
using System.Windows.Threading;
using Broobu.Authentication.UI.Controls;
using Broobu.HamRadio.Contract.Domain;
using Broobu.ManageQso.Contract;
using Broobu.Fx.UI;

namespace Broobu.FindStation.UI.Controls
{
    /// <summary>
    /// Class StationCardViewModel.
    /// </summary>
    public class FindStationViewModel : AuthenticatedViewModel
    {
        /// <summary>
        /// Class Property.
        /// </summary>
        public new class Property
        {
            /// <summary>
            /// The discovered services
            /// </summary>
            public const string StationInfo = "StationInfo";
            /// <summary>
            /// The request duration
            /// </summary>
            public const string RequestDuration = "RequestDuration";
            /// <summary>
            /// The call identifier
            /// </summary>
            public const string CallId = "CallId";
            /// <summary>
            /// The station avatar
            /// </summary>
            public const string StationAvatar = "StationAvatar";

            public const string StationSummary = "StationSummary";
        }

        /// <summary>
        /// The sw request
        /// </summary>
        private readonly Stopwatch _swRequest;


        /// <summary>
        /// Gets the duration of the request.
        /// </summary>
        /// <value>The duration of the request.</value>
        public string RequestDuration
        {
            get
            {
                return String.Format("{0:F1} seconds", _swRequest.Elapsed.TotalSeconds);
            }
        }


        public string StationSummary
        {
            get
            {
                return _stationSummary;
            }
            set
            {
                _stationSummary = value;
                RaisePropertyChanged(Property.StationSummary);
            }
        }


        /// <summary>
        /// Gets or sets the refresh.
        /// </summary>
        /// <value>The refresh.</value>
        public ICommand Refresh {get;set;}

        /// <summary>
        /// Gets or sets the refresh time span.
        /// </summary>
        /// <value>The refresh time span.</value>
        public TimeSpan RefreshTimeSpan
        {
            get
            {
                return tmr.Interval;
            }
            set
            {
                tmr.Interval = value;
            }
        }

        /// <summary>
        /// The TMR
        /// </summary>
        private DispatcherTimer tmr;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindStationViewModel" /> class.
        /// </summary>
        public FindStationViewModel()
        {
            Refresh = new DelegateCommand(GetStationInfo);
            tmr = CreateRefreshTimer();
            _swRequest = new Stopwatch();
        }

        private byte[] _stationAvatar;

        /// <summary>
        /// Gets the station avatar.
        /// </summary>
        /// <value>The station avatar.</value>
        public byte[] StationAvatar
        {
            get
            {
                return _stationAvatar;
            }
            set
            {
                _stationAvatar = value;
                RaisePropertyChanged(Property.StationAvatar);
            }
        }

        /// <summary>
        /// Gets the station avatar.
        /// </summary>
        /// <returns>System.Byte[][].</returns>
        private byte[] GetStationAvatar()
        {
            if (StationInfo == null || String.IsNullOrEmpty(StationInfo.ImageUrl)) return new byte[] {};
            var webClient = new WebClient();
            return webClient.DownloadData(StationInfo.ImageUrl);
        }


        /// <summary>
        /// Gets the station information.
        /// </summary>
        private void GetStationInfo()
        {
            try
            {
                StationInfo = new StationItem();
                _swRequest.Start();
                tmr.Stop();
                IsBusy = true;
                StationInfo = ManageQsoPortal
                    .Agent
                    .GetStationInfo(CallId);
            }
            catch
            {
                IsBusy = false;
                IsEmpty = true;
            }

        }

        /// <summary>
        /// Gets or sets the call identifier.
        /// </summary>
        /// <value>The call identifier.</value>
    public string CallId 
    {
        get
        {
            return _callId;
        }
        set
        {
            if (_callId == value) return;
            _callId = value;
            GetStationInfo();
        }
    }

    /// <summary>
    /// Creates the refresh timer.
    /// </summary>
    /// <returns>DispatcherTimer.</returns>
        private DispatcherTimer CreateRefreshTimer()
        {
            var tmr = new DispatcherTimer();
            tmr.Tick += (s, e) => GetStationInfo();
            tmr.Interval = TimeSpan.FromSeconds(1*60);
            return tmr;
        }


        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            GetStationInfo();
        }




        /// <summary>
        /// The _discovered services
        /// </summary>
        private StationItem _stationInfo;

        /// <summary>
        /// The _call identifier
        /// </summary>
        private string _callId;

        private string _stationSummary;

        /// <summary>
    /// Gets or sets the discovered services.
    /// </summary>
    /// <value>The discovered services.</value>
        public StationItem StationInfo
        {
            get
            {
                return _stationInfo;
            }
            set 
            {
                _stationInfo = value;
                StationAvatar = GetStationAvatar();
                StationSummary = GetStationSummary();
                RaisePropertyChanged(Property.StationInfo);
            }
        }

        /// <summary>
        /// Gets the station summary.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetStationSummary()
        {
            return String.Format("{0}\n{1} {2}\n{3}, {4} {5}\n{6} \t {7}\n{8} ",
                StationInfo.CallId,
                StationInfo.FirstName,
                StationInfo.LastName,
                StationInfo.Address2,
                StationInfo.State,
                StationInfo.Country,
                StationInfo.Latitude,
                StationInfo.Longitude,
                StationInfo.Lotw);
        }


        /// <summary>
        /// Called when [get all endpoints async completed].
        /// </summary>
        /// <param name="items">The items.</param>
        public void OnGetStationInfoAsyncCompleted(StationItem items)
        {
            RaisePropertyChanged(Property.StationInfo);
            IsBusy = false;
            tmr.Start();
            _swRequest.Stop();
            RaisePropertyChanged(Property.RequestDuration);
            _swRequest.Reset();
        }

    }

}
