package com.broobu.hamdroid.fragments.stationinfo;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.location.LocationManager;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.broobu.hamdroid.R;
import com.broobu.hamdroid.controllers.DeviceController;
import com.broobu.hamdroid.domain.stationinfo.DeviceLocationResponse;
import com.broobu.hamdroid.interfaces.IOnChangeListener;
import com.broobu.hamdroid.models.DeviceInfoModel;
import com.broobu.hamdroid.utils.DeviceLocationListener;

/**
 * Created by ON8RL on 1/24/14.
 */
public class DeviceFragment extends Fragment implements IOnChangeListener{



    private TextView txtYourAltitude;
    private TextView txtYourLongitude;
    private TextView txtYourLatitude;
    private TextView txtYourDateTime;
    private TextView txtYourBearing;
    private TextView txtYourSpeed;
    private TextView txtYourGrid;
    private DeviceInfoModel model;
    private DeviceController controller;
    AlertDialog alert;
    public boolean UserDisabledGPS = false;
    private FragmentActivity parentActivity;




    @Override
    public void onResume()
    {
        super.onResume();
        UserDisabledGPS = false;
        checkGPSEnabled();
    }



    public static DeviceFragment newInstance(DeviceInfoModel deviceInfoModel)
    {
        DeviceFragment fragment = new DeviceFragment(deviceInfoModel);
        deviceInfoModel.addListener(fragment);
        return fragment;
    }

    View v;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
            v = inflater.inflate(R.layout.fragment_device, container, false);
            parentActivity = super.getActivity();
            txtYourAltitude= (TextView) v.findViewById(R.id.txtYourAltitude);
            txtYourBearing = (TextView) v.findViewById(R.id.txtYourBearing);
            txtYourDateTime = (TextView) v.findViewById(R.id.txtYourDateTime);
            txtYourGrid = (TextView) v.findViewById(R.id.txtYourGrid);
            txtYourLatitude = (TextView) v.findViewById(R.id.txtYourLatitude);
            txtYourLongitude = (TextView) v.findViewById(R.id.txtYourLongitude);
            txtYourSpeed = (TextView) v.findViewById(R.id.txtYourSpeed);
            model.LocManager=(LocationManager)parentActivity.getSystemService(Context.LOCATION_SERVICE);
            model.LocListener= new DeviceLocationListener(model);
            model.requestLocationUpdates();
        bindModel();
        return v;
    }


    public DeviceFragment(DeviceInfoModel model)
    {
        this.model = model;
        controller = new DeviceController();
    }




    private void buildAlertMessageNoGps() {
        if(model==null) return;
        final AlertDialog.Builder builder = new AlertDialog.Builder(this.getActivity());
        builder.setMessage("Your GPS seems to be disabled, do you want to enable it?")
                .setCancelable(false)
                .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    public void onClick(@SuppressWarnings("unused") final DialogInterface dialog, @SuppressWarnings("unused") final int id) {
                        startActivity(new Intent(android.provider.Settings.ACTION_LOCATION_SOURCE_SETTINGS));
                        model.setGPSEnabled(true);
                    }
                })
                .setNegativeButton("No", new DialogInterface.OnClickListener() {
                    public void onClick(final DialogInterface dialog, @SuppressWarnings("unused") final int id) {
                        UserDisabledGPS = true;
                        model.setGPSEnabled(false);
                        dialog.cancel();
                    }
                });
        alert = builder.create();
        alert.show();
    }





    @Override
    public void onDestroy() {
        if(alert != null)
            alert.dismiss();
        super.onDestroy();
    }


    public void handleModelMessage(int message) {
        switch (message)
        {
            case DeviceController.MESSAGE_DEVICE_LOCATION_CHANGED:
            {
                bindModel();
                break;
            }
            case DeviceController.MESSAGE_GPS_STATUS_CHANGED:
            {
                configureGPS();
                break;
            }
        }
    }


    public void configureGPS() {
        if(model==null) return;
        if ( !model.isGPSEnabled()) {
            if(!UserDisabledGPS)
                buildAlertMessageNoGps();
        }
        if (model.isGPSEnabled() ) {
            model.requestLocationUpdates();
        }
    }

    private void bindModel()
    {
        if(model==null) return;
        if(txtYourAltitude == null) return;
        DeviceLocationResponse deviceLocationResponse = model.getDeviceLocationResponse();
        txtYourLongitude.setText(deviceLocationResponse.DisplayLongitude);
        txtYourLatitude.setText(deviceLocationResponse.DisplayLatitude);
        txtYourSpeed.setText(deviceLocationResponse.DisplaySpeed);
        txtYourDateTime.setText(deviceLocationResponse.getDisplayTime());
        txtYourAltitude.setText(deviceLocationResponse.DisplayAltitude);
        txtYourBearing.setText(deviceLocationResponse.DisplayBearing);
        txtYourGrid.setText(deviceLocationResponse.DisplayGrid);
    }

    public void checkGPSEnabled() {
        model.checkGPSEnabled();
    }
}