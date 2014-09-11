package com.broobu.hamdroid.activities;

import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.ViewPager;
import android.view.Menu;
import android.view.MenuItem;

import com.broobu.hamdroid.R;
import com.broobu.hamdroid.fragments.stationinfo.DeviceFragment;
import com.broobu.hamdroid.fragments.stationinfo.NavigationViewPagerAdapter;
import com.broobu.hamdroid.fragments.stationinfo.SplashFragment;
import com.broobu.hamdroid.fragments.stationinfo.StationInfoFragment;
import com.broobu.hamdroid.models.DeviceInfoModel;
import com.broobu.hamdroid.models.StationInfoModel;

public class NavActivity extends FragmentActivity  {


    private DeviceFragment deviceFragment;
    private StationInfoFragment stationInfoFragment;
    private SplashFragment splashFragment;
    /**
     * The serialization (saved instance state) Bundle key representing the
     * current dropdown position.
     */
    private static final String STATE_SELECTED_NAVIGATION_ITEM = "selected_navigation_item";

    private StationInfoModel stationInfoModel;
    private DeviceInfoModel deviceInfoModel;
    private ViewPager viewPager;
    private NavigationViewPagerAdapter viewPagerAdapter;
    FragmentManager fragmentManager;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_nav);
        stationInfoModel = new StationInfoModel();
        deviceInfoModel = new DeviceInfoModel();

        fragmentManager = getSupportFragmentManager();
        viewPager = (ViewPager)findViewById(R.id.navViewPager);
        if (viewPagerAdapter == null) {
            viewPagerAdapter = new NavigationViewPagerAdapter(
                    getApplicationContext(),
                    fragmentManager,
                    stationInfoModel,
                    deviceInfoModel);
            viewPager.setAdapter(viewPagerAdapter);
        }
        viewPager.setCurrentItem(0);
        stationInfoModel.setStationImage(BitmapFactory.decodeResource(getResources(), R.drawable.anonymous_avatar));
    }

    @Override
    public void onRestoreInstanceState(Bundle savedInstanceState) {
        // Restore the previously serialized current dropdown position.
        if (savedInstanceState.containsKey(STATE_SELECTED_NAVIGATION_ITEM)) {
            getActionBar().setSelectedNavigationItem(
                    savedInstanceState.getInt(STATE_SELECTED_NAVIGATION_ITEM));
        }
    }

    @Override
    public void onSaveInstanceState(Bundle outState) {
        // Serialize the current dropdown position.
        outState.putInt(STATE_SELECTED_NAVIGATION_ITEM,
                getActionBar().getSelectedNavigationIndex());
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.nav, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }




}
