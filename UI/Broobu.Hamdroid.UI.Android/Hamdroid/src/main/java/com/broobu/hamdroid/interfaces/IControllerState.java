package com.broobu.hamdroid.interfaces;

/**
 * Created by ON8RL on 1/21/14.
 */
public interface IControllerState {
    boolean handleMessage(int what);
    boolean handleMessage(int what, Object data);
}
