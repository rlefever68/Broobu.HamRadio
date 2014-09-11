package com.broobu.hamdroid.fragments.stationinfo;

import android.content.Context;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

import com.broobu.hamdroid.models.DeviceInfoModel;
import com.broobu.hamdroid.models.StationInfoModel;

/**
 * Created by ON8RL on 3/10/14.
 */
public class StationInfoViewPagerAdapter extends FragmentPagerAdapter {

    private Context _context;


    private InfoFragment _infoFragment;
    private PoIMapFragment _mapFragment;
    private HomeFragment _homeFragment;

    StationInfoModel station;
    DeviceInfoModel device;

    public StationInfoViewPagerAdapter(Context context, FragmentManager fm, StationInfoModel model, DeviceInfoModel device) {
        super(fm);
        _context=context;
        this.station = model;
        this.device = device;
    }

    @Override
    public Fragment getItem(int position) {

        switch(position){
            case 1:
                return PoIMapFragment.newInstance(station,device);
            case 2:
                return ImageFragment.newInstance(station);
            case 3:
                return HomeFragment.newInstance(station);
            default:
            case 0:
                return InfoFragment.newInstance(station);
        }
    }

    @Override
    public int getCount() {
        return 4;
    }




}