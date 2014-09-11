package com.broobu.hamdroid.fragments.stationinfo;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.broobu.hamdroid.R;
import com.broobu.hamdroid.controllers.StationInfoController;
import com.broobu.hamdroid.domain.stationinfo.CallSignResponse;
import com.broobu.hamdroid.interfaces.IOnChangeListener;
import com.broobu.hamdroid.models.StationInfoModel;

/**
 * Created by ON8RL on 1/24/14.
 */
public class CaptionFragment extends Fragment implements IOnChangeListener {

    private TextView txtDisplayName;
    private TextView txtCountryCity;
    public StationInfoModel model;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        View v = inflater.inflate(R.layout.fragment_caption, container, false);
        txtCountryCity = (TextView)v.findViewById(R.id.txtCountryCity);
        txtDisplayName = (TextView)v.findViewById(R.id.txtDisplayName);
        bindModel();
        return v;
    }

    private void bindModel() {
        if(model==null) return;
        if(txtCountryCity==null) return;
        CallSignResponse info = model.getCallSignResponse();
        txtCountryCity.setText(info.DisplayLocation);
        txtDisplayName.setText(info.DisplayName);
    }



    public void handleModelMessage(int message) {
        switch (message)
        {
            case StationInfoController.MESSAGE_GET_CALLSIGN:
            {
                bindModel();
            }
        }
    }
}