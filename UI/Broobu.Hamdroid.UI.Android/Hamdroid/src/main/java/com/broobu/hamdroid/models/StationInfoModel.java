package com.broobu.hamdroid.models;

import android.graphics.Bitmap;

import com.broobu.hamdroid.controllers.DeviceController;
import com.broobu.hamdroid.controllers.StationInfoController;
import com.broobu.hamdroid.domain.stationinfo.CallSignResponse;
import com.broobu.hamdroid.domain.stationinfo.DeviceLocationResponse;
import com.broobu.hamdroid.domain.stationinfo.SettingInfo;
import com.broobu.hamdroid.tasks.tasks.GetAvatarRequest;
import com.broobu.hamdroid.tasks.tasks.GetAvatarTask;
import com.broobu.hamdroid.tasks.tasks.GetCallSignRequest;
import com.broobu.hamdroid.tasks.tasks.GetCallSignTask;
import com.broobu.hamdroid.tasks.tasks.RegisterDeviceLocationRequest;
import com.broobu.hamdroid.utils.ModelBase;

/**
 * Created by ON8RL on 1/21/14.
 */
public class StationInfoModel extends ModelBase  {

    private Bitmap  stationImage;
    private GetCallSignRequest getCallSignRequest;

    public int fragmentWidth;
    public int fragmentHeight;

    private RegisterDeviceLocationRequest deviceLocationRequest;

    public GetAvatarRequest getAvatarRequest() {
        return avatarRequest;
    }
    private GetAvatarRequest avatarRequest;

    public Bitmap getStationImage() {
        return stationImage;
    }
    public void setStationImage(Bitmap stationImage) {
        this.stationImage = stationImage;
        notifyObservers(StationInfoController.MESSAGE_GET_AVATAR);
    }

    private SettingInfo settings;
    public SettingInfo getSettings() {
        return settings;
    }
    public void setSettings(SettingInfo settings) {
        this.settings = settings;
        notifyObservers(StationInfoController.MESSAGE_SETTING_CHANGED);
    }

    private CallSignResponse callSignResponse;
    public CallSignResponse getCallSignResponse() {
        return callSignResponse;
    }
    public void setCallSignResponse(CallSignResponse callSignResponse)
    {
        this.callSignResponse = callSignResponse;
        notifyObservers(StationInfoController.MESSAGE_GET_CALLSIGN);
        if(callSignResponse.ImageUrl!=null)
          LaunchAvatarRequest(fragmentHeight,fragmentWidth);
        if(callSignResponse.BioUrl!=null)
          notifyObservers(StationInfoController.MESSAGE_REFRESH_HOME);
    }


    private DeviceLocationResponse deviceLocationResponse;
    public DeviceLocationResponse getDeviceLocationResponse() {
        return deviceLocationResponse;
    }
    public void setDeviceLocationResponse(DeviceLocationResponse devLocation) {
        deviceLocationResponse = devLocation;
        notifyObservers(DeviceController.MESSAGE_DEVICE_LOCATION_CHANGED);
    }


    public RegisterDeviceLocationRequest getDeviceLocationRequest() {
        return deviceLocationRequest;
    }

    public StationInfoModel()  {
        deviceLocationResponse = new DeviceLocationResponse();
        deviceLocationRequest = new RegisterDeviceLocationRequest();
        getCallSignRequest = new GetCallSignRequest();
        avatarRequest = new GetAvatarRequest();
        callSignResponse = new CallSignResponse();
        settings = new SettingInfo();
        settings.GPSTimeInterval = 60000;
        settings.DistanceUnit = "km";
    }

    public void setDeviceLocationRequest(RegisterDeviceLocationRequest deviceLocationRequest) {
        this.deviceLocationRequest = deviceLocationRequest;
        notifyObservers(DeviceController.MESSAGE_DEVICE_LOCATION_CHANGED);
    }

    public GetCallSignRequest getGetCallSignRequest() {
        return getCallSignRequest;
    }

    public void setGetCallSignRequest(GetCallSignRequest getCallSignRequest) {
        this.getCallSignRequest = getCallSignRequest;
    }

    private GetCallSignRequest prepareCallSignRequest(String query, double lat, double lon)
    {
        makeCallSignResponseSearching();
        getCallSignRequest.Id = query;
        getCallSignRequest.Lat = lat;
        getCallSignRequest.Lon = lon;
        getCallSignRequest.Unit = settings.DistanceUnit;
        getCallSignRequest.Model = this;
        return getCallSignRequest;
    }

    private void makeCallSignResponseSearching() {
        callSignResponse.DisplayName = "Searching...";
        callSignResponse.DisplayLatitude = "";
        callSignResponse.DisplayLocation = "";
        callSignResponse.DisplayLongitude = "";
        callSignResponse.ShortPath ="";
        callSignResponse.LongPath = "";
        callSignResponse.Bearing = "";
        callSignResponse.Grid = "";
        notifyObservers(StationInfoController.MESSAGE_GET_CALLSIGN);
    }


    public GetAvatarRequest perpareAvatarRequest(int height, int width)
    {
        avatarRequest.height = height;
        avatarRequest.width = width;
        avatarRequest.url = callSignResponse.ImageUrl;
        return avatarRequest;
    }




    //----------------------------------------------------------------------------------------------
    public void LaunchAvatarRequest(int height, int width) {
        perpareAvatarRequest(height,width);
        GetAvatarTask tsk = new GetAvatarTask(this);
        tsk.execute(avatarRequest);
    }



    public void LaunchCallSignRequest(String query, double lat, double lon) {
        prepareCallSignRequest(query, lat, lon);
        GetCallSignTask tsk = new GetCallSignTask(this);
        tsk.execute(getCallSignRequest);
    }


}
