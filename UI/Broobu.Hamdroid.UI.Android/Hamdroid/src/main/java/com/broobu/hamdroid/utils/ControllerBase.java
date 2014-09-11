package com.broobu.hamdroid.utils;

import android.os.Handler;
import android.os.Message;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by ON8RL on 1/21/14.
 */
public abstract class ControllerBase {

    @SuppressWarnings("unused")
    private static final String TAG = ControllerBase.class.getSimpleName();
    private final List<Handler> outboxHandlers = new ArrayList<Handler>();


    public ControllerBase() {

    }

    public void dispose() {}

    abstract public boolean handleMessage(int what, Object data);

    public boolean handleMessage(int what) {
        return handleMessage(what, null);
    }

    public final void addOutboxHandler(Handler handler) {
        outboxHandlers.add(handler);
    }

    public final void removeOutboxHandler(Handler handler) {
        outboxHandlers.remove(handler);
    }

    protected final void notifyOutboxHandlers(int what, int arg1, int arg2, Object obj) {
        if (!outboxHandlers.isEmpty()) {
            for (Handler handler : outboxHandlers) {
                Message msg = Message.obtain(handler, what, arg1, arg2, obj);
                msg.sendToTarget();
            }
        }
    }
}
