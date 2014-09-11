package com.broobu.hamdroid.fragments.stationinfo;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;

import com.broobu.hamdroid.R;
import com.broobu.hamdroid.controllers.StationInfoController;
import com.broobu.hamdroid.domain.stationinfo.CallSignResponse;
import com.broobu.hamdroid.interfaces.IOnChangeListener;
import com.broobu.hamdroid.models.StationInfoModel;

/**
 * Created by ON8RL on 1/24/14.
 */
public class HomeFragment extends Fragment  implements IOnChangeListener {

    public HomeFragment(StationInfoModel model) {
        this.model = model;
    }

    public static HomeFragment newInstance(StationInfoModel station)
    {
        HomeFragment fragment = new HomeFragment(station);
        station.addListener(fragment);
        return fragment;
    }


    private StationInfoModel model;

    View v;
    WebView homePage;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        v = inflater.inflate(R.layout.fragment_home, container, false);
        homePage  = (WebView) v.findViewById(R.id.homePage);
        bindModel();
        return v;
    }


    public void handleModelMessage(int message) {
        switch (message)
        {
            case StationInfoController.MESSAGE_REFRESH_HOME:
            case StationInfoController.MESSAGE_GET_CALLSIGN:
            {
                bindModel();
            }
        }
    }

    private void bindModel() {
        if(homePage==null) return;
        if(model==null) return;
        CallSignResponse resp = model.getCallSignResponse();
        homePage.getSettings().setJavaScriptEnabled(true);
        if(resp.BioUrl!=null)
            homePage.loadUrl(resp.BioUrl);
    }
}