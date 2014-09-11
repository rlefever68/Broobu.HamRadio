package com.broobu.hamdroid.fragments.stationinfo;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.broobu.hamdroid.R;
import com.broobu.hamdroid.models.StationInfoModel;

/**
 * Created by ON8RL on 1/24/14.
 */
public class SplashFragment  extends Fragment {
    private ImageView imgSplash;
    public static SplashFragment newInstance() {return new SplashFragment();}


    public void onChange(StationInfoModel model, int message)
    {

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_splash, container, false);
        imgSplash  = (ImageView) v.findViewById(R.id.imgSplash);
        return v;
    }


}