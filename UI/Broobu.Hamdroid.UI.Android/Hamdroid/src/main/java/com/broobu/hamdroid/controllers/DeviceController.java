package com.broobu.hamdroid.controllers;

import com.broobu.hamdroid.utils.ControllerBase;

/**
 * Created by ON8RL on 3/9/14.
 */
public class DeviceController extends ControllerBase {

    public static final int MESSAGE_DEVICE_LOCATION_CHANGED = 3;
    public static final int MESSAGE_GPS_STATUS_CHANGED = 9;


    @Override
    public boolean handleMessage(int what, Object data) {
        return false;
    }




}
