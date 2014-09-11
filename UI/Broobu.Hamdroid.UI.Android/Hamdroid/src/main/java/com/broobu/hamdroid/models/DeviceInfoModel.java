package com.broobu.hamdroid.models;

import android.location.Location;
import android.location.LocationManager;
import android.os.Build;

import com.broobu.hamdroid.controllers.DeviceController;
import com.broobu.hamdroid.controllers.StationInfoController;
import com.broobu.hamdroid.domain.stationinfo.DeviceLocationResponse;
import com.broobu.hamdroid.domain.stationinfo.SettingInfo;
import com.broobu.hamdroid.tasks.tasks.RegisterDeviceLocationRequest;
import com.broobu.hamdroid.tasks.tasks.RegisterDeviceLocationTask;
import com.broobu.hamdroid.utils.DeviceLocationListener;
import com.broobu.hamdroid.utils.ModelBase;

import java.util.UUID;

/**
 * Created by ON8RL on 3/8/14.
 */
public class DeviceInfoModel extends ModelBase {

    public LocationManager LocManager;
    public DeviceLocationListener LocListener;
    private RegisterDeviceLocationRequest deviceLocationRequest;
    private boolean gPSEnabled;

    private DeviceLocationResponse deviceLocationResponse;
    public DeviceLocationResponse getDeviceLocationResponse() {
        return deviceLocationResponse;
    }
    public void setDeviceLocationResponse(DeviceLocationResponse devLocation) {
        deviceLocationResponse = devLocation;
        notifyObservers(DeviceController.MESSAGE_DEVICE_LOCATION_CHANGED);
    }



    //----------------------------------------------------------------------------------------------
    private void registerDeviceLocation(RegisterDeviceLocationRequest req) {
        RegisterDeviceLocationTask tsk = new RegisterDeviceLocationTask(this);
        tsk.execute(req);
    }

    public RegisterDeviceLocationRequest getDeviceLocationRequest() {
        return deviceLocationRequest;
    }

    public DeviceInfoModel()
    {
        deviceLocationResponse = new DeviceLocationResponse();
        deviceLocationRequest = new RegisterDeviceLocationRequest();
        settings = new SettingInfo();
        settings.GPSTimeInterval = 60000;
        settings.DistanceUnit = "km";
    }

    public void setDeviceLocationRequest(RegisterDeviceLocationRequest deviceLocationRequest) {
        this.deviceLocationRequest = deviceLocationRequest;
        notifyObservers(DeviceController.MESSAGE_DEVICE_LOCATION_CHANGED);
    }


    public void setGPSEnabled(boolean GPSEnabled) {
        this.gPSEnabled = GPSEnabled;
        if(!gPSEnabled)
        {
            this.setDeviceLocationResponse(createNoGpsDeviceLocationResponse());
        }
        notifyObservers(DeviceController.MESSAGE_GPS_STATUS_CHANGED);
    }

    private DeviceLocationResponse createNoGpsDeviceLocationResponse() {
        DeviceLocationResponse resp = new DeviceLocationResponse();
        resp.DisplayAltitude = "";
        resp.DisplayBearing = "No GPS";
        resp.DisplayGrid = "";
        resp.DisplayLatitude = "";
        resp.DisplayLongitude = "";
        resp.DisplaySpeed = "";
        return resp;
    }


    public boolean isGPSEnabled() {
        return gPSEnabled;
    }


    public void checkGPSEnabled() {
        setGPSEnabled(LocManager.isProviderEnabled( LocationManager.GPS_PROVIDER));
    }


    public void requestLocationUpdates() {
        LocManager.requestLocationUpdates(LocationManager.GPS_PROVIDER,
                settings.GPSTimeInterval,
                settings.GPSMinimalDistance,
                LocListener);
    }

    private SettingInfo settings;
    public SettingInfo getSettings() {
        return settings;
    }
    public void setSettings(SettingInfo settings) {
        this.settings = settings;
        notifyObservers(StationInfoController.MESSAGE_SETTING_CHANGED);
    }

    public static String getUniquePsuedoID()
    {
        // IF all else fails, if the user does is lower than API 9(lower
        // than Gingerbread), has reset their phone or 'Secure.ANDROID_ID'
        // returns 'null', then simply the ID returned will be soley based
        // off their Android device information. This is where the collisions
        // can happen.
        // Thanks http://www.pocketmagic.net/?p=1662!
        // Try not to use DISPLAY, HOST or ID - these items could change
        // If there are collisions, there will be overlapping data
        String m_szDevIDShort = "35" + (Build.BOARD.length() % 10) + (Build.BRAND.length() % 10) + (Build.CPU_ABI.length() % 10) + (Build.DEVICE.length() % 10) + (Build.MANUFACTURER.length() % 10) + (Build.MODEL.length() % 10) + (Build.PRODUCT.length() % 10);

        // Thanks to @Roman SL!
        // http://stackoverflow.com/a/4789483/950427
        // Only devices with API >= 9 have android.os.Build.SERIAL
        // http://developer.android.com/reference/android/os/Build.html#SERIAL
        // If a user upgrades software or roots their phone, there will be a duplicate entry
        String serial = null;
        try
        {
            serial = android.os.Build.class.getField("SERIAL").toString();

            // go ahead and return the serial for api => 9
            return new UUID(m_szDevIDShort.hashCode(), serial.hashCode()).toString();
        }
        catch (Exception e)
        {
            // String needs to be initialized
            serial = "serial"; // some value
        }

        // Thanks @Joe!
        // http://stackoverflow.com/a/2853253/950427
        // Finally, combine the values we have found by using the UUID class to create a unique identifier
        return new UUID(m_szDevIDShort.hashCode(), serial.hashCode()).toString();
    }



    public void saveLocation(Location loc)
    {
        if(!deviceLocationRequest.IsBusy)
        {
            deviceLocationRequest.DeviceId = getUniquePsuedoID();
            deviceLocationRequest.Latitude = loc.getLatitude();
            deviceLocationRequest.Longitude = loc.getLongitude();
            deviceLocationRequest.Altitude = loc.getAltitude();
            deviceLocationRequest.Bearing = loc.getBearing();
            deviceLocationRequest.Speed = loc.getSpeed();
            registerDeviceLocation(deviceLocationRequest);
        }
    }

}
