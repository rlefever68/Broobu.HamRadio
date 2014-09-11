package com.broobu.hamdroid.fragments.stationinfo;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.broobu.hamdroid.R;
import com.broobu.hamdroid.controllers.DeviceController;
import com.broobu.hamdroid.controllers.StationInfoController;
import com.broobu.hamdroid.domain.stationinfo.CallSignResponse;
import com.broobu.hamdroid.domain.stationinfo.DeviceLocationResponse;
import com.broobu.hamdroid.interfaces.IOnChangeListener;
import com.broobu.hamdroid.models.DeviceInfoModel;
import com.broobu.hamdroid.models.StationInfoModel;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.UiSettings;
import com.google.android.gms.maps.model.CameraPosition;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.LatLngBounds;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.maps.model.PolygonOptions;

/**
 * Created by ON8RL on 1/24/14.
 */
public class PoIMapFragment extends Fragment implements IOnChangeListener {

    private GoogleMap mMap;

    public StationInfoModel model;
    public DeviceInfoModel device;


    public static PoIMapFragment newInstance(StationInfoModel model, DeviceInfoModel device)
    {
        PoIMapFragment fragment = new PoIMapFragment(model,device);
        model.addListener(fragment);
        device.addListener(fragment);
        return fragment;
    }

    public PoIMapFragment(StationInfoModel model, DeviceInfoModel device)
    {
        this.model = model;
        this.device = device;
    }


    public void bindModel()
    {
        if(model==null) return;
        if(mMap==null) return;
        if(device==null) return;
        mMap.clear();
        DeviceLocationResponse loc = device.getDeviceLocationResponse();
        CallSignResponse signInfo= model.getCallSignResponse();

        LatLng there = new LatLng(signInfo.Latitude,signInfo.Longitude);
        LatLng here = new LatLng(loc.Latitude,loc.Longitude);

        MarkerOptions remoteMarkerOptions = new MarkerOptions();
        remoteMarkerOptions.position(there);
        remoteMarkerOptions.title(signInfo.CallSign);
        MarkerOptions localMarkerOptions = new MarkerOptions();
        localMarkerOptions.position(here);
        localMarkerOptions.title("You");
        Marker remoteMarker = mMap.addMarker(remoteMarkerOptions);
        Marker localMarker = mMap.addMarker(localMarkerOptions);

        PolygonOptions polygonOptions= new PolygonOptions();
        polygonOptions.add(here, there);
        mMap.addPolygon(polygonOptions);

        builder = new LatLngBounds.Builder();
        builder.include(here);
        builder.include(there);
        final LatLngBounds bounds = builder.build();
        mMap.setOnCameraChangeListener(new GoogleMap.OnCameraChangeListener() {

            @Override
            public void onCameraChange(CameraPosition arg0) {
                 // Move camera.
                mMap.moveCamera(CameraUpdateFactory.newLatLngBounds(bounds,40));
                // Remove listener to prevent position reset on camera move.
                mMap.setOnCameraChangeListener(null);
            }
        });
    }







    LatLngBounds.Builder builder;

    View v;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        //View v = super.onCreateView(inflater,container,savedInstanceState);
        v = inflater.inflate(R.layout.fragment_poimap, container, false);
        SupportMapFragment mapFragment = (SupportMapFragment) getFragmentManager().findFragmentById(R.id.fgmPoIMap);
        mMap = mapFragment.getMap();
        mMap.setMyLocationEnabled(true);
        UiSettings settings = mMap.getUiSettings();
        settings.setScrollGesturesEnabled(true);
        settings.setTiltGesturesEnabled(true);
        settings.setMyLocationButtonEnabled(true);
//        settings.setCompassEnabled(true);
        mMap.setBuildingsEnabled(true);
        mMap.setIndoorEnabled(true);
        bindModel();
        return v;
    }

/*    @Override
    public void onStart()
    {
        bindModel();
    } */


    public void handleModelMessage(int message) {
        switch (message)
        {

            case DeviceController.MESSAGE_DEVICE_LOCATION_CHANGED:
            case StationInfoController.MESSAGE_REFRESH_MAP:
            case StationInfoController.MESSAGE_GET_CALLSIGN:
            {
                bindModel();
            }
        }
    }
}