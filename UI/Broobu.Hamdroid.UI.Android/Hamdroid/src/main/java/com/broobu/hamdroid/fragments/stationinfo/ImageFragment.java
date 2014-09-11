package com.broobu.hamdroid.fragments.stationinfo;

import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.broobu.hamdroid.R;
import com.broobu.hamdroid.controllers.StationInfoController;
import com.broobu.hamdroid.interfaces.IOnChangeListener;
import com.broobu.hamdroid.models.StationInfoModel;

/**
 * Created by ON8RL on 1/24/14.
 */
public class ImageFragment extends Fragment implements IOnChangeListener {


    private StationInfoModel model;
    public static ImageFragment newInstance(StationInfoModel model)
    {
        ImageFragment fragment = new ImageFragment(model);
        model.addListener(fragment);
        return fragment;
    }

    public ImageFragment(StationInfoModel model)
    {
        this.model = model;
    }


    private View v;
    private ImageView imgStation;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

       v = inflater.inflate(R.layout.fragment_image, container, false);
       imgStation = (ImageView) v.findViewById(R.id.imgStation);
       bindModel();
       return v;
    }


    private void bindModel() {
        if(imgStation==null) return;
        if(model==null) return;
        Bitmap img = model.getStationImage();
        imgStation.setImageBitmap(img);
    }

    public void handleModelMessage(int message) {
        switch (message)
        {
            case StationInfoController.MESSAGE_GET_AVATAR:
            case StationInfoController.MESSAGE_REFRESHAVATAR:
            {
                bindModel();
            }
        }
    }


}