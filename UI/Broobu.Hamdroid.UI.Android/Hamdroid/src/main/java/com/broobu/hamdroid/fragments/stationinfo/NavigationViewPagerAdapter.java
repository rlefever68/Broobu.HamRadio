package com.broobu.hamdroid.fragments.stationinfo;


import android.content.Context;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

import com.broobu.hamdroid.models.DeviceInfoModel;
import com.broobu.hamdroid.models.StationInfoModel;

/**
 * Created by ON8RL on 3/16/14.
 */


public class NavigationViewPagerAdapter extends FragmentPagerAdapter {


    DeviceFragment deviceFragment;
    StationInfoFragment stationInfoFragment;
    SplashFragment splashFragment;

    StationInfoModel station;
    DeviceInfoModel device;



    public NavigationViewPagerAdapter(Context context, FragmentManager fm, StationInfoModel station, DeviceInfoModel device)
    {
        super(fm);
        this.station = station;
        this.device = device;
    }

    @Override
    public Fragment getItem(int position) {
        switch (position)
        {
            case 1:
                return StationInfoFragment.newInstance(station,device);
            case 2:
                return SplashFragment.newInstance();
            default:
            case 0:
                return DeviceFragment.newInstance(device);
        }
    }

    @Override
    public int getCount() {
        return 3;
    }





}
