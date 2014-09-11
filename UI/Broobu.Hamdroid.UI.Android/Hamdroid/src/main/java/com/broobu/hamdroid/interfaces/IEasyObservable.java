package com.broobu.hamdroid.interfaces;

/**
 * Created by ON8RL on 1/21/14.
 */
public interface IEasyObservable {

    void addListener(IOnChangeListener listener);
    void removeListener(IOnChangeListener listener);

}