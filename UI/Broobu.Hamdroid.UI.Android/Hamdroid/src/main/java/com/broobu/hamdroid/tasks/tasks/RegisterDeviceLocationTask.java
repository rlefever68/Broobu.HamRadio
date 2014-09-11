package com.broobu.hamdroid.tasks.tasks;

import android.os.AsyncTask;
import android.util.Log;

import com.broobu.hamdroid.domain.stationinfo.DeviceLocationResponse;
import com.broobu.hamdroid.models.DeviceInfoModel;

import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.web.client.RestTemplate;

/**
 * Created by ON8RL on 1/22/14.
 */
public class RegisterDeviceLocationTask extends AsyncTask<RegisterDeviceLocationRequest,Void,DeviceLocationResponse> {


    private RegisterDeviceLocationRequest request;
    private DeviceInfoModel model;



    public RegisterDeviceLocationTask(DeviceInfoModel model)
    {
        super();
        this.model=model;
    }


    @Override
    protected DeviceLocationResponse doInBackground(RegisterDeviceLocationRequest... requests) {

        String id = "Error";
        try {
            request = requests[0];
            request.IsBusy=true;
            String urlTemplate = "http://www.broobu.com/services/business.hamradio/hamdroid/hamdroid.svc/location?id=%1$s&Lat=%2$s&Lon=%3$s&alt=%4$s&bea=%5$s&spe=%6$s";
            final String url = String.format(urlTemplate,request.DeviceId,request.Latitude,request.Longitude, request.Altitude,request.Bearing, request.Speed);
            RestTemplate restTemplate = new RestTemplate();
            restTemplate.getMessageConverters().add(new MappingJackson2HttpMessageConverter());
            DeviceLocationResponse deviceLocationResponseInfo = restTemplate.getForObject(url, DeviceLocationResponse.class);
            return deviceLocationResponseInfo;
        } catch (Exception e) {
            request.IsBusy=false;
            Log.e("RegisterDeviceLocationTask", e.getMessage(), e);
            return createUnknownDeviceLocation(id);
        }
    }



    private DeviceLocationResponse createUnknownDeviceLocation(String id) {
        request.IsBusy=false;
        return new DeviceLocationResponse();
    }


    @Override
    protected void onPostExecute(DeviceLocationResponse info) {
        model.setDeviceLocationResponse(info);
    }
}
