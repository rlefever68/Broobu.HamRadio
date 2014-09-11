package com.broobu.hamdroid.tasks.tasks;

import com.broobu.hamdroid.controllers.StationInfoController;
import com.broobu.hamdroid.models.StationInfoModel;
import com.broobu.hamdroid.utils.MessageBase;

/**
 * Created by ON8RL on 1/21/14.
 */
public class GetAvatarRequest extends MessageBase {
    public String url;
    public int width;
    public int height;
    public StationInfoModel Model;
    public StationInfoController Controller;
}
