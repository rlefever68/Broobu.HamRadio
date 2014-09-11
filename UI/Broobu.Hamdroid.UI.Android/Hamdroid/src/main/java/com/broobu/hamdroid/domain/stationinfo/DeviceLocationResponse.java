package com.broobu.hamdroid.domain.stationinfo;

import com.broobu.hamdroid.utils.MessageBase;

import java.text.DateFormat;
import java.util.Date;
import java.util.TimeZone;

/**
 * Created by ON8RL on 1/21/14.
 */
public class DeviceLocationResponse extends MessageBase {

    public String Device;

    public double Altitude;
    public float Bearing;

    public double Latitude;
    public double Longitude;
    public float Speed;
    public long Time;

    public float Accuracy;
    public String DisplayGrid;
    public String DisplayLongitude;
    public String DisplayLatitude;
    public String DisplayBearing;
    public String DisplaySpeed;
    public String DisplayAltitude;


    public String getDisplayTime() {
        DateFormat df = DateFormat.getTimeInstance();
        df.setTimeZone(TimeZone.getTimeZone("gmt"));
        String res = df.format(new Date());
        res = String.format("%1$s UTC", res);
        return res;
    }
}
