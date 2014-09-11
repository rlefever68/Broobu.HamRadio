package com.broobu.hamdroid.tasks.tasks;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.util.Base64;
import android.util.Log;

import com.broobu.hamdroid.models.StationInfoModel;

import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.web.client.RestTemplate;

public class GetAvatarTask extends AsyncTask<GetAvatarRequest,Void,String>
{


    GetAvatarRequest request;
    StationInfoModel model;


    public GetAvatarTask(StationInfoModel model)
    {
        this.model = model;
    }


    @Override
    protected String doInBackground(GetAvatarRequest... requests) {
        try {
            request = requests[0];
            String urlTemplate = "http://www.broobu.com/services/business.hamradio/hamdroid/hamdroid.svc/avatar?url=%1$s&w=%2$s&h=%3$s";
            final String imgurl = String.format(urlTemplate, request.url, request.width,request.height);
            RestTemplate restTemplate = new RestTemplate();
            restTemplate.getMessageConverters().add(new MappingJackson2HttpMessageConverter());
            String avatar = restTemplate.getForObject(imgurl, String.class);
            return avatar;
        } catch (Exception e) {
            Log.e("StationInfoFragment", e.getMessage(), e);
        }
        return null;
    }

    @Override
    protected void onPostExecute(String info) {
        byte[] decodedString = Base64.decode(info, Base64.DEFAULT);
        Bitmap img = BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);
        model.setStationImage(img);
    }

}
