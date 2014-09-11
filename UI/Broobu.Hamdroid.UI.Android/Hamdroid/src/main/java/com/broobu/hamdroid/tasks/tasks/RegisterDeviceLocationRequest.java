package com.broobu.hamdroid.tasks.tasks;

import com.broobu.hamdroid.utils.MessageBase;

/**
 * Created by ON8RL on 1/22/14.
 */
public class RegisterDeviceLocationRequest extends MessageBase {
    public String DeviceId;
    public double Longitude;
    public double Latitude;
    public double Altitude;
    public float Bearing;
    public float Speed;
    public long LastRequest;
}
