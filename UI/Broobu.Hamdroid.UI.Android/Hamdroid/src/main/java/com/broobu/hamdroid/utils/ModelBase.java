package com.broobu.hamdroid.utils;


import com.broobu.hamdroid.interfaces.IEasyObservable;
import com.broobu.hamdroid.interfaces.IOnChangeListener;

import java.util.ArrayList;

/**
 * Created by ON8RL on 1/21/14.
 */
public class ModelBase implements IEasyObservable {

    private final ArrayList<IOnChangeListener> listeners = new ArrayList<IOnChangeListener>();


    public void addListener(IOnChangeListener listener) {
        synchronized (listeners) {
            listeners.add(listener);
        }
    }


    public void removeListener(IOnChangeListener listener) {
        synchronized (listeners) {
            listeners.remove(listener);
        }
    }

    protected void notifyObservers(int message) {
        synchronized (listeners) {
            for (IOnChangeListener listener : listeners) {
                if(listener!=null)
                    listener.handleModelMessage(message);
            }
        }
    }

}