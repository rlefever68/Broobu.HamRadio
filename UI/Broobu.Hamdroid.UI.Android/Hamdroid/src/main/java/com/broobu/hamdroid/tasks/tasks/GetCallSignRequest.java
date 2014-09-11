package com.broobu.hamdroid.tasks.tasks;

import com.broobu.hamdroid.controllers.StationInfoController;
import com.broobu.hamdroid.models.StationInfoModel;
import com.broobu.hamdroid.utils.MessageBase;

/**
 * Created by ON8RL on 1/21/14.
 */
public class GetCallSignRequest extends MessageBase {
    public String Id;
    public double Lat;
    public double Lon;
    public String Unit;

    public int StationImageWidth;
    public int StationImageHeight;
    public String AvatarUrl;

    public StationInfoController Controller;
    public StationInfoModel Model;
}
