package com.broobu.hamdroid.tasks.tasks;

import android.os.AsyncTask;
import android.util.Log;

import com.broobu.hamdroid.domain.stationinfo.CallSignResponse;
import com.broobu.hamdroid.models.StationInfoModel;

import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.web.client.RestTemplate;


public class GetCallSignTask extends AsyncTask<GetCallSignRequest,Void,CallSignResponse> {



    private GetCallSignRequest request;

    private StationInfoModel model;


    public GetCallSignTask(StationInfoModel model)
    {
        this.model = model;
    }

    //----------------------------------------------------------------------------------------------
    @Override
    protected CallSignResponse doInBackground(GetCallSignRequest... requests)
    {
        String id = "Error";
        try {
            request = requests[0];
            String urlTemplate = "http://www.broobu.com/services/business.hamradio/hamdroid/hamdroid.svc/callsign?id=%1$s&Lat=%2$s&Lon=%3$s&unit=%4$s";
            final String url = String.format(urlTemplate,request.Id,request.Lat,request.Lon,request.Unit);
            RestTemplate restTemplate = new RestTemplate();
            restTemplate.getMessageConverters().add(new MappingJackson2HttpMessageConverter());
            CallSignResponse callSignResponse = restTemplate.getForObject(url, CallSignResponse.class);
            return callSignResponse;
        } catch (Exception e) {
            Log.e("GetCallSignTask", e.getMessage(), e);
            return createUnknownCallSignInfo(id);
        }
    }


    //------------------------------------------------------------------------------------------
    private CallSignResponse createUnknownCallSignInfo(String id) {
        CallSignResponse res = new CallSignResponse();
        res.DisplayName ="Not Found";
        res.Bearing = "Unknown";
        res.BioUrl = "Not found";
        res.CallSign = id;
        res.DisplayLatitude ="Unknown";
        res.DisplayLocation ="Unknown";
        res.DisplayLongitude ="Unknown";
        res.ShortPath ="Unknown";
        res.LongPath ="Unknown";
        res.ImageUrl = "";
        res.Grid = "Unknown";
        return res;
    }

    //------------------------------------------------------------------------------------------
    @Override
    protected void onPostExecute(CallSignResponse info) {
        model.setCallSignResponse(info);
    }
}
