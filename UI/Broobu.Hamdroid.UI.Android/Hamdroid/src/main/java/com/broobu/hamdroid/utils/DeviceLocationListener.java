package com.broobu.hamdroid.utils;

import android.location.Location;
import android.location.LocationListener;
import android.os.Bundle;

import com.broobu.hamdroid.models.DeviceInfoModel;
import com.broobu.hamdroid.tasks.tasks.RegisterDeviceLocationRequest;

public class DeviceLocationListener implements LocationListener {

    private DeviceInfoModel model;
    RegisterDeviceLocationRequest deviceLocationRequest;
    private int isBusy = 1;

    public DeviceLocationListener(DeviceInfoModel model) {
        this.model = model;
    }

    @Override
    public void onLocationChanged(Location loc)
    {
        model.saveLocation(loc);
    }

    @Override
    public void onProviderDisabled(String provider)
    {
        //print "Currently GPS is Disabled";
    }
    @Override
    public void onProviderEnabled(String provider)
    {
        //print "GPS got Enabled";
    }
    @Override
    public void onStatusChanged(String provider, int status, Bundle extras)
    {
    }

}