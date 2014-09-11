package com.broobu.hamdroid.fragments.stationinfo;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.broobu.hamdroid.R;
import com.broobu.hamdroid.controllers.DeviceController;
import com.broobu.hamdroid.controllers.StationInfoController;
import com.broobu.hamdroid.domain.stationinfo.CallSignResponse;
import com.broobu.hamdroid.interfaces.IOnChangeListener;
import com.broobu.hamdroid.models.StationInfoModel;

/**
 * Created by ON8RL on 1/24/14.
 */
public class InfoFragment extends Fragment implements IOnChangeListener {


    private TextView txtLon;
    private TextView txtLat;
    private TextView txtGrid;
    private TextView txtShortPath;
    private TextView txtLongPath;
    private TextView txtBearing;

    private StationInfoModel model;

    public static InfoFragment newInstance(StationInfoModel model)
    {
        InfoFragment fragment = new InfoFragment(model);
        model.addListener(fragment);
        return fragment;
    }


    public InfoFragment(StationInfoModel model)
    {
        this.model=model;
    }

    View v;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        v = inflater.inflate(R.layout.fragment_info, container, false);
        txtLon = (TextView) v.findViewById(R.id.txtLon);
        txtLat = (TextView) v.findViewById(R.id.txtLat);
        txtGrid = (TextView) v.findViewById(R.id.txtGrid);
        txtShortPath = (TextView) v.findViewById(R.id.txtShortPath);
        txtLongPath = (TextView) v.findViewById(R.id.txtLongPath);
        txtBearing = (TextView) v.findViewById(R.id.txtBearing);
        bindModel();
        return v;
    }

    public void handleModelMessage(int message) {
        switch (message)
        {
            case StationInfoController.MESSAGE_GET_CALLSIGN:
            case DeviceController.MESSAGE_DEVICE_LOCATION_CHANGED:
            {
                bindModel();
            }
        }
    }

    private void bindModel() {
        if(model==null) return;
        if(txtLon==null) return;
        CallSignResponse info = model.getCallSignResponse();
        txtLon.setText(info.DisplayLongitude);
        txtLat.setText(info.DisplayLatitude);
        txtGrid.setText(info.Grid);
        txtShortPath.setText(info.ShortPath);
        txtLongPath.setText(info.LongPath);
        txtBearing.setText(info.Bearing);
    }
}