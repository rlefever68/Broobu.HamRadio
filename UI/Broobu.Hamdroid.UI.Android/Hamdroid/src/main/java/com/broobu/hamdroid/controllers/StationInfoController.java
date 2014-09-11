package com.broobu.hamdroid.controllers;

import com.broobu.hamdroid.models.StationInfoModel;
import com.broobu.hamdroid.utils.ControllerBase;

/**
 * Created by ON8RL on 1/21/14.
 */
public class StationInfoController extends ControllerBase {

    private static final String TAG = StationInfoController.class.getSimpleName();

    public static final int MESSAGE_GET_CALLSIGN = 1;
    public static final int MESSAGE_GET_AVATAR = 2;
    public static final int MESSAGE_TIMER = 4;
    public static final int MESSAGE_REFRESH_MAP = 5;
    public static final int MESSAGE_SETTING_CHANGED = 6;
    public static final int MESSAGE_REFRESHAVATAR = 7;
    public static final int MESSAGE_REFRESH_HOME = 8 ;


    private StationInfoModel model;
    public StationInfoModel getModel() {return model;}


    //----------------------------------------------------------------------------------------------
    @Override
    public boolean handleMessage(int what, Object data) {

        switch(what) {


            case StationInfoController.MESSAGE_TIMER:
                return true;
            default:
                return false;
        }
    }








}
