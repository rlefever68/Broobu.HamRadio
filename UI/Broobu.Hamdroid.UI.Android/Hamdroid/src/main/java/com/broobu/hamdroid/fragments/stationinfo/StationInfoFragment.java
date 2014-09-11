package com.broobu.hamdroid.fragments.stationinfo;


import android.app.SearchManager;
import android.app.SearchableInfo;
import android.content.ComponentName;
import android.content.Context;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.SearchView;

import com.broobu.hamdroid.R;
import com.broobu.hamdroid.controllers.StationInfoController;
import com.broobu.hamdroid.domain.stationinfo.DeviceLocationResponse;
import com.broobu.hamdroid.interfaces.IOnChangeListener;
import com.broobu.hamdroid.models.DeviceInfoModel;
import com.broobu.hamdroid.models.StationInfoModel;
import com.broobu.hamdroid.tasks.tasks.GetCallSignRequest;

public class StationInfoFragment extends Fragment implements IOnChangeListener {

    private final DeviceInfoModel deviceInfoModel;
    FragmentActivity parentActivity;
    StationInfoModel stationInfoModel;
    StationInfoController stationInfoController;
    GetCallSignRequest request;
    SearchView searchView;
    CaptionFragment captionFragment;
    FragmentManager fragmentManager;
    private ViewPager viewPager;
    private StationInfoViewPagerAdapter viewPagerAdapter;



    public StationInfoFragment(StationInfoModel stationInfoModel, DeviceInfoModel deviceInfoModel)
    {
        this.stationInfoModel = stationInfoModel;
        this.deviceInfoModel = deviceInfoModel;
    }

    View v;
    //-----------------------------------------------------------------------------
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState) {
       // super.onCreate(savedInstanceState);

        v = inflater.inflate(R.layout.fragment_stationinfo, container, false);
        parentActivity = super.getActivity();
        request = new GetCallSignRequest();
        fragmentManager = parentActivity.getSupportFragmentManager();
        stationInfoController = new StationInfoController();
        captionFragment = (CaptionFragment) fragmentManager.findFragmentById(R.id.fgmCaption);
        captionFragment.model = stationInfoModel;
        stationInfoModel.addListener(this);
        stationInfoModel.addListener(captionFragment);
        searchView = findSearchView(v);

            viewPager = (ViewPager) v.findViewById(R.id.viewpager);
            if (viewPagerAdapter == null) {
                viewPagerAdapter = new StationInfoViewPagerAdapter(
                        parentActivity.getApplicationContext(),
                        fragmentManager,
                        stationInfoModel,
                        deviceInfoModel);
                viewPager.setAdapter(viewPagerAdapter);
            }
            stationInfoModel.setStationImage(BitmapFactory.decodeResource(getResources(), R.drawable.anonymous_avatar));
            viewPager.setCurrentItem(0);
    /*        Intent intent = act.getIntent();
            if (Intent.ACTION_SEARCH.equals(intent.getAction())) {
                stationInfoModel.fragmentHeight = viewPager.getLayoutParams().height;
                stationInfoModel.fragmentWidth = viewPager.getLayoutParams().width;
                String query = intent.getStringExtra(SearchManager.QUERY);
            }*/
        return v;
    }


    private SearchView findSearchView(View v) {
        // Get the SearchView and set the searchable configuration
        SearchManager searchManager = (SearchManager) parentActivity.getSystemService(Context.SEARCH_SERVICE);
        SearchView result = (SearchView) v.findViewById(R.id.searchView);
        ComponentName s = parentActivity.getComponentName();
        SearchableInfo nfo = searchManager.getSearchableInfo(s);
        result.setSearchableInfo(nfo);
        result.setIconifiedByDefault(false); // Do not iconify the widget; expand it by default
        result.setOnQueryTextFocusChangeListener(new View.OnFocusChangeListener(){

            @Override
            public void onFocusChange(View v, boolean hasFocus)
            {
            }
        });
        result.setOnQueryTextListener(new SearchView.OnQueryTextListener() {

            @Override
            public boolean onQueryTextSubmit(String query) {
                hideKeyboard();
                View v = getView().findViewById(R.id._containerParent);
                stationInfoModel.fragmentHeight = v.getHeight();
                stationInfoModel.fragmentWidth = v.getWidth();
                DeviceLocationResponse dev = deviceInfoModel.getDeviceLocationResponse();
                stationInfoModel.LaunchCallSignRequest(query, dev.Latitude, dev.Longitude);
                return true;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                return true;
            }
        });
        return result;
    }

    private void hideKeyboard() {
        if(parentActivity==null) return;
        InputMethodManager imm = (InputMethodManager)parentActivity.getSystemService(Context.INPUT_METHOD_SERVICE);
        imm.hideSoftInputFromWindow(searchView.getWindowToken(), 0);
    }


    @Override
    public void handleModelMessage(int message) {
            hideKeyboard();
    }

    public static StationInfoFragment newInstance(StationInfoModel stationInfoModel, DeviceInfoModel deviceInfoModel) {
        StationInfoFragment fragment =  new StationInfoFragment(stationInfoModel,deviceInfoModel);
        stationInfoModel.addListener(fragment);
        deviceInfoModel.addListener(fragment);
        return fragment;
    }
}


